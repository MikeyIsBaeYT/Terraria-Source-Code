// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ShaderData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
  public class ShaderData
  {
    private readonly Ref<Effect> _shader;
    private string _passName;
    private EffectPass _effectPass;

    public Effect Shader => this._shader != null ? this._shader.Value : (Effect) null;

    public ShaderData(Ref<Effect> shader, string passName)
    {
      this._passName = passName;
      this._shader = shader;
    }

    public void SwapProgram(string passName)
    {
      this._passName = passName;
      if (passName == null)
        return;
      this._effectPass = this.Shader.CurrentTechnique.Passes[passName];
    }

    public virtual void Apply()
    {
      if (this._shader != null && this.Shader != null && this._passName != null)
        this._effectPass = this.Shader.CurrentTechnique.Passes[this._passName];
      this._effectPass.Apply();
    }
  }
}
