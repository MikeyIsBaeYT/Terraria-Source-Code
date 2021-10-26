// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.BackgroundChangeFlashInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent
{
  public class BackgroundChangeFlashInfo
  {
    private int[] _variations = new int[13];
    private float[] _flashPower = new float[13];

    public void UpdateCache()
    {
      this.UpdateVariation(0, WorldGen.treeBG1);
      this.UpdateVariation(1, WorldGen.treeBG2);
      this.UpdateVariation(2, WorldGen.treeBG3);
      this.UpdateVariation(3, WorldGen.treeBG4);
      this.UpdateVariation(4, WorldGen.corruptBG);
      this.UpdateVariation(5, WorldGen.jungleBG);
      this.UpdateVariation(6, WorldGen.snowBG);
      this.UpdateVariation(7, WorldGen.hallowBG);
      this.UpdateVariation(8, WorldGen.crimsonBG);
      this.UpdateVariation(9, WorldGen.desertBG);
      this.UpdateVariation(10, WorldGen.oceanBG);
      this.UpdateVariation(11, WorldGen.mushroomBG);
      this.UpdateVariation(12, WorldGen.underworldBG);
    }

    private void UpdateVariation(int areaId, int newVariationValue)
    {
      int variation = this._variations[areaId];
      this._variations[areaId] = newVariationValue;
      int num = newVariationValue;
      if (variation == num)
        return;
      this.ValueChanged(areaId);
    }

    private void ValueChanged(int areaId)
    {
      if (Main.gameMenu)
        return;
      this._flashPower[areaId] = 1f;
    }

    public void UpdateFlashValues()
    {
      for (int index = 0; index < this._flashPower.Length; ++index)
        this._flashPower[index] = MathHelper.Clamp(this._flashPower[index] - 0.05f, 0.0f, 1f);
    }

    public float GetFlashPower(int areaId) => this._flashPower[areaId];
  }
}
