// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Golf.GolfState
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria.GameContent.Golf
{
  public class GolfState
  {
    private const int BALL_RETURN_PENALTY = 1;
    private int golfScoreTime;
    private int golfScoreTimeMax = 3600;
    private int golfScoreDelay = 90;
    private double _lastRecordedBallTime;
    private Vector2? _lastRecordedBallLocation;
    private bool _waitingForBallToSettle;
    private Vector2 _lastSwingPosition;
    private Projectile _lastHitGolfBall;
    private int _lastRecordedSwingCount;
    private GolfBallTrackRecord[] _hitRecords = new GolfBallTrackRecord[1000];

    private void UpdateScoreTime()
    {
      if (this.golfScoreTime >= this.golfScoreTimeMax)
        return;
      ++this.golfScoreTime;
    }

    public void ResetScoreTime() => this.golfScoreTime = 0;

    public void SetScoreTime() => this.golfScoreTime = this.golfScoreTimeMax;

    public float ScoreAdjustment => (float) this.golfScoreTime / (float) this.golfScoreTimeMax;

    public bool ShouldScoreHole => this.golfScoreTime >= this.golfScoreDelay;

    public bool IsTrackingBall => this.GetLastHitBall() != null && this._waitingForBallToSettle;

    public bool ShouldCameraTrackBallLastKnownLocation => this._lastRecordedBallTime + 2.0 >= Main.gameTimeCache.TotalGameTime.TotalSeconds && this.GetLastHitBall() == null;

    public Vector2? GetLastBallLocation() => this._lastRecordedBallLocation;

    public void CancelBallTracking() => this._waitingForBallToSettle = false;

    public void RecordSwing(Projectile golfBall)
    {
      this._lastSwingPosition = golfBall.position;
      this._lastHitGolfBall = golfBall;
      this._lastRecordedSwingCount = (int) golfBall.ai[1];
      this._waitingForBallToSettle = true;
      int golfBallId = this.GetGolfBallId(golfBall);
      if (this._hitRecords[golfBallId] == null || this._lastRecordedSwingCount == 1)
        this._hitRecords[golfBallId] = new GolfBallTrackRecord();
      this._hitRecords[golfBallId].RecordHit(golfBall.position);
    }

    private int GetGolfBallId(Projectile golfBall) => golfBall.whoAmI;

    public Projectile GetLastHitBall() => this._lastHitGolfBall == null || !this._lastHitGolfBall.active || !ProjectileID.Sets.IsAGolfBall[this._lastHitGolfBall.type] || this._lastHitGolfBall.owner != Main.myPlayer || this._lastRecordedSwingCount != (int) this._lastHitGolfBall.ai[1] ? (Projectile) null : this._lastHitGolfBall;

    public void Update()
    {
      this.UpdateScoreTime();
      Projectile lastHitBall = this.GetLastHitBall();
      if (lastHitBall == null)
      {
        this._waitingForBallToSettle = false;
      }
      else
      {
        if (this._waitingForBallToSettle)
          this._waitingForBallToSettle = (int) lastHitBall.localAI[1] == 1;
        if (Item.IsAGolfingItem(Main.LocalPlayer.HeldItem))
          return;
        this._waitingForBallToSettle = false;
      }
    }

    public void RecordBallInfo(Projectile golfBall)
    {
      if (this.GetLastHitBall() != golfBall || !this._waitingForBallToSettle)
        return;
      this._lastRecordedBallLocation = new Vector2?(golfBall.Center);
      this._lastRecordedBallTime = Main.gameTimeCache.TotalGameTime.TotalSeconds;
    }

    public void LandBall(Projectile golfBall) => this._hitRecords[this.GetGolfBallId(golfBall)]?.RecordHit(golfBall.position);

    public int GetGolfBallScore(Projectile golfBall)
    {
      GolfBallTrackRecord hitRecord = this._hitRecords[this.GetGolfBallId(golfBall)];
      return hitRecord == null ? 0 : (int) ((double) hitRecord.GetAccumulatedScore() * (double) this.ScoreAdjustment);
    }

    public void ResetGolfBall()
    {
      Projectile lastHitBall = this.GetLastHitBall();
      if (lastHitBall == null || (double) Vector2.Distance(lastHitBall.position, this._lastSwingPosition) < 1.0)
        return;
      lastHitBall.position = this._lastSwingPosition;
      lastHitBall.velocity = Vector2.Zero;
      ++lastHitBall.ai[1];
      lastHitBall.netUpdate2 = true;
      this._lastRecordedSwingCount = (int) lastHitBall.ai[1];
    }
  }
}
