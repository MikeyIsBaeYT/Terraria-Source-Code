// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.EmpressShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class EmpressShader : ChromaShader
  {
    private static readonly Vector4[] _colors = new Vector4[12]
    {
      new Vector4(1f, 0.1f, 0.1f, 1f),
      new Vector4(1f, 0.5f, 0.1f, 1f),
      new Vector4(1f, 1f, 0.1f, 1f),
      new Vector4(0.5f, 1f, 0.1f, 1f),
      new Vector4(0.1f, 1f, 0.1f, 1f),
      new Vector4(0.1f, 1f, 0.5f, 1f),
      new Vector4(0.1f, 1f, 1f, 1f),
      new Vector4(0.1f, 0.5f, 1f, 1f),
      new Vector4(0.1f, 0.1f, 1f, 1f),
      new Vector4(0.5f, 0.1f, 1f, 1f),
      new Vector4(1f, 0.1f, 1f, 1f),
      new Vector4(1f, 0.1f, 0.5f, 1f)
    };

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      float num1 = time * 2f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        double num2 = (double) MathHelper.Max(0.0f, (float) Math.Cos(((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) + (double) num1) * 6.28318548202515 * 0.200000002980232));
        Vector4 vector4_1 = Color.Lerp(Color.Black, Color.Indigo, 0.5f).ToVector4();
        Math.Max(0.0f, (float) Math.Sin((double) Main.GlobalTimeWrappedHourly * 2.0 + (double) canvasPositionOfIndex.X * 1.0));
        float amount1 = 0.0f;
        Vector4 vector4_2 = Vector4.Lerp(vector4_1, new Vector4(1f, 0.1f, 0.1f, 1f), amount1);
        double x = (double) canvasPositionOfIndex.X;
        float amount2 = (float) ((num2 + x + (double) canvasPositionOfIndex.Y) % 1.0);
        if ((double) amount2 > 0.0)
        {
          int num3 = (gridPositionOfIndex.X + gridPositionOfIndex.Y) % EmpressShader._colors.Length;
          if (num3 < 0)
          {
            int num4 = num3 + EmpressShader._colors.Length;
          }
          Vector4 vector4_3 = Main.hslToRgb((float) ((((double) canvasPositionOfIndex.X + (double) canvasPositionOfIndex.Y) * 0.150000005960464 + (double) time * 0.100000001490116) % 1.0), 1f, 0.5f).ToVector4();
          vector4_2 = Vector4.Lerp(vector4_2, vector4_3, amount2);
        }
        fragment.SetColor(index, vector4_2);
      }
    }

    private static void RedsVersion(Fragment fragment, float time)
    {
      time *= 3f;
      for (int index1 = 0; index1 < fragment.Count; ++index1)
      {
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index1);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index1);
        float num = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 7.0 + (double) time * 0.400000005960464) % 7.0) - canvasPositionOfIndex.Y;
        Vector4 vector4 = new Vector4();
        if ((double) num > 0.0)
        {
          float amount = Math.Max(0.0f, 1.4f - num);
          if ((double) num < 0.400000005960464)
            amount = num / 0.4f;
          int index2 = (gridPositionOfIndex.X + EmpressShader._colors.Length + (int) ((double) time / 6.0)) % EmpressShader._colors.Length;
          vector4 = Vector4.Lerp(vector4, EmpressShader._colors[index2], amount);
        }
        fragment.SetColor(index1, vector4);
      }
    }
  }
}
