// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.MoonLordSky
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class MoonLordSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private bool _isActive;
    private int _moonLordIndex = -1;

    public override void OnLoad()
    {
    }

    public override void Update(GameTime gameTime)
    {
    }

    private float GetIntensity()
    {
      if (!this.UpdateMoonLordIndex())
        return 0.0f;
      float x = 0.0f;
      if (this._moonLordIndex != -1)
        x = Vector2.Distance(Main.player[Main.myPlayer].Center, Main.npc[this._moonLordIndex].Center);
      return 1f - Utils.SmoothStep(3000f, 6000f, x);
    }

    public override Color OnTileColor(Color inColor)
    {
      float intensity = this.GetIntensity();
      return new Color(Vector4.Lerp(new Vector4(0.5f, 0.8f, 1f, 1f), inColor.ToVector4(), 1f - intensity));
    }

    private bool UpdateMoonLordIndex()
    {
      if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
        return true;
      int num = -1;
      for (int index = 0; index < Main.npc.Length; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 398)
        {
          num = index;
          break;
        }
      }
      this._moonLordIndex = num;
      return num != -1;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) maxDepth < 0.0 || (double) minDepth >= 0.0)
        return;
      float intensity = this.GetIntensity();
      spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * intensity);
    }

    public override float GetCloudAlpha() => 0.0f;

    internal override void Activate(Vector2 position, params object[] args) => this._isActive = true;

    internal override void Deactivate(params object[] args) => this._isActive = false;

    public override void Reset() => this._isActive = false;

    public override bool IsActive() => this._isActive;
  }
}
