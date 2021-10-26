// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerDrawHeadSet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.DataStructures
{
  public struct PlayerDrawHeadSet
  {
    public List<Terraria.DataStructures.DrawData> DrawData;
    public List<int> Dust;
    public List<int> Gore;
    public Player drawPlayer;
    public int cHead;
    public int cFace;
    public int cUnicornHorn;
    public int skinVar;
    public int hairShaderPacked;
    public int skinDyePacked;
    public float scale;
    public Color colorEyeWhites;
    public Color colorEyes;
    public Color colorHair;
    public Color colorHead;
    public Color colorArmorHead;
    public SpriteEffects playerEffect;
    public Vector2 headVect;
    public Rectangle bodyFrameMemory;
    public bool fullHair;
    public bool hatHair;
    public bool hideHair;
    public bool helmetIsTall;
    public bool helmetIsOverFullHair;
    public bool helmetIsNormal;
    public bool drawUnicornHorn;
    public Vector2 Position;
    public Vector2 helmetOffset;

    public Rectangle HairFrame
    {
      get
      {
        Rectangle bodyFrameMemory = this.bodyFrameMemory;
        --bodyFrameMemory.Height;
        return bodyFrameMemory;
      }
    }

    public void BoringSetup(
      Player drawPlayer2,
      List<Terraria.DataStructures.DrawData> drawData,
      List<int> dust,
      List<int> gore,
      float X,
      float Y,
      float Alpha,
      float Scale)
    {
      this.DrawData = drawData;
      this.Dust = dust;
      this.Gore = gore;
      this.drawPlayer = drawPlayer2;
      this.Position = this.drawPlayer.position;
      this.cHead = 0;
      this.cFace = 0;
      this.cUnicornHorn = 0;
      this.drawUnicornHorn = false;
      this.skinVar = this.drawPlayer.skinVariant;
      this.hairShaderPacked = PlayerDrawHelper.PackShader((int) this.drawPlayer.hairDye, PlayerDrawHelper.ShaderConfiguration.HairShader);
      if (this.drawPlayer.head == 0 && this.drawPlayer.hairDye == (byte) 0)
        this.hairShaderPacked = PlayerDrawHelper.PackShader(1, PlayerDrawHelper.ShaderConfiguration.HairShader);
      this.skinDyePacked = this.drawPlayer.skinDyePacked;
      if (this.drawPlayer.face > (sbyte) 0 && this.drawPlayer.face < (sbyte) 16)
        Main.instance.LoadAccFace((int) this.drawPlayer.face);
      this.cHead = this.drawPlayer.cHead;
      this.cFace = this.drawPlayer.cFace;
      this.cUnicornHorn = this.drawPlayer.cUnicornHorn;
      this.drawUnicornHorn = this.drawPlayer.hasUnicornHorn;
      Main.instance.LoadHair(this.drawPlayer.hair);
      this.scale = Scale;
      this.colorEyeWhites = Main.quickAlpha(Color.White, Alpha);
      this.colorEyes = Main.quickAlpha(this.drawPlayer.eyeColor, Alpha);
      this.colorHair = Main.quickAlpha(this.drawPlayer.GetHairColor(false), Alpha);
      this.colorHead = Main.quickAlpha(this.drawPlayer.skinColor, Alpha);
      this.colorArmorHead = Main.quickAlpha(Color.White, Alpha);
      this.playerEffect = SpriteEffects.None;
      if (this.drawPlayer.direction < 0)
        this.playerEffect = SpriteEffects.FlipHorizontally;
      this.headVect = new Vector2((float) this.drawPlayer.legFrame.Width * 0.5f, (float) this.drawPlayer.legFrame.Height * 0.4f);
      this.bodyFrameMemory = this.drawPlayer.bodyFrame;
      this.bodyFrameMemory.Y = 0;
      this.Position = Main.screenPosition;
      this.Position.X += X;
      this.Position.Y += Y;
      this.Position.X -= 6f;
      this.Position.Y -= 4f;
      this.Position.Y -= (float) this.drawPlayer.HeightMapOffset;
      if (this.drawPlayer.head > 0 && this.drawPlayer.head < 266)
      {
        Main.instance.LoadArmorHead(this.drawPlayer.head);
        int i = ArmorIDs.Head.Sets.FrontToBackID[this.drawPlayer.head];
        if (i >= 0)
          Main.instance.LoadArmorHead(i);
      }
      if (this.drawPlayer.face > (sbyte) 0 && this.drawPlayer.face < (sbyte) 16)
        Main.instance.LoadAccFace((int) this.drawPlayer.face);
      this.helmetOffset = this.drawPlayer.GetHelmetDrawOffset();
      this.drawPlayer.GetHairSettings(out this.fullHair, out this.hatHair, out this.hideHair, out bool _, out this.helmetIsOverFullHair);
      this.helmetIsTall = this.drawPlayer.head == 14 || this.drawPlayer.head == 56 || this.drawPlayer.head == 158;
      this.helmetIsNormal = !this.helmetIsTall && !this.helmetIsOverFullHair && this.drawPlayer.head > 0 && this.drawPlayer.head < 266 && this.drawPlayer.head != 28;
    }
  }
}
