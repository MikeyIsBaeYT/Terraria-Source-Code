// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.CreditsRollSky
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent.Skies.CreditsRoll;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
  public class CreditsRollSky : CustomSky
  {
    private int _endTime;
    private int _currentTime;
    private List<ICreditsRollSegment> _segments;

    public void EnsureSegmentsAreMade()
    {
      this._segments = new List<ICreditsRollSegment>();
      new string[1][0] = "Now, this is a story all about how";
      Segments.ACreditsRollSegmentWithActions<NPC> segmentWithActions1 = new Segments.NPCSegment(0, 22, new Vector2(-300f, 0.0f), new Vector2(0.5f, 1f)).Then((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Fade((int) byte.MaxValue)).With((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Fade(-5, 51)).Then((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Move(new Vector2(1f, 0.0f), 60));
      Segments.ACreditsRollSegmentWithActions<Segments.LooseSprite> segmentWithActions2 = new Segments.SpriteSegment(0, new DrawData(TextureAssets.Extra[156].Value, Vector2.Zero, new Rectangle?(), Color.White, 0.0f, TextureAssets.Extra[156].Size() / 2f, 0.25f, SpriteEffects.None, 0), new Vector2(-100f, 0.0f)).Then((ICreditsRollSegmentAction<Segments.LooseSprite>) new Actions.Sprites.Fade(0.0f, 0)).Then((ICreditsRollSegmentAction<Segments.LooseSprite>) new Actions.Sprites.Fade(1f, 60)).Then((ICreditsRollSegmentAction<Segments.LooseSprite>) new Actions.Sprites.Wait(60)).Then((ICreditsRollSegmentAction<Segments.LooseSprite>) new Actions.Sprites.Fade(0.0f, 60));
      int num = 60;
      Segments.EmoteSegment emoteSegment = new Segments.EmoteSegment(3, (int) segmentWithActions1.DedicatedTimeNeeded, num, new Vector2(-254f, -38f), SpriteEffects.FlipHorizontally);
      segmentWithActions1.Then((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Wait(num)).Then((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Wait(60)).With((ICreditsRollSegmentAction<NPC>) new Actions.NPCs.Fade(5, 51));
      this._segments.Add((ICreditsRollSegment) segmentWithActions1);
      this._segments.Add((ICreditsRollSegment) emoteSegment);
      this._segments.Add((ICreditsRollSegment) segmentWithActions2);
      foreach (ICreditsRollSegment segment in this._segments)
        this._endTime += (int) segment.DedicatedTimeNeeded;
      this._endTime += 300;
    }

    public override void Update(GameTime gameTime)
    {
      ++this._currentTime;
      int num = 0;
      foreach (ICreditsRollSegment segment in this._segments)
        num += (int) segment.DedicatedTimeNeeded;
      if (this._currentTime < num + 1)
        return;
      this._currentTime = 0;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      float num = 4.5f;
      if ((double) num < (double) minDepth || (double) num > (double) maxDepth)
        return;
      CreditsRollInfo info = new CreditsRollInfo()
      {
        SpriteBatch = spriteBatch,
        AnchorPositionOnScreen = Main.ScreenSize.ToVector2() / 2f,
        TimeInAnimation = this._currentTime
      };
      for (int index = 0; index < this._segments.Count; ++index)
        this._segments[index].Draw(ref info);
    }

    public override bool IsActive() => this._currentTime < this._endTime;

    public override void Reset()
    {
      this._currentTime = 0;
      this.EnsureSegmentsAreMade();
    }

    public override void Activate(Vector2 position, params object[] args)
    {
      this._currentTime = 0;
      this.EnsureSegmentsAreMade();
    }

    public override void Deactivate(params object[] args) => this._currentTime = 0;
  }
}
