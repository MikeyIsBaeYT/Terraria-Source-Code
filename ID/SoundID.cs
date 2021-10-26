// Decompiled with JetBrains decompiler
// Type: Terraria.ID.SoundID
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria.Audio;

namespace Terraria.ID
{
  public class SoundID
  {
    private static readonly SoundID.SoundStyleDefaults ItemDefaults = new SoundID.SoundStyleDefaults(1f, 0.06f);
    public const int Dig = 0;
    public const int PlayerHit = 1;
    public const int Item = 2;
    public const int NPCHit = 3;
    public const int NPCKilled = 4;
    public const int PlayerKilled = 5;
    public const int Grass = 6;
    public const int Grab = 7;
    public const int DoorOpen = 8;
    public const int DoorClosed = 9;
    public const int MenuOpen = 10;
    public const int MenuClose = 11;
    public const int MenuTick = 12;
    public const int Shatter = 13;
    public const int ZombieMoan = 14;
    public const int Roar = 15;
    public const int DoubleJump = 16;
    public const int Run = 17;
    public const int Coins = 18;
    public const int Splash = 19;
    public const int FemaleHit = 20;
    public const int Tink = 21;
    public const int Unlock = 22;
    public const int Drown = 23;
    public const int Chat = 24;
    public const int MaxMana = 25;
    public const int Mummy = 26;
    public const int Pixie = 27;
    public const int Mech = 28;
    public const int Zombie = 29;
    public const int Duck = 30;
    public const int Frog = 31;
    public const int Bird = 32;
    public const int Critter = 33;
    public const int Waterfall = 34;
    public const int Lavafall = 35;
    public const int ForceRoar = 36;
    public const int Meowmere = 37;
    public const int CoinPickup = 38;
    public const int Drip = 39;
    public const int Camera = 40;
    public const int MoonLord = 41;
    public const int Trackable = 42;
    public const int Thunder = 43;
    public const int Seagull = 44;
    public const int Dolphin = 45;
    public const int Owl = 46;
    public const int GuitarC = 47;
    public const int GuitarD = 48;
    public const int GuitarEm = 49;
    public const int GuitarG = 50;
    public const int GuitarAm = 51;
    public const int GuitarF = 52;
    public const int DrumHiHat = 53;
    public const int DrumTomHigh = 54;
    public const int DrumTomLow = 55;
    public const int DrumTomMid = 56;
    public const int DrumClosedHiHat = 57;
    public const int DrumCymbal1 = 58;
    public const int DrumCymbal2 = 59;
    public const int DrumKick = 60;
    public const int DrumTamaSnare = 61;
    public const int DrumFloorTom = 62;
    public const int Research = 63;
    public const int ResearchComplete = 64;
    public const int QueenSlime = 65;
    public static readonly LegacySoundStyle NPCHit1 = new LegacySoundStyle(3, 1);
    public static readonly LegacySoundStyle NPCHit2 = new LegacySoundStyle(3, 2);
    public static readonly LegacySoundStyle NPCHit3 = new LegacySoundStyle(3, 3);
    public static readonly LegacySoundStyle NPCHit4 = new LegacySoundStyle(3, 4);
    public static readonly LegacySoundStyle NPCHit5 = new LegacySoundStyle(3, 5);
    public static readonly LegacySoundStyle NPCHit6 = new LegacySoundStyle(3, 6);
    public static readonly LegacySoundStyle NPCHit7 = new LegacySoundStyle(3, 7);
    public static readonly LegacySoundStyle NPCHit8 = new LegacySoundStyle(3, 8);
    public static readonly LegacySoundStyle NPCHit9 = new LegacySoundStyle(3, 9);
    public static readonly LegacySoundStyle NPCHit10 = new LegacySoundStyle(3, 10);
    public static readonly LegacySoundStyle NPCHit11 = new LegacySoundStyle(3, 11);
    public static readonly LegacySoundStyle NPCHit12 = new LegacySoundStyle(3, 12);
    public static readonly LegacySoundStyle NPCHit13 = new LegacySoundStyle(3, 13);
    public static readonly LegacySoundStyle NPCHit14 = new LegacySoundStyle(3, 14);
    public static readonly LegacySoundStyle NPCHit15 = new LegacySoundStyle(3, 15);
    public static readonly LegacySoundStyle NPCHit16 = new LegacySoundStyle(3, 16);
    public static readonly LegacySoundStyle NPCHit17 = new LegacySoundStyle(3, 17);
    public static readonly LegacySoundStyle NPCHit18 = new LegacySoundStyle(3, 18);
    public static readonly LegacySoundStyle NPCHit19 = new LegacySoundStyle(3, 19);
    public static readonly LegacySoundStyle NPCHit20 = new LegacySoundStyle(3, 20);
    public static readonly LegacySoundStyle NPCHit21 = new LegacySoundStyle(3, 21);
    public static readonly LegacySoundStyle NPCHit22 = new LegacySoundStyle(3, 22);
    public static readonly LegacySoundStyle NPCHit23 = new LegacySoundStyle(3, 23);
    public static readonly LegacySoundStyle NPCHit24 = new LegacySoundStyle(3, 24);
    public static readonly LegacySoundStyle NPCHit25 = new LegacySoundStyle(3, 25);
    public static readonly LegacySoundStyle NPCHit26 = new LegacySoundStyle(3, 26);
    public static readonly LegacySoundStyle NPCHit27 = new LegacySoundStyle(3, 27);
    public static readonly LegacySoundStyle NPCHit28 = new LegacySoundStyle(3, 28);
    public static readonly LegacySoundStyle NPCHit29 = new LegacySoundStyle(3, 29);
    public static readonly LegacySoundStyle NPCHit30 = new LegacySoundStyle(3, 30);
    public static readonly LegacySoundStyle NPCHit31 = new LegacySoundStyle(3, 31);
    public static readonly LegacySoundStyle NPCHit32 = new LegacySoundStyle(3, 32);
    public static readonly LegacySoundStyle NPCHit33 = new LegacySoundStyle(3, 33);
    public static readonly LegacySoundStyle NPCHit34 = new LegacySoundStyle(3, 34);
    public static readonly LegacySoundStyle NPCHit35 = new LegacySoundStyle(3, 35);
    public static readonly LegacySoundStyle NPCHit36 = new LegacySoundStyle(3, 36);
    public static readonly LegacySoundStyle NPCHit37 = new LegacySoundStyle(3, 37);
    public static readonly LegacySoundStyle NPCHit38 = new LegacySoundStyle(3, 38);
    public static readonly LegacySoundStyle NPCHit39 = new LegacySoundStyle(3, 39);
    public static readonly LegacySoundStyle NPCHit40 = new LegacySoundStyle(3, 40);
    public static readonly LegacySoundStyle NPCHit41 = new LegacySoundStyle(3, 41);
    public static readonly LegacySoundStyle NPCHit42 = new LegacySoundStyle(3, 42);
    public static readonly LegacySoundStyle NPCHit43 = new LegacySoundStyle(3, 43);
    public static readonly LegacySoundStyle NPCHit44 = new LegacySoundStyle(3, 44);
    public static readonly LegacySoundStyle NPCHit45 = new LegacySoundStyle(3, 45);
    public static readonly LegacySoundStyle NPCHit46 = new LegacySoundStyle(3, 46);
    public static readonly LegacySoundStyle NPCHit47 = new LegacySoundStyle(3, 47);
    public static readonly LegacySoundStyle NPCHit48 = new LegacySoundStyle(3, 48);
    public static readonly LegacySoundStyle NPCHit49 = new LegacySoundStyle(3, 49);
    public static readonly LegacySoundStyle NPCHit50 = new LegacySoundStyle(3, 50);
    public static readonly LegacySoundStyle NPCHit51 = new LegacySoundStyle(3, 51);
    public static readonly LegacySoundStyle NPCHit52 = new LegacySoundStyle(3, 52);
    public static readonly LegacySoundStyle NPCHit53 = new LegacySoundStyle(3, 53);
    public static readonly LegacySoundStyle NPCHit54 = new LegacySoundStyle(3, 54);
    public static readonly LegacySoundStyle NPCHit55 = new LegacySoundStyle(3, 55);
    public static readonly LegacySoundStyle NPCHit56 = new LegacySoundStyle(3, 56);
    public static readonly LegacySoundStyle NPCHit57 = new LegacySoundStyle(3, 57);
    public static readonly LegacySoundStyle NPCDeath1 = new LegacySoundStyle(4, 1);
    public static readonly LegacySoundStyle NPCDeath2 = new LegacySoundStyle(4, 2);
    public static readonly LegacySoundStyle NPCDeath3 = new LegacySoundStyle(4, 3);
    public static readonly LegacySoundStyle NPCDeath4 = new LegacySoundStyle(4, 4);
    public static readonly LegacySoundStyle NPCDeath5 = new LegacySoundStyle(4, 5);
    public static readonly LegacySoundStyle NPCDeath6 = new LegacySoundStyle(4, 6);
    public static readonly LegacySoundStyle NPCDeath7 = new LegacySoundStyle(4, 7);
    public static readonly LegacySoundStyle NPCDeath8 = new LegacySoundStyle(4, 8);
    public static readonly LegacySoundStyle NPCDeath9 = new LegacySoundStyle(4, 9);
    public static readonly LegacySoundStyle NPCDeath10 = new LegacySoundStyle(4, 10);
    public static readonly LegacySoundStyle NPCDeath11 = new LegacySoundStyle(4, 11);
    public static readonly LegacySoundStyle NPCDeath12 = new LegacySoundStyle(4, 12);
    public static readonly LegacySoundStyle NPCDeath13 = new LegacySoundStyle(4, 13);
    public static readonly LegacySoundStyle NPCDeath14 = new LegacySoundStyle(4, 14);
    public static readonly LegacySoundStyle NPCDeath15 = new LegacySoundStyle(4, 15);
    public static readonly LegacySoundStyle NPCDeath16 = new LegacySoundStyle(4, 16);
    public static readonly LegacySoundStyle NPCDeath17 = new LegacySoundStyle(4, 17);
    public static readonly LegacySoundStyle NPCDeath18 = new LegacySoundStyle(4, 18);
    public static readonly LegacySoundStyle NPCDeath19 = new LegacySoundStyle(4, 19);
    public static readonly LegacySoundStyle NPCDeath20 = new LegacySoundStyle(4, 20);
    public static readonly LegacySoundStyle NPCDeath21 = new LegacySoundStyle(4, 21);
    public static readonly LegacySoundStyle NPCDeath22 = new LegacySoundStyle(4, 22);
    public static readonly LegacySoundStyle NPCDeath23 = new LegacySoundStyle(4, 23);
    public static readonly LegacySoundStyle NPCDeath24 = new LegacySoundStyle(4, 24);
    public static readonly LegacySoundStyle NPCDeath25 = new LegacySoundStyle(4, 25);
    public static readonly LegacySoundStyle NPCDeath26 = new LegacySoundStyle(4, 26);
    public static readonly LegacySoundStyle NPCDeath27 = new LegacySoundStyle(4, 27);
    public static readonly LegacySoundStyle NPCDeath28 = new LegacySoundStyle(4, 28);
    public static readonly LegacySoundStyle NPCDeath29 = new LegacySoundStyle(4, 29);
    public static readonly LegacySoundStyle NPCDeath30 = new LegacySoundStyle(4, 30);
    public static readonly LegacySoundStyle NPCDeath31 = new LegacySoundStyle(4, 31);
    public static readonly LegacySoundStyle NPCDeath32 = new LegacySoundStyle(4, 32);
    public static readonly LegacySoundStyle NPCDeath33 = new LegacySoundStyle(4, 33);
    public static readonly LegacySoundStyle NPCDeath34 = new LegacySoundStyle(4, 34);
    public static readonly LegacySoundStyle NPCDeath35 = new LegacySoundStyle(4, 35);
    public static readonly LegacySoundStyle NPCDeath36 = new LegacySoundStyle(4, 36);
    public static readonly LegacySoundStyle NPCDeath37 = new LegacySoundStyle(4, 37);
    public static readonly LegacySoundStyle NPCDeath38 = new LegacySoundStyle(4, 38);
    public static readonly LegacySoundStyle NPCDeath39 = new LegacySoundStyle(4, 39);
    public static readonly LegacySoundStyle NPCDeath40 = new LegacySoundStyle(4, 40);
    public static readonly LegacySoundStyle NPCDeath41 = new LegacySoundStyle(4, 41);
    public static readonly LegacySoundStyle NPCDeath42 = new LegacySoundStyle(4, 42);
    public static readonly LegacySoundStyle NPCDeath43 = new LegacySoundStyle(4, 43);
    public static readonly LegacySoundStyle NPCDeath44 = new LegacySoundStyle(4, 44);
    public static readonly LegacySoundStyle NPCDeath45 = new LegacySoundStyle(4, 45);
    public static readonly LegacySoundStyle NPCDeath46 = new LegacySoundStyle(4, 46);
    public static readonly LegacySoundStyle NPCDeath47 = new LegacySoundStyle(4, 47);
    public static readonly LegacySoundStyle NPCDeath48 = new LegacySoundStyle(4, 48);
    public static readonly LegacySoundStyle NPCDeath49 = new LegacySoundStyle(4, 49);
    public static readonly LegacySoundStyle NPCDeath50 = new LegacySoundStyle(4, 50);
    public static readonly LegacySoundStyle NPCDeath51 = new LegacySoundStyle(4, 51);
    public static readonly LegacySoundStyle NPCDeath52 = new LegacySoundStyle(4, 52);
    public static readonly LegacySoundStyle NPCDeath53 = new LegacySoundStyle(4, 53);
    public static readonly LegacySoundStyle NPCDeath54 = new LegacySoundStyle(4, 54);
    public static readonly LegacySoundStyle NPCDeath55 = new LegacySoundStyle(4, 55);
    public static readonly LegacySoundStyle NPCDeath56 = new LegacySoundStyle(4, 56);
    public static readonly LegacySoundStyle NPCDeath57 = new LegacySoundStyle(4, 57);
    public static readonly LegacySoundStyle NPCDeath58 = new LegacySoundStyle(4, 58);
    public static readonly LegacySoundStyle NPCDeath59 = new LegacySoundStyle(4, 59);
    public static readonly LegacySoundStyle NPCDeath60 = new LegacySoundStyle(4, 60);
    public static readonly LegacySoundStyle NPCDeath61 = new LegacySoundStyle(4, 61);
    public static readonly LegacySoundStyle NPCDeath62 = new LegacySoundStyle(4, 62);
    public static readonly LegacySoundStyle NPCDeath63 = new LegacySoundStyle(4, 63);
    public static readonly LegacySoundStyle NPCDeath64 = new LegacySoundStyle(4, 64);
    public static readonly LegacySoundStyle NPCDeath65 = new LegacySoundStyle(4, 65);
    public static short NPCDeathCount = 66;
    public static readonly LegacySoundStyle Item1 = new LegacySoundStyle(2, 1);
    public static readonly LegacySoundStyle Item2 = new LegacySoundStyle(2, 2);
    public static readonly LegacySoundStyle Item3 = new LegacySoundStyle(2, 3);
    public static readonly LegacySoundStyle Item4 = new LegacySoundStyle(2, 4);
    public static readonly LegacySoundStyle Item5 = new LegacySoundStyle(2, 5);
    public static readonly LegacySoundStyle Item6 = new LegacySoundStyle(2, 6);
    public static readonly LegacySoundStyle Item7 = new LegacySoundStyle(2, 7);
    public static readonly LegacySoundStyle Item8 = new LegacySoundStyle(2, 8);
    public static readonly LegacySoundStyle Item9 = new LegacySoundStyle(2, 9);
    public static readonly LegacySoundStyle Item10 = new LegacySoundStyle(2, 10);
    public static readonly LegacySoundStyle Item11 = new LegacySoundStyle(2, 11);
    public static readonly LegacySoundStyle Item12 = new LegacySoundStyle(2, 12);
    public static readonly LegacySoundStyle Item13 = new LegacySoundStyle(2, 13);
    public static readonly LegacySoundStyle Item14 = new LegacySoundStyle(2, 14);
    public static readonly LegacySoundStyle Item15 = new LegacySoundStyle(2, 15);
    public static readonly LegacySoundStyle Item16 = new LegacySoundStyle(2, 16);
    public static readonly LegacySoundStyle Item17 = new LegacySoundStyle(2, 17);
    public static readonly LegacySoundStyle Item18 = new LegacySoundStyle(2, 18);
    public static readonly LegacySoundStyle Item19 = new LegacySoundStyle(2, 19);
    public static readonly LegacySoundStyle Item20 = new LegacySoundStyle(2, 20);
    public static readonly LegacySoundStyle Item21 = new LegacySoundStyle(2, 21);
    public static readonly LegacySoundStyle Item22 = new LegacySoundStyle(2, 22);
    public static readonly LegacySoundStyle Item23 = new LegacySoundStyle(2, 23);
    public static readonly LegacySoundStyle Item24 = new LegacySoundStyle(2, 24);
    public static readonly LegacySoundStyle Item25 = new LegacySoundStyle(2, 25);
    public static readonly LegacySoundStyle Item26 = new LegacySoundStyle(2, 26);
    public static readonly LegacySoundStyle Item27 = new LegacySoundStyle(2, 27);
    public static readonly LegacySoundStyle Item28 = new LegacySoundStyle(2, 28);
    public static readonly LegacySoundStyle Item29 = new LegacySoundStyle(2, 29);
    public static readonly LegacySoundStyle Item30 = new LegacySoundStyle(2, 30);
    public static readonly LegacySoundStyle Item31 = new LegacySoundStyle(2, 31);
    public static readonly LegacySoundStyle Item32 = new LegacySoundStyle(2, 32);
    public static readonly LegacySoundStyle Item33 = new LegacySoundStyle(2, 33);
    public static readonly LegacySoundStyle Item34 = new LegacySoundStyle(2, 34);
    public static readonly LegacySoundStyle Item35 = new LegacySoundStyle(2, 35);
    public static readonly LegacySoundStyle Item36 = new LegacySoundStyle(2, 36);
    public static readonly LegacySoundStyle Item37 = new LegacySoundStyle(2, 37);
    public static readonly LegacySoundStyle Item38 = new LegacySoundStyle(2, 38);
    public static readonly LegacySoundStyle Item39 = new LegacySoundStyle(2, 39);
    public static readonly LegacySoundStyle Item40 = new LegacySoundStyle(2, 40);
    public static readonly LegacySoundStyle Item41 = new LegacySoundStyle(2, 41);
    public static readonly LegacySoundStyle Item42 = new LegacySoundStyle(2, 42);
    public static readonly LegacySoundStyle Item43 = new LegacySoundStyle(2, 43);
    public static readonly LegacySoundStyle Item44 = new LegacySoundStyle(2, 44);
    public static readonly LegacySoundStyle Item45 = new LegacySoundStyle(2, 45);
    public static readonly LegacySoundStyle Item46 = new LegacySoundStyle(2, 46);
    public static readonly LegacySoundStyle Item47 = new LegacySoundStyle(2, 47);
    public static readonly LegacySoundStyle Item48 = new LegacySoundStyle(2, 48);
    public static readonly LegacySoundStyle Item49 = new LegacySoundStyle(2, 49);
    public static readonly LegacySoundStyle Item50 = new LegacySoundStyle(2, 50);
    public static readonly LegacySoundStyle Item51 = new LegacySoundStyle(2, 51);
    public static readonly LegacySoundStyle Item52 = new LegacySoundStyle(2, 52);
    public static readonly LegacySoundStyle Item53 = new LegacySoundStyle(2, 53);
    public static readonly LegacySoundStyle Item54 = new LegacySoundStyle(2, 54);
    public static readonly LegacySoundStyle Item55 = new LegacySoundStyle(2, 55);
    public static readonly LegacySoundStyle Item56 = new LegacySoundStyle(2, 56);
    public static readonly LegacySoundStyle Item57 = new LegacySoundStyle(2, 57);
    public static readonly LegacySoundStyle Item58 = new LegacySoundStyle(2, 58);
    public static readonly LegacySoundStyle Item59 = new LegacySoundStyle(2, 59);
    public static readonly LegacySoundStyle Item60 = new LegacySoundStyle(2, 60);
    public static readonly LegacySoundStyle Item61 = new LegacySoundStyle(2, 61);
    public static readonly LegacySoundStyle Item62 = new LegacySoundStyle(2, 62);
    public static readonly LegacySoundStyle Item63 = new LegacySoundStyle(2, 63);
    public static readonly LegacySoundStyle Item64 = new LegacySoundStyle(2, 64);
    public static readonly LegacySoundStyle Item65 = new LegacySoundStyle(2, 65);
    public static readonly LegacySoundStyle Item66 = new LegacySoundStyle(2, 66);
    public static readonly LegacySoundStyle Item67 = new LegacySoundStyle(2, 67);
    public static readonly LegacySoundStyle Item68 = new LegacySoundStyle(2, 68);
    public static readonly LegacySoundStyle Item69 = new LegacySoundStyle(2, 69);
    public static readonly LegacySoundStyle Item70 = new LegacySoundStyle(2, 70);
    public static readonly LegacySoundStyle Item71 = new LegacySoundStyle(2, 71);
    public static readonly LegacySoundStyle Item72 = new LegacySoundStyle(2, 72);
    public static readonly LegacySoundStyle Item73 = new LegacySoundStyle(2, 73);
    public static readonly LegacySoundStyle Item74 = new LegacySoundStyle(2, 74);
    public static readonly LegacySoundStyle Item75 = new LegacySoundStyle(2, 75);
    public static readonly LegacySoundStyle Item76 = new LegacySoundStyle(2, 76);
    public static readonly LegacySoundStyle Item77 = new LegacySoundStyle(2, 77);
    public static readonly LegacySoundStyle Item78 = new LegacySoundStyle(2, 78);
    public static readonly LegacySoundStyle Item79 = new LegacySoundStyle(2, 79);
    public static readonly LegacySoundStyle Item80 = new LegacySoundStyle(2, 80);
    public static readonly LegacySoundStyle Item81 = new LegacySoundStyle(2, 81);
    public static readonly LegacySoundStyle Item82 = new LegacySoundStyle(2, 82);
    public static readonly LegacySoundStyle Item83 = new LegacySoundStyle(2, 83);
    public static readonly LegacySoundStyle Item84 = new LegacySoundStyle(2, 84);
    public static readonly LegacySoundStyle Item85 = new LegacySoundStyle(2, 85);
    public static readonly LegacySoundStyle Item86 = new LegacySoundStyle(2, 86);
    public static readonly LegacySoundStyle Item87 = new LegacySoundStyle(2, 87);
    public static readonly LegacySoundStyle Item88 = new LegacySoundStyle(2, 88);
    public static readonly LegacySoundStyle Item89 = new LegacySoundStyle(2, 89);
    public static readonly LegacySoundStyle Item90 = new LegacySoundStyle(2, 90);
    public static readonly LegacySoundStyle Item91 = new LegacySoundStyle(2, 91);
    public static readonly LegacySoundStyle Item92 = new LegacySoundStyle(2, 92);
    public static readonly LegacySoundStyle Item93 = new LegacySoundStyle(2, 93);
    public static readonly LegacySoundStyle Item94 = new LegacySoundStyle(2, 94);
    public static readonly LegacySoundStyle Item95 = new LegacySoundStyle(2, 95);
    public static readonly LegacySoundStyle Item96 = new LegacySoundStyle(2, 96);
    public static readonly LegacySoundStyle Item97 = new LegacySoundStyle(2, 97);
    public static readonly LegacySoundStyle Item98 = new LegacySoundStyle(2, 98);
    public static readonly LegacySoundStyle Item99 = new LegacySoundStyle(2, 99);
    public static readonly LegacySoundStyle Item100 = new LegacySoundStyle(2, 100);
    public static readonly LegacySoundStyle Item101 = new LegacySoundStyle(2, 101);
    public static readonly LegacySoundStyle Item102 = new LegacySoundStyle(2, 102);
    public static readonly LegacySoundStyle Item103 = new LegacySoundStyle(2, 103);
    public static readonly LegacySoundStyle Item104 = new LegacySoundStyle(2, 104);
    public static readonly LegacySoundStyle Item105 = new LegacySoundStyle(2, 105);
    public static readonly LegacySoundStyle Item106 = new LegacySoundStyle(2, 106);
    public static readonly LegacySoundStyle Item107 = new LegacySoundStyle(2, 107);
    public static readonly LegacySoundStyle Item108 = new LegacySoundStyle(2, 108);
    public static readonly LegacySoundStyle Item109 = new LegacySoundStyle(2, 109);
    public static readonly LegacySoundStyle Item110 = new LegacySoundStyle(2, 110);
    public static readonly LegacySoundStyle Item111 = new LegacySoundStyle(2, 111);
    public static readonly LegacySoundStyle Item112 = new LegacySoundStyle(2, 112);
    public static readonly LegacySoundStyle Item113 = new LegacySoundStyle(2, 113);
    public static readonly LegacySoundStyle Item114 = new LegacySoundStyle(2, 114);
    public static readonly LegacySoundStyle Item115 = new LegacySoundStyle(2, 115);
    public static readonly LegacySoundStyle Item116 = new LegacySoundStyle(2, 116);
    public static readonly LegacySoundStyle Item117 = new LegacySoundStyle(2, 117);
    public static readonly LegacySoundStyle Item118 = new LegacySoundStyle(2, 118);
    public static readonly LegacySoundStyle Item119 = new LegacySoundStyle(2, 119);
    public static readonly LegacySoundStyle Item120 = new LegacySoundStyle(2, 120);
    public static readonly LegacySoundStyle Item121 = new LegacySoundStyle(2, 121);
    public static readonly LegacySoundStyle Item122 = new LegacySoundStyle(2, 122);
    public static readonly LegacySoundStyle Item123 = new LegacySoundStyle(2, 123);
    public static readonly LegacySoundStyle Item124 = new LegacySoundStyle(2, 124);
    public static readonly LegacySoundStyle Item125 = new LegacySoundStyle(2, 125);
    public static readonly LegacySoundStyle Item126 = new LegacySoundStyle(2, 126);
    public static readonly LegacySoundStyle Item127 = new LegacySoundStyle(2, (int) sbyte.MaxValue);
    public static readonly LegacySoundStyle Item128 = new LegacySoundStyle(2, 128);
    public static readonly LegacySoundStyle Item129 = new LegacySoundStyle(2, 129);
    public static readonly LegacySoundStyle Item130 = new LegacySoundStyle(2, 130);
    public static readonly LegacySoundStyle Item131 = new LegacySoundStyle(2, 131);
    public static readonly LegacySoundStyle Item132 = new LegacySoundStyle(2, 132);
    public static readonly LegacySoundStyle Item133 = new LegacySoundStyle(2, 133);
    public static readonly LegacySoundStyle Item134 = new LegacySoundStyle(2, 134);
    public static readonly LegacySoundStyle Item135 = new LegacySoundStyle(2, 135);
    public static readonly LegacySoundStyle Item136 = new LegacySoundStyle(2, 136);
    public static readonly LegacySoundStyle Item137 = new LegacySoundStyle(2, 137);
    public static readonly LegacySoundStyle Item138 = new LegacySoundStyle(2, 138);
    public static readonly LegacySoundStyle Item139 = new LegacySoundStyle(2, 139);
    public static readonly LegacySoundStyle Item140 = new LegacySoundStyle(2, 140);
    public static readonly LegacySoundStyle Item141 = new LegacySoundStyle(2, 141);
    public static readonly LegacySoundStyle Item142 = new LegacySoundStyle(2, 142);
    public static readonly LegacySoundStyle Item143 = new LegacySoundStyle(2, 143);
    public static readonly LegacySoundStyle Item144 = new LegacySoundStyle(2, 144);
    public static readonly LegacySoundStyle Item145 = new LegacySoundStyle(2, 145);
    public static readonly LegacySoundStyle Item146 = new LegacySoundStyle(2, 146);
    public static readonly LegacySoundStyle Item147 = new LegacySoundStyle(2, 147);
    public static readonly LegacySoundStyle Item148 = new LegacySoundStyle(2, 148);
    public static readonly LegacySoundStyle Item149 = new LegacySoundStyle(2, 149);
    public static readonly LegacySoundStyle Item150 = new LegacySoundStyle(2, 150);
    public static readonly LegacySoundStyle Item151 = new LegacySoundStyle(2, 151);
    public static readonly LegacySoundStyle Item152 = new LegacySoundStyle(2, 152);
    public static readonly LegacySoundStyle Item153 = new LegacySoundStyle(2, 153);
    public static readonly LegacySoundStyle Item154 = new LegacySoundStyle(2, 154);
    public static readonly LegacySoundStyle Item155 = new LegacySoundStyle(2, 155);
    public static readonly LegacySoundStyle Item156 = new LegacySoundStyle(2, 156);
    public static readonly LegacySoundStyle Item157 = new LegacySoundStyle(2, 157);
    public static readonly LegacySoundStyle Item158 = new LegacySoundStyle(2, 158);
    public static readonly LegacySoundStyle Item159 = new LegacySoundStyle(2, 159);
    public static readonly LegacySoundStyle Item160 = new LegacySoundStyle(2, 160);
    public static readonly LegacySoundStyle Item161 = new LegacySoundStyle(2, 161);
    public static readonly LegacySoundStyle Item162 = new LegacySoundStyle(2, 162);
    public static readonly LegacySoundStyle Item163 = new LegacySoundStyle(2, 163);
    public static readonly LegacySoundStyle Item164 = new LegacySoundStyle(2, 164);
    public static readonly LegacySoundStyle Item165 = new LegacySoundStyle(2, 165);
    public static readonly LegacySoundStyle Item166 = new LegacySoundStyle(2, 166);
    public static readonly LegacySoundStyle Item167 = new LegacySoundStyle(2, 167);
    public static readonly LegacySoundStyle Item168 = new LegacySoundStyle(2, 168);
    public static readonly LegacySoundStyle Item169 = new LegacySoundStyle(2, 169);
    public static readonly LegacySoundStyle Item170 = new LegacySoundStyle(2, 170);
    public static readonly LegacySoundStyle Item171 = new LegacySoundStyle(2, 171);
    public static readonly LegacySoundStyle Item172 = new LegacySoundStyle(2, 172);
    public static short ItemSoundCount = 173;
    public static readonly LegacySoundStyle DD2_GoblinBomb = new LegacySoundStyle(2, 14).WithVolume(0.5f);
    public static readonly LegacySoundStyle AchievementComplete = SoundID.CreateTrackable("achievement_complete");
    public static readonly LegacySoundStyle BlizzardInsideBuildingLoop = SoundID.CreateTrackable("blizzard_inside_building_loop", SoundType.Ambient);
    public static readonly LegacySoundStyle BlizzardStrongLoop = SoundID.CreateTrackable("blizzard_strong_loop", SoundType.Ambient).WithVolume(0.5f);
    public static readonly LegacySoundStyle LiquidsHoneyWater = SoundID.CreateTrackable("liquids_honey_water", 3, SoundType.Ambient);
    public static readonly LegacySoundStyle LiquidsHoneyLava = SoundID.CreateTrackable("liquids_honey_lava", 3, SoundType.Ambient);
    public static readonly LegacySoundStyle LiquidsWaterLava = SoundID.CreateTrackable("liquids_water_lava", 3, SoundType.Ambient);
    public static readonly LegacySoundStyle DD2_BallistaTowerShot = SoundID.CreateTrackable("dd2_ballista_tower_shot", 3);
    public static readonly LegacySoundStyle DD2_ExplosiveTrapExplode = SoundID.CreateTrackable("dd2_explosive_trap_explode", 3);
    public static readonly LegacySoundStyle DD2_FlameburstTowerShot = SoundID.CreateTrackable("dd2_flameburst_tower_shot", 3);
    public static readonly LegacySoundStyle DD2_LightningAuraZap = SoundID.CreateTrackable("dd2_lightning_aura_zap", 4);
    public static readonly LegacySoundStyle DD2_DefenseTowerSpawn = SoundID.CreateTrackable("dd2_defense_tower_spawn");
    public static readonly LegacySoundStyle DD2_BetsyDeath = SoundID.CreateTrackable("dd2_betsy_death", 3);
    public static readonly LegacySoundStyle DD2_BetsyFireballShot = SoundID.CreateTrackable("dd2_betsy_fireball_shot", 3);
    public static readonly LegacySoundStyle DD2_BetsyFireballImpact = SoundID.CreateTrackable("dd2_betsy_fireball_impact", 3);
    public static readonly LegacySoundStyle DD2_BetsyFlameBreath = SoundID.CreateTrackable("dd2_betsy_flame_breath");
    public static readonly LegacySoundStyle DD2_BetsyFlyingCircleAttack = SoundID.CreateTrackable("dd2_betsy_flying_circle_attack");
    public static readonly LegacySoundStyle DD2_BetsyHurt = SoundID.CreateTrackable("dd2_betsy_hurt", 3);
    public static readonly LegacySoundStyle DD2_BetsyScream = SoundID.CreateTrackable("dd2_betsy_scream");
    public static readonly LegacySoundStyle DD2_BetsySummon = SoundID.CreateTrackable("dd2_betsy_summon", 3);
    public static readonly LegacySoundStyle DD2_BetsyWindAttack = SoundID.CreateTrackable("dd2_betsy_wind_attack", 3);
    public static readonly LegacySoundStyle DD2_DarkMageAttack = SoundID.CreateTrackable("dd2_dark_mage_attack", 3);
    public static readonly LegacySoundStyle DD2_DarkMageCastHeal = SoundID.CreateTrackable("dd2_dark_mage_cast_heal", 3);
    public static readonly LegacySoundStyle DD2_DarkMageDeath = SoundID.CreateTrackable("dd2_dark_mage_death", 3);
    public static readonly LegacySoundStyle DD2_DarkMageHealImpact = SoundID.CreateTrackable("dd2_dark_mage_heal_impact", 3);
    public static readonly LegacySoundStyle DD2_DarkMageHurt = SoundID.CreateTrackable("dd2_dark_mage_hurt", 3);
    public static readonly LegacySoundStyle DD2_DarkMageSummonSkeleton = SoundID.CreateTrackable("dd2_dark_mage_summon_skeleton", 3);
    public static readonly LegacySoundStyle DD2_DrakinBreathIn = SoundID.CreateTrackable("dd2_drakin_breath_in", 3);
    public static readonly LegacySoundStyle DD2_DrakinDeath = SoundID.CreateTrackable("dd2_drakin_death", 3);
    public static readonly LegacySoundStyle DD2_DrakinHurt = SoundID.CreateTrackable("dd2_drakin_hurt", 3);
    public static readonly LegacySoundStyle DD2_DrakinShot = SoundID.CreateTrackable("dd2_drakin_shot", 3);
    public static readonly LegacySoundStyle DD2_GoblinDeath = SoundID.CreateTrackable("dd2_goblin_death", 3);
    public static readonly LegacySoundStyle DD2_GoblinHurt = SoundID.CreateTrackable("dd2_goblin_hurt", 6);
    public static readonly LegacySoundStyle DD2_GoblinScream = SoundID.CreateTrackable("dd2_goblin_scream", 3);
    public static readonly LegacySoundStyle DD2_GoblinBomberDeath = SoundID.CreateTrackable("dd2_goblin_bomber_death", 3);
    public static readonly LegacySoundStyle DD2_GoblinBomberHurt = SoundID.CreateTrackable("dd2_goblin_bomber_hurt", 3);
    public static readonly LegacySoundStyle DD2_GoblinBomberScream = SoundID.CreateTrackable("dd2_goblin_bomber_scream", 3);
    public static readonly LegacySoundStyle DD2_GoblinBomberThrow = SoundID.CreateTrackable("dd2_goblin_bomber_throw", 3);
    public static readonly LegacySoundStyle DD2_JavelinThrowersAttack = SoundID.CreateTrackable("dd2_javelin_throwers_attack", 3);
    public static readonly LegacySoundStyle DD2_JavelinThrowersDeath = SoundID.CreateTrackable("dd2_javelin_throwers_death", 3);
    public static readonly LegacySoundStyle DD2_JavelinThrowersHurt = SoundID.CreateTrackable("dd2_javelin_throwers_hurt", 3);
    public static readonly LegacySoundStyle DD2_JavelinThrowersTaunt = SoundID.CreateTrackable("dd2_javelin_throwers_taunt", 3);
    public static readonly LegacySoundStyle DD2_KoboldDeath = SoundID.CreateTrackable("dd2_kobold_death", 3);
    public static readonly LegacySoundStyle DD2_KoboldExplosion = SoundID.CreateTrackable("dd2_kobold_explosion", 3);
    public static readonly LegacySoundStyle DD2_KoboldHurt = SoundID.CreateTrackable("dd2_kobold_hurt", 3);
    public static readonly LegacySoundStyle DD2_KoboldIgnite = SoundID.CreateTrackable("dd2_kobold_ignite");
    public static readonly LegacySoundStyle DD2_KoboldIgniteLoop = SoundID.CreateTrackable("dd2_kobold_ignite_loop");
    public static readonly LegacySoundStyle DD2_KoboldScreamChargeLoop = SoundID.CreateTrackable("dd2_kobold_scream_charge_loop");
    public static readonly LegacySoundStyle DD2_KoboldFlyerChargeScream = SoundID.CreateTrackable("dd2_kobold_flyer_charge_scream", 3);
    public static readonly LegacySoundStyle DD2_KoboldFlyerDeath = SoundID.CreateTrackable("dd2_kobold_flyer_death", 3);
    public static readonly LegacySoundStyle DD2_KoboldFlyerHurt = SoundID.CreateTrackable("dd2_kobold_flyer_hurt", 3);
    public static readonly LegacySoundStyle DD2_LightningBugDeath = SoundID.CreateTrackable("dd2_lightning_bug_death", 3);
    public static readonly LegacySoundStyle DD2_LightningBugHurt = SoundID.CreateTrackable("dd2_lightning_bug_hurt", 3);
    public static readonly LegacySoundStyle DD2_LightningBugZap = SoundID.CreateTrackable("dd2_lightning_bug_zap", 3);
    public static readonly LegacySoundStyle DD2_OgreAttack = SoundID.CreateTrackable("dd2_ogre_attack", 3);
    public static readonly LegacySoundStyle DD2_OgreDeath = SoundID.CreateTrackable("dd2_ogre_death", 3);
    public static readonly LegacySoundStyle DD2_OgreGroundPound = SoundID.CreateTrackable("dd2_ogre_ground_pound");
    public static readonly LegacySoundStyle DD2_OgreHurt = SoundID.CreateTrackable("dd2_ogre_hurt", 3);
    public static readonly LegacySoundStyle DD2_OgreRoar = SoundID.CreateTrackable("dd2_ogre_roar", 3);
    public static readonly LegacySoundStyle DD2_OgreSpit = SoundID.CreateTrackable("dd2_ogre_spit");
    public static readonly LegacySoundStyle DD2_SkeletonDeath = SoundID.CreateTrackable("dd2_skeleton_death", 3);
    public static readonly LegacySoundStyle DD2_SkeletonHurt = SoundID.CreateTrackable("dd2_skeleton_hurt", 3);
    public static readonly LegacySoundStyle DD2_SkeletonSummoned = SoundID.CreateTrackable("dd2_skeleton_summoned");
    public static readonly LegacySoundStyle DD2_WitherBeastAuraPulse = SoundID.CreateTrackable("dd2_wither_beast_aura_pulse", 2);
    public static readonly LegacySoundStyle DD2_WitherBeastCrystalImpact = SoundID.CreateTrackable("dd2_wither_beast_crystal_impact", 3);
    public static readonly LegacySoundStyle DD2_WitherBeastDeath = SoundID.CreateTrackable("dd2_wither_beast_death", 3);
    public static readonly LegacySoundStyle DD2_WitherBeastHurt = SoundID.CreateTrackable("dd2_wither_beast_hurt", 3);
    public static readonly LegacySoundStyle DD2_WyvernDeath = SoundID.CreateTrackable("dd2_wyvern_death", 3);
    public static readonly LegacySoundStyle DD2_WyvernHurt = SoundID.CreateTrackable("dd2_wyvern_hurt", 3);
    public static readonly LegacySoundStyle DD2_WyvernScream = SoundID.CreateTrackable("dd2_wyvern_scream", 3);
    public static readonly LegacySoundStyle DD2_WyvernDiveDown = SoundID.CreateTrackable("dd2_wyvern_dive_down", 3);
    public static readonly LegacySoundStyle DD2_EtherianPortalDryadTouch = SoundID.CreateTrackable("dd2_etherian_portal_dryad_touch");
    public static readonly LegacySoundStyle DD2_EtherianPortalIdleLoop = SoundID.CreateTrackable("dd2_etherian_portal_idle_loop");
    public static readonly LegacySoundStyle DD2_EtherianPortalOpen = SoundID.CreateTrackable("dd2_etherian_portal_open");
    public static readonly LegacySoundStyle DD2_EtherianPortalSpawnEnemy = SoundID.CreateTrackable("dd2_etherian_portal_spawn_enemy", 3);
    public static readonly LegacySoundStyle DD2_CrystalCartImpact = SoundID.CreateTrackable("dd2_crystal_cart_impact", 3);
    public static readonly LegacySoundStyle DD2_DefeatScene = SoundID.CreateTrackable("dd2_defeat_scene");
    public static readonly LegacySoundStyle DD2_WinScene = SoundID.CreateTrackable("dd2_win_scene");
    public static readonly LegacySoundStyle DD2_BetsysWrathShot = SoundID.DD2_BetsyFireballShot.WithVolume(0.4f);
    public static readonly LegacySoundStyle DD2_BetsysWrathImpact = SoundID.DD2_BetsyFireballImpact.WithVolume(0.4f);
    public static readonly LegacySoundStyle DD2_BookStaffCast = SoundID.CreateTrackable("dd2_book_staff_cast", 3);
    public static readonly LegacySoundStyle DD2_BookStaffTwisterLoop = SoundID.CreateTrackable("dd2_book_staff_twister_loop");
    public static readonly LegacySoundStyle DD2_GhastlyGlaiveImpactGhost = SoundID.CreateTrackable("dd2_ghastly_glaive_impact_ghost", 3);
    public static readonly LegacySoundStyle DD2_GhastlyGlaivePierce = SoundID.CreateTrackable("dd2_ghastly_glaive_pierce", 3);
    public static readonly LegacySoundStyle DD2_MonkStaffGroundImpact = SoundID.CreateTrackable("dd2_monk_staff_ground_impact", 3);
    public static readonly LegacySoundStyle DD2_MonkStaffGroundMiss = SoundID.CreateTrackable("dd2_monk_staff_ground_miss", 3);
    public static readonly LegacySoundStyle DD2_MonkStaffSwing = SoundID.CreateTrackable("dd2_monk_staff_swing", 4);
    public static readonly LegacySoundStyle DD2_PhantomPhoenixShot = SoundID.CreateTrackable("dd2_phantom_phoenix_shot", 3);
    public static readonly LegacySoundStyle DD2_SonicBoomBladeSlash = SoundID.CreateTrackable("dd2_sonic_boom_blade_slash", 3, SoundID.ItemDefaults).WithVolume(0.5f);
    public static readonly LegacySoundStyle DD2_SkyDragonsFuryCircle = SoundID.CreateTrackable("dd2_sky_dragons_fury_circle", 3);
    public static readonly LegacySoundStyle DD2_SkyDragonsFuryShot = SoundID.CreateTrackable("dd2_sky_dragons_fury_shot", 3);
    public static readonly LegacySoundStyle DD2_SkyDragonsFurySwing = SoundID.CreateTrackable("dd2_sky_dragons_fury_swing", 4);
    private static List<string> _trackableLegacySoundPathList;
    public static Dictionary<string, LegacySoundStyle> SoundByName = (Dictionary<string, LegacySoundStyle>) null;
    public static Dictionary<string, ushort> IndexByName = (Dictionary<string, ushort>) null;
    public static Dictionary<ushort, LegacySoundStyle> SoundByIndex = (Dictionary<ushort, LegacySoundStyle>) null;

    public static int TrackableLegacySoundCount => SoundID._trackableLegacySoundPathList.Count;

    public static string GetTrackableLegacySoundPath(int id) => SoundID._trackableLegacySoundPathList[id];

    private static LegacySoundStyle CreateTrackable(
      string name,
      SoundID.SoundStyleDefaults defaults)
    {
      return SoundID.CreateTrackable(name, 1, defaults.Type).WithPitchVariance(defaults.PitchVariance).WithVolume(defaults.Volume);
    }

    private static LegacySoundStyle CreateTrackable(
      string name,
      int variations,
      SoundID.SoundStyleDefaults defaults)
    {
      return SoundID.CreateTrackable(name, variations, defaults.Type).WithPitchVariance(defaults.PitchVariance).WithVolume(defaults.Volume);
    }

    private static LegacySoundStyle CreateTrackable(string name, SoundType type = SoundType.Sound) => SoundID.CreateTrackable(name, 1, type);

    private static LegacySoundStyle CreateTrackable(
      string name,
      int variations,
      SoundType type = SoundType.Sound)
    {
      if (SoundID._trackableLegacySoundPathList == null)
        SoundID._trackableLegacySoundPathList = new List<string>();
      int count = SoundID._trackableLegacySoundPathList.Count;
      if (variations == 1)
      {
        SoundID._trackableLegacySoundPathList.Add(name);
      }
      else
      {
        for (int index = 0; index < variations; ++index)
          SoundID._trackableLegacySoundPathList.Add(name + "_" + (object) index);
      }
      return new LegacySoundStyle(42, count, variations, type);
    }

    public static void FillAccessMap()
    {
      Dictionary<string, LegacySoundStyle> ret = new Dictionary<string, LegacySoundStyle>();
      Dictionary<string, ushort> ret2 = new Dictionary<string, ushort>();
      Dictionary<ushort, LegacySoundStyle> ret3 = new Dictionary<ushort, LegacySoundStyle>();
      ushort nextIndex = 0;
      List<FieldInfo> list = ((IEnumerable<FieldInfo>) typeof (SoundID).GetFields(BindingFlags.Static | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (f => f.FieldType == typeof (LegacySoundStyle))).ToList<FieldInfo>();
      list.Sort((Comparison<FieldInfo>) ((a, b) => string.Compare(a.Name, b.Name)));
      list.ForEach((Action<FieldInfo>) (field =>
      {
        ret[field.Name] = (LegacySoundStyle) field.GetValue((object) null);
        ret2[field.Name] = nextIndex;
        ret3[nextIndex] = (LegacySoundStyle) field.GetValue((object) null);
        ++nextIndex;
      }));
      SoundID.SoundByName = ret;
      SoundID.IndexByName = ret2;
      SoundID.SoundByIndex = ret3;
    }

    private struct SoundStyleDefaults
    {
      public readonly float PitchVariance;
      public readonly float Volume;
      public readonly SoundType Type;

      public SoundStyleDefaults(float volume, float pitchVariance, SoundType type = SoundType.Sound)
      {
        this.PitchVariance = pitchVariance;
        this.Volume = volume;
        this.Type = type;
      }
    }
  }
}
