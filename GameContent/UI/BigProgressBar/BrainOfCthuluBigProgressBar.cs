// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.BrainOfCthuluBigProgressBar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class BrainOfCthuluBigProgressBar : IBigProgressBar
  {
    private float _lifePercentToShow;
    private NPC _creeperForReference;

    public BrainOfCthuluBigProgressBar() => this._creeperForReference = new NPC();

    public bool ValidateAndCollectNecessaryInfo(ref BigProgressBarInfo info)
    {
      if (info.npcIndexToAimAt < 0 || info.npcIndexToAimAt > 200)
        return false;
      NPC npc1 = Main.npc[info.npcIndexToAimAt];
      if (!npc1.active)
        return false;
      int cthuluCreepersCount = NPC.GetBrainOfCthuluCreepersCount();
      this._creeperForReference.SetDefaults(267, npc1.GetMatchingSpawnParams());
      int num1 = this._creeperForReference.lifeMax * cthuluCreepersCount;
      float num2 = 0.0f;
      for (int index = 0; index < 200; ++index)
      {
        NPC npc2 = Main.npc[index];
        if (npc2.active && npc2.type == this._creeperForReference.type)
          num2 += (float) npc2.life;
      }
      this._lifePercentToShow = Utils.Clamp<float>(((float) npc1.life + num2) / (float) (npc1.lifeMax + num1), 0.0f, 1f);
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      int bossHeadTexture = NPCID.Sets.BossHeadTextures[266];
      Texture2D texture2D = TextureAssets.NpcHeadBoss[bossHeadTexture].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._lifePercentToShow, texture2D, barIconFrame);
    }
  }
}
