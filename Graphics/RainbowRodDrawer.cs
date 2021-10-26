// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.RainbowRodDrawer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct RainbowRodDrawer
  {
    private static VertexStrip _vertexStrip = new VertexStrip();

    public void Draw(Projectile proj)
    {
      MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
      miscShaderData.UseSaturation(-2.8f);
      miscShaderData.UseOpacity(4f);
      miscShaderData.Apply(new DrawData?());
      RainbowRodDrawer._vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, new VertexStrip.StripColorFunction(this.StripColors), new VertexStrip.StripHalfWidthFunction(this.StripWidth), -Main.screenPosition + proj.Size / 2f);
      RainbowRodDrawer._vertexStrip.DrawTrail();
      Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    private Color StripColors(float progressOnStrip)
    {
      Color color = Color.Lerp(Color.White, Main.hslToRgb((float) (((double) progressOnStrip * 1.60000002384186 - (double) Main.GlobalTimeWrappedHourly) % 1.0), 1f, 0.5f), Utils.GetLerpValue(-0.2f, 0.5f, progressOnStrip, true)) * (1f - Utils.GetLerpValue(0.0f, 0.98f, progressOnStrip, false));
      color.A = (byte) 0;
      return color;
    }

    private float StripWidth(float progressOnStrip)
    {
      float num = 1f;
      float lerpValue = Utils.GetLerpValue(0.0f, 0.2f, progressOnStrip, true);
      return MathHelper.Lerp(0.0f, 32f, num * (float) (1.0 - (1.0 - (double) lerpValue) * (1.0 - (double) lerpValue)));
    }
  }
}
