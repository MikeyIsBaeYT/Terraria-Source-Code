// Decompiled with JetBrains decompiler
// Type: Terraria.ID.NPCID
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Reflection;
using System.Collections.Generic;

namespace Terraria.ID
{
  public class NPCID
  {
    private static readonly int[] NetIdMap = new int[65]
    {
      81,
      81,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      6,
      6,
      31,
      31,
      77,
      42,
      42,
      176,
      176,
      176,
      176,
      173,
      173,
      183,
      183,
      3,
      3,
      132,
      132,
      186,
      186,
      187,
      187,
      188,
      188,
      189,
      189,
      190,
      191,
      192,
      193,
      194,
      2,
      200,
      200,
      21,
      21,
      201,
      201,
      202,
      202,
      203,
      203,
      223,
      223,
      231,
      231,
      232,
      232,
      233,
      233,
      234,
      234,
      235,
      235
    };
    private static readonly Dictionary<string, int> LegacyNameToIdMap = new Dictionary<string, int>()
    {
      {
        nameof (Slimeling),
        -1
      },
      {
        nameof (Slimer2),
        -2
      },
      {
        "Green Slime",
        -3
      },
      {
        nameof (Pinky),
        -4
      },
      {
        "Baby Slime",
        -5
      },
      {
        "Black Slime",
        -6
      },
      {
        "Purple Slime",
        -7
      },
      {
        "Red Slime",
        -8
      },
      {
        "Yellow Slime",
        -9
      },
      {
        "Jungle Slime",
        -10
      },
      {
        "Little Eater",
        -11
      },
      {
        "Big Eater",
        -12
      },
      {
        "Short Bones",
        -13
      },
      {
        "Big Boned",
        -14
      },
      {
        "Heavy Skeleton",
        -15
      },
      {
        "Little Stinger",
        -16
      },
      {
        "Big Stinger",
        -17
      },
      {
        "Tiny Moss Hornet",
        -18
      },
      {
        "Little Moss Hornet",
        -19
      },
      {
        "Big Moss Hornet",
        -20
      },
      {
        "Giant Moss Hornet",
        -21
      },
      {
        "Little Crimera",
        -22
      },
      {
        "Big Crimera",
        -23
      },
      {
        "Little Crimslime",
        -24
      },
      {
        "Big Crimslime",
        -25
      },
      {
        "Small Zombie",
        -26
      },
      {
        "Big Zombie",
        -27
      },
      {
        "Small Bald Zombie",
        -28
      },
      {
        "Big Bald Zombie",
        -29
      },
      {
        "Small Pincushion Zombie",
        -30
      },
      {
        "Big Pincushion Zombie",
        -31
      },
      {
        "Small Slimed Zombie",
        -32
      },
      {
        "Big Slimed Zombie",
        -33
      },
      {
        "Small Swamp Zombie",
        -34
      },
      {
        "Big Swamp Zombie",
        -35
      },
      {
        "Small Twiggy Zombie",
        -36
      },
      {
        "Big Twiggy Zombie",
        -37
      },
      {
        "Cataract Eye 2",
        -38
      },
      {
        "Sleepy Eye 2",
        -39
      },
      {
        "Dialated Eye 2",
        -40
      },
      {
        "Green Eye 2",
        -41
      },
      {
        "Purple Eye 2",
        -42
      },
      {
        "Demon Eye 2",
        -43
      },
      {
        "Small Female Zombie",
        -44
      },
      {
        "Big Female Zombie",
        -45
      },
      {
        "Small Skeleton",
        -46
      },
      {
        "Big Skeleton",
        -47
      },
      {
        "Small Headache Skeleton",
        -48
      },
      {
        "Big Headache Skeleton",
        -49
      },
      {
        "Small Misassembled Skeleton",
        -50
      },
      {
        "Big Misassembled Skeleton",
        -51
      },
      {
        "Small Pantless Skeleton",
        -52
      },
      {
        "Big Pantless Skeleton",
        -53
      },
      {
        "Small Rain Zombie",
        -54
      },
      {
        "Big Rain Zombie",
        -55
      },
      {
        "Little Hornet Fatty",
        -56
      },
      {
        "Big Hornet Fatty",
        -57
      },
      {
        "Little Hornet Honey",
        -58
      },
      {
        "Big Hornet Honey",
        -59
      },
      {
        "Little Hornet Leafy",
        -60
      },
      {
        "Big Hornet Leafy",
        -61
      },
      {
        "Little Hornet Spikey",
        -62
      },
      {
        "Big Hornet Spikey",
        -63
      },
      {
        "Little Hornet Stingy",
        -64
      },
      {
        "Big Hornet Stingy",
        -65
      },
      {
        "Blue Slime",
        1
      },
      {
        "Demon Eye",
        2
      },
      {
        nameof (Zombie),
        3
      },
      {
        "Eye of Cthulhu",
        4
      },
      {
        "Servant of Cthulhu",
        5
      },
      {
        "Eater of Souls",
        6
      },
      {
        "Devourer",
        7
      },
      {
        "Giant Worm",
        10
      },
      {
        "Eater of Worlds",
        13
      },
      {
        "Mother Slime",
        16
      },
      {
        nameof (Merchant),
        17
      },
      {
        nameof (Nurse),
        18
      },
      {
        "Arms Dealer",
        19
      },
      {
        nameof (Dryad),
        20
      },
      {
        nameof (Skeleton),
        21
      },
      {
        nameof (Guide),
        22
      },
      {
        "Meteor Head",
        23
      },
      {
        "Fire Imp",
        24
      },
      {
        "Burning Sphere",
        25
      },
      {
        "Goblin Peon",
        26
      },
      {
        "Goblin Thief",
        27
      },
      {
        "Goblin Warrior",
        28
      },
      {
        "Goblin Sorcerer",
        29
      },
      {
        "Chaos Ball",
        30
      },
      {
        "Angry Bones",
        31
      },
      {
        "Dark Caster",
        32
      },
      {
        "Water Sphere",
        33
      },
      {
        "Cursed Skull",
        34
      },
      {
        "Skeletron",
        35
      },
      {
        "Old Man",
        37
      },
      {
        nameof (Demolitionist),
        38
      },
      {
        "Bone Serpent",
        39
      },
      {
        nameof (Hornet),
        42
      },
      {
        "Man Eater",
        43
      },
      {
        "Undead Miner",
        44
      },
      {
        nameof (Tim),
        45
      },
      {
        nameof (Bunny),
        46
      },
      {
        "Corrupt Bunny",
        47
      },
      {
        nameof (Harpy),
        48
      },
      {
        "Cave Bat",
        49
      },
      {
        "King Slime",
        50
      },
      {
        "Jungle Bat",
        51
      },
      {
        "Doctor Bones",
        52
      },
      {
        "The Groom",
        53
      },
      {
        nameof (Clothier),
        54
      },
      {
        nameof (Goldfish),
        55
      },
      {
        nameof (Snatcher),
        56
      },
      {
        "Corrupt Goldfish",
        57
      },
      {
        nameof (Piranha),
        58
      },
      {
        "Lava Slime",
        59
      },
      {
        nameof (Hellbat),
        60
      },
      {
        nameof (Vulture),
        61
      },
      {
        nameof (Demon),
        62
      },
      {
        "Blue Jellyfish",
        63
      },
      {
        "Pink Jellyfish",
        64
      },
      {
        nameof (Shark),
        65
      },
      {
        "Voodoo Demon",
        66
      },
      {
        nameof (Crab),
        67
      },
      {
        "Dungeon Guardian",
        68
      },
      {
        nameof (Antlion),
        69
      },
      {
        "Spike Ball",
        70
      },
      {
        "Dungeon Slime",
        71
      },
      {
        "Blazing Wheel",
        72
      },
      {
        "Goblin Scout",
        73
      },
      {
        nameof (Bird),
        74
      },
      {
        nameof (Pixie),
        75
      },
      {
        "Armored Skeleton",
        77
      },
      {
        nameof (Mummy),
        78
      },
      {
        "Dark Mummy",
        79
      },
      {
        "Light Mummy",
        80
      },
      {
        "Corrupt Slime",
        81
      },
      {
        nameof (Wraith),
        82
      },
      {
        "Cursed Hammer",
        83
      },
      {
        "Enchanted Sword",
        84
      },
      {
        nameof (Mimic),
        85
      },
      {
        nameof (Unicorn),
        86
      },
      {
        "Wyvern",
        87
      },
      {
        "Giant Bat",
        93
      },
      {
        nameof (Corruptor),
        94
      },
      {
        "Digger",
        95
      },
      {
        "World Feeder",
        98
      },
      {
        nameof (Clinger),
        101
      },
      {
        "Angler Fish",
        102
      },
      {
        "Green Jellyfish",
        103
      },
      {
        nameof (Werewolf),
        104
      },
      {
        "Bound Goblin",
        105
      },
      {
        "Bound Wizard",
        106
      },
      {
        "Goblin Tinkerer",
        107
      },
      {
        nameof (Wizard),
        108
      },
      {
        nameof (Clown),
        109
      },
      {
        "Skeleton Archer",
        110
      },
      {
        "Goblin Archer",
        111
      },
      {
        "Vile Spit",
        112
      },
      {
        "Wall of Flesh",
        113
      },
      {
        "The Hungry",
        115
      },
      {
        "Leech",
        117
      },
      {
        "Chaos Elemental",
        120
      },
      {
        nameof (Slimer),
        121
      },
      {
        nameof (Gastropod),
        122
      },
      {
        "Bound Mechanic",
        123
      },
      {
        nameof (Mechanic),
        124
      },
      {
        nameof (Retinazer),
        125
      },
      {
        nameof (Spazmatism),
        126
      },
      {
        "Skeletron Prime",
        (int) sbyte.MaxValue
      },
      {
        "Prime Cannon",
        128
      },
      {
        "Prime Saw",
        129
      },
      {
        "Prime Vice",
        130
      },
      {
        "Prime Laser",
        131
      },
      {
        "Wandering Eye",
        133
      },
      {
        "The Destroyer",
        134
      },
      {
        "Illuminant Bat",
        137
      },
      {
        "Illuminant Slime",
        138
      },
      {
        nameof (Probe),
        139
      },
      {
        "Possessed Armor",
        140
      },
      {
        "Toxic Sludge",
        141
      },
      {
        "Santa Claus",
        142
      },
      {
        "Snowman Gangsta",
        143
      },
      {
        "Mister Stabby",
        144
      },
      {
        "Snow Balla",
        145
      },
      {
        "Ice Slime",
        147
      },
      {
        nameof (Penguin),
        148
      },
      {
        "Ice Bat",
        150
      },
      {
        "Lava Bat",
        151
      },
      {
        "Giant Flying Fox",
        152
      },
      {
        "Giant Tortoise",
        153
      },
      {
        "Ice Tortoise",
        154
      },
      {
        nameof (Wolf),
        155
      },
      {
        "Red Devil",
        156
      },
      {
        nameof (Arapaima),
        157
      },
      {
        nameof (Vampire),
        158
      },
      {
        nameof (Truffle),
        160
      },
      {
        "Zombie Eskimo",
        161
      },
      {
        nameof (Frankenstein),
        162
      },
      {
        "Black Recluse",
        163
      },
      {
        "Wall Creeper",
        164
      },
      {
        "Swamp Thing",
        166
      },
      {
        "Undead Viking",
        167
      },
      {
        "Corrupt Penguin",
        168
      },
      {
        "Ice Elemental",
        169
      },
      {
        "Pigron",
        170
      },
      {
        "Rune Wizard",
        172
      },
      {
        nameof (Crimera),
        173
      },
      {
        nameof (Herpling),
        174
      },
      {
        "Angry Trapper",
        175
      },
      {
        "Moss Hornet",
        176
      },
      {
        nameof (Derpling),
        177
      },
      {
        nameof (Steampunker),
        178
      },
      {
        "Crimson Axe",
        179
      },
      {
        "Face Monster",
        181
      },
      {
        "Floaty Gross",
        182
      },
      {
        nameof (Crimslime),
        183
      },
      {
        "Spiked Ice Slime",
        184
      },
      {
        "Snow Flinx",
        185
      },
      {
        "Lost Girl",
        195
      },
      {
        nameof (Nymph),
        196
      },
      {
        "Armored Viking",
        197
      },
      {
        nameof (Lihzahrd),
        198
      },
      {
        "Spiked Jungle Slime",
        204
      },
      {
        nameof (Moth),
        205
      },
      {
        "Icy Merman",
        206
      },
      {
        "Dye Trader",
        207
      },
      {
        "Party Girl",
        208
      },
      {
        nameof (Cyborg),
        209
      },
      {
        nameof (Bee),
        210
      },
      {
        "Pirate Deckhand",
        212
      },
      {
        "Pirate Corsair",
        213
      },
      {
        "Pirate Deadeye",
        214
      },
      {
        "Pirate Crossbower",
        215
      },
      {
        "Pirate Captain",
        216
      },
      {
        "Cochineal Beetle",
        217
      },
      {
        "Cyan Beetle",
        218
      },
      {
        "Lac Beetle",
        219
      },
      {
        "Sea Snail",
        220
      },
      {
        nameof (Squid),
        221
      },
      {
        "Queen Bee",
        222
      },
      {
        "Raincoat Zombie",
        223
      },
      {
        "Flying Fish",
        224
      },
      {
        "Umbrella Slime",
        225
      },
      {
        "Flying Snake",
        226
      },
      {
        nameof (Painter),
        227
      },
      {
        "Witch Doctor",
        228
      },
      {
        nameof (Pirate),
        229
      },
      {
        "Jungle Creeper",
        236
      },
      {
        "Blood Crawler",
        239
      },
      {
        "Blood Feeder",
        241
      },
      {
        "Blood Jelly",
        242
      },
      {
        "Ice Golem",
        243
      },
      {
        "Rainbow Slime",
        244
      },
      {
        nameof (Golem),
        245
      },
      {
        "Golem Head",
        246
      },
      {
        "Golem Fist",
        247
      },
      {
        "Angry Nimbus",
        250
      },
      {
        nameof (Eyezor),
        251
      },
      {
        nameof (Parrot),
        252
      },
      {
        nameof (Reaper),
        253
      },
      {
        "Spore Zombie",
        254
      },
      {
        "Fungo Fish",
        256
      },
      {
        "Anomura Fungus",
        257
      },
      {
        "Mushi Ladybug",
        258
      },
      {
        "Fungi Bulb",
        259
      },
      {
        "Giant Fungi Bulb",
        260
      },
      {
        "Fungi Spore",
        261
      },
      {
        nameof (Plantera),
        262
      },
      {
        "Plantera's Hook",
        263
      },
      {
        "Plantera's Tentacle",
        264
      },
      {
        nameof (Spore),
        265
      },
      {
        "Brain of Cthulhu",
        266
      },
      {
        nameof (Creeper),
        267
      },
      {
        "Ichor Sticker",
        268
      },
      {
        "Rusty Armored Bones",
        269
      },
      {
        "Blue Armored Bones",
        273
      },
      {
        "Hell Armored Bones",
        277
      },
      {
        "Ragged Caster",
        281
      },
      {
        nameof (Necromancer),
        283
      },
      {
        "Diabolist",
        285
      },
      {
        "Bone Lee",
        287
      },
      {
        "Dungeon Spirit",
        288
      },
      {
        "Giant Cursed Skull",
        289
      },
      {
        nameof (Paladin),
        290
      },
      {
        "Skeleton Sniper",
        291
      },
      {
        "Tactical Skeleton",
        292
      },
      {
        "Skeleton Commando",
        293
      },
      {
        "Blue Jay",
        297
      },
      {
        "Cardinal",
        298
      },
      {
        nameof (Squirrel),
        299
      },
      {
        nameof (Mouse),
        300
      },
      {
        nameof (Raven),
        301
      },
      {
        "Slime",
        302
      },
      {
        "Hoppin' Jack",
        304
      },
      {
        "Scarecrow",
        305
      },
      {
        "Headless Horseman",
        315
      },
      {
        nameof (Ghost),
        316
      },
      {
        "Mourning Wood",
        325
      },
      {
        nameof (Splinterling),
        326
      },
      {
        nameof (Pumpking),
        327
      },
      {
        nameof (Hellhound),
        329
      },
      {
        nameof (Poltergeist),
        330
      },
      {
        "Zombie Elf",
        338
      },
      {
        "Present Mimic",
        341
      },
      {
        "Gingerbread Man",
        342
      },
      {
        nameof (Yeti),
        343
      },
      {
        nameof (Everscream),
        344
      },
      {
        "Ice Queen",
        345
      },
      {
        "Santa",
        346
      },
      {
        "Elf Copter",
        347
      },
      {
        nameof (Nutcracker),
        348
      },
      {
        "Elf Archer",
        350
      },
      {
        nameof (Krampus),
        351
      },
      {
        nameof (Flocko),
        352
      },
      {
        nameof (Stylist),
        353
      },
      {
        "Webbed Stylist",
        354
      },
      {
        nameof (Firefly),
        355
      },
      {
        nameof (Butterfly),
        356
      },
      {
        nameof (Worm),
        357
      },
      {
        "Lightning Bug",
        358
      },
      {
        nameof (Snail),
        359
      },
      {
        "Glowing Snail",
        360
      },
      {
        nameof (Frog),
        361
      },
      {
        nameof (Duck),
        362
      },
      {
        nameof (Scorpion),
        366
      },
      {
        "Traveling Merchant",
        368
      },
      {
        nameof (Angler),
        369
      },
      {
        "Duke Fishron",
        370
      },
      {
        "Detonating Bubble",
        371
      },
      {
        nameof (Sharkron),
        372
      },
      {
        "Truffle Worm",
        374
      },
      {
        "Sleeping Angler",
        376
      },
      {
        nameof (Grasshopper),
        377
      },
      {
        "Chattering Teeth Bomb",
        378
      },
      {
        "Blue Cultist Archer",
        379
      },
      {
        "White Cultist Archer",
        380
      },
      {
        "Brain Scrambler",
        381
      },
      {
        "Ray Gunner",
        382
      },
      {
        "Martian Officer",
        383
      },
      {
        "Bubble Shield",
        384
      },
      {
        "Gray Grunt",
        385
      },
      {
        "Martian Engineer",
        386
      },
      {
        "Tesla Turret",
        387
      },
      {
        "Martian Drone",
        388
      },
      {
        "Gigazapper",
        389
      },
      {
        "Scutlix Gunner",
        390
      },
      {
        nameof (Scutlix),
        391
      },
      {
        "Martian Saucer",
        392
      },
      {
        "Martian Saucer Turret",
        393
      },
      {
        "Martian Saucer Cannon",
        394
      },
      {
        "Moon Lord",
        396
      },
      {
        "Moon Lord's Hand",
        397
      },
      {
        "Moon Lord's Core",
        398
      },
      {
        "Martian Probe",
        399
      },
      {
        "Milkyway Weaver",
        402
      },
      {
        "Star Cell",
        405
      },
      {
        "Flow Invader",
        407
      },
      {
        "Twinkle Popper",
        409
      },
      {
        "Twinkle",
        410
      },
      {
        "Stargazer",
        411
      },
      {
        "Crawltipede",
        412
      },
      {
        "Drakomire",
        415
      },
      {
        "Drakomire Rider",
        416
      },
      {
        "Sroller",
        417
      },
      {
        "Corite",
        418
      },
      {
        "Selenian",
        419
      },
      {
        "Nebula Floater",
        420
      },
      {
        "Brain Suckler",
        421
      },
      {
        "Vortex Pillar",
        422
      },
      {
        "Evolution Beast",
        423
      },
      {
        "Predictor",
        424
      },
      {
        "Storm Diver",
        425
      },
      {
        "Alien Queen",
        426
      },
      {
        "Alien Hornet",
        427
      },
      {
        "Alien Larva",
        428
      },
      {
        "Vortexian",
        429
      },
      {
        "Mysterious Tablet",
        437
      },
      {
        "Lunatic Devote",
        438
      },
      {
        "Lunatic Cultist",
        439
      },
      {
        "Tax Collector",
        441
      },
      {
        "Gold Bird",
        442
      },
      {
        "Gold Bunny",
        443
      },
      {
        "Gold Butterfly",
        444
      },
      {
        "Gold Frog",
        445
      },
      {
        "Gold Grasshopper",
        446
      },
      {
        "Gold Mouse",
        447
      },
      {
        "Gold Worm",
        448
      },
      {
        "Phantasm Dragon",
        454
      },
      {
        nameof (Butcher),
        460
      },
      {
        "Creature from the Deep",
        461
      },
      {
        nameof (Fritz),
        462
      },
      {
        nameof (Nailhead),
        463
      },
      {
        "Crimtane Bunny",
        464
      },
      {
        "Crimtane Goldfish",
        465
      },
      {
        nameof (Psycho),
        466
      },
      {
        "Deadly Sphere",
        467
      },
      {
        "Dr. Man Fly",
        468
      },
      {
        "The Possessed",
        469
      },
      {
        "Vicious Penguin",
        470
      },
      {
        "Goblin Summoner",
        471
      },
      {
        "Shadowflame Apparation",
        472
      },
      {
        "Corrupt Mimic",
        473
      },
      {
        "Crimson Mimic",
        474
      },
      {
        "Hallowed Mimic",
        475
      },
      {
        "Jungle Mimic",
        476
      },
      {
        nameof (Mothron),
        477
      },
      {
        "Mothron Egg",
        478
      },
      {
        "Baby Mothron",
        479
      },
      {
        nameof (Medusa),
        480
      },
      {
        "Hoplite",
        481
      },
      {
        "Granite Golem",
        482
      },
      {
        "Granite Elemental",
        483
      },
      {
        "Enchanted Nightcrawler",
        484
      },
      {
        nameof (Grubby),
        485
      },
      {
        nameof (Sluggy),
        486
      },
      {
        nameof (Buggy),
        487
      },
      {
        "Target Dummy",
        488
      },
      {
        "Blood Zombie",
        489
      },
      {
        nameof (Drippler),
        490
      },
      {
        "Stardust Pillar",
        493
      },
      {
        nameof (Crawdad),
        494
      },
      {
        "Giant Shelly",
        496
      },
      {
        nameof (Salamander),
        498
      },
      {
        "Nebula Pillar",
        507
      },
      {
        "Antlion Charger",
        508
      },
      {
        "Antlion Swarmer",
        509
      },
      {
        "Dune Splicer",
        510
      },
      {
        "Tomb Crawler",
        513
      },
      {
        "Solar Flare",
        516
      },
      {
        "Solar Pillar",
        517
      },
      {
        "Drakanian",
        518
      },
      {
        "Solar Fragment",
        519
      },
      {
        "Martian Walker",
        520
      },
      {
        "Ancient Vision",
        521
      },
      {
        "Ancient Light",
        522
      },
      {
        "Ancient Doom",
        523
      },
      {
        "Ghoul",
        524
      },
      {
        "Vile Ghoul",
        525
      },
      {
        "Tainted Ghoul",
        526
      },
      {
        "Dreamer Ghoul",
        527
      },
      {
        "Lamia",
        528
      },
      {
        "Sand Poacher",
        530
      },
      {
        "Basilisk",
        532
      },
      {
        "Desert Spirit",
        533
      },
      {
        "Tortured Soul",
        534
      },
      {
        "Spiked Slime",
        535
      },
      {
        "The Bride",
        536
      },
      {
        "Sand Slime",
        537
      },
      {
        "Red Squirrel",
        538
      },
      {
        "Gold Squirrel",
        539
      },
      {
        "Sand Elemental",
        541
      },
      {
        "Sand Shark",
        542
      },
      {
        "Bone Biter",
        543
      },
      {
        "Flesh Reaver",
        544
      },
      {
        "Crystal Thresher",
        545
      },
      {
        "Angry Tumbler",
        546
      },
      {
        "???",
        547
      },
      {
        "Eternia Crystal",
        548
      },
      {
        "Mysterious Portal",
        549
      },
      {
        "Tavernkeep",
        550
      },
      {
        "Betsy",
        551
      },
      {
        "Etherian Goblin",
        552
      },
      {
        "Etherian Goblin Bomber",
        555
      },
      {
        "Etherian Wyvern",
        558
      },
      {
        "Etherian Javelin Thrower",
        561
      },
      {
        "Dark Mage",
        564
      },
      {
        "Old One's Skeleton",
        566
      },
      {
        "Wither Beast",
        568
      },
      {
        "Drakin",
        570
      },
      {
        "Kobold",
        572
      },
      {
        "Kobold Glider",
        574
      },
      {
        "Ogre",
        576
      },
      {
        "Etherian Lightning Bug",
        578
      }
    };
    public static readonly IdDictionary Search = IdDictionary.Create<NPCID, short>();
    public const short NegativeIDCount = -66;
    public const short BigHornetStingy = -65;
    public const short LittleHornetStingy = -64;
    public const short BigHornetSpikey = -63;
    public const short LittleHornetSpikey = -62;
    public const short BigHornetLeafy = -61;
    public const short LittleHornetLeafy = -60;
    public const short BigHornetHoney = -59;
    public const short LittleHornetHoney = -58;
    public const short BigHornetFatty = -57;
    public const short LittleHornetFatty = -56;
    public const short BigRainZombie = -55;
    public const short SmallRainZombie = -54;
    public const short BigPantlessSkeleton = -53;
    public const short SmallPantlessSkeleton = -52;
    public const short BigMisassembledSkeleton = -51;
    public const short SmallMisassembledSkeleton = -50;
    public const short BigHeadacheSkeleton = -49;
    public const short SmallHeadacheSkeleton = -48;
    public const short BigSkeleton = -47;
    public const short SmallSkeleton = -46;
    public const short BigFemaleZombie = -45;
    public const short SmallFemaleZombie = -44;
    public const short DemonEye2 = -43;
    public const short PurpleEye2 = -42;
    public const short GreenEye2 = -41;
    public const short DialatedEye2 = -40;
    public const short SleepyEye2 = -39;
    public const short CataractEye2 = -38;
    public const short BigTwiggyZombie = -37;
    public const short SmallTwiggyZombie = -36;
    public const short BigSwampZombie = -35;
    public const short SmallSwampZombie = -34;
    public const short BigSlimedZombie = -33;
    public const short SmallSlimedZombie = -32;
    public const short BigPincushionZombie = -31;
    public const short SmallPincushionZombie = -30;
    public const short BigBaldZombie = -29;
    public const short SmallBaldZombie = -28;
    public const short BigZombie = -27;
    public const short SmallZombie = -26;
    public const short BigCrimslime = -25;
    public const short LittleCrimslime = -24;
    public const short BigCrimera = -23;
    public const short LittleCrimera = -22;
    public const short GiantMossHornet = -21;
    public const short BigMossHornet = -20;
    public const short LittleMossHornet = -19;
    public const short TinyMossHornet = -18;
    public const short BigStinger = -17;
    public const short LittleStinger = -16;
    public const short HeavySkeleton = -15;
    public const short BigBoned = -14;
    public const short ShortBones = -13;
    public const short BigEater = -12;
    public const short LittleEater = -11;
    public const short JungleSlime = -10;
    public const short YellowSlime = -9;
    public const short RedSlime = -8;
    public const short PurpleSlime = -7;
    public const short BlackSlime = -6;
    public const short BabySlime = -5;
    public const short Pinky = -4;
    public const short GreenSlime = -3;
    public const short Slimer2 = -2;
    public const short Slimeling = -1;
    public const short None = 0;
    public const short BlueSlime = 1;
    public const short DemonEye = 2;
    public const short Zombie = 3;
    public const short EyeofCthulhu = 4;
    public const short ServantofCthulhu = 5;
    public const short EaterofSouls = 6;
    public const short DevourerHead = 7;
    public const short DevourerBody = 8;
    public const short DevourerTail = 9;
    public const short GiantWormHead = 10;
    public const short GiantWormBody = 11;
    public const short GiantWormTail = 12;
    public const short EaterofWorldsHead = 13;
    public const short EaterofWorldsBody = 14;
    public const short EaterofWorldsTail = 15;
    public const short MotherSlime = 16;
    public const short Merchant = 17;
    public const short Nurse = 18;
    public const short ArmsDealer = 19;
    public const short Dryad = 20;
    public const short Skeleton = 21;
    public const short Guide = 22;
    public const short MeteorHead = 23;
    public const short FireImp = 24;
    public const short BurningSphere = 25;
    public const short GoblinPeon = 26;
    public const short GoblinThief = 27;
    public const short GoblinWarrior = 28;
    public const short GoblinSorcerer = 29;
    public const short ChaosBall = 30;
    public const short AngryBones = 31;
    public const short DarkCaster = 32;
    public const short WaterSphere = 33;
    public const short CursedSkull = 34;
    public const short SkeletronHead = 35;
    public const short SkeletronHand = 36;
    public const short OldMan = 37;
    public const short Demolitionist = 38;
    public const short BoneSerpentHead = 39;
    public const short BoneSerpentBody = 40;
    public const short BoneSerpentTail = 41;
    public const short Hornet = 42;
    public const short ManEater = 43;
    public const short UndeadMiner = 44;
    public const short Tim = 45;
    public const short Bunny = 46;
    public const short CorruptBunny = 47;
    public const short Harpy = 48;
    public const short CaveBat = 49;
    public const short KingSlime = 50;
    public const short JungleBat = 51;
    public const short DoctorBones = 52;
    public const short TheGroom = 53;
    public const short Clothier = 54;
    public const short Goldfish = 55;
    public const short Snatcher = 56;
    public const short CorruptGoldfish = 57;
    public const short Piranha = 58;
    public const short LavaSlime = 59;
    public const short Hellbat = 60;
    public const short Vulture = 61;
    public const short Demon = 62;
    public const short BlueJellyfish = 63;
    public const short PinkJellyfish = 64;
    public const short Shark = 65;
    public const short VoodooDemon = 66;
    public const short Crab = 67;
    public const short DungeonGuardian = 68;
    public const short Antlion = 69;
    public const short SpikeBall = 70;
    public const short DungeonSlime = 71;
    public const short BlazingWheel = 72;
    public const short GoblinScout = 73;
    public const short Bird = 74;
    public const short Pixie = 75;
    public const short None2 = 76;
    public const short ArmoredSkeleton = 77;
    public const short Mummy = 78;
    public const short DarkMummy = 79;
    public const short LightMummy = 80;
    public const short CorruptSlime = 81;
    public const short Wraith = 82;
    public const short CursedHammer = 83;
    public const short EnchantedSword = 84;
    public const short Mimic = 85;
    public const short Unicorn = 86;
    public const short WyvernHead = 87;
    public const short WyvernLegs = 88;
    public const short WyvernBody = 89;
    public const short WyvernBody2 = 90;
    public const short WyvernBody3 = 91;
    public const short WyvernTail = 92;
    public const short GiantBat = 93;
    public const short Corruptor = 94;
    public const short DiggerHead = 95;
    public const short DiggerBody = 96;
    public const short DiggerTail = 97;
    public const short SeekerHead = 98;
    public const short SeekerBody = 99;
    public const short SeekerTail = 100;
    public const short Clinger = 101;
    public const short AnglerFish = 102;
    public const short GreenJellyfish = 103;
    public const short Werewolf = 104;
    public const short BoundGoblin = 105;
    public const short BoundWizard = 106;
    public const short GoblinTinkerer = 107;
    public const short Wizard = 108;
    public const short Clown = 109;
    public const short SkeletonArcher = 110;
    public const short GoblinArcher = 111;
    public const short VileSpit = 112;
    public const short WallofFlesh = 113;
    public const short WallofFleshEye = 114;
    public const short TheHungry = 115;
    public const short TheHungryII = 116;
    public const short LeechHead = 117;
    public const short LeechBody = 118;
    public const short LeechTail = 119;
    public const short ChaosElemental = 120;
    public const short Slimer = 121;
    public const short Gastropod = 122;
    public const short BoundMechanic = 123;
    public const short Mechanic = 124;
    public const short Retinazer = 125;
    public const short Spazmatism = 126;
    public const short SkeletronPrime = 127;
    public const short PrimeCannon = 128;
    public const short PrimeSaw = 129;
    public const short PrimeVice = 130;
    public const short PrimeLaser = 131;
    public const short BaldZombie = 132;
    public const short WanderingEye = 133;
    public const short TheDestroyer = 134;
    public const short TheDestroyerBody = 135;
    public const short TheDestroyerTail = 136;
    public const short IlluminantBat = 137;
    public const short IlluminantSlime = 138;
    public const short Probe = 139;
    public const short PossessedArmor = 140;
    public const short ToxicSludge = 141;
    public const short SantaClaus = 142;
    public const short SnowmanGangsta = 143;
    public const short MisterStabby = 144;
    public const short SnowBalla = 145;
    public const short None3 = 146;
    public const short IceSlime = 147;
    public const short Penguin = 148;
    public const short PenguinBlack = 149;
    public const short IceBat = 150;
    public const short Lavabat = 151;
    public const short GiantFlyingFox = 152;
    public const short GiantTortoise = 153;
    public const short IceTortoise = 154;
    public const short Wolf = 155;
    public const short RedDevil = 156;
    public const short Arapaima = 157;
    public const short VampireBat = 158;
    public const short Vampire = 159;
    public const short Truffle = 160;
    public const short ZombieEskimo = 161;
    public const short Frankenstein = 162;
    public const short BlackRecluse = 163;
    public const short WallCreeper = 164;
    public const short WallCreeperWall = 165;
    public const short SwampThing = 166;
    public const short UndeadViking = 167;
    public const short CorruptPenguin = 168;
    public const short IceElemental = 169;
    public const short PigronCorruption = 170;
    public const short PigronHallow = 171;
    public const short RuneWizard = 172;
    public const short Crimera = 173;
    public const short Herpling = 174;
    public const short AngryTrapper = 175;
    public const short MossHornet = 176;
    public const short Derpling = 177;
    public const short Steampunker = 178;
    public const short CrimsonAxe = 179;
    public const short PigronCrimson = 180;
    public const short FaceMonster = 181;
    public const short FloatyGross = 182;
    public const short Crimslime = 183;
    public const short SpikedIceSlime = 184;
    public const short SnowFlinx = 185;
    public const short PincushionZombie = 186;
    public const short SlimedZombie = 187;
    public const short SwampZombie = 188;
    public const short TwiggyZombie = 189;
    public const short CataractEye = 190;
    public const short SleepyEye = 191;
    public const short DialatedEye = 192;
    public const short GreenEye = 193;
    public const short PurpleEye = 194;
    public const short LostGirl = 195;
    public const short Nymph = 196;
    public const short ArmoredViking = 197;
    public const short Lihzahrd = 198;
    public const short LihzahrdCrawler = 199;
    public const short FemaleZombie = 200;
    public const short HeadacheSkeleton = 201;
    public const short MisassembledSkeleton = 202;
    public const short PantlessSkeleton = 203;
    public const short SpikedJungleSlime = 204;
    public const short Moth = 205;
    public const short IcyMerman = 206;
    public const short DyeTrader = 207;
    public const short PartyGirl = 208;
    public const short Cyborg = 209;
    public const short Bee = 210;
    public const short BeeSmall = 211;
    public const short PirateDeckhand = 212;
    public const short PirateCorsair = 213;
    public const short PirateDeadeye = 214;
    public const short PirateCrossbower = 215;
    public const short PirateCaptain = 216;
    public const short CochinealBeetle = 217;
    public const short CyanBeetle = 218;
    public const short LacBeetle = 219;
    public const short SeaSnail = 220;
    public const short Squid = 221;
    public const short QueenBee = 222;
    public const short ZombieRaincoat = 223;
    public const short FlyingFish = 224;
    public const short UmbrellaSlime = 225;
    public const short FlyingSnake = 226;
    public const short Painter = 227;
    public const short WitchDoctor = 228;
    public const short Pirate = 229;
    public const short GoldfishWalker = 230;
    public const short HornetFatty = 231;
    public const short HornetHoney = 232;
    public const short HornetLeafy = 233;
    public const short HornetSpikey = 234;
    public const short HornetStingy = 235;
    public const short JungleCreeper = 236;
    public const short JungleCreeperWall = 237;
    public const short BlackRecluseWall = 238;
    public const short BloodCrawler = 239;
    public const short BloodCrawlerWall = 240;
    public const short BloodFeeder = 241;
    public const short BloodJelly = 242;
    public const short IceGolem = 243;
    public const short RainbowSlime = 244;
    public const short Golem = 245;
    public const short GolemHead = 246;
    public const short GolemFistLeft = 247;
    public const short GolemFistRight = 248;
    public const short GolemHeadFree = 249;
    public const short AngryNimbus = 250;
    public const short Eyezor = 251;
    public const short Parrot = 252;
    public const short Reaper = 253;
    public const short ZombieMushroom = 254;
    public const short ZombieMushroomHat = 255;
    public const short FungoFish = 256;
    public const short AnomuraFungus = 257;
    public const short MushiLadybug = 258;
    public const short FungiBulb = 259;
    public const short GiantFungiBulb = 260;
    public const short FungiSpore = 261;
    public const short Plantera = 262;
    public const short PlanterasHook = 263;
    public const short PlanterasTentacle = 264;
    public const short Spore = 265;
    public const short BrainofCthulhu = 266;
    public const short Creeper = 267;
    public const short IchorSticker = 268;
    public const short RustyArmoredBonesAxe = 269;
    public const short RustyArmoredBonesFlail = 270;
    public const short RustyArmoredBonesSword = 271;
    public const short RustyArmoredBonesSwordNoArmor = 272;
    public const short BlueArmoredBones = 273;
    public const short BlueArmoredBonesMace = 274;
    public const short BlueArmoredBonesNoPants = 275;
    public const short BlueArmoredBonesSword = 276;
    public const short HellArmoredBones = 277;
    public const short HellArmoredBonesSpikeShield = 278;
    public const short HellArmoredBonesMace = 279;
    public const short HellArmoredBonesSword = 280;
    public const short RaggedCaster = 281;
    public const short RaggedCasterOpenCoat = 282;
    public const short Necromancer = 283;
    public const short NecromancerArmored = 284;
    public const short DiabolistRed = 285;
    public const short DiabolistWhite = 286;
    public const short BoneLee = 287;
    public const short DungeonSpirit = 288;
    public const short GiantCursedSkull = 289;
    public const short Paladin = 290;
    public const short SkeletonSniper = 291;
    public const short TacticalSkeleton = 292;
    public const short SkeletonCommando = 293;
    public const short AngryBonesBig = 294;
    public const short AngryBonesBigMuscle = 295;
    public const short AngryBonesBigHelmet = 296;
    public const short BirdBlue = 297;
    public const short BirdRed = 298;
    public const short Squirrel = 299;
    public const short Mouse = 300;
    public const short Raven = 301;
    public const short SlimeMasked = 302;
    public const short BunnySlimed = 303;
    public const short HoppinJack = 304;
    public const short Scarecrow1 = 305;
    public const short Scarecrow2 = 306;
    public const short Scarecrow3 = 307;
    public const short Scarecrow4 = 308;
    public const short Scarecrow5 = 309;
    public const short Scarecrow6 = 310;
    public const short Scarecrow7 = 311;
    public const short Scarecrow8 = 312;
    public const short Scarecrow9 = 313;
    public const short Scarecrow10 = 314;
    public const short HeadlessHorseman = 315;
    public const short Ghost = 316;
    public const short DemonEyeOwl = 317;
    public const short DemonEyeSpaceship = 318;
    public const short ZombieDoctor = 319;
    public const short ZombieSuperman = 320;
    public const short ZombiePixie = 321;
    public const short SkeletonTopHat = 322;
    public const short SkeletonAstonaut = 323;
    public const short SkeletonAlien = 324;
    public const short MourningWood = 325;
    public const short Splinterling = 326;
    public const short Pumpking = 327;
    public const short PumpkingBlade = 328;
    public const short Hellhound = 329;
    public const short Poltergeist = 330;
    public const short ZombieXmas = 331;
    public const short ZombieSweater = 332;
    public const short SlimeRibbonWhite = 333;
    public const short SlimeRibbonYellow = 334;
    public const short SlimeRibbonGreen = 335;
    public const short SlimeRibbonRed = 336;
    public const short BunnyXmas = 337;
    public const short ZombieElf = 338;
    public const short ZombieElfBeard = 339;
    public const short ZombieElfGirl = 340;
    public const short PresentMimic = 341;
    public const short GingerbreadMan = 342;
    public const short Yeti = 343;
    public const short Everscream = 344;
    public const short IceQueen = 345;
    public const short SantaNK1 = 346;
    public const short ElfCopter = 347;
    public const short Nutcracker = 348;
    public const short NutcrackerSpinning = 349;
    public const short ElfArcher = 350;
    public const short Krampus = 351;
    public const short Flocko = 352;
    public const short Stylist = 353;
    public const short WebbedStylist = 354;
    public const short Firefly = 355;
    public const short Butterfly = 356;
    public const short Worm = 357;
    public const short LightningBug = 358;
    public const short Snail = 359;
    public const short GlowingSnail = 360;
    public const short Frog = 361;
    public const short Duck = 362;
    public const short Duck2 = 363;
    public const short DuckWhite = 364;
    public const short DuckWhite2 = 365;
    public const short ScorpionBlack = 366;
    public const short Scorpion = 367;
    public const short TravellingMerchant = 368;
    public const short Angler = 369;
    public const short DukeFishron = 370;
    public const short DetonatingBubble = 371;
    public const short Sharkron = 372;
    public const short Sharkron2 = 373;
    public const short TruffleWorm = 374;
    public const short TruffleWormDigger = 375;
    public const short SleepingAngler = 376;
    public const short Grasshopper = 377;
    public const short ChatteringTeethBomb = 378;
    public const short CultistArcherBlue = 379;
    public const short CultistArcherWhite = 380;
    public const short BrainScrambler = 381;
    public const short RayGunner = 382;
    public const short MartianOfficer = 383;
    public const short ForceBubble = 384;
    public const short GrayGrunt = 385;
    public const short MartianEngineer = 386;
    public const short MartianTurret = 387;
    public const short MartianDrone = 388;
    public const short GigaZapper = 389;
    public const short ScutlixRider = 390;
    public const short Scutlix = 391;
    public const short MartianSaucer = 392;
    public const short MartianSaucerTurret = 393;
    public const short MartianSaucerCannon = 394;
    public const short MartianSaucerCore = 395;
    public const short MoonLordHead = 396;
    public const short MoonLordHand = 397;
    public const short MoonLordCore = 398;
    public const short MartianProbe = 399;
    public const short MoonLordFreeEye = 400;
    public const short MoonLordLeechBlob = 401;
    public const short StardustWormHead = 402;
    public const short StardustWormBody = 403;
    public const short StardustWormTail = 404;
    public const short StardustCellBig = 405;
    public const short StardustCellSmall = 406;
    public const short StardustJellyfishBig = 407;
    public const short StardustJellyfishSmall = 408;
    public const short StardustSpiderBig = 409;
    public const short StardustSpiderSmall = 410;
    public const short StardustSoldier = 411;
    public const short SolarCrawltipedeHead = 412;
    public const short SolarCrawltipedeBody = 413;
    public const short SolarCrawltipedeTail = 414;
    public const short SolarDrakomire = 415;
    public const short SolarDrakomireRider = 416;
    public const short SolarSroller = 417;
    public const short SolarCorite = 418;
    public const short SolarSolenian = 419;
    public const short NebulaBrain = 420;
    public const short NebulaHeadcrab = 421;
    public const short NebulaBeast = 423;
    public const short NebulaSoldier = 424;
    public const short VortexRifleman = 425;
    public const short VortexHornetQueen = 426;
    public const short VortexHornet = 427;
    public const short VortexLarva = 428;
    public const short VortexSoldier = 429;
    public const short ArmedZombie = 430;
    public const short ArmedZombieEskimo = 431;
    public const short ArmedZombiePincussion = 432;
    public const short ArmedZombieSlimed = 433;
    public const short ArmedZombieSwamp = 434;
    public const short ArmedZombieTwiggy = 435;
    public const short ArmedZombieCenx = 436;
    public const short CultistTablet = 437;
    public const short CultistDevote = 438;
    public const short CultistBoss = 439;
    public const short CultistBossClone = 440;
    public const short GoldBird = 442;
    public const short GoldBunny = 443;
    public const short GoldButterfly = 444;
    public const short GoldFrog = 445;
    public const short GoldGrasshopper = 446;
    public const short GoldMouse = 447;
    public const short GoldWorm = 448;
    public const short BoneThrowingSkeleton = 449;
    public const short BoneThrowingSkeleton2 = 450;
    public const short BoneThrowingSkeleton3 = 451;
    public const short BoneThrowingSkeleton4 = 452;
    public const short SkeletonMerchant = 453;
    public const short CultistDragonHead = 454;
    public const short CultistDragonBody1 = 455;
    public const short CultistDragonBody2 = 456;
    public const short CultistDragonBody3 = 457;
    public const short CultistDragonBody4 = 458;
    public const short CultistDragonTail = 459;
    public const short Butcher = 460;
    public const short CreatureFromTheDeep = 461;
    public const short Fritz = 462;
    public const short Nailhead = 463;
    public const short CrimsonBunny = 464;
    public const short CrimsonGoldfish = 465;
    public const short Psycho = 466;
    public const short DeadlySphere = 467;
    public const short DrManFly = 468;
    public const short ThePossessed = 469;
    public const short CrimsonPenguin = 470;
    public const short GoblinSummoner = 471;
    public const short ShadowFlameApparition = 472;
    public const short BigMimicCorruption = 473;
    public const short BigMimicCrimson = 474;
    public const short BigMimicHallow = 475;
    public const short BigMimicJungle = 476;
    public const short Mothron = 477;
    public const short MothronEgg = 478;
    public const short MothronSpawn = 479;
    public const short Medusa = 480;
    public const short GreekSkeleton = 481;
    public const short GraniteGolem = 482;
    public const short GraniteFlyer = 483;
    public const short EnchantedNightcrawler = 484;
    public const short Grubby = 485;
    public const short Sluggy = 486;
    public const short Buggy = 487;
    public const short TargetDummy = 488;
    public const short BloodZombie = 489;
    public const short Drippler = 490;
    public const short PirateShip = 491;
    public const short PirateShipCannon = 492;
    public const short LunarTowerStardust = 493;
    public const short Crawdad = 494;
    public const short Crawdad2 = 495;
    public const short GiantShelly = 496;
    public const short GiantShelly2 = 497;
    public const short Salamander = 498;
    public const short Salamander2 = 499;
    public const short Salamander3 = 500;
    public const short Salamander4 = 501;
    public const short Salamander5 = 502;
    public const short Salamander6 = 503;
    public const short Salamander7 = 504;
    public const short Salamander8 = 505;
    public const short Salamander9 = 506;
    public const short LunarTowerNebula = 507;
    public const short LunarTowerVortex = 422;
    public const short TaxCollector = 441;
    public const short GiantWalkingAntlion = 508;
    public const short GiantFlyingAntlion = 509;
    public const short DuneSplicerHead = 510;
    public const short DuneSplicerBody = 511;
    public const short DuneSplicerTail = 512;
    public const short TombCrawlerHead = 513;
    public const short TombCrawlerBody = 514;
    public const short TombCrawlerTail = 515;
    public const short SolarFlare = 516;
    public const short LunarTowerSolar = 517;
    public const short SolarSpearman = 518;
    public const short SolarGoop = 519;
    public const short MartianWalker = 520;
    public const short AncientCultistSquidhead = 521;
    public const short AncientLight = 522;
    public const short AncientDoom = 523;
    public const short DesertGhoul = 524;
    public const short DesertGhoulCorruption = 525;
    public const short DesertGhoulCrimson = 526;
    public const short DesertGhoulHallow = 527;
    public const short DesertLamiaLight = 528;
    public const short DesertLamiaDark = 529;
    public const short DesertScorpionWalk = 530;
    public const short DesertScorpionWall = 531;
    public const short DesertBeast = 532;
    public const short DesertDjinn = 533;
    public const short DemonTaxCollector = 534;
    public const short SlimeSpiked = 535;
    public const short TheBride = 536;
    public const short SandSlime = 537;
    public const short SquirrelRed = 538;
    public const short SquirrelGold = 539;
    public const short PartyBunny = 540;
    public const short SandElemental = 541;
    public const short SandShark = 542;
    public const short SandsharkCorrupt = 543;
    public const short SandsharkCrimson = 544;
    public const short SandsharkHallow = 545;
    public const short Tumbleweed = 546;
    public const short DD2AttackerTest = 547;
    public const short DD2EterniaCrystal = 548;
    public const short DD2LanePortal = 549;
    public const short DD2Bartender = 550;
    public const short DD2Betsy = 551;
    public const short DD2GoblinT1 = 552;
    public const short DD2GoblinT2 = 553;
    public const short DD2GoblinT3 = 554;
    public const short DD2GoblinBomberT1 = 555;
    public const short DD2GoblinBomberT2 = 556;
    public const short DD2GoblinBomberT3 = 557;
    public const short DD2WyvernT1 = 558;
    public const short DD2WyvernT2 = 559;
    public const short DD2WyvernT3 = 560;
    public const short DD2JavelinstT1 = 561;
    public const short DD2JavelinstT2 = 562;
    public const short DD2JavelinstT3 = 563;
    public const short DD2DarkMageT1 = 564;
    public const short DD2DarkMageT3 = 565;
    public const short DD2SkeletonT1 = 566;
    public const short DD2SkeletonT3 = 567;
    public const short DD2WitherBeastT2 = 568;
    public const short DD2WitherBeastT3 = 569;
    public const short DD2DrakinT2 = 570;
    public const short DD2DrakinT3 = 571;
    public const short DD2KoboldWalkerT2 = 572;
    public const short DD2KoboldWalkerT3 = 573;
    public const short DD2KoboldFlyerT2 = 574;
    public const short DD2KoboldFlyerT3 = 575;
    public const short DD2OgreT2 = 576;
    public const short DD2OgreT3 = 577;
    public const short DD2LightningBugT3 = 578;
    public const short BartenderUnconscious = 579;
    public const short WalkingAntlion = 580;
    public const short FlyingAntlion = 581;
    public const short LarvaeAntlion = 582;
    public const short FairyCritterPink = 583;
    public const short FairyCritterGreen = 584;
    public const short FairyCritterBlue = 585;
    public const short ZombieMerman = 586;
    public const short EyeballFlyingFish = 587;
    public const short Golfer = 588;
    public const short GolferRescue = 589;
    public const short TorchZombie = 590;
    public const short ArmedTorchZombie = 591;
    public const short GoldGoldfish = 592;
    public const short GoldGoldfishWalker = 593;
    public const short WindyBalloon = 594;
    public const short BlackDragonfly = 595;
    public const short BlueDragonfly = 596;
    public const short GreenDragonfly = 597;
    public const short OrangeDragonfly = 598;
    public const short RedDragonfly = 599;
    public const short YellowDragonfly = 600;
    public const short GoldDragonfly = 601;
    public const short Seagull = 602;
    public const short Seagull2 = 603;
    public const short LadyBug = 604;
    public const short GoldLadyBug = 605;
    public const short Maggot = 606;
    public const short Pupfish = 607;
    public const short Grebe = 608;
    public const short Grebe2 = 609;
    public const short Rat = 610;
    public const short Owl = 611;
    public const short WaterStrider = 612;
    public const short GoldWaterStrider = 613;
    public const short ExplosiveBunny = 614;
    public const short Dolphin = 615;
    public const short Turtle = 616;
    public const short TurtleJungle = 617;
    public const short BloodNautilus = 618;
    public const short BloodSquid = 619;
    public const short GoblinShark = 620;
    public const short BloodEelHead = 621;
    public const short BloodEelBody = 622;
    public const short BloodEelTail = 623;
    public const short Gnome = 624;
    public const short SeaTurtle = 625;
    public const short Seahorse = 626;
    public const short GoldSeahorse = 627;
    public const short Dandelion = 628;
    public const short IceMimic = 629;
    public const short BloodMummy = 630;
    public const short RockGolem = 631;
    public const short MaggotZombie = 632;
    public const short BestiaryGirl = 633;
    public const short SporeBat = 634;
    public const short SporeSkeleton = 635;
    public const short HallowBoss = 636;
    public const short TownCat = 637;
    public const short TownDog = 638;
    public const short GemSquirrelAmethyst = 639;
    public const short GemSquirrelTopaz = 640;
    public const short GemSquirrelSapphire = 641;
    public const short GemSquirrelEmerald = 642;
    public const short GemSquirrelRuby = 643;
    public const short GemSquirrelDiamond = 644;
    public const short GemSquirrelAmber = 645;
    public const short GemBunnyAmethyst = 646;
    public const short GemBunnyTopaz = 647;
    public const short GemBunnySapphire = 648;
    public const short GemBunnyEmerald = 649;
    public const short GemBunnyRuby = 650;
    public const short GemBunnyDiamond = 651;
    public const short GemBunnyAmber = 652;
    public const short HellButterfly = 653;
    public const short Lavafly = 654;
    public const short MagmaSnail = 655;
    public const short TownBunny = 656;
    public const short QueenSlimeBoss = 657;
    public const short QueenSlimeMinionBlue = 658;
    public const short QueenSlimeMinionPink = 659;
    public const short QueenSlimeMinionPurple = 660;
    public const short EmpressButterfly = 661;
    public const short PirateGhost = 662;
    public const short Count = 663;

    public static int FromLegacyName(string name)
    {
      int num;
      return NPCID.LegacyNameToIdMap.TryGetValue(name, out num) ? num : 0;
    }

    public static int FromNetId(int id) => id < 0 ? NPCID.NetIdMap[-id - 1] : id;

    public static class Sets
    {
      public static SetFactory Factory = new SetFactory(663);
      public static Dictionary<int, int> SpecialSpawningRules = new Dictionary<int, int>()
      {
        {
          259,
          0
        },
        {
          260,
          0
        },
        {
          175,
          0
        },
        {
          43,
          0
        },
        {
          56,
          0
        },
        {
          101,
          0
        }
      };
      public static Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> NPCBestiaryDrawOffset = NPCID.Sets.NPCBestiaryDrawOffsetCreation();
      public static List<int> NormalGoldCritterBestiaryPriority = new List<int>()
      {
        46,
        540,
        614,
        303,
        337,
        443,
        74,
        297,
        298,
        442,
        55,
        230,
        592,
        593,
        299,
        538,
        539,
        300,
        447,
        361,
        445,
        377,
        446,
        356,
        444,
        357,
        448,
        595,
        596,
        597,
        598,
        599,
        600,
        601,
        626,
        627,
        612,
        613,
        604,
        605
      };
      public static List<int> BossBestiaryPriority = new List<int>()
      {
        4,
        5,
        50,
        535,
        13,
        14,
        15,
        266,
        267,
        35,
        36,
        222,
        113,
        114,
        117,
        115,
        116,
        657,
        658,
        659,
        660,
        125,
        126,
        134,
        135,
        136,
        139,
        (int) sbyte.MaxValue,
        128,
        131,
        129,
        130,
        262,
        263,
        264,
        636,
        245,
        246,
        249,
        247,
        248,
        370,
        372,
        373,
        439,
        438,
        379,
        380,
        440,
        521,
        454,
        507,
        517,
        422,
        493,
        398,
        396,
        397,
        400,
        401
      };
      public static List<int> TownNPCBestiaryPriority = new List<int>()
      {
        22,
        17,
        18,
        38,
        369,
        20,
        19,
        207,
        227,
        353,
        633,
        550,
        588,
        107,
        228,
        124,
        54,
        108,
        178,
        229,
        160,
        441,
        209,
        208,
        142,
        637,
        638,
        656,
        368,
        453,
        37
      };
      public static bool[] DontDoHardmodeScaling = NPCID.Sets.Factory.CreateBoolSet(5, 13, 14, 15, 267, 113, 114, 115, 116, 117, 118, 119, 658, 659, 660, 400);
      public static bool[] IsTownPet = NPCID.Sets.Factory.CreateBoolSet(637, 638, 656);
      public static List<int> GoldCrittersCollection = new List<int>()
      {
        443,
        442,
        592,
        444,
        601,
        445,
        446,
        605,
        447,
        627,
        613,
        448,
        539
      };
      public static bool[] CantTakeLunchMoney = NPCID.Sets.Factory.CreateBoolSet(394, 393, 392, 492, 491, 662, 384, 478, 658, 659, 660, 128, 131, 129, 130, 139, 267, 247, 248, 246, 249, 245, 397, 396, 401, 400, 440, 68);
      public static Dictionary<int, int> RespawnEnemyID = new Dictionary<int, int>()
      {
        {
          492,
          0
        },
        {
          491,
          0
        },
        {
          394,
          0
        },
        {
          393,
          0
        },
        {
          392,
          0
        },
        {
          13,
          0
        },
        {
          14,
          0
        },
        {
          15,
          0
        },
        {
          412,
          0
        },
        {
          413,
          0
        },
        {
          414,
          0
        },
        {
          134,
          0
        },
        {
          135,
          0
        },
        {
          136,
          0
        },
        {
          454,
          0
        },
        {
          455,
          0
        },
        {
          456,
          0
        },
        {
          457,
          0
        },
        {
          458,
          0
        },
        {
          459,
          0
        },
        {
          8,
          7
        },
        {
          9,
          7
        },
        {
          11,
          10
        },
        {
          12,
          10
        },
        {
          40,
          39
        },
        {
          41,
          39
        },
        {
          96,
          95
        },
        {
          97,
          95
        },
        {
          99,
          98
        },
        {
          100,
          98
        },
        {
          88,
          87
        },
        {
          89,
          87
        },
        {
          90,
          87
        },
        {
          91,
          87
        },
        {
          92,
          87
        },
        {
          118,
          117
        },
        {
          119,
          117
        },
        {
          514,
          513
        },
        {
          515,
          513
        },
        {
          511,
          510
        },
        {
          512,
          510
        },
        {
          622,
          621
        },
        {
          623,
          621
        }
      };
      public static int[] TrailingMode = NPCID.Sets.Factory.CreateIntSet(-1, 439, 0, 440, 0, 370, 1, 372, 1, 373, 1, 396, 1, 400, 1, 401, 1, 473, 2, 474, 2, 475, 2, 476, 2, 4, 3, 471, 3, 477, 3, 479, 3, 120, 4, 137, 4, 138, 4, 94, 5, 125, 6, 126, 6, (int) sbyte.MaxValue, 6, 128, 6, 129, 6, 130, 6, 131, 6, 139, 6, 140, 6, 407, 6, 420, 6, 425, 6, 427, 6, 426, 6, 581, 6, 516, 6, 542, 6, 543, 6, 544, 6, 545, 6, 402, 7, 417, 7, 419, 7, 418, 7, 574, 7, 575, 7, 519, 7, 521, 7, 522, 7, 546, 7, 558, 7, 559, 7, 560, 7, 551, 7, 620, 7, 657, 6, 636, 7);
      public static bool[] IsDragonfly = NPCID.Sets.Factory.CreateBoolSet(595, 596, 597, 598, 599, 600, 601);
      public static bool[] BelongsToInvasionOldOnesArmy = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 548, 549, 564, 565, 574, 575, 551, 578);
      public static bool[] TeleportationImmune = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 548, 549, 564, 565, 574, 575, 551, 578);
      public static bool[] UsesNewTargetting = NPCID.Sets.Factory.CreateBoolSet(547, 552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 564, 565, 574, 575, 551, 578, 210, 211, 620);
      public static bool[] TakesDamageFromHostilesWithoutBeingFriendly = NPCID.Sets.Factory.CreateBoolSet(46, 55, 74, 148, 149, 230, 297, 298, 299, 303, 355, 356, 358, 359, 360, 361, 362, 363, 364, 365, 366, 367, 377, 357, 374, 442, 443, 444, 445, 446, 448, 538, 539, 337, 540, 484, 485, 486, 487, 592, 593, 595, 596, 597, 598, 599, 600, 601, 602, 603, 604, 605, 606, 607, 608, 609, 611, 612, 613, 614, 615, 616, 617, 625, 626, 627, 639, 640, 641, 642, 643, 644, 645, 646, 647, 648, 649, 650, 651, 652, 653, 654, 655, 583, 584, 585);
      public static bool[] AllNPCs = NPCID.Sets.Factory.CreateBoolSet(true);
      public static bool[] HurtingBees = NPCID.Sets.Factory.CreateBoolSet(210, 211, 222);
      public static bool[] FighterUsesDD2PortalAppearEffect = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 576, 577, 568, 569, 570, 571, 572, 573, 564, 565);
      public static float[] StatueSpawnedDropRarity = NPCID.Sets.Factory.CreateCustomSet<float>(-1f, (object) (short) 480, (object) 0.05f, (object) (short) 82, (object) 0.05f, (object) (short) 86, (object) 0.05f, (object) (short) 48, (object) 0.05f, (object) (short) 490, (object) 0.05f, (object) (short) 489, (object) 0.05f, (object) (short) 170, (object) 0.05f, (object) (short) 180, (object) 0.05f, (object) (short) 171, (object) 0.05f, (object) (short) 167, (object) 0.25f, (object) (short) 73, (object) 0.01f, (object) (short) 24, (object) 0.05f, (object) (short) 481, (object) 0.05f, (object) (short) 42, (object) 0.05f, (object) (short) 6, (object) 0.05f, (object) (short) 2, (object) 0.05f, (object) (short) 49, (object) 0.2f, (object) (short) 3, (object) 0.2f, (object) (short) 58, (object) 0.2f, (object) (short) 21, (object) 0.2f, (object) (short) 65, (object) 0.2f, (object) (short) 449, (object) 0.2f, (object) (short) 482, (object) 0.2f, (object) (short) 103, (object) 0.2f, (object) (short) 64, (object) 0.2f, (object) (short) 63, (object) 0.2f, (object) (short) 85, (object) 0.0f);
      public static bool[] NoEarlymodeLootWhenSpawnedFromStatue = NPCID.Sets.Factory.CreateBoolSet(480, 82, 86, 170, 180, 171);
      public static bool[] NeedsExpertScaling = NPCID.Sets.Factory.CreateBoolSet(25, 30, 33, 112, 261, 265, 371, 516, 519, 522, 397, 396, 398, 491);
      public static bool[] ProjectileNPC = NPCID.Sets.Factory.CreateBoolSet(25, 30, 33, 112, 261, 265, 371, 516, 519, 522);
      public static bool[] SavesAndLoads = NPCID.Sets.Factory.CreateBoolSet(422, 507, 517, 493);
      public static int[] TrailCacheLength = NPCID.Sets.Factory.CreateIntSet(10, 402, 36, 519, 20, 522, 20, 620, 20);
      public static bool[] NoMultiplayerSmoothingByType = NPCID.Sets.Factory.CreateBoolSet(113, 114, 50, 657, 120, 245, 247, 248, 246, 370, 222);
      public static bool[] NoMultiplayerSmoothingByAI = NPCID.Sets.Factory.CreateBoolSet(6, 8, 37);
      public static bool[] MPAllowedEnemies = NPCID.Sets.Factory.CreateBoolSet(4, 13, 50, 126, 125, 134, (int) sbyte.MaxValue, 128, 131, 129, 130, 222, 245, 266, 370, 657);
      public static bool[] TownCritter = NPCID.Sets.Factory.CreateBoolSet(46, 148, 149, 230, 299, 300, 303, 337, 361, 362, 364, 366, 367, 443, 445, 447, 538, 539, 540, 583, 584, 585, 592, 593, 602, 607, 608, 610, 616, 617, 625, 626, 627, 639, 640, 641, 642, 643, 644, 645, 646, 647, 648, 649, 650, 651, 652);
      public static bool[] CountsAsCritter = NPCID.Sets.Factory.CreateBoolSet(46, 303, 337, 540, 443, 74, 297, 298, 442, 611, 377, 446, 612, 613, 356, 444, 595, 596, 597, 598, 599, 600, 601, 604, 605, 357, 448, 374, 484, 355, 358, 606, 359, 360, 485, 486, 487, 148, 149, 55, 230, 592, 593, 299, 538, 539, 300, 447, 361, 445, 362, 363, 364, 365, 367, 366, 583, 584, 585, 602, 603, 607, 608, 609, 610, 616, 617, 625, 626, 627, 615, 639, 640, 641, 642, 643, 644, 645, 646, 647, 648, 649, 650, 651, 652, 653, 654, 655, 661);
      public static bool[] HasNoPartyText = NPCID.Sets.Factory.CreateBoolSet(441, 453);
      public static int[] HatOffsetY = NPCID.Sets.Factory.CreateIntSet(0, 227, 4, 107, 2, 108, 2, 229, 4, 17, 2, 38, 8, 160, -10, 208, 2, 142, 2, 124, 2, 453, 2, 37, 4, 54, 4, 209, 4, 369, 6, 441, 6, 353, -2, 633, -2, 550, -2, 588, 2, 637, 0, 638, 0, 656, 4);
      public static int[] FaceEmote = NPCID.Sets.Factory.CreateIntSet(0, 17, 101, 18, 102, 19, 103, 20, 104, 22, 105, 37, 106, 38, 107, 54, 108, 107, 109, 108, 110, 124, 111, 142, 112, 160, 113, 178, 114, 207, 115, 208, 116, 209, 117, 227, 118, 228, 119, 229, 120, 353, 121, 368, 122, 369, 123, 453, 124, 441, 125, 588, 140, 633, 141);
      public static int[] ExtraFramesCount = NPCID.Sets.Factory.CreateIntSet(0, 17, 9, 18, 9, 19, 9, 20, 7, 22, 10, 37, 5, 38, 9, 54, 7, 107, 9, 108, 7, 124, 9, 142, 9, 160, 7, 178, 9, 207, 9, 208, 9, 209, 10, 227, 9, 228, 10, 229, 10, 353, 9, 633, 9, 368, 10, 369, 9, 453, 9, 441, 9, 550, 9, 588, 9, 637, 18, 638, 11, 656, 20);
      public static int[] AttackFrameCount = NPCID.Sets.Factory.CreateIntSet(0, 17, 4, 18, 4, 19, 4, 20, 2, 22, 5, 37, 0, 38, 4, 54, 2, 107, 4, 108, 2, 124, 4, 142, 4, 160, 2, 178, 4, 207, 4, 208, 4, 209, 5, 227, 4, 228, 5, 229, 5, 353, 4, 633, 4, 368, 5, 369, 4, 453, 4, 441, 4, 550, 4, 588, 4, 637, 0, 638, 0, 656, 0);
      public static int[] DangerDetectRange = NPCID.Sets.Factory.CreateIntSet(-1, 38, 300, 17, 320, 107, 300, 19, 900, 22, 700, 124, 800, 228, 800, 178, 900, 18, 300, 229, 1000, 209, 1000, 54, 700, 108, 700, 160, 700, 20, 1200, 369, 300, 453, 300, 368, 900, 207, 60, 227, 800, 208, 400, 142, 500, 441, 50, 353, 60, 633, 100, 550, 120, 588, 120, 638, 250, 637, 250, 656, 250);
      public static int[] AttackTime = NPCID.Sets.Factory.CreateIntSet(-1, 38, 34, 17, 34, 107, 60, 19, 40, 22, 30, 124, 34, 228, 40, 178, 24, 18, 34, 229, 60, 209, 60, 54, 60, 108, 30, 160, 60, 20, 600, 369, 34, 453, 34, 368, 60, 207, 15, 227, 60, 208, 34, 142, 34, 441, 15, 353, 12, 633, 12, 550, 34, 588, 20, 638, -1, 637, -1, 656, -1);
      public static int[] AttackAverageChance = NPCID.Sets.Factory.CreateIntSet(1, 38, 40, 17, 30, 107, 60, 19, 30, 22, 30, 124, 30, 228, 50, 178, 50, 18, 60, 229, 40, 209, 30, 54, 30, 108, 30, 160, 60, 20, 60, 369, 50, 453, 30, 368, 40, 207, 1, 227, 30, 208, 50, 142, 50, 441, 1, 353, 1, 633, 1, 550, 40, 588, 20, 638, 1, 637, 1, 656, 1);
      public static int[] AttackType = NPCID.Sets.Factory.CreateIntSet(-1, 38, 0, 17, 0, 107, 0, 19, 1, 22, 1, 124, 0, 228, 1, 178, 1, 18, 0, 229, 1, 209, 1, 54, 2, 108, 2, 160, 2, 20, 2, 369, 0, 453, 0, 368, 1, 207, 3, 227, 1, 208, 0, 142, 0, 441, 3, 353, 3, 633, 0, 550, 0, 588, 0, 638, -1, 637, -1, 656, -1);
      public static int[] PrettySafe = NPCID.Sets.Factory.CreateIntSet(-1, 19, 300, 22, 200, 124, 200, 228, 300, 178, 300, 229, 300, 209, 300, 54, 100, 108, 100, 160, 100, 20, 200, 368, 200, 227, 200);
      public static Color[] MagicAuraColor = NPCID.Sets.Factory.CreateCustomSet<Color>(Color.White, (object) (short) 54, (object) new Color(100, 4, 227, (int) sbyte.MaxValue), (object) (short) 108, (object) new Color((int) byte.MaxValue, 80, 60, (int) sbyte.MaxValue), (object) (short) 160, (object) new Color(40, 80, (int) byte.MaxValue, (int) sbyte.MaxValue), (object) (short) 20, (object) new Color(40, (int) byte.MaxValue, 80, (int) sbyte.MaxValue));
      public static bool[] DemonEyes = NPCID.Sets.Factory.CreateBoolSet(2, 190, 192, 193, 191, 194, 317, 318);
      public static bool[] Zombies = NPCID.Sets.Factory.CreateBoolSet(3, 132, 186, 187, 188, 189, 200, 223, 161, 254, (int) byte.MaxValue, 52, 53, 536, 319, 320, 321, 332, 436, 431, 432, 433, 434, 435, 331, 430, 590);
      public static bool[] Skeletons = NPCID.Sets.Factory.CreateBoolSet(77, 449, 450, 451, 452, 481, 201, 202, 203, 21, 324, 110, 323, 293, 291, 322, 292, 197, 167, 44, 635);
      public static int[] BossHeadTextures = NPCID.Sets.Factory.CreateIntSet(-1, 4, 0, 13, 2, 344, 3, 370, 4, 246, 5, 249, 5, 345, 6, 50, 7, 396, 8, 395, 9, 325, 10, 262, 11, 327, 13, 222, 14, 125, 15, 126, 20, 346, 17, (int) sbyte.MaxValue, 18, 35, 19, 68, 19, 113, 22, 266, 23, 439, 24, 440, 24, 134, 25, 491, 26, 517, 27, 422, 28, 507, 29, 493, 30, 549, 35, 564, 32, 565, 32, 576, 33, 577, 33, 551, 34, 548, 36, 636, 37, 657, 38);
      public static bool[] PositiveNPCTypesExcludedFromDeathTally = NPCID.Sets.Factory.CreateBoolSet(121, 384, 406, 478, 479, 410);
      public static bool[] ShouldBeCountedAsBoss = NPCID.Sets.Factory.CreateBoolSet(false, 517, 422, 507, 493, 13);
      public static bool[] DangerThatPreventsOtherDangers = NPCID.Sets.Factory.CreateBoolSet(517, 422, 507, 493, 399);
      public static bool[] MustAlwaysDraw = NPCID.Sets.Factory.CreateBoolSet(113, 114, 115, 116, 126, 125);
      public static int[] ExtraTextureCount = NPCID.Sets.Factory.CreateIntSet(0, 38, 1, 17, 1, 107, 0, 19, 0, 22, 0, 124, 1, 228, 0, 178, 1, 18, 1, 229, 1, 209, 1, 54, 1, 108, 1, 160, 0, 20, 0, 369, 1, 453, 1, 368, 1, 207, 1, 227, 1, 208, 0, 142, 1, 441, 1, 353, 1, 633, 1, 550, 0, 588, 1, 633, 2, 638, 0, 637, 0, 656, 0);
      public static int[] NPCFramingGroup = NPCID.Sets.Factory.CreateIntSet(0, 18, 1, 20, 1, 208, 1, 178, 1, 124, 1, 353, 1, 633, 1, 369, 2, 160, 3, 637, 4, 638, 5, 656, 6);
      public static int[][] TownNPCsFramingGroups = new int[7][]
      {
        new int[26]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[25]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[25]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          -2,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[23]
        {
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          2,
          6
        },
        new int[28]
        {
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          2,
          2,
          4,
          6,
          4,
          2,
          2,
          -2,
          -4,
          -6,
          -4,
          -2,
          -4,
          -4,
          -6,
          -6,
          -6,
          -4
        },
        new int[28]
        {
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          -2,
          -2,
          0,
          0,
          4,
          6,
          6,
          6,
          6,
          4,
          4,
          4,
          4,
          4,
          4
        },
        new int[26]
        {
          0,
          0,
          -2,
          -4,
          -4,
          -2,
          0,
          -2,
          0,
          0,
          2,
          4,
          6,
          4,
          2,
          0,
          -2,
          -4,
          -6,
          -6,
          -6,
          -6,
          -6,
          -6,
          -4,
          -2
        }
      };

      public static Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> NPCBestiaryDrawOffsetCreation()
      {
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> redigitEntries = NPCID.Sets.GetRedigitEntries();
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> leinforsEntries = NPCID.Sets.GetLeinforsEntries();
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> groxEntries = NPCID.Sets.GetGroxEntries();
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> dictionary = new Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers>();
        foreach (KeyValuePair<int, NPCID.Sets.NPCBestiaryDrawModifiers> keyValuePair in groxEntries)
          dictionary[keyValuePair.Key] = keyValuePair.Value;
        foreach (KeyValuePair<int, NPCID.Sets.NPCBestiaryDrawModifiers> keyValuePair in leinforsEntries)
          dictionary[keyValuePair.Key] = keyValuePair.Value;
        foreach (KeyValuePair<int, NPCID.Sets.NPCBestiaryDrawModifiers> keyValuePair in redigitEntries)
          dictionary[keyValuePair.Key] = keyValuePair.Value;
        return dictionary;
      }

      private static Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> GetRedigitEntries()
      {
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> dictionary = new Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers>();
        NPCID.Sets.NPCBestiaryDrawModifiers bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(430, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(431, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(432, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(433, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(434, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(435, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(436, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(591, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(449, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(450, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(451, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(452, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(595, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(596, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(597, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(598, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(600, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(495, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(497, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(498, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(500, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(501, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(502, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(503, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(504, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(505, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(506, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(230, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(593, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(158, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-2, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(440, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(568, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(566, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(576, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(558, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(559, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(552, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(553, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(564, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(570, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(555, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(556, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(574, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(561, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(562, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(572, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(535, bestiaryDrawModifiers);
        return dictionary;
      }

      private static Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> GetGroxEntries() => new Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers>();

      private static Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> GetLeinforsEntries()
      {
        Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers> dictionary = new Dictionary<int, NPCID.Sets.NPCBestiaryDrawModifiers>();
        NPCID.Sets.NPCBestiaryDrawModifiers bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-65, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-64, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-63, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-62, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 4f);
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-61, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 3f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-60, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-59, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-58, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-57, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-56, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        dictionary.Add(-55, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        dictionary.Add(-54, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-53, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-52, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-51, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-50, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-49, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-48, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-47, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-46, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-45, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-44, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-43, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-42, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-41, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-40, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-39, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-38, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-37, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-36, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-35, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-34, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-33, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-32, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-31, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-30, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-29, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-28, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-27, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-26, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -9f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Scale = 1.2f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-23, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -9f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Scale = 0.8f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-22, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-25, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-24, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 5f);
        bestiaryDrawModifiers.Scale = 1.2f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-21, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 4f);
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-20, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 3f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-19, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 2f);
        bestiaryDrawModifiers.Scale = 0.8f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-18, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 3f);
        bestiaryDrawModifiers.Scale = 1.2f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-17, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 3f);
        bestiaryDrawModifiers.Scale = 0.8f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-16, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.2f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-15, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 1.1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-14, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-13, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -9f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Scale = 1.2f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-12, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -9f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Scale = 0.8f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(-11, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(2, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(3, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(25f, -30f);
        bestiaryDrawModifiers.Rotation = 0.7f;
        bestiaryDrawModifiers.Frame = new int?(4);
        dictionary.Add(4, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 4f);
        bestiaryDrawModifiers.Rotation = 1.5f;
        dictionary.Add(5, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -9f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        dictionary.Add(6, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_7";
        bestiaryDrawModifiers.Position = new Vector2(20f, 29f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(7, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(8, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(9, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_10";
        bestiaryDrawModifiers.Position = new Vector2(2f, 24f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(10, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(11, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(12, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_13";
        bestiaryDrawModifiers.Position = new Vector2(40f, 22f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(13, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(14, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(15, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(17, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(18, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(19, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(20, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(22, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(25, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(26, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(27, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(28, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(30, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(31, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(33, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(34, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(21, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -12f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-1f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-3f);
        dictionary.Add(35, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(36, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(38, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(37, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_39";
        bestiaryDrawModifiers.Position = new Vector2(40f, 23f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(39, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(40, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(41, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, -6f);
        bestiaryDrawModifiers.Rotation = 2.356194f;
        dictionary.Add(43, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(44, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(46, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(47, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, -14f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(48, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -13f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(49, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 90f);
        bestiaryDrawModifiers.PortraitScale = new float?(1.1f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(70f);
        dictionary.Add(50, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -13f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(51, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(52, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(53, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(54, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(7f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(55, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, -6f);
        bestiaryDrawModifiers.Rotation = 2.356194f;
        dictionary.Add(56, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(6f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(57, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(6f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(58, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -19f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-36f);
        dictionary.Add(60, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-15f);
        dictionary.Add(61, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-25f);
        dictionary.Add(62, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, 4f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(5f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(65, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -6f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-15f);
        dictionary.Add(66, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-1f, -12f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-3f);
        dictionary.Add(68, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(70, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(72, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(73, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, -14f);
        bestiaryDrawModifiers.Velocity = 0.05f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(74, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        dictionary.Add(75, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(76, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(77, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(78, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(79, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(80, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-4f, -4f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-25f);
        dictionary.Add(83, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, -11f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-28f);
        dictionary.Add(84, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 6f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(2f);
        dictionary.Add(86, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_87";
        bestiaryDrawModifiers.Position = new Vector2(55f, 15f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(87, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(88, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(89, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(90, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(91, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(92, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(93, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(8f, 0.0f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        dictionary.Add(94, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_95";
        bestiaryDrawModifiers.Position = new Vector2(20f, 28f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(95, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(96, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(97, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_98";
        bestiaryDrawModifiers.Position = new Vector2(40f, 24f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(12f);
        dictionary.Add(98, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(99, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(100, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 6f);
        bestiaryDrawModifiers.Rotation = 2.356194f;
        dictionary.Add(101, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(6f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(102, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(104, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(105, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(106, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(107, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(108, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 35f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(109, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(110, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(111, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(112, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_113";
        bestiaryDrawModifiers.Position = new Vector2(56f, 5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(113, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(114, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_115";
        bestiaryDrawModifiers.Position = new Vector2(56f, 3f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(55f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(115, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, -5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-26f);
        dictionary.Add(116, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_117";
        bestiaryDrawModifiers.Position = new Vector2(10f, 20f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(117, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(118, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(119, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(120, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(123, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(124, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, -4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-20f);
        dictionary.Add(121, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        dictionary.Add(122, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-28f, -23f);
        bestiaryDrawModifiers.Rotation = -0.75f;
        dictionary.Add(125, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(28f, 30f);
        bestiaryDrawModifiers.Rotation = 2.25f;
        dictionary.Add(126, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_127";
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 0.0f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(1f);
        dictionary.Add((int) sbyte.MaxValue, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-6f, -2f);
        bestiaryDrawModifiers.Rotation = -0.75f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(128, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, 4f);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(129, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 8f);
        bestiaryDrawModifiers.Rotation = 2.25f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(130, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-8f, 8f);
        bestiaryDrawModifiers.Rotation = -2.25f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(131, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(132, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -5f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-25f);
        dictionary.Add(133, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_134";
        bestiaryDrawModifiers.Position = new Vector2(60f, 8f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(134, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(135, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(136, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(137, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(140, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(1f);
        dictionary.Add(142, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(146, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(148, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(149, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(150, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(151, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(152, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(153, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(154, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(15f, 0.0f);
        bestiaryDrawModifiers.Velocity = 3f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(155, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-15f);
        dictionary.Add(156, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(5f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(157, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(160, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -11f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(158, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(159, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(161, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(162, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(163, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(164, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Rotation = -1.6f;
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(165, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(167, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(168, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-12f);
        dictionary.Add(170, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-12f);
        dictionary.Add(171, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Rotation = 0.75f;
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -5f);
        dictionary.Add(173, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -5f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(174, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, -2f);
        bestiaryDrawModifiers.Rotation = 2.356194f;
        dictionary.Add(175, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(176, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 15f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(1f);
        bestiaryDrawModifiers.Frame = new int?(0);
        dictionary.Add(177, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(178, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 12f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-7f);
        dictionary.Add(179, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 5f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-12f);
        dictionary.Add(180, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(181, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(185, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(186, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(187, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(188, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(189, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(190, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(191, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(192, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(193, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(194, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(196, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(197, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(198, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(199, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(2f);
        dictionary.Add(200, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(201, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(202, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(203, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(206, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(207, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(208, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(209, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(212, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(213, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(214, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(215, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(216, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(221, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 55f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(40f);
        dictionary.Add(222, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(223, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(224, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, 3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-15f);
        dictionary.Add(226, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-3f);
        dictionary.Add(227, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-5f);
        dictionary.Add(228, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(229, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 0.0f);
        dictionary.Add(225, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(230, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(231, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(232, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(233, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(234, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(235, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(236, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Rotation = -1.6f;
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(237, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Rotation = -1.6f;
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(238, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(239, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Rotation = -1.6f;
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(240, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(6f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(241, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 10f);
        dictionary.Add(242, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 60f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(15f);
        dictionary.Add(243, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_245";
        bestiaryDrawModifiers.Position = new Vector2(2f, 48f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(24f);
        dictionary.Add(245, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(246, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(247, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(248, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(249, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-26f);
        dictionary.Add(250, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(251, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 3f);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(252, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(253, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(254, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-2f);
        dictionary.Add((int) byte.MaxValue, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        dictionary.Add(256, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(257, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(258, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_259";
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 25f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(8f);
        dictionary.Add(259, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_260";
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 25f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(1f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(4f);
        dictionary.Add(260, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(261, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 20f);
        bestiaryDrawModifiers.Scale = 0.8f;
        dictionary.Add(262, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(264, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(263, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(265, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, 5f);
        bestiaryDrawModifiers.Frame = new int?(4);
        dictionary.Add(266, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, -5f);
        dictionary.Add(268, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(269, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(270, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(271, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(272, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(273, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(274, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(3f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(275, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(276, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(277, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(278, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-5f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(279, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(280, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(287, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 10f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(289, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, 6f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(290, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(291, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(292, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(293, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(294, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(295, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(296, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, -14f);
        bestiaryDrawModifiers.Velocity = 0.05f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(297, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, -14f);
        bestiaryDrawModifiers.Velocity = 0.05f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(298, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(299, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-20f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(301, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(303, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(305, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(306, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(307, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(308, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(309, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(310, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(311, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(312, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(313, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(314, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(14f, 26f);
        bestiaryDrawModifiers.Velocity = 2f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(315, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        dictionary.Add(316, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -15f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-35f);
        dictionary.Add(317, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, -13f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-31f);
        dictionary.Add(318, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(319, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(320, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(321, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(322, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(323, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(324, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 36f);
        dictionary.Add(325, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(326, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -8f);
        dictionary.Add(327, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(328, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(329, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 14f);
        dictionary.Add(330, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(331, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(332, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(337, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(338, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(339, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(340, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(342, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, 25f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(343, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 90f);
        dictionary.Add(344, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-1f, 90f);
        dictionary.Add(345, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(30f, 80f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(60f);
        dictionary.Add(346, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        dictionary.Add(347, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(348, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 18f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(349, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(350, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 60f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(30f);
        dictionary.Add(351, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(353, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(633, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(354, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 2f);
        dictionary.Add(355, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(1f);
        dictionary.Add(356, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 2f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(357, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 2f);
        dictionary.Add(358, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 18f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(40f);
        dictionary.Add(359, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 17f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(39f);
        dictionary.Add(360, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(362, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(363, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(364, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(365, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(366, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(367, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(368, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(369, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(56f, -4f);
        bestiaryDrawModifiers.Direction = new int?(1);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(370, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(371, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, 4f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-3f);
        dictionary.Add(372, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(373, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(374, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(375, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(376, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(379, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(380, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(381, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(382, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(383, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(384, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(385, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(386, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 3f;
        dictionary.Add(387, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(388, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-6f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(389, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(12f, 0.0f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 2f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-12f);
        dictionary.Add(390, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(16f, 12f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 2f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(391, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(392, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_395";
        bestiaryDrawModifiers.Position = new Vector2(-1f, 18f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(1f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(395, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(393, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(394, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(396, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(397, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_398";
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 5f);
        bestiaryDrawModifiers.Scale = 0.4f;
        bestiaryDrawModifiers.PortraitScale = new float?(0.7f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(398, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(400, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(401, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_402";
        bestiaryDrawModifiers.Position = new Vector2(42f, 15f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(402, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(403, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(404, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(408, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(410, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(411, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_412";
        bestiaryDrawModifiers.Position = new Vector2(50f, 28f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(4f);
        dictionary.Add(412, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(413, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(414, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(26f, 0.0f);
        bestiaryDrawModifiers.Velocity = 3f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(5f);
        dictionary.Add(415, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 20f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(416, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 8f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(417, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 4f);
        dictionary.Add(418, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(419, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(420, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, -1f);
        dictionary.Add(421, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 44f);
        bestiaryDrawModifiers.Scale = 0.4f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(134f);
        dictionary.Add(422, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(423, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, 0.0f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(424, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(4f, 0.0f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(425, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 8f);
        bestiaryDrawModifiers.Velocity = 2f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(426, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-4f);
        dictionary.Add(427, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(428, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(429, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(430, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(431, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(432, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(433, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(434, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(435, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(436, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(437, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(439, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(440, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(441, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, -14f);
        bestiaryDrawModifiers.Velocity = 0.05f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(442, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(443, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(444, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(448, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(449, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(450, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(451, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(452, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(453, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_454";
        bestiaryDrawModifiers.Position = new Vector2(57f, 10f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(5f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(454, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(455, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(456, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(457, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(458, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(459, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(460, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(461, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(462, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(463, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(464, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(6f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(465, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(466, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(467, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(468, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(469, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(470, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(471, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        bestiaryDrawModifiers.SpriteDirection = new int?(-1);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(472, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(476, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(25f, 6f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        dictionary.Add(477, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(478, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, 4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-15f);
        dictionary.Add(479, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(481, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(482, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(483, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(484, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(487, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(486, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(485, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(489, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_491";
        bestiaryDrawModifiers.Position = new Vector2(30f, -5f);
        bestiaryDrawModifiers.Scale = 0.8f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(1f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-1f);
        dictionary.Add(491, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(492, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 44f);
        bestiaryDrawModifiers.Scale = 0.4f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(134f);
        dictionary.Add(493, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(494, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-4f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(495, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(496, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(497, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(498, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(499, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(500, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(501, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(502, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(503, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(504, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(505, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(506, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 44f);
        bestiaryDrawModifiers.Scale = 0.4f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(134f);
        dictionary.Add(507, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Position = new Vector2(10f, 0.0f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(508, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 0.0f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-20f);
        dictionary.Add(509, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_510";
        bestiaryDrawModifiers.Position = new Vector2(55f, 18f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(12f);
        dictionary.Add(510, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(512, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(511, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_513";
        bestiaryDrawModifiers.Position = new Vector2(37f, 24f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(17f);
        dictionary.Add(513, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(514, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(515, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(516, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 44f);
        bestiaryDrawModifiers.Scale = 0.4f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(135f);
        dictionary.Add(517, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-17f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(518, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(519, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 56f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(520, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(5f, 5f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-10f);
        bestiaryDrawModifiers.SpriteDirection = new int?(-1);
        bestiaryDrawModifiers.Velocity = 0.05f;
        dictionary.Add(521, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(522, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(523, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(524, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(525, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(526, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(527, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(528, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(529, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(530, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        bestiaryDrawModifiers.Velocity = 2f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(531, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(532, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, 5f);
        dictionary.Add(533, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(534, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(536, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(538, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(539, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(540, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 30f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(541, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, -3f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(542, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, -3f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(543, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, -3f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(544, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(35f, -3f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        dictionary.Add(545, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -3f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(546, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(547, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(548, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(549, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(-2f);
        dictionary.Add(550, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(95f, -4f);
        dictionary.Add(551, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(552, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(553, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(554, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(555, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(556, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(557, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, -2f);
        dictionary.Add(558, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, -2f);
        dictionary.Add(559, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(3f, -2f);
        dictionary.Add(560, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(561, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(562, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(563, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(566, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-3f, 0.0f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(567, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(568, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(569, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 5f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(2f);
        dictionary.Add(570, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(10f, 5f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(2f);
        dictionary.Add(571, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(572, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(573, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 4f);
        dictionary.Add(578, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(16f, 6f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(574, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(16f, 6f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(575, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 70f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitScale = new float?(0.75f);
        dictionary.Add(576, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(20f, 70f);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        bestiaryDrawModifiers.PortraitScale = new float?(0.75f);
        dictionary.Add(577, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 0.0f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(580, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -8f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(581, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(582, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 1f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(585, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 1f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(584, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 1f);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(583, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(586, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(579, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(1f);
        dictionary.Add(588, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, -14f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(587, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(9f, 0.0f);
        dictionary.Add(591, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(2f);
        dictionary.Add(590, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(7f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(592, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(593, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_594";
        bestiaryDrawModifiers.Scale = 0.8f;
        dictionary.Add(594, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(589, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(602, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(603, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 22f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(41f);
        dictionary.Add(604, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 22f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(41f);
        dictionary.Add(605, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(606, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 6f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(7f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(607, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(608, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(609, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 0.0f);
        bestiaryDrawModifiers.Direction = new int?(-1);
        bestiaryDrawModifiers.SpriteDirection = new int?(1);
        dictionary.Add(611, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(612, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(613, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(614, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 10f);
        bestiaryDrawModifiers.Scale = 0.88f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(20f);
        bestiaryDrawModifiers.IsWet = true;
        dictionary.Add(615, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(616, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(617, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(12f, -5f);
        bestiaryDrawModifiers.Scale = 0.9f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(0.0f);
        dictionary.Add(618, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 7f);
        bestiaryDrawModifiers.Scale = 0.85f;
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(10f);
        dictionary.Add(619, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(6f, 5f);
        bestiaryDrawModifiers.Scale = 0.78f;
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(620, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.CustomTexturePath = "Images/UI/Bestiary/NPCs/NPC_621";
        bestiaryDrawModifiers.Position = new Vector2(46f, 20f);
        bestiaryDrawModifiers.PortraitPositionXOverride = new float?(10f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(17f);
        dictionary.Add(621, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(622, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(623, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 2f;
        dictionary.Add(624, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -12f);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(625, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -16f);
        dictionary.Add(626, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -16f);
        dictionary.Add(627, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Direction = new int?(1);
        dictionary.Add(628, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.5f;
        dictionary.Add(630, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(632, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.75f;
        dictionary.Add(631, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        bestiaryDrawModifiers.Position = new Vector2(0.0f, -13f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-30f);
        dictionary.Add(634, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(635, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 50f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(30f);
        dictionary.Add(636, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(639, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(640, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(641, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(642, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(643, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(644, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(645, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(646, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(647, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(648, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(649, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(650, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(651, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(652, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 0.25f;
        dictionary.Add(637, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(638, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(1f);
        dictionary.Add(653, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 2f);
        dictionary.Add(654, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(1f, 17f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(39f);
        dictionary.Add(655, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Velocity = 1f;
        dictionary.Add(656, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(0.0f, 60f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(40f);
        dictionary.Add(657, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(-2f, -4f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(-20f);
        dictionary.Add(660, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Position = new Vector2(2f, 3f);
        bestiaryDrawModifiers.PortraitPositionYOverride = new float?(1f);
        dictionary.Add(661, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(662, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(0, bestiaryDrawModifiers);
        bestiaryDrawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0);
        bestiaryDrawModifiers.Hide = true;
        dictionary.Add(488, bestiaryDrawModifiers);
        return dictionary;
      }

      public struct NPCBestiaryDrawModifiers
      {
        public Vector2 Position;
        public float? PortraitPositionXOverride;
        public float? PortraitPositionYOverride;
        public float Rotation;
        public float Scale;
        public float? PortraitScale;
        public bool Hide;
        public bool IsWet;
        public int? Frame;
        public int? Direction;
        public int? SpriteDirection;
        public float Velocity;
        public string CustomTexturePath;

        public NPCBestiaryDrawModifiers(
          int seriouslyWhyCantStructsHaveParameterlessConstructors)
        {
          this.Position = new Vector2();
          this.Rotation = 0.0f;
          this.Scale = 1f;
          this.PortraitScale = new float?(1f);
          this.Hide = false;
          this.IsWet = false;
          this.Frame = new int?();
          this.Direction = new int?();
          this.SpriteDirection = new int?();
          this.Velocity = 0.0f;
          this.PortraitPositionXOverride = new float?();
          this.PortraitPositionYOverride = new float?();
          this.CustomTexturePath = (string) null;
        }
      }
    }
  }
}
