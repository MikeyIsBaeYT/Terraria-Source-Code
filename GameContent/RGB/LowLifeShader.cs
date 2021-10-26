// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.LowLifeShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class LowLifeShader : ChromaShader
  {
    private static Vector4 _baseColor = new Color(40, 0, 8, (int) byte.MaxValue).ToVector4();

    [RgbProcessor]
    private void ProcessAnyDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      float num = (float) (Math.Cos((double) time * 3.14159274101257) * 0.300000011920929 + 0.699999988079071);
      Vector4 vector4 = LowLifeShader._baseColor * num;
      vector4.W = LowLifeShader._baseColor.W;
      for (int index = 0; index < fragment.Count; ++index)
        fragment.SetColor(index, vector4);
    }
  }
}
