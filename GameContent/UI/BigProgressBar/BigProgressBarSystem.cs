// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.BigProgressBarSystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class BigProgressBarSystem
  {
    private IBigProgressBar _currentBar;
    private CommonBossBigProgressBar _bossBar = new CommonBossBigProgressBar();
    private BigProgressBarInfo _info;
    private static TwinsBigProgressBar _twinsBar = new TwinsBigProgressBar();
    private static EaterOfWorldsProgressBar _eaterOfWorldsBar = new EaterOfWorldsProgressBar();
    private static BrainOfCthuluBigProgressBar _brainOfCthuluBar = new BrainOfCthuluBigProgressBar();
    private static GolemHeadProgressBar _golemBar = new GolemHeadProgressBar();
    private static MoonLordProgressBar _moonlordBar = new MoonLordProgressBar();
    private static SolarFlarePillarBigProgressBar _solarPillarBar = new SolarFlarePillarBigProgressBar();
    private static VortexPillarBigProgressBar _vortexPillarBar = new VortexPillarBigProgressBar();
    private static NebulaPillarBigProgressBar _nebulaPillarBar = new NebulaPillarBigProgressBar();
    private static StardustPillarBigProgressBar _stardustPillarBar = new StardustPillarBigProgressBar();
    private static NeverValidProgressBar _neverValid = new NeverValidProgressBar();
    private static PirateShipBigProgressBar _pirateShipBar = new PirateShipBigProgressBar();
    private static MartianSaucerBigProgressBar _martianSaucerBar = new MartianSaucerBigProgressBar();
    private Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId = new Dictionary<int, IBigProgressBar>()
    {
      {
        125,
        (IBigProgressBar) BigProgressBarSystem._twinsBar
      },
      {
        126,
        (IBigProgressBar) BigProgressBarSystem._twinsBar
      },
      {
        13,
        (IBigProgressBar) BigProgressBarSystem._eaterOfWorldsBar
      },
      {
        14,
        (IBigProgressBar) BigProgressBarSystem._eaterOfWorldsBar
      },
      {
        15,
        (IBigProgressBar) BigProgressBarSystem._eaterOfWorldsBar
      },
      {
        266,
        (IBigProgressBar) BigProgressBarSystem._brainOfCthuluBar
      },
      {
        245,
        (IBigProgressBar) BigProgressBarSystem._golemBar
      },
      {
        246,
        (IBigProgressBar) BigProgressBarSystem._golemBar
      },
      {
        517,
        (IBigProgressBar) BigProgressBarSystem._solarPillarBar
      },
      {
        422,
        (IBigProgressBar) BigProgressBarSystem._vortexPillarBar
      },
      {
        507,
        (IBigProgressBar) BigProgressBarSystem._nebulaPillarBar
      },
      {
        493,
        (IBigProgressBar) BigProgressBarSystem._stardustPillarBar
      },
      {
        398,
        (IBigProgressBar) BigProgressBarSystem._moonlordBar
      },
      {
        396,
        (IBigProgressBar) BigProgressBarSystem._moonlordBar
      },
      {
        397,
        (IBigProgressBar) BigProgressBarSystem._moonlordBar
      },
      {
        548,
        (IBigProgressBar) BigProgressBarSystem._neverValid
      },
      {
        549,
        (IBigProgressBar) BigProgressBarSystem._neverValid
      },
      {
        491,
        (IBigProgressBar) BigProgressBarSystem._pirateShipBar
      },
      {
        492,
        (IBigProgressBar) BigProgressBarSystem._pirateShipBar
      },
      {
        440,
        (IBigProgressBar) BigProgressBarSystem._neverValid
      },
      {
        395,
        (IBigProgressBar) BigProgressBarSystem._martianSaucerBar
      },
      {
        393,
        (IBigProgressBar) BigProgressBarSystem._martianSaucerBar
      },
      {
        394,
        (IBigProgressBar) BigProgressBarSystem._martianSaucerBar
      },
      {
        68,
        (IBigProgressBar) BigProgressBarSystem._neverValid
      }
    };

    public void Update()
    {
      if (this._currentBar == null)
        this.TryFindingNPCToTrack();
      if (this._currentBar == null || this._currentBar.ValidateAndCollectNecessaryInfo(ref this._info))
        return;
      this._currentBar = (IBigProgressBar) null;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (this._currentBar == null)
        return;
      this._currentBar.Draw(ref this._info, spriteBatch);
    }

    private void TryFindingNPCToTrack()
    {
      Rectangle rectangle = new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
      rectangle.Inflate(5000, 5000);
      float num1 = float.PositiveInfinity;
      for (int npcIndex = 0; npcIndex < 200; ++npcIndex)
      {
        NPC npc = Main.npc[npcIndex];
        if (npc.active && npc.Hitbox.Intersects(rectangle))
        {
          float num2 = npc.Distance(Main.LocalPlayer.Center);
          if ((double) num1 > (double) num2 && this.TryTracking(npcIndex))
            num1 = num2;
        }
      }
    }

    public bool TryTracking(int npcIndex)
    {
      if (npcIndex < 0 || npcIndex > 200)
        return false;
      NPC npc = Main.npc[npcIndex];
      if (!npc.active)
        return false;
      BigProgressBarInfo info = new BigProgressBarInfo()
      {
        npcIndexToAimAt = npcIndex
      };
      IBigProgressBar bigProgressBar1 = (IBigProgressBar) this._bossBar;
      IBigProgressBar bigProgressBar2;
      if (this._bossBarsByNpcNetId.TryGetValue(npc.netID, out bigProgressBar2))
        bigProgressBar1 = bigProgressBar2;
      if (!bigProgressBar1.ValidateAndCollectNecessaryInfo(ref info))
        return false;
      this._currentBar = bigProgressBar1;
      this._info = info;
      return true;
    }
  }
}
