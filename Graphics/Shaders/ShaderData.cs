// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ShaderData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
  public class ShaderData
  {
    protected Ref<Effect> _shader;
    protected string _passName;
    private EffectPass _effectPass;
    private Effect _lastEffect;

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

    protected virtual void Apply()
    {
      if (this._shader != null && this._lastEffect != this._shader.Value && this.Shader != null && this._passName != null)
        this._effectPass = this.Shader.CurrentTechnique.Passes[this._passName];
      this._effectPass.Apply();
    }
  }
}
