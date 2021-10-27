// Decompiled with JetBrains decompiler
// Type: Terraria.Minecart
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace Terraria
{
  public static class Minecart
  {
    private const int TotalFrames = 36;
    public const int LeftDownDecoration = 36;
    public const int RightDownDecoration = 37;
    public const int BouncyBumperDecoration = 38;
    public const int RegularBumperDecoration = 39;
    public const int Flag_OnTrack = 0;
    public const int Flag_BouncyBumper = 1;
    public const int Flag_UsedRamp = 2;
    public const int Flag_HitSwitch = 3;
    public const int Flag_BoostLeft = 4;
    public const int Flag_BoostRight = 5;
    private const int NoConnection = -1;
    private const int TopConnection = 0;
    private const int MiddleConnection = 1;
    private const int BottomConnection = 2;
    private const int BumperEnd = -1;
    private const int BouncyEnd = -2;
    private const int RampEnd = -3;
    private const int OpenEnd = -4;
    public const float BoosterSpeed = 4f;
    private const int Type_Normal = 0;
    private const int Type_Pressure = 1;
    private const int Type_Booster = 2;
    private static Vector2 _trackMagnetOffset = new Vector2(25f, 26f);
    private const float MinecartTextureWidth = 50f;
    private static int[] _leftSideConnection;
    private static int[] _rightSideConnection;
    private static int[] _trackType;
    private static bool[] _boostLeft;
    private static Vector2[] _texturePosition;
    private static short _firstPressureFrame;
    private static short _firstLeftBoostFrame;
    private static short _firstRightBoostFrame;
    private static int[][] _trackSwitchOptions;
    private static int[][] _tileHeight;

    public static void Initialize()
    {
      if ((double) Main.minecartMountTexture.Width != 50.0)
        throw new Exception("Be sure to update Minecart.textureWidth to match the actual texture size of " + (object) 50f + ".");
      Minecart._rightSideConnection = new int[36];
      Minecart._leftSideConnection = new int[36];
      Minecart._trackType = new int[36];
      Minecart._boostLeft = new bool[36];
      Minecart._texturePosition = new Vector2[40];
      Minecart._tileHeight = new int[36][];
      for (int index1 = 0; index1 < 36; ++index1)
      {
        int[] numArray = new int[8];
        for (int index2 = 0; index2 < numArray.Length; ++index2)
          numArray[index2] = 5;
        Minecart._tileHeight[index1] = numArray;
      }
      int index3 = 0;
      Minecart._leftSideConnection[index3] = -1;
      Minecart._rightSideConnection[index3] = -1;
      Minecart._tileHeight[index3][0] = -4;
      Minecart._tileHeight[index3][7] = -4;
      Minecart._texturePosition[index3] = new Vector2(0.0f, 0.0f);
      int index4 = index3 + 1;
      Minecart._leftSideConnection[index4] = 1;
      Minecart._rightSideConnection[index4] = 1;
      Minecart._texturePosition[index4] = new Vector2(1f, 0.0f);
      int index5 = index4 + 1;
      Minecart._leftSideConnection[index5] = -1;
      Minecart._rightSideConnection[index5] = 1;
      for (int index6 = 0; index6 < 4; ++index6)
        Minecart._tileHeight[index5][index6] = -1;
      Minecart._texturePosition[index5] = new Vector2(2f, 1f);
      int index7 = index5 + 1;
      Minecart._leftSideConnection[index7] = 1;
      Minecart._rightSideConnection[index7] = -1;
      for (int index8 = 4; index8 < 8; ++index8)
        Minecart._tileHeight[index7][index8] = -1;
      Minecart._texturePosition[index7] = new Vector2(3f, 1f);
      int index9 = index7 + 1;
      Minecart._leftSideConnection[index9] = 2;
      Minecart._rightSideConnection[index9] = 1;
      Minecart._tileHeight[index9][0] = 1;
      Minecart._tileHeight[index9][1] = 2;
      Minecart._tileHeight[index9][2] = 3;
      Minecart._tileHeight[index9][3] = 3;
      Minecart._tileHeight[index9][4] = 4;
      Minecart._tileHeight[index9][5] = 4;
      Minecart._texturePosition[index9] = new Vector2(0.0f, 2f);
      int index10 = index9 + 1;
      Minecart._leftSideConnection[index10] = 1;
      Minecart._rightSideConnection[index10] = 2;
      Minecart._tileHeight[index10][2] = 4;
      Minecart._tileHeight[index10][3] = 4;
      Minecart._tileHeight[index10][4] = 3;
      Minecart._tileHeight[index10][5] = 3;
      Minecart._tileHeight[index10][6] = 2;
      Minecart._tileHeight[index10][7] = 1;
      Minecart._texturePosition[index10] = new Vector2(1f, 2f);
      int index11 = index10 + 1;
      Minecart._leftSideConnection[index11] = 1;
      Minecart._rightSideConnection[index11] = 0;
      Minecart._tileHeight[index11][4] = 6;
      Minecart._tileHeight[index11][5] = 6;
      Minecart._tileHeight[index11][6] = 7;
      Minecart._tileHeight[index11][7] = 8;
      Minecart._texturePosition[index11] = new Vector2(0.0f, 1f);
      int index12 = index11 + 1;
      Minecart._leftSideConnection[index12] = 0;
      Minecart._rightSideConnection[index12] = 1;
      Minecart._tileHeight[index12][0] = 8;
      Minecart._tileHeight[index12][1] = 7;
      Minecart._tileHeight[index12][2] = 6;
      Minecart._tileHeight[index12][3] = 6;
      Minecart._texturePosition[index12] = new Vector2(1f, 1f);
      int index13 = index12 + 1;
      Minecart._leftSideConnection[index13] = 0;
      Minecart._rightSideConnection[index13] = 2;
      for (int index14 = 0; index14 < 8; ++index14)
        Minecart._tileHeight[index13][index14] = 8 - index14;
      Minecart._texturePosition[index13] = new Vector2(0.0f, 3f);
      int index15 = index13 + 1;
      Minecart._leftSideConnection[index15] = 2;
      Minecart._rightSideConnection[index15] = 0;
      for (int index16 = 0; index16 < 8; ++index16)
        Minecart._tileHeight[index15][index16] = index16 + 1;
      Minecart._texturePosition[index15] = new Vector2(1f, 3f);
      int index17 = index15 + 1;
      Minecart._leftSideConnection[index17] = 2;
      Minecart._rightSideConnection[index17] = -1;
      Minecart._tileHeight[index17][0] = 1;
      Minecart._tileHeight[index17][1] = 2;
      for (int index18 = 2; index18 < 8; ++index18)
        Minecart._tileHeight[index17][index18] = -1;
      Minecart._texturePosition[index17] = new Vector2(4f, 1f);
      int index19 = index17 + 1;
      Minecart._leftSideConnection[index19] = -1;
      Minecart._rightSideConnection[index19] = 2;
      Minecart._tileHeight[index19][6] = 2;
      Minecart._tileHeight[index19][7] = 1;
      for (int index20 = 0; index20 < 6; ++index20)
        Minecart._tileHeight[index19][index20] = -1;
      Minecart._texturePosition[index19] = new Vector2(5f, 1f);
      int index21 = index19 + 1;
      Minecart._leftSideConnection[index21] = 0;
      Minecart._rightSideConnection[index21] = -1;
      Minecart._tileHeight[index21][0] = 8;
      Minecart._tileHeight[index21][1] = 7;
      Minecart._tileHeight[index21][2] = 6;
      for (int index22 = 3; index22 < 8; ++index22)
        Minecart._tileHeight[index21][index22] = -1;
      Minecart._texturePosition[index21] = new Vector2(6f, 1f);
      int index23 = index21 + 1;
      Minecart._leftSideConnection[index23] = -1;
      Minecart._rightSideConnection[index23] = 0;
      Minecart._tileHeight[index23][5] = 6;
      Minecart._tileHeight[index23][6] = 7;
      Minecart._tileHeight[index23][7] = 8;
      for (int index24 = 0; index24 < 5; ++index24)
        Minecart._tileHeight[index23][index24] = -1;
      Minecart._texturePosition[index23] = new Vector2(7f, 1f);
      int index25 = index23 + 1;
      Minecart._leftSideConnection[index25] = -1;
      Minecart._rightSideConnection[index25] = 1;
      Minecart._tileHeight[index25][0] = -4;
      Minecart._texturePosition[index25] = new Vector2(2f, 0.0f);
      int index26 = index25 + 1;
      Minecart._leftSideConnection[index26] = 1;
      Minecart._rightSideConnection[index26] = -1;
      Minecart._tileHeight[index26][7] = -4;
      Minecart._texturePosition[index26] = new Vector2(3f, 0.0f);
      int index27 = index26 + 1;
      Minecart._leftSideConnection[index27] = 2;
      Minecart._rightSideConnection[index27] = -1;
      for (int index28 = 0; index28 < 6; ++index28)
        Minecart._tileHeight[index27][index28] = index28 + 1;
      Minecart._tileHeight[index27][6] = -3;
      Minecart._tileHeight[index27][7] = -3;
      Minecart._texturePosition[index27] = new Vector2(4f, 0.0f);
      int index29 = index27 + 1;
      Minecart._leftSideConnection[index29] = -1;
      Minecart._rightSideConnection[index29] = 2;
      Minecart._tileHeight[index29][0] = -3;
      Minecart._tileHeight[index29][1] = -3;
      for (int index30 = 2; index30 < 8; ++index30)
        Minecart._tileHeight[index29][index30] = 8 - index30;
      Minecart._texturePosition[index29] = new Vector2(5f, 0.0f);
      int index31 = index29 + 1;
      Minecart._leftSideConnection[index31] = 0;
      Minecart._rightSideConnection[index31] = -1;
      for (int index32 = 0; index32 < 6; ++index32)
        Minecart._tileHeight[index31][index32] = 8 - index32;
      Minecart._tileHeight[index31][6] = -3;
      Minecart._tileHeight[index31][7] = -3;
      Minecart._texturePosition[index31] = new Vector2(6f, 0.0f);
      int index33 = index31 + 1;
      Minecart._leftSideConnection[index33] = -1;
      Minecart._rightSideConnection[index33] = 0;
      Minecart._tileHeight[index33][0] = -3;
      Minecart._tileHeight[index33][1] = -3;
      for (int index34 = 2; index34 < 8; ++index34)
        Minecart._tileHeight[index33][index34] = index34 + 1;
      Minecart._texturePosition[index33] = new Vector2(7f, 0.0f);
      int index35 = index33 + 1;
      Minecart._leftSideConnection[index35] = -1;
      Minecart._rightSideConnection[index35] = -1;
      Minecart._tileHeight[index35][0] = -4;
      Minecart._tileHeight[index35][7] = -4;
      Minecart._trackType[index35] = 1;
      Minecart._texturePosition[index35] = new Vector2(0.0f, 4f);
      int index36 = index35 + 1;
      Minecart._leftSideConnection[index36] = 1;
      Minecart._rightSideConnection[index36] = 1;
      Minecart._trackType[index36] = 1;
      Minecart._texturePosition[index36] = new Vector2(1f, 4f);
      int index37 = index36 + 1;
      Minecart._leftSideConnection[index37] = -1;
      Minecart._rightSideConnection[index37] = 1;
      Minecart._tileHeight[index37][0] = -4;
      Minecart._trackType[index37] = 1;
      Minecart._texturePosition[index37] = new Vector2(0.0f, 5f);
      int index38 = index37 + 1;
      Minecart._leftSideConnection[index38] = 1;
      Minecart._rightSideConnection[index38] = -1;
      Minecart._tileHeight[index38][7] = -4;
      Minecart._trackType[index38] = 1;
      Minecart._texturePosition[index38] = new Vector2(1f, 5f);
      int index39 = index38 + 1;
      Minecart._leftSideConnection[index39] = -1;
      Minecart._rightSideConnection[index39] = 1;
      for (int index40 = 0; index40 < 6; ++index40)
        Minecart._tileHeight[index39][index40] = -2;
      Minecart._texturePosition[index39] = new Vector2(2f, 2f);
      int index41 = index39 + 1;
      Minecart._leftSideConnection[index41] = 1;
      Minecart._rightSideConnection[index41] = -1;
      for (int index42 = 2; index42 < 8; ++index42)
        Minecart._tileHeight[index41][index42] = -2;
      Minecart._texturePosition[index41] = new Vector2(3f, 2f);
      int index43 = index41 + 1;
      Minecart._leftSideConnection[index43] = 2;
      Minecart._rightSideConnection[index43] = -1;
      Minecart._tileHeight[index43][0] = 1;
      Minecart._tileHeight[index43][1] = 2;
      for (int index44 = 2; index44 < 8; ++index44)
        Minecart._tileHeight[index43][index44] = -2;
      Minecart._texturePosition[index43] = new Vector2(4f, 2f);
      int index45 = index43 + 1;
      Minecart._leftSideConnection[index45] = -1;
      Minecart._rightSideConnection[index45] = 2;
      Minecart._tileHeight[index45][6] = 2;
      Minecart._tileHeight[index45][7] = 1;
      for (int index46 = 0; index46 < 6; ++index46)
        Minecart._tileHeight[index45][index46] = -2;
      Minecart._texturePosition[index45] = new Vector2(5f, 2f);
      int index47 = index45 + 1;
      Minecart._leftSideConnection[index47] = 0;
      Minecart._rightSideConnection[index47] = -1;
      Minecart._tileHeight[index47][0] = 8;
      Minecart._tileHeight[index47][1] = 7;
      Minecart._tileHeight[index47][2] = 6;
      for (int index48 = 3; index48 < 8; ++index48)
        Minecart._tileHeight[index47][index48] = -2;
      Minecart._texturePosition[index47] = new Vector2(6f, 2f);
      int index49 = index47 + 1;
      Minecart._leftSideConnection[index49] = -1;
      Minecart._rightSideConnection[index49] = 0;
      Minecart._tileHeight[index49][5] = 6;
      Minecart._tileHeight[index49][6] = 7;
      Minecart._tileHeight[index49][7] = 8;
      for (int index50 = 0; index50 < 5; ++index50)
        Minecart._tileHeight[index49][index50] = -2;
      Minecart._texturePosition[index49] = new Vector2(7f, 2f);
      int index51 = index49 + 1;
      Minecart._leftSideConnection[index51] = 1;
      Minecart._rightSideConnection[index51] = 1;
      Minecart._trackType[index51] = 2;
      Minecart._boostLeft[index51] = false;
      Minecart._texturePosition[index51] = new Vector2(2f, 3f);
      int index52 = index51 + 1;
      Minecart._leftSideConnection[index52] = 1;
      Minecart._rightSideConnection[index52] = 1;
      Minecart._trackType[index52] = 2;
      Minecart._boostLeft[index52] = true;
      Minecart._texturePosition[index52] = new Vector2(3f, 3f);
      int index53 = index52 + 1;
      Minecart._leftSideConnection[index53] = 0;
      Minecart._rightSideConnection[index53] = 2;
      for (int index54 = 0; index54 < 8; ++index54)
        Minecart._tileHeight[index53][index54] = 8 - index54;
      Minecart._trackType[index53] = 2;
      Minecart._boostLeft[index53] = false;
      Minecart._texturePosition[index53] = new Vector2(4f, 3f);
      int index55 = index53 + 1;
      Minecart._leftSideConnection[index55] = 2;
      Minecart._rightSideConnection[index55] = 0;
      for (int index56 = 0; index56 < 8; ++index56)
        Minecart._tileHeight[index55][index56] = index56 + 1;
      Minecart._trackType[index55] = 2;
      Minecart._boostLeft[index55] = true;
      Minecart._texturePosition[index55] = new Vector2(5f, 3f);
      int index57 = index55 + 1;
      Minecart._leftSideConnection[index57] = 0;
      Minecart._rightSideConnection[index57] = 2;
      for (int index58 = 0; index58 < 8; ++index58)
        Minecart._tileHeight[index57][index58] = 8 - index58;
      Minecart._trackType[index57] = 2;
      Minecart._boostLeft[index57] = true;
      Minecart._texturePosition[index57] = new Vector2(6f, 3f);
      int index59 = index57 + 1;
      Minecart._leftSideConnection[index59] = 2;
      Minecart._rightSideConnection[index59] = 0;
      for (int index60 = 0; index60 < 8; ++index60)
        Minecart._tileHeight[index59][index60] = index60 + 1;
      Minecart._trackType[index59] = 2;
      Minecart._boostLeft[index59] = false;
      Minecart._texturePosition[index59] = new Vector2(7f, 3f);
      int num1 = index59 + 1;
      Minecart._texturePosition[36] = new Vector2(0.0f, 6f);
      Minecart._texturePosition[37] = new Vector2(1f, 6f);
      Minecart._texturePosition[39] = new Vector2(0.0f, 7f);
      Minecart._texturePosition[38] = new Vector2(1f, 7f);
      for (int index61 = 0; index61 < Minecart._texturePosition.Length; ++index61)
        Minecart._texturePosition[index61] = Minecart._texturePosition[index61] * 18f;
      for (int index62 = 0; index62 < Minecart._tileHeight.Length; ++index62)
      {
        int[] numArray = Minecart._tileHeight[index62];
        for (int index63 = 0; index63 < numArray.Length; ++index63)
        {
          if (numArray[index63] >= 0)
            numArray[index63] = (8 - numArray[index63]) * 2;
        }
      }
      int[] numArray1 = new int[36];
      Minecart._trackSwitchOptions = new int[64][];
      for (int index64 = 0; index64 < 64; ++index64)
      {
        int num2 = 0;
        for (int index65 = 1; index65 < 256; index65 <<= 1)
        {
          if ((index64 & index65) == index65)
            ++num2;
        }
        int length = 0;
        for (int index66 = 0; index66 < 36; ++index66)
        {
          numArray1[index66] = -1;
          int num3 = 0;
          switch (Minecart._leftSideConnection[index66])
          {
            case 0:
              num3 |= 1;
              break;
            case 1:
              num3 |= 2;
              break;
            case 2:
              num3 |= 4;
              break;
          }
          switch (Minecart._rightSideConnection[index66])
          {
            case 0:
              num3 |= 8;
              break;
            case 1:
              num3 |= 16;
              break;
            case 2:
              num3 |= 32;
              break;
          }
          if (num2 < 2)
          {
            if (index64 != num3)
              continue;
          }
          else if (num3 == 0 || (index64 & num3) != num3)
            continue;
          numArray1[index66] = index66;
          ++length;
        }
        if (length != 0)
        {
          int[] numArray2 = new int[length];
          int index67 = 0;
          for (int index68 = 0; index68 < 36; ++index68)
          {
            if (numArray1[index68] != -1)
            {
              numArray2[index67] = numArray1[index68];
              ++index67;
            }
          }
          Minecart._trackSwitchOptions[index64] = numArray2;
        }
      }
      Minecart._firstPressureFrame = (short) -1;
      Minecart._firstLeftBoostFrame = (short) -1;
      Minecart._firstRightBoostFrame = (short) -1;
      for (int index69 = 0; index69 < Minecart._trackType.Length; ++index69)
      {
        switch (Minecart._trackType[index69])
        {
          case 1:
            if (Minecart._firstPressureFrame == (short) -1)
            {
              Minecart._firstPressureFrame = (short) index69;
              break;
            }
            break;
          case 2:
            if (Minecart._boostLeft[index69])
            {
              if (Minecart._firstLeftBoostFrame == (short) -1)
              {
                Minecart._firstLeftBoostFrame = (short) index69;
                break;
              }
              break;
            }
            if (Minecart._firstRightBoostFrame == (short) -1)
            {
              Minecart._firstRightBoostFrame = (short) index69;
              break;
            }
            break;
        }
      }
    }

    public static BitsByte TrackCollision(
      ref Vector2 Position,
      ref Vector2 Velocity,
      ref Vector2 lastBoost,
      int Width,
      int Height,
      bool followDown,
      bool followUp,
      int fallStart,
      bool trackOnly,
      Action<Vector2> MinecartDust)
    {
      if (followDown & followUp)
      {
        followDown = false;
        followUp = false;
      }
      Vector2 vector2_1 = new Vector2((float) (Width / 2) - 25f, (float) (Height / 2));
      Vector2 vector2_2 = Position + new Vector2((float) (Width / 2) - 25f, (float) (Height / 2)) + Minecart._trackMagnetOffset;
      Vector2 vector2_3 = Velocity;
      float num1 = vector2_3.Length();
      vector2_3.Normalize();
      Vector2 vector2_4 = vector2_2;
      Tile tileTrack = (Tile) null;
      bool flag1 = false;
      bool flag2 = true;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      Minecart.TrackState trackState1 = Minecart.TrackState.NoTrack;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      Vector2 vector2_5 = Vector2.Zero;
      Vector2 vector2_6 = Vector2.Zero;
      BitsByte bitsByte = new BitsByte();
      while (true)
      {
        int index1 = (int) ((double) vector2_4.X / 16.0);
        int index2 = (int) ((double) vector2_4.Y / 16.0);
        int index3 = (int) vector2_4.X % 16 / 2;
        if (flag2)
          num4 = index3;
        bool flag7 = index3 != num4;
        if ((trackState1 == Minecart.TrackState.OnBack || trackState1 == Minecart.TrackState.OnTrack || trackState1 == Minecart.TrackState.OnFront) && index1 != num2)
        {
          int index4 = trackState1 != Minecart.TrackState.OnBack ? (int) tileTrack.FrontTrack() : (int) tileTrack.BackTrack();
          switch ((double) vector2_3.X >= 0.0 ? Minecart._rightSideConnection[index4] : Minecart._leftSideConnection[index4])
          {
            case 0:
              --index2;
              vector2_4.Y -= 2f;
              break;
            case 2:
              ++index2;
              vector2_4.Y += 2f;
              break;
          }
        }
        Minecart.TrackState trackState2 = Minecart.TrackState.NoTrack;
        bool flag8 = false;
        if (index1 != num2 || index2 != num3)
        {
          if (flag2)
            flag2 = false;
          else
            flag8 = true;
          tileTrack = Main.tile[index1, index2];
          if (tileTrack == null)
          {
            tileTrack = new Tile();
            Main.tile[index1, index2] = tileTrack;
          }
          flag1 = tileTrack.nactive() && tileTrack.type == (ushort) 314;
        }
        if (flag1)
        {
          Minecart.TrackState trackState3 = Minecart.TrackState.NoTrack;
          int index5 = (int) tileTrack.FrontTrack();
          int index6 = (int) tileTrack.BackTrack();
          int num5 = Minecart._tileHeight[index5][index3];
          switch (num5)
          {
            case -4:
              if (trackState1 == Minecart.TrackState.OnFront)
              {
                if (trackOnly)
                {
                  vector2_4 -= vector2_6;
                  num1 = 0.0f;
                  trackState2 = Minecart.TrackState.OnFront;
                  flag6 = true;
                  break;
                }
                trackState2 = Minecart.TrackState.NoTrack;
                flag5 = true;
                break;
              }
              break;
            case -3:
              if (trackState1 == Minecart.TrackState.OnFront)
              {
                trackState1 = Minecart.TrackState.NoTrack;
                Matrix matrix = (double) Velocity.X <= 0.0 ? (Minecart._rightSideConnection[index5] != 2 ? Matrix.CreateRotationZ(-0.7853982f) : Matrix.CreateRotationZ(0.7853982f)) : (Minecart._leftSideConnection[index5] != 2 ? Matrix.CreateRotationZ(0.7853982f) : Matrix.CreateRotationZ(-0.7853982f));
                vector2_5 = Vector2.Transform(new Vector2(Velocity.X, 0.0f), matrix);
                vector2_5.X = Velocity.X;
                flag4 = true;
                num1 = 0.0f;
                break;
              }
              break;
            case -2:
              if (trackState1 == Minecart.TrackState.OnFront)
              {
                if (trackOnly)
                {
                  vector2_4 -= vector2_6;
                  num1 = 0.0f;
                  trackState2 = Minecart.TrackState.OnFront;
                  flag6 = true;
                  break;
                }
                if ((double) vector2_3.X < 0.0)
                {
                  float num6 = (float) (index1 * 16 + (index3 + 1) * 2) - vector2_4.X;
                  vector2_4.X += num6;
                  num1 += num6 / vector2_3.X;
                }
                vector2_3.X = -vector2_3.X;
                bitsByte[1] = true;
                trackState2 = Minecart.TrackState.OnFront;
                break;
              }
              break;
            case -1:
              if (trackState1 == Minecart.TrackState.OnFront)
              {
                vector2_4 -= vector2_6;
                num1 = 0.0f;
                trackState2 = Minecart.TrackState.OnFront;
                flag6 = true;
                break;
              }
              break;
            default:
              float num7 = (float) (index2 * 16 + num5);
              if (index1 != num2 && trackState1 == Minecart.TrackState.NoTrack && (double) vector2_4.Y > (double) num7 && (double) vector2_4.Y - (double) num7 < 2.0)
              {
                flag8 = false;
                trackState1 = Minecart.TrackState.AboveFront;
              }
              Minecart.TrackState trackState4 = (double) vector2_4.Y >= (double) num7 ? ((double) vector2_4.Y <= (double) num7 ? Minecart.TrackState.OnTrack : Minecart.TrackState.BelowTrack) : Minecart.TrackState.AboveTrack;
              if (index6 != -1)
              {
                float num8 = (float) (index2 * 16 + Minecart._tileHeight[index6][index3]);
                trackState3 = (double) vector2_4.Y >= (double) num8 ? ((double) vector2_4.Y <= (double) num8 ? Minecart.TrackState.OnTrack : Minecart.TrackState.BelowTrack) : Minecart.TrackState.AboveTrack;
              }
              switch (trackState4)
              {
                case Minecart.TrackState.AboveTrack:
                  switch (trackState3)
                  {
                    case Minecart.TrackState.AboveTrack:
                      trackState2 = Minecart.TrackState.AboveTrack;
                      break;
                    case Minecart.TrackState.OnTrack:
                      trackState2 = Minecart.TrackState.OnBack;
                      break;
                    case Minecart.TrackState.BelowTrack:
                      trackState2 = Minecart.TrackState.AboveFront;
                      break;
                    default:
                      trackState2 = Minecart.TrackState.AboveFront;
                      break;
                  }
                  break;
                case Minecart.TrackState.OnTrack:
                  trackState2 = trackState3 != Minecart.TrackState.OnTrack ? Minecart.TrackState.OnFront : Minecart.TrackState.OnTrack;
                  break;
                case Minecart.TrackState.BelowTrack:
                  switch (trackState3)
                  {
                    case Minecart.TrackState.AboveTrack:
                      trackState2 = Minecart.TrackState.AboveBack;
                      break;
                    case Minecart.TrackState.OnTrack:
                      trackState2 = Minecart.TrackState.OnBack;
                      break;
                    case Minecart.TrackState.BelowTrack:
                      trackState2 = Minecart.TrackState.BelowTrack;
                      break;
                    default:
                      trackState2 = Minecart.TrackState.BelowTrack;
                      break;
                  }
                  break;
              }
              break;
          }
        }
        if (!flag8)
        {
          if (trackState1 != trackState2)
          {
            bool flag9 = false;
            if (flag7 || (double) vector2_3.Y > 0.0)
            {
              switch (trackState1)
              {
                case Minecart.TrackState.AboveTrack:
                  switch (trackState2)
                  {
                    case Minecart.TrackState.AboveTrack:
                      trackState2 = Minecart.TrackState.OnTrack;
                      break;
                    case Minecart.TrackState.AboveFront:
                      trackState2 = Minecart.TrackState.OnBack;
                      break;
                    case Minecart.TrackState.AboveBack:
                      trackState2 = Minecart.TrackState.OnFront;
                      break;
                  }
                  break;
                case Minecart.TrackState.OnTrack:
                  int num9 = Minecart._tileHeight[(int) tileTrack.FrontTrack()][index3];
                  int num10 = Minecart._tileHeight[(int) tileTrack.BackTrack()][index3];
                  trackState2 = !followDown ? (!followUp ? Minecart.TrackState.OnFront : (num9 >= num10 ? Minecart.TrackState.OnBack : Minecart.TrackState.OnFront)) : (num9 >= num10 ? Minecart.TrackState.OnFront : Minecart.TrackState.OnBack);
                  flag9 = true;
                  break;
                case Minecart.TrackState.AboveFront:
                  if (trackState2 == Minecart.TrackState.BelowTrack)
                  {
                    trackState2 = Minecart.TrackState.OnFront;
                    break;
                  }
                  break;
                case Minecart.TrackState.AboveBack:
                  if (trackState2 == Minecart.TrackState.BelowTrack)
                  {
                    trackState2 = Minecart.TrackState.OnBack;
                    break;
                  }
                  break;
                case Minecart.TrackState.OnFront:
                  trackState2 = Minecart.TrackState.OnFront;
                  flag9 = true;
                  break;
                case Minecart.TrackState.OnBack:
                  trackState2 = Minecart.TrackState.OnBack;
                  flag9 = true;
                  break;
              }
              int index7 = -1;
              if (trackState2 != Minecart.TrackState.OnTrack && trackState2 != Minecart.TrackState.OnFront)
              {
                if (trackState2 == Minecart.TrackState.OnBack)
                  index7 = (int) tileTrack.BackTrack();
              }
              else
                index7 = (int) tileTrack.FrontTrack();
              if (index7 != -1)
              {
                if (!flag9 && (double) Velocity.Y > (double) Player.defaultGravity)
                {
                  int num11 = (int) ((double) Position.Y / 16.0);
                  if (fallStart < num11 - 1)
                  {
                    Main.PlaySound(SoundID.Item53, (int) Position.X + Width / 2, (int) Position.Y + Height / 2);
                    Minecart.WheelSparks(MinecartDust, Position, Width, Height, 10);
                  }
                }
                if (trackState1 == Minecart.TrackState.AboveFront && Minecart._trackType[index7] == 1)
                  flag3 = true;
                vector2_3.Y = 0.0f;
                vector2_4.Y = (float) (index2 * 16 + Minecart._tileHeight[index7][index3]);
              }
            }
          }
        }
        else if (trackState2 == Minecart.TrackState.OnFront || trackState2 == Minecart.TrackState.OnBack || trackState2 == Minecart.TrackState.OnTrack)
        {
          if (flag1 && Minecart._trackType[(int) tileTrack.FrontTrack()] == 1)
            flag3 = true;
          vector2_3.Y = 0.0f;
        }
        if (trackState2 == Minecart.TrackState.OnFront)
        {
          int index8 = (int) tileTrack.FrontTrack();
          if (Minecart._trackType[index8] == 2 && (double) lastBoost.X == 0.0 && (double) lastBoost.Y == 0.0)
          {
            lastBoost = new Vector2((float) index1, (float) index2);
            if (Minecart._boostLeft[index8])
              bitsByte[4] = true;
            else
              bitsByte[5] = true;
          }
        }
        num4 = index3;
        trackState1 = trackState2;
        num2 = index1;
        num3 = index2;
        if ((double) num1 > 0.0)
        {
          float num12 = vector2_4.X % 2f;
          float num13 = vector2_4.Y % 2f;
          float num14 = 3f;
          float num15 = 3f;
          if ((double) vector2_3.X < 0.0)
            num14 = num12 + 0.125f;
          else if ((double) vector2_3.X > 0.0)
            num14 = 2f - num12;
          if ((double) vector2_3.Y < 0.0)
            num15 = num13 + 0.125f;
          else if ((double) vector2_3.Y > 0.0)
            num15 = 2f - num13;
          if ((double) num14 != 3.0 || (double) num15 != 3.0)
          {
            float num16 = Math.Abs(num14 / vector2_3.X);
            float num17 = Math.Abs(num15 / vector2_3.Y);
            float num18 = (double) num16 < (double) num17 ? num16 : num17;
            if ((double) num18 > (double) num1)
            {
              vector2_6 = vector2_3 * num1;
              num1 = 0.0f;
            }
            else
            {
              vector2_6 = vector2_3 * num18;
              num1 -= num18;
            }
            vector2_4 += vector2_6;
          }
          else
            goto label_99;
        }
        else
          break;
      }
      if ((double) lastBoost.X != (double) num2 || (double) lastBoost.Y != (double) num3)
        lastBoost = Vector2.Zero;
label_99:
      if (flag3)
        bitsByte[3] = true;
      if (flag5)
      {
        Velocity.X = vector2_4.X - vector2_2.X;
        Velocity.Y = Player.defaultGravity;
      }
      else if (flag4)
      {
        bitsByte[2] = true;
        Velocity = vector2_5;
      }
      else if (bitsByte[1])
      {
        Velocity.X = -Velocity.X;
        Position.X = vector2_4.X - Minecart._trackMagnetOffset.X - vector2_1.X - Velocity.X;
        if ((double) vector2_3.Y == 0.0)
          Velocity.Y = 0.0f;
      }
      else
      {
        if (flag6)
          Velocity.X = vector2_4.X - vector2_2.X;
        if ((double) vector2_3.Y == 0.0)
          Velocity.Y = 0.0f;
      }
      Position.Y += vector2_4.Y - vector2_2.Y - Velocity.Y;
      Position.Y = (float) Math.Round((double) Position.Y, 2);
      switch (trackState1)
      {
        case Minecart.TrackState.OnTrack:
        case Minecart.TrackState.OnFront:
        case Minecart.TrackState.OnBack:
          bitsByte[0] = true;
          break;
      }
      return bitsByte;
    }

    public static bool FrameTrack(int i, int j, bool pound, bool mute = false)
    {
      int index1 = 0;
      Tile tileTrack = Main.tile[i, j];
      if (tileTrack == null)
      {
        tileTrack = new Tile();
        Main.tile[i, j] = tileTrack;
      }
      if (mute && tileTrack.type != (ushort) 314)
        return false;
      if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].type == (ushort) 314)
        ++index1;
      if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].type == (ushort) 314)
        index1 += 2;
      if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].type == (ushort) 314)
        index1 += 4;
      if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].type == (ushort) 314)
        index1 += 8;
      if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].type == (ushort) 314)
        index1 += 16;
      if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].type == (ushort) 314)
        index1 += 32;
      int index2 = (int) tileTrack.FrontTrack();
      int num1 = (int) tileTrack.BackTrack();
      if (Minecart._trackType == null)
        return false;
      int num2 = index2 < 0 || index2 >= Minecart._trackType.Length ? 0 : Minecart._trackType[index2];
      int index3 = -1;
      int index4 = -1;
      int[] trackSwitchOption = Minecart._trackSwitchOptions[index1];
      if (trackSwitchOption == null)
      {
        if (pound)
          return false;
        tileTrack.FrontTrack((short) 0);
        tileTrack.BackTrack((short) -1);
        return false;
      }
      if (!pound)
      {
        int num3 = -1;
        int num4 = -1;
        bool flag = false;
        for (int index5 = 0; index5 < trackSwitchOption.Length; ++index5)
        {
          int index6 = trackSwitchOption[index5];
          if (num1 == trackSwitchOption[index5])
            index4 = index5;
          if (Minecart._trackType[index6] == num2)
          {
            if (Minecart._leftSideConnection[index6] == -1 || Minecart._rightSideConnection[index6] == -1)
            {
              if (index2 == trackSwitchOption[index5])
              {
                index3 = index5;
                flag = true;
              }
              if (num3 == -1)
                num3 = index5;
            }
            else
            {
              if (index2 == trackSwitchOption[index5])
              {
                index3 = index5;
                flag = false;
              }
              if (num4 == -1)
                num4 = index5;
            }
          }
        }
        if (num4 != -1)
        {
          if (index3 == -1 | flag)
            index3 = num4;
        }
        else
        {
          if (index3 == -1)
          {
            if (num2 == 2 || num2 == 1)
              return false;
            index3 = num3;
          }
          index4 = -1;
        }
      }
      else
      {
        for (int index7 = 0; index7 < trackSwitchOption.Length; ++index7)
        {
          if (index2 == trackSwitchOption[index7])
            index3 = index7;
          if (num1 == trackSwitchOption[index7])
            index4 = index7;
        }
        int num5 = 0;
        int num6 = 0;
        for (int index8 = 0; index8 < trackSwitchOption.Length; ++index8)
        {
          if (Minecart._trackType[trackSwitchOption[index8]] == num2)
          {
            if (Minecart._leftSideConnection[trackSwitchOption[index8]] == -1 || Minecart._rightSideConnection[trackSwitchOption[index8]] == -1)
              ++num6;
            else
              ++num5;
          }
        }
        if (num5 < 2 && num6 < 2)
          return false;
        bool flag1 = num5 == 0;
        bool flag2 = false;
        if (!flag1)
        {
          while (!flag2)
          {
            ++index4;
            if (index4 >= trackSwitchOption.Length)
            {
              index4 = -1;
              break;
            }
            if ((Minecart._leftSideConnection[trackSwitchOption[index4]] != Minecart._leftSideConnection[trackSwitchOption[index3]] || Minecart._rightSideConnection[trackSwitchOption[index4]] != Minecart._rightSideConnection[trackSwitchOption[index3]]) && Minecart._trackType[trackSwitchOption[index4]] == num2 && Minecart._leftSideConnection[trackSwitchOption[index4]] != -1 && Minecart._rightSideConnection[trackSwitchOption[index4]] != -1)
              flag2 = true;
          }
        }
        if (!flag2)
        {
          do
          {
            ++index3;
            if (index3 >= trackSwitchOption.Length)
            {
              index3 = -1;
              do
              {
                ++index3;
              }
              while (Minecart._trackType[trackSwitchOption[index3]] != num2 || (Minecart._leftSideConnection[trackSwitchOption[index3]] == -1 ? 1 : (Minecart._rightSideConnection[trackSwitchOption[index3]] == -1 ? 1 : 0)) != (flag1 ? 1 : 0));
              break;
            }
          }
          while (Minecart._trackType[trackSwitchOption[index3]] != num2 || (Minecart._leftSideConnection[trackSwitchOption[index3]] == -1 ? 1 : (Minecart._rightSideConnection[trackSwitchOption[index3]] == -1 ? 1 : 0)) != (flag1 ? 1 : 0));
        }
      }
      bool flag3 = false;
      switch (index3)
      {
        case -2:
          if ((int) tileTrack.FrontTrack() != (int) Minecart._firstPressureFrame)
          {
            flag3 = true;
            break;
          }
          break;
        case -1:
          if (tileTrack.FrontTrack() != (short) 0)
          {
            flag3 = true;
            break;
          }
          break;
        default:
          if ((int) tileTrack.FrontTrack() != trackSwitchOption[index3])
          {
            flag3 = true;
            break;
          }
          break;
      }
      if (index4 == -1)
      {
        if (tileTrack.BackTrack() != (short) -1)
          flag3 = true;
      }
      else if ((int) tileTrack.BackTrack() != trackSwitchOption[index4])
        flag3 = true;
      switch (index3)
      {
        case -2:
          tileTrack.FrontTrack(Minecart._firstPressureFrame);
          break;
        case -1:
          tileTrack.FrontTrack((short) 0);
          break;
        default:
          tileTrack.FrontTrack((short) trackSwitchOption[index3]);
          break;
      }
      if (index4 == -1)
        tileTrack.BackTrack((short) -1);
      else
        tileTrack.BackTrack((short) trackSwitchOption[index4]);
      if (pound & flag3 && !mute)
        WorldGen.KillTile(i, j, true);
      return true;
    }

    public static bool GetOnTrack(
      int tileX,
      int tileY,
      ref Vector2 Position,
      int Width,
      int Height)
    {
      Tile tile = Main.tile[tileX, tileY];
      if (tile.type != (ushort) 314)
        return false;
      Vector2 vector2_1 = new Vector2((float) (Width / 2) - 25f, (float) (Height / 2));
      Vector2 vector2_2 = Position + vector2_1 + Minecart._trackMagnetOffset;
      int num1 = (int) vector2_2.X % 16 / 2;
      int num2 = -1;
      int num3 = 0;
      for (int index = num1; index < 8; ++index)
      {
        num3 = Minecart._tileHeight[(int) tile.frameX][index];
        if (num3 >= 0)
        {
          num2 = index;
          break;
        }
      }
      if (num2 == -1)
      {
        for (int index = num1 - 1; index >= 0; --index)
        {
          num3 = Minecart._tileHeight[(int) tile.frameX][index];
          if (num3 >= 0)
          {
            num2 = index;
            break;
          }
        }
      }
      if (num2 == -1)
        return false;
      vector2_2.X = (float) (tileX * 16 + num2 * 2);
      vector2_2.Y = (float) (tileY * 16 + num3);
      vector2_2 -= Minecart._trackMagnetOffset;
      vector2_2 -= vector2_1;
      Position = vector2_2;
      return true;
    }

    public static bool OnTrack(Vector2 Position, int Width, int Height)
    {
      Vector2 vector2 = Position + new Vector2((float) (Width / 2) - 25f, (float) (Height / 2)) + Minecart._trackMagnetOffset;
      int index1 = (int) ((double) vector2.X / 16.0);
      int index2 = (int) ((double) vector2.Y / 16.0);
      return Main.tile[index1, index2] != null && Main.tile[index1, index2].type == (ushort) 314;
    }

    public static float TrackRotation(
      ref float rotation,
      Vector2 Position,
      int Width,
      int Height,
      bool followDown,
      bool followUp,
      Action<Vector2> MinecartDust)
    {
      Vector2 Position1 = Position;
      Vector2 Position2 = Position;
      Vector2 zero = Vector2.Zero;
      Vector2 Velocity = new Vector2(-12f, 0.0f);
      Minecart.TrackCollision(ref Position1, ref Velocity, ref zero, Width, Height, followDown, followUp, 0, true, MinecartDust);
      Vector2 vector2_1 = Position1 + Velocity;
      Velocity = new Vector2(12f, 0.0f);
      Minecart.TrackCollision(ref Position2, ref Velocity, ref zero, Width, Height, followDown, followUp, 0, true, MinecartDust);
      Vector2 vector2_2 = Position2 + Velocity;
      float num1 = vector2_2.Y - vector2_1.Y;
      float num2 = vector2_2.X - vector2_1.X;
      float num3 = num1 / num2;
      double num4 = (double) vector2_1.Y + ((double) Position.X - (double) vector2_1.X) * (double) num3;
      float num5 = (Position.X - (float) (int) Position.X) * num3;
      rotation = (float) Math.Atan2((double) num1, (double) num2);
      double y = (double) Position.Y;
      return (float) (num4 - y) + num5;
    }

    public static void HitTrackSwitch(Vector2 Position, int Width, int Height)
    {
      Vector2 vector2_1 = new Vector2((float) (Width / 2) - 25f, (float) (Height / 2));
      Vector2 vector2_2 = Position + new Vector2((float) (Width / 2) - 25f, (float) (Height / 2)) + Minecart._trackMagnetOffset;
      int num = (int) ((double) vector2_2.X / 16.0);
      int j = (int) ((double) vector2_2.Y / 16.0);
      Wiring.HitSwitch(num, j);
      NetMessage.SendData(59, number: num, number2: ((float) j));
    }

    public static void FlipSwitchTrack(int i, int j)
    {
      Tile tileTrack = Main.tile[i, j];
      short trackID = tileTrack.FrontTrack();
      if (trackID == (short) -1)
        return;
      switch (Minecart._trackType[(int) trackID])
      {
        case 0:
          if (tileTrack.BackTrack() == (short) -1)
            break;
          tileTrack.FrontTrack(tileTrack.BackTrack());
          tileTrack.BackTrack(trackID);
          NetMessage.SendTileSquare(-1, i, j, 1);
          break;
        case 2:
          Minecart.FrameTrack(i, j, true, true);
          NetMessage.SendTileSquare(-1, i, j, 1);
          break;
      }
    }

    public static void TrackColors(
      int i,
      int j,
      Tile trackTile,
      out int frontColor,
      out int backColor)
    {
      if (trackTile.type == (ushort) 314)
      {
        frontColor = (int) trackTile.color();
        backColor = frontColor;
        if (trackTile.frameY == (short) -1)
          return;
        int num1 = Minecart._leftSideConnection[(int) trackTile.frameX];
        int num2 = Minecart._rightSideConnection[(int) trackTile.frameX];
        int num3 = Minecart._leftSideConnection[(int) trackTile.frameY];
        int num4 = Minecart._rightSideConnection[(int) trackTile.frameY];
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int num8 = 0;
        for (int index = 0; index < 4; ++index)
        {
          int num9;
          switch (index - 1)
          {
            case 0:
              num9 = num2;
              break;
            case 1:
              num9 = num3;
              break;
            case 2:
              num9 = num4;
              break;
            default:
              num9 = num1;
              break;
          }
          int num10;
          switch (num9)
          {
            case 0:
              num10 = -1;
              break;
            case 1:
              num10 = 0;
              break;
            case 2:
              num10 = 1;
              break;
            default:
              num10 = 0;
              break;
          }
          Tile tile = index % 2 != 0 ? Main.tile[i + 1, j + num10] : Main.tile[i - 1, j + num10];
          int num11 = tile == null || !tile.active() || tile.type != (ushort) 314 ? 0 : (int) tile.color();
          switch (index)
          {
            case 1:
              num6 = num11;
              break;
            case 2:
              num7 = num11;
              break;
            case 3:
              num8 = num11;
              break;
            default:
              num5 = num11;
              break;
          }
        }
        if (num1 == num3)
        {
          if (num6 != 0)
            frontColor = num6;
          else if (num5 != 0)
            frontColor = num5;
          if (num8 != 0)
          {
            backColor = num8;
          }
          else
          {
            if (num7 == 0)
              return;
            backColor = num7;
          }
        }
        else if (num2 == num4)
        {
          if (num5 != 0)
            frontColor = num5;
          else if (num6 != 0)
            frontColor = num6;
          if (num7 != 0)
          {
            backColor = num7;
          }
          else
          {
            if (num8 == 0)
              return;
            backColor = num8;
          }
        }
        else
        {
          if (num6 == 0)
          {
            if (num5 != 0)
              frontColor = num5;
          }
          else if (num5 != 0)
            frontColor = num2 <= num1 ? num6 : num5;
          if (num8 == 0)
          {
            if (num7 == 0)
              return;
            backColor = num7;
          }
          else
          {
            if (num7 == 0)
              return;
            backColor = num4 <= num3 ? num8 : num7;
          }
        }
      }
      else
      {
        frontColor = 0;
        backColor = 0;
      }
    }

    public static bool DrawLeftDecoration(int frameID) => frameID >= 0 && frameID < 36 && Minecart._leftSideConnection[frameID] == 2;

    public static bool DrawRightDecoration(int frameID) => frameID >= 0 && frameID < 36 && Minecart._rightSideConnection[frameID] == 2;

    public static bool DrawBumper(int frameID)
    {
      if (frameID < 0 || frameID >= 36)
        return false;
      return Minecart._tileHeight[frameID][0] == -1 || Minecart._tileHeight[frameID][7] == -1;
    }

    public static bool DrawBouncyBumper(int frameID)
    {
      if (frameID < 0 || frameID >= 36)
        return false;
      return Minecart._tileHeight[frameID][0] == -2 || Minecart._tileHeight[frameID][7] == -2;
    }

    public static void PlaceTrack(Tile trackCache, int style)
    {
      trackCache.active(true);
      trackCache.type = (ushort) 314;
      trackCache.frameY = (short) -1;
      switch (style)
      {
        case 0:
          trackCache.frameX = (short) -1;
          break;
        case 1:
          trackCache.frameX = Minecart._firstPressureFrame;
          break;
        case 2:
          trackCache.frameX = Minecart._firstLeftBoostFrame;
          break;
        case 3:
          trackCache.frameX = Minecart._firstRightBoostFrame;
          break;
      }
    }

    public static int GetTrackItem(Tile trackCache)
    {
      switch (Minecart._trackType[(int) trackCache.frameX])
      {
        case 0:
          return 2340;
        case 1:
          return 2492;
        case 2:
          return 2739;
        default:
          return 0;
      }
    }

    public static Rectangle GetSourceRect(int frameID, int animationFrame = 0)
    {
      if (frameID < 0 || frameID >= 40)
        return new Rectangle(0, 0, 0, 0);
      Vector2 vector2 = Minecart._texturePosition[frameID];
      Rectangle rectangle = new Rectangle((int) vector2.X, (int) vector2.Y, 16, 16);
      if (frameID < 36 && Minecart._trackType[frameID] == 2)
        rectangle.Y += 18 * animationFrame;
      return rectangle;
    }

    public static void WheelSparks(
      Action<Vector2> DustAction,
      Vector2 Position,
      int Width,
      int Height,
      int sparkCount)
    {
      Vector2 vector2_1 = new Vector2((float) (Width / 2) - 25f, (float) (Height / 2));
      Vector2 vector2_2 = Position + vector2_1 + Minecart._trackMagnetOffset;
      for (int index = 0; index < sparkCount; ++index)
        DustAction(vector2_2);
    }

    private static short FrontTrack(this Tile tileTrack) => tileTrack.frameX;

    private static void FrontTrack(this Tile tileTrack, short trackID) => tileTrack.frameX = trackID;

    private static short BackTrack(this Tile tileTrack) => tileTrack.frameY;

    private static void BackTrack(this Tile tileTrack, short trackID) => tileTrack.frameY = trackID;

    private enum TrackState
    {
      NoTrack = -1, // 0xFFFFFFFF
      AboveTrack = 0,
      OnTrack = 1,
      BelowTrack = 2,
      AboveFront = 3,
      AboveBack = 4,
      OnFront = 5,
      OnBack = 6,
    }
  }
}
