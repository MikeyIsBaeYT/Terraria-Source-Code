// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.EaterOfWorldsProgressBar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class EaterOfWorldsProgressBar : IBigProgressBar
  {
    private float _lifePercentToShow;

    public bool ValidateAndCollectNecessaryInfo(ref BigProgressBarInfo info)
    {
      if (info.npcIndexToAimAt < 0 || info.npcIndexToAimAt > 200 || !Main.npc[info.npcIndexToAimAt].active && !this.TryFindingAnotherEOWPiece(ref info))
        return false;
      int worldsSegmentsCount = NPC.GetEaterOfWorldsSegmentsCount();
      float num = 0.0f;
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && npc.type >= 13 && npc.type <= 15)
          num += (float) npc.life / (float) npc.lifeMax;
      }
      this._lifePercentToShow = Utils.Clamp<float>(num / (float) worldsSegmentsCount, 0.0f, 1f);
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      int bossHeadTexture = NPCID.Sets.BossHeadTextures[13];
      Texture2D texture2D = TextureAssets.NpcHeadBoss[bossHeadTexture].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._lifePercentToShow, texture2D, barIconFrame);
    }

    private bool TryFindingAnotherEOWPiece(ref BigProgressBarInfo info)
    {
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && npc.type >= 13 && npc.type <= 15)
        {
          info.npcIndexToAimAt = index;
          return true;
        }
      }
      return false;
    }
  }
}
