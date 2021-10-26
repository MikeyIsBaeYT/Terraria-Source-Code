// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.AnOutlinedDrawRenderTargetContent
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.GameContent
{
  public abstract class AnOutlinedDrawRenderTargetContent : ARenderTargetContentByRequest
  {
    protected int width = 84;
    protected int height = 84;
    public Color _borderColor = Color.White;
    private EffectPass _coloringShader;
    private RenderTarget2D _helperTarget;

    public void UseColor(Color color) => this._borderColor = color;

    protected override void HandleUseReqest(GraphicsDevice device, SpriteBatch spriteBatch)
    {
      Effect pixelShader = Main.pixelShader;
      if (this._coloringShader == null)
        this._coloringShader = pixelShader.CurrentTechnique.Passes["ColorOnly"];
      Rectangle rectangle = new Rectangle(0, 0, this.width, this.height);
      this.PrepareARenderTarget_AndListenToEvents(ref this._target, device, this.width, this.height, RenderTargetUsage.PreserveContents);
      this.PrepareARenderTarget_WithoutListeningToEvents(ref this._helperTarget, device, this.width, this.height, RenderTargetUsage.DiscardContents);
      device.SetRenderTarget(this._helperTarget);
      device.Clear(Color.Transparent);
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null);
      this.DrawTheContent(spriteBatch);
      spriteBatch.End();
      device.SetRenderTarget(this._target);
      device.Clear(Color.Transparent);
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null);
      this._coloringShader.Apply();
      int num1 = 2;
      int num2 = num1 * 2;
      for (int index1 = -num2; index1 <= num2; index1 += num1)
      {
        for (int index2 = -num2; index2 <= num2; index2 += num1)
        {
          if (Math.Abs(index1) + Math.Abs(index2) == num2)
            spriteBatch.Draw((Texture2D) this._helperTarget, new Vector2((float) index1, (float) index2), Color.Black);
        }
      }
      int num3 = num1;
      for (int index3 = -num3; index3 <= num3; index3 += num1)
      {
        for (int index4 = -num3; index4 <= num3; index4 += num1)
        {
          if (Math.Abs(index3) + Math.Abs(index4) == num3)
            spriteBatch.Draw((Texture2D) this._helperTarget, new Vector2((float) index3, (float) index4), this._borderColor);
        }
      }
      pixelShader.CurrentTechnique.Passes[0].Apply();
      spriteBatch.Draw((Texture2D) this._helperTarget, Vector2.Zero, Color.White);
      spriteBatch.End();
      device.SetRenderTarget((RenderTarget2D) null);
      this._wasPrepared = true;
    }

    internal abstract void DrawTheContent(SpriteBatch spriteBatch);
  }
}
