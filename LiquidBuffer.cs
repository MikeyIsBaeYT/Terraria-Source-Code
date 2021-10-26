// Decompiled with JetBrains decompiler
// Type: Terraria.LiquidBuffer
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria
{
  public class LiquidBuffer
  {
    public const int maxLiquidBuffer = 10000;
    public static int numLiquidBuffer;
    public int x;
    public int y;

    public static void AddBuffer(int x, int y)
    {
      if (LiquidBuffer.numLiquidBuffer == 9999 || Main.tile[x, y].checkingLiquid)
        return;
      Main.tile[x, y].checkingLiquid = true;
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x = x;
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y = y;
      ++LiquidBuffer.numLiquidBuffer;
    }

    public static void DelBuffer(int l)
    {
      --LiquidBuffer.numLiquidBuffer;
      Main.liquidBuffer[l].x = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x;
      Main.liquidBuffer[l].y = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y;
    }
  }
}
