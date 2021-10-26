// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.LunarPillarBigProgessBar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public abstract class LunarPillarBigProgessBar : IBigProgressBar
  {
    private float _lifePercentToShow;
    private float _shieldPercentToShow;
    private int _headIndex;

    public bool ValidateAndCollectNecessaryInfo(ref BigProgressBarInfo info)
    {
      if (info.npcIndexToAimAt < 0 || info.npcIndexToAimAt > 200)
        return false;
      NPC npc = Main.npc[info.npcIndexToAimAt];
      if (!npc.active)
        return false;
      int headTextureIndex = npc.GetBossHeadTextureIndex();
      if (headTextureIndex == -1 || !this.IsPlayerInCombatArea() || (double) npc.ai[2] == 1.0)
        return false;
      float num1 = Utils.Clamp<float>((float) npc.life / (float) npc.lifeMax, 0.0f, 1f);
      float num2 = this.GetCurrentShieldValue() / this.GetMaxShieldValue();
      double num3 = 600.0 * (double) Main.GameModeInfo.EnemyMaxLifeMultiplier * (double) this.GetMaxShieldValue() / (double) npc.lifeMax;
      this._lifePercentToShow = num1;
      this._shieldPercentToShow = num2;
      this._headIndex = headTextureIndex;
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      Texture2D texture2D = TextureAssets.NpcHeadBoss[this._headIndex].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._lifePercentToShow, texture2D, barIconFrame, this._shieldPercentToShow);
    }

    internal abstract float GetCurrentShieldValue();

    internal abstract float GetMaxShieldValue();

    internal abstract bool IsPlayerInCombatArea();
  }
}
