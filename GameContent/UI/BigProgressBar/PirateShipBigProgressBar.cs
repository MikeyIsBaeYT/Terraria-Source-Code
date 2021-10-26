// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.PirateShipBigProgressBar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class PirateShipBigProgressBar : IBigProgressBar
  {
    private float _lifePercentToShow;
    private NPC _referenceDummy;
    private HashSet<int> ValidIds = new HashSet<int>()
    {
      491
    };

    public PirateShipBigProgressBar() => this._referenceDummy = new NPC();

    public bool ValidateAndCollectNecessaryInfo(ref BigProgressBarInfo info)
    {
      if (info.npcIndexToAimAt < 0 || info.npcIndexToAimAt > 200)
        return false;
      NPC npc1 = Main.npc[info.npcIndexToAimAt];
      if (!npc1.active || npc1.type != 491)
      {
        if (!this.TryFindingAnotherPirateShipPiece(ref info))
          return false;
        npc1 = Main.npc[info.npcIndexToAimAt];
      }
      int num1 = 0;
      this._referenceDummy.SetDefaults(492, npc1.GetMatchingSpawnParams());
      int num2 = num1 + this._referenceDummy.lifeMax * 4;
      float num3 = 0.0f;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int index2 = (int) npc1.ai[index1];
        if (Main.npc.IndexInRange<NPC>(index2))
        {
          NPC npc2 = Main.npc[index2];
          if (npc2.active && npc2.type == 492)
            num3 += (float) npc2.life;
        }
      }
      this._lifePercentToShow = Utils.Clamp<float>(num3 / (float) num2, 0.0f, 1f);
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      int bossHeadTexture = NPCID.Sets.BossHeadTextures[491];
      Texture2D texture2D = TextureAssets.NpcHeadBoss[bossHeadTexture].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._lifePercentToShow, texture2D, barIconFrame);
    }

    private bool TryFindingAnotherPirateShipPiece(ref BigProgressBarInfo info)
    {
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && this.ValidIds.Contains(npc.type))
        {
          info.npcIndexToAimAt = index;
          return true;
        }
      }
      return false;
    }
  }
}
