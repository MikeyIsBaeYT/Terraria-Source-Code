// Decompiled with JetBrains decompiler
// Type: Terraria.Lang
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria
{
  internal class Lang
  {
    public static int lang = 0;
    public static string[] misc = new string[20];
    public static string[] menu = new string[106];
    public static string[] gen = new string[60];
    public static string[] inter = new string[55];
    public static string[] tip = new string[52];
    public static string[] mp = new string[21];
    public static string[] dt = new string[2];
    public static string the;

    public static string dialog(int l)
    {
      string str1 = Main.chrName[18];
      string str2 = Main.chrName[17];
      string str3 = Main.chrName[19];
      string str4 = Main.chrName[20];
      string str5 = Main.chrName[38];
      string str6 = Main.chrName[54];
      string str7 = Main.chrName[22];
      string str8 = Main.chrName[108];
      string str9 = Main.chrName[107];
      string str10 = Main.chrName[124];
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 1:
            return "I hope a scrawny kid like you isn't all that is standing between us and Cthulu's Eye.";
          case 2:
            return "Look at that shoddy armor you're wearing. Better buy some more healing potions.";
          case 3:
            return "I feel like an evil presence is watching me.";
          case 4:
            return "Sword beats paper! Get one today.";
          case 5:
            return "You want apples? You want carrots? You want pineapples? We got torches.";
          case 6:
            return "Lovely morning, wouldn't you say? Was there something you needed?";
          case 7:
            return "Night will be upon us soon, friend. Make your choices while you can.";
          case 8:
            return "You have no idea how much Dirt Blocks sell for overseas.";
          case 9:
            return "Ah, they will tell tales of " + Main.player[Main.myPlayer].name + " some day... good ones I'm sure.";
          case 10:
            return "Check out my dirt blocks; they are extra dirty.";
          case 11:
            return "Boy, that sun is hot! I do have some perfectly ventilated armor.";
          case 12:
            return "The sun is high, but my prices are not.";
          case 13:
            return "Oh, great. I can hear " + str10 + " and " + str1 + " arguing from here.";
          case 14:
            return "Have you seen Chith...Shith.. Chat... The big eye?";
          case 15:
            return "Hey, this house is secure, right? Right? " + Main.player[Main.myPlayer].name + "?";
          case 16:
            return "Not even a blood moon can stop capitalism. Let's do some business.";
          case 17:
            return "Keep your eye on the prize, buy a lense!";
          case 18:
            return "Kosh, kapleck Mog. Oh sorry, that's klingon for 'Buy something or die.'";
          case 19:
            return Main.player[Main.myPlayer].name + " is it? I've heard good things, friend!";
          case 20:
            return "I hear there's a secret treasure... oh never mind.";
          case 21:
            return "Angel Statue you say? I'm sorry, I'm not a junk dealer.";
          case 22:
            return "The last guy who was here left me some junk... er I mean... treasures!";
          case 23:
            return "I wonder if the moon is made of cheese...huh, what? Oh yes, buy something!";
          case 24:
            return "Did you say gold?  I'll take that off of ya.";
          case 25:
            return "You better not get blood on me.";
          case 26:
            return "Hurry up and stop bleeding.";
          case 27:
            return "If you're going to die, do it outside.";
          case 28:
            return "What is that supposed to mean?!";
          case 29:
            return "I don't think I like your tone.";
          case 30:
            return "Why are you even here? If you aren't bleeding, you don't need to be here. Get out.";
          case 31:
            return "WHAT?!";
          case 32:
            return "Have you seen that old man pacing around the dungeon? He looks troubled.";
          case 33:
            return "I wish " + str5 + " would be more careful.  I'm getting tired of having to sew his limbs back on every day.";
          case 34:
            return "Hey, has " + str3 + " mentioned needing to go to the doctor for any reason? Just wondering.";
          case 35:
            return "I need to have a serious talk with " + str7 + ". How many times a week can you come in with severe lava burns?";
          case 36:
            return "I think you look better this way.";
          case 37:
            return "Eww... What happened to your face?";
          case 38:
            return "MY GOODNESS! I'm good, but I'm not THAT good.";
          case 39:
            return "Dear friends we are gathered here today to bid farewell... Oh, you'll be fine.";
          case 40:
            return "You left your arm over there. Let me get that for you...";
          case 41:
            return "Quit being such a baby! I've seen worse.";
          case 42:
            return "That's gonna need stitches!";
          case 43:
            return "Trouble with those bullies again?";
          case 44:
            return "Hold on, I've got some cartoon bandages around here somewhere.";
          case 45:
            return "Walk it off, " + Main.player[Main.myPlayer].name + ", you'll be fine. Sheesh.";
          case 46:
            return "Does it hurt when you do that? Don't do that.";
          case 47:
            return "You look half digested. Have you been chasing slimes again?";
          case 48:
            return "Turn your head and cough.";
          case 49:
            return "That's not the biggest I've ever seen... Yes, I've seen bigger wounds for sure.";
          case 50:
            return "Would you like a lollipop?";
          case 51:
            return "Show me where it hurts.";
          case 52:
            return "I'm sorry, but you can't afford me.";
          case 53:
            return "I'm gonna need more gold than that.";
          case 54:
            return "I don't work for free you know.";
          case 55:
            return "I don't give happy endings.";
          case 56:
            return "I can't do anymore for you without plastic surgery.";
          case 57:
            return "Quit wasting my time.";
          case 58:
            return "I heard there is a doll that looks very similar to " + str7 + " somewhere in the underworld.  I'd like to put a few rounds in it.";
          case 59:
            return "Make it quick! I've got a date with " + str1 + " in an hour.";
          case 60:
            return "I want what " + str1 + " is sellin'. What do you mean, she doesn't sell anything?";
          case 61:
            return str4 + " is a looker.  Too bad she's such a prude.";
          case 62:
            return "Don't bother with " + str5 + ", I've got all you need right here.";
          case 63:
            return "What's " + str5 + "'s problem? Does he even realize we sell completely different stuff?";
          case 64:
            return "Man, it's a good night not to talk to anybody, don't you think, " + Main.player[Main.myPlayer].name + "?";
          case 65:
            return "I love nights like tonight.  There is never a shortage of things to kill!";
          case 66:
            return "I see you're eyeballin' the Minishark.. You really don't want to know how it was made.";
          case 67:
            return "Hey, this ain't a movie, pal. Ammo is extra.";
          case 68:
            return "Keep your hands off my gun, buddy!";
          case 69:
            return "Have you tried using purification powder on the ebonstone of the corruption?";
          case 70:
            return "I wish " + str3 + " would stop flirting with me. Doesn't he realize I'm 500 years old?";
          case 71:
            return "Why does " + str2 + " keep trying to sell me an angel statues? Everyone knows that they don't do anything.";
          case 72:
            return "Have you seen the old man walking around the dungeon? He doesn't look well at all...";
          case 73:
            return "I sell what I want! If you don't like it, too bad.";
          case 74:
            return "Why do you have to be so confrontational during a time like this?";
          case 75:
            return "I don't want you to buy my stuff. I want you to want to buy my stuff, ok?";
          case 76:
            return "Dude, is it just me or is there like a million zombies out tonight?";
          case 77:
            return "You must cleanse the world of this corruption.";
          case 78:
            return "Be safe; Terraria needs you!";
          case 79:
            return "The sands of time are flowing. And well, you are not aging very gracefully.";
          case 80:
            return "What's this about me having more 'bark' than bite?";
          case 81:
            return "So two goblins walk into a bar, and one says to the other, 'Want to get a Goblet of beer?!";
          case 82:
            return "I cannot let you enter until you free me of my curse.";
          case 83:
            return "Come back at night if you wish to enter.";
          case 84:
            return "My master cannot be summoned under the light of day.";
          case 85:
            return "You are far too weak to defeat my curse.  Come back when you aren't so worthless.";
          case 86:
            return "You pathetic fool.  You cannot hope to face my master as you are now.";
          case 87:
            return "I hope you have like six friends standing around behind you.";
          case 88:
            return "Please, no, stranger. You'll only get yourself killed.";
          case 89:
            return "You just might be strong enough to free me from my curse...";
          case 90:
            return "Stranger, do you possess the strength to defeat my master?";
          case 91:
            return "Please! Battle my captor and free me! I beg you!";
          case 92:
            return "Defeat my master, and I will grant you passage into the Dungeon.";
          case 93:
            return "Trying to get past that ebonrock, eh?  Why not introduce it to one of these explosives!";
          case 94:
            return "Hey, have you seen a clown around?";
          case 95:
            return "There was a bomb sitting right here, and now I can't seem to find it...";
          case 96:
            return "I've got something for them zombies alright!";
          case 97:
            return "Even " + str3 + " wants what I'm selling!";
          case 98:
            return "Would you rather have a bullet hole or a grenade hole? That's what I thought.";
          case 99:
            return "I'm sure " + str1 + " will help if you accidentally lose a limb to these.";
          case 100:
            return "Why purify the world when you can just blow it up?";
          case 101:
            return "If you throw this one in the bathtub and close all the windows, it'll clear your sinuses and pop your ears!";
          case 102:
            return "Wanna play Fuse Chicken?";
          case 103:
            return "Hey, could you sign this Griefing Waiver?";
          case 104:
            return "NO SMOKING IN HERE!!";
          case 105:
            return "Explosives are da' bomb these days.  Buy some now!";
          case 106:
            return "It's a good day to die!";
          case 107:
            return "I wonder what happens if I... (BOOM!)... Oh, sorry, did you need that leg?";
          case 108:
            return "Dynamite, my own special cure-all for what ails ya.";
          case 109:
            return "Check out my goods; they have explosive prices!";
          case 110:
            return "I keep having vague memories of tying up a woman and throwing her in a dungeon.";
          case 111:
            return "... we have a problem! Its a blood moon out there!";
          case 112:
            return "T'were I younger, I would ask " + str1 + " out. I used to be quite the lady killer.";
          case 113:
            return "That Red Hat of yours looks familiar...";
          case 114:
            return "Thanks again for freeing me from my curse. Felt like something jumped up and bit me.";
          case 115:
            return "Mama always said I would make a great tailor.";
          case 116:
            return "Life's like a box of clothes; you never know what you are gonna wear!";
          case 117:
            return "Of course embroidery is hard! If it wasn't hard, no one would do it! That's what makes it great.";
          case 118:
            return "I know everything they is to know about the clothierin' business.";
          case 119:
            return "Being cursed was lonely, so I once made a friend out of leather. I named him Wilson.";
          case 120:
            return "Thank you for freeing me, human.  I was tied up and left here by the other goblins.  You could say that we didn't get along very well.";
          case 121:
            return "I can't believe they tied me up and left me here just for pointing out that they weren't going east!";
          case 122:
            return "Now that I'm an outcast, can I throw away the spiked balls? My pockets hurt.";
          case 123:
            return "Looking for a gadgets expert? I'm your goblin!";
          case 124:
            return "Thanks for your help. Now, I have to finish pacing around aimlessly here. I'm sure we'll meet again.";
          case 125:
            return "I thought you'd be taller.";
          case 126:
            return "Hey...what's " + str10 + " up to? Have you...have you talked to her, by chance?";
          case (int) sbyte.MaxValue:
            return "Hey, does your hat need a motor? I think I have a motor that would fit exactly in that hat.";
          case 128:
            return "Yo, I heard you like rockets and running boots, so I put some rockets in your running boots.";
          case 129:
            return "Silence is golden. Duct tape is silver.";
          case 130:
            return "YES, gold is stronger than iron. What are they teaching these humans nowadays?";
          case 131:
            return "You know, that mining helmet-flipper combination was a much better idea on paper.";
          case 132:
            return "Goblins are surprisingly easy to anger. In fact, they could start a war over cloth!";
          case 133:
            return "To be honest, most goblins aren't exactly rocket scientists. Well, some are.";
          case 134:
            return "Do you know why we all carry around these spiked balls? Because I don't.";
          case 135:
            return "I just finished my newest creation! This version doesn't explode violently if you breathe on it too hard.";
          case 136:
            return "Goblin thieves aren't very good at their job. They can't even steal from an unlocked chest!";
          case 137:
            return "Thanks for saving me, friend!  This bondage was starting to chafe.";
          case 138:
            return "Ohh, my hero!";
          case 139:
            return "Oh, how heroic! Thank you for saving me, young lady!";
          case 140:
            return "Oh, how heroic! Thank you for saving me, young man!";
          case 141:
            return "Now that we know each other, I can move in with you, right?";
          case 142:
            return "Well, hi there, " + str7 + "! What can I do for you today?";
          case 143:
            return "Well, hi there, " + str5 + "! What can I do for you today?";
          case 144:
            return "Well, hi there, " + str9 + "! What can I do for you today?";
          case 145:
            return "Well, hi there, " + str1 + "! What can I do for you today?";
          case 146:
            return "Well, hi there, " + str10 + "! What can I do for you today?";
          case 147:
            return "Well, hi there, " + str4 + "! What can I do for you today?";
          case 148:
            return "Want me to pull a coin from behind your ear? No? Ok.";
          case 149:
            return "Do you want some magic candy? No? Ok.";
          case 150:
            return "I make a rather enchanting hot chocolate if you'd be inter...No? Ok.";
          case 151:
            return "Are you here for a peek at my crystal ball?";
          case 152:
            return "Ever wanted an enchanted ring that turns rocks into slimes? Well neither did I.";
          case 153:
            return "Someone once told me friendship is magic. That's ridiculous. You can't turn people into frogs with friendship.";
          case 154:
            return "I can see your future now... You will buy a lot of items from me!";
          case 155:
            return "I once tried to bring an Angel Statue to life. It didn't do anything.";
          case 156:
            return "Thanks!  It was just a matter of time before I ended up like the rest of the skeletons down here.";
          case 157:
            return "Hey, watch where you're going! I was over there a little while ago!";
          case 158:
            return "Hold on, I've almost got wifi going down here.";
          case 159:
            return "But I was almost done putting blinking lights up here!";
          case 160:
            return "DON'T MOVE. I DROPPED MY CONTACT.";
          case 161:
            return "All I want is for the switch to make the... What?!";
          case 162:
            return "Oh, let me guess. Didn't buy enough wire. Idiot.";
          case 163:
            return "Just-could you just... Please? Ok? Ok. Ugh.";
          case 164:
            return "I don't appreciate the way you're looking at me. I am WORKING right now.";
          case 165:
            return "Hey, " + Main.player[Main.myPlayer].name + ", did you just come from " + str9 + "'s? Did he say anything about me by chance?";
          case 166:
            return str3 + " keeps talking about pressing my pressure plate. I told him it was for stepping on.";
          case 167:
            return "Always buy more wire than you need!";
          case 168:
            return "Did you make sure your device was plugged in?";
          case 169:
            return "Oh, you know what this house needs? More blinking lights.";
          case 170:
            return "You can tell a Blood Moon is out when the sky turns red. There is something about it that causes monsters to swarm.";
          case 171:
            return "Hey, buddy, do you know where any deathweed is? Oh, no reason; just wondering, is all.";
          case 172:
            return "If you were to look up, you'd see that the moon is red right now.";
          case 173:
            return "You should stay indoors at night. It is very dangerous to be wandering around in the dark.";
          case 174:
            return "Greetings, " + Main.player[Main.myPlayer].name + ". Is there something I can help you with?";
          case 175:
            return "I am here to give you advice on what to do next.  It is recommended that you talk with me anytime you get stuck.";
          case 176:
            return "They say there is a person who will tell you how to survive in this land... oh wait. That's me.";
          case 177:
            return "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and click!";
          case 178:
            return "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
          case 179:
            return "Press ESC to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
          case 180:
            return "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
          case 181:
            return "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
          case 182:
            return "To interact with backgrounds and placed objects, use a hammer!";
          case 183:
            return "You should do some mining to find metal ore. You can craft very useful things with it.";
          case 184:
            return "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
          case 185:
            return "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
          case 186:
            return "You will need an anvil to make most things out of metal bars.";
          case 187:
            return "Anvils can be crafted out of iron, or purchased from a merchant.";
          case 188:
            return "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
          case 189:
            return "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
          case 190:
            return "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
          case 191:
            return "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
          case 192:
            return "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
          case 193:
            return "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
          case 194:
            return "You can use the housing interface to assign and view housing. Open you inventory and click the house icon.";
          case 195:
            return "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
          case 196:
            return "For a nurse to move in, you might want to increase your maximum life.";
          case 197:
            return "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
          case 198:
            return "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
          case 199:
            return "Make sure to explore the dungeon thoroughly. There may be prisoners held deep within.";
          case 200:
            return "Perhaps the old man by the dungeon would like to join us now that his curse has been lifted.";
          case 201:
            return "Hang on to any bombs you might find. A demolitionist may want to have a look at them.";
          case 202:
            return "Are goblins really so different from us that we couldn't live together peacefully?";
          case 203:
            return "I heard there was a powerfully wizard who lives in these parts.  Make sure to keep an eye out for him next time you go underground.";
          case 204:
            return "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
          case 205:
            return "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
          case 206:
            return "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
          case 207:
            return "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
          case 208:
            return "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
          case 209:
            return "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
          case 210:
            return "Smashing a shadow orb will sometimes cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
          case 211:
            return "You should focus on gathering more heart crystals to increase your maximum life.";
          case 212:
            return "Your current equipment simply won't do. You need to make better armor.";
          case 213:
            return "I think you are ready for your first major battle. Gather some lenses from the eyeballs at night and take them to a demon altar.";
          case 214:
            return "You will want to increase your life before facing your next challenge. Fifteen hearts should be enough.";
          case 215:
            return "The ebonstone in the corruption can be purified using some powder from a dryad, or it can be destroyed with explosives.";
          case 216:
            return "Your next step should be to explore the corrupt chasms.  Find and destroy any shadow orb you find.";
          case 217:
            return "There is a old dungeon not far from here. Now would be a good time to go check it out.";
          case 218:
            return "You should make an attempt to max out your available life. Try to gather twenty hearts.";
          case 219:
            return "There are many treasures to be discovered in the jungle, if you are willing to dig deep enough.";
          case 220:
            return "The underworld is made of a material called hellstone. It's perfect for making weapons and armor.";
          case 221:
            return "When you are ready to challenge the keeper of the underworld, you will have to make a living sacrifice. Everything you need for it can be found in the underworld.";
          case 222:
            return "Make sure to smash any demon altar you can find. Something good is bound to happen if you do!";
          case 223:
            return "Souls can sometimes be gathered from fallen creatures in places of extreme light or dark.";
          case 224:
            return "Ho ho ho, and a bottle of... Egg Nog!";
          case 225:
            return "Care to bake me some cookies?";
          case 226:
            return "What? You thought I wasn't real?";
          case 227:
            return "I managed to sew your face back on. Be more careful next time.";
          case 228:
            return "That's probably going to leave a scar.";
          case 229:
            return "All better. I don't want to see you jumping off anymore cliffs.";
          case 230:
            return "That didn't hurt too bad, now did it?";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 1:
            return "Ich hoffe, du duennes Hemd bist nicht das Einzige, was zwischen Chtulus Auge und uns steht.";
          case 2:
            return "Was fuer eine schaebige Ruestung du traegst. Kaufe lieber ein paar Heiltraenke.";
          case 3:
            return "Ich habe das Gefuehl, dass mich eine boese Kraft beobachtet.";
          case 4:
            return "Schwert schlaegt Papier! Hol dir noch heute eins.";
          case 5:
            return "Du moechtest Aepfel? Du willst Karotten? Ananas? Wir haben Fackeln.";
          case 6:
            return "Ein schoener Morgen, nicht wahr? War da noch was, was du brauchst?";
          case 7:
            return "Die Nacht wird bald hereinbrechen. Entscheide dich, solange du kannst.";
          case 8:
            return "Du hast keine Ahnung, wie gut sich Dreckbloecke nach Uebersee verkaufen.";
          case 9:
            return "Ach, eines Tages werden sie Geschichten ueber" + Main.player[Main.myPlayer].name + " erzaehlen ... sicher gute";
          case 10:
            return "Schau dir mal meine Schmutzbloecke an; die sind wirklich super-dreckig.";
          case 11:
            return "Junge, Junge, wie die Sonne brennt! Ich hab da eine tolle klimatisierte Ruestung.";
          case 12:
            return "Die Sonne steht zwar hoch, meine Preise sind's aber nicht.";
          case 13:
            return "Toll. Ich kann " + str10 + " und " + str1 + " von hier aus diskutieren hoeren.";
          case 14:
            return "Hast du Chith ... Shith.. Chat... Das grosse Auge gesehen?";
          case 15:
            return "Heh, dieses Haus ist doch wohl sicher? Oder? " + Main.player[Main.myPlayer].name + "?";
          case 16:
            return "Nicht mal ein Blutmond kann den Kapitalismus stoppen. Lass uns also Geschaefte machen.";
          case 17:
            return "Achte auf den Preis, kaufe eine Linse!";
          case 18:
            return "Kosh, kapleck Mog. Oha, sorry. Das ist klingonisch fuer: Kauf oder stirb!";
          case 19:
            return Main.player[Main.myPlayer].name + " ist es? Ich habe nur Gutes ueber dich gehoert!";
          case 20:
            return "Ich hoerte, es gibt einen geheimen Schatz ... oh, vergiss es!";
          case 21:
            return "Engelsstatue, sagst du? Tut mir Leid, ich bin kein Nippesverkaeufer.";
          case 22:
            return "Der letzte Typ, der hier war, hinterliess mir einigen Nippes, aeh, ... Schaetze!";
          case 23:
            return "Ich frage mich, ob der Mond aus Kaese ist ... huch, was? Oh, ja, kauf etwas!";
          case 24:
            return "Hast du Gold gesagt? Ich nehm dir das ab.";
          case 25:
            return "Blute mich bloss nicht voll!";
          case 26:
            return "Mach schon und hoer mit dem Bluten auf!";
          case 27:
            return "Wenn du stirbst, dann bitte draussen.";
          case 28:
            return "Was soll das heissen?!";
          case 29:
            return "Irgendwie gefaellt mir dein Ton nicht.";
          case 30:
            return "Warum bist du ueberhaupt hier? Wenn du nicht blutest, gehoerst du nicht her. Raus jetzt!";
          case 31:
            return "WAS?!";
          case 32:
            return "Hast du den Greis um den Dungeon schreiten sehen? Der scheint Probleme zu haben.";
          case 33:
            return "Ich wuenschte, " + str5 + " waere vorsichtiger. Es nervt mich, taeglich seine Glieder zusammennaehen zu muessen.";
          case 34:
            return "Heh, hat " + str3 + " den Grund fuer einen notwendigen Arztbesuch erwaehnt? Ich wundere mich nur.";
          case 35:
            return "Ich muss mal ein ernsthaftes Wort mit  " + str7 + " reden. Wie oft kann man in einer Woche mit schweren Lava-Verbrennungen hereinkommen?";
          case 36:
            return "Ich finde, du siehst so besser aus.";
          case 37:
            return "Aehhh ... Was ist denn mit deinem Gesicht passiert?";
          case 38:
            return "MEINE GUeTE! Ich bin gut, aber ich bin nicht SO gut.";
          case 39:
            return "Liebe Freunde, wir sind zusammengekommen, um Aufwiedersehen zu sagen ... Ach, es wird schon werden.";
          case 40:
            return "Du hast deinen Arm da drueben gelassen. Lass ihn mich holen ...";
          case 41:
            return "Hoer schon auf, wie ein Baby zu plaerren! Ich habe Schlimmeres gesehen.";
          case 42:
            return "Das geht nicht ohne ein paar Stiche!";
          case 43:
            return "Schon wieder Aerger mit diesen Rabauken?";
          case 44:
            return "Halt aus. Ich hab hier irgendwo ein paar huebsch bedruckte Pflaster.";
          case 45:
            return "Hoer schon auf, " + Main.player[Main.myPlayer].name + ", du ueberstehst das schon. Mist.";
          case 46:
            return "Tut es weh, wenn ich das mache? Tu das nicht.";
          case 47:
            return "Du siehst halb verdaut aus. Hast du schon wieder Schleimis gejagt?";
          case 48:
            return "Drehe deinen Kopf und huste!";
          case 49:
            return "Ich habe schon Schlimmeres gesehen ... ja, ganz sicher habe ich schon groessere Wunden gesehen.";
          case 50:
            return "Moechtest du einen Lollipop?";
          case 51:
            return "Zeig mir, wo es schmerzt.";
          case 52:
            return "Tut mir Leid, aber du kannst mich dir gar nicht leisten.";
          case 53:
            return "Dafuer brauche ich mehr Gold.";
          case 54:
            return "Ich arbeite schliesslich nicht umsonst.";
          case 55:
            return "Ich verschenke keine Happy-Ends.";
          case 56:
            return "Ich kann nicht mehr fuer dich tun ohne Schoenheitsoperation.";
          case 57:
            return "Verschwende meine Zeit nicht laenger!";
          case 58:
            return "Ich habe gehoert, es gibt eine Puppe in der Unterwelt, die " + str7 + " sehr aehnlich sieht. Ich wuerde gern ein bisschen schiessen.";
          case 59:
            return "Mach schnell! Ich habe in einer Stunde ein Date mit " + str1 + ".";
          case 60:
            return "Ich moechte das, was " + str1 + "  verkauft. Was heisst, sie verkauft nichts?";
          case 61:
            return str4 + " ist ein Huebscher. Zu dumm, dass sie so pruede ist.";
          case 62:
            return "Halte dich nicht mit " + str5 + " auf, ich habe alles, was du brauchst hier.";
          case 63:
            return "Was ist eigentlich mit " + str5 + " los? Kriegt der mal mit, dass wir ganz andere Sachen verkaufen?";
          case 64:
            return "Das ist eine gute Nacht, um mit niemandem zu sprechen, denkst du nicht, " + Main.player[Main.myPlayer].name + "?";
          case 65:
            return "Ich liebe Naechte wie diese. Es gibt immer genug zu toeten!";
          case 66:
            return "Wie ich sehe, starrst du den Minihai an ... Du solltest lieber nicht fragen, wie der entstand.";
          case 67:
            return "Moment, das ist kein Film, Freundchen. Munition geht extra.";
          case 68:
            return "Haende weg von meinem Gewehr, Kumpel!";
          case 69:
            return "Hast du versucht, das Reinigungspulver auf dem Ebenstein des Verderbens auszuprobieren?";
          case 70:
            return "Ich wuenschte,  " + str3 + " wuerde die Flirterei lassen. Versteht er nicht, dass ich 500 Jahre alt bin?";
          case 71:
            return "Warum versucht " + str2 + " , mir Engelsstatuen zu verkaufen? Jeder weiss, dass sie nutzlos sind.";
          case 72:
            return "Hast du den Greis um den Dungeon herumgehen sehen? Der sieht gar nicht gut aus ...";
          case 73:
            return "Ich verkaufe, was ich will! Dein Pech, wenn du es nicht magst.";
          case 74:
            return "Warum bist du in einer Zeit wie dieser so aggressiv?";
          case 75:
            return "Ich moechte nicht, dass du meine Sachen kaufst, sondern dass du dir wuenschst, sie zu kaufen.";
          case 76:
            return "Kommt es mir nur so vor oder sind heute Nacht eine Million Zombies draussen?";
          case 77:
            return "Du musst die Welt von diesem Verderben befreien.";
          case 78:
            return "Verlass dich darauf, Terraria braucht dich!";
          case 79:
            return "Der Zahn der Zeit nagt und du alterst nicht gerade wuerdevoll.";
          case 80:
            return "Was soll das heissen: Ich belle mehr als ich beisse?";
          case 81:
            return "Zwei Goblins kommen in einen Stoffladen. Sagt der eine zum anderen: Sitzt du gerne auf Gobelin?";
          case 82:
            return "Ich kann dich nicht hineinlassen, bevor du mich von meinem Fluch befreit hast.";
          case 83:
            return "Komm in der Nacht wieder, wenn du hinein willst.";
          case 84:
            return "Mein Meister kann nicht bei Tageslicht herbeigerufen werden.";
          case 85:
            return "Du bist viel zu schwach, um meinen Fluch zu brechen. Komm wieder, wenn du was aus dir gemacht hast.";
          case 86:
            return "Du armseliger Wicht. So kannst du meinem Meister nicht gegenuebertreten.";
          case 87:
            return "Ich hoffe, du hast mindestens sechs Freunde, die hinter dir stehen.";
          case 88:
            return "Bitte nicht, Fremdling. Du bringst dich nur selbst um.";
          case 89:
            return "Du koenntest tatsaechlich stark genug sein, um meinen Fluch aufzuheben ...";
          case 90:
            return "Fremdling, hast du die Kraft, meinen Meister zu besiegen?";
          case 91:
            return "Bitte! Bezwinge meinen Kerkermeister und befreie mich! Ich flehe dich an!";
          case 92:
            return "Besiege meinen Meister und ich gewaehre dir den Zutritt in den Dungeon.";
          case 93:
            return "Du versuchst, den Ebenstein in den Griff zu kriegen? Warum fuehrst du ihn nicht  mit diesen Explosiva zusammen?";
          case 94:
            return "Heh, hast du hier in der Gegend einen Clown gesehen?";
          case 95:
            return "Genau hier war doch eine Bombe und jetzt kann ich sie nicht finden ...";
          case 96:
            return "Ich habe etwas fuer diese Zombies!";
          case 97:
            return "Sogar " + str3 + " ist scharf auf meine Waren!";
          case 98:
            return "Haettest du lieber das Einschussloch eines Gewehrs oder einer Granate? Das dachte ich mir.";
          case 99:
            return "Ich bin sicher, dass " + str1 + " dir helfen wird, wenn du versehentlich ein Glied verlierst.";
          case 100:
            return "Warum willst du die Welt reinigen, wenn du sie einfach in die Luft jagen kannst?";
          case 101:
            return "Wenn du das hier in die Badewanne schmeisst und alle Fenster schliesst, durchpustet es deine Nasenhoehlen und  dir fliegen die Ohren weg!";
          case 102:
            return "Moechtest du mal Grillhaehnchen spielen?";
          case 103:
            return "Koenntest du hier unterschreiben, dass du nicht jammern wirst?";
          case 104:
            return "RAUCHEN IST HIER NICHT ERLAUBT!!";
          case 105:
            return "Explosiva sind zur Zeit der Knaller. Kaufe dir jetzt welche!";
          case 106:
            return "Ein schoener Tag, um zu sterben!";
          case 107:
            return "Ich frage mich, was passiert, wenn ich ... (BUMM!) ... Oha, sorry, brauchtest du dieses Bein noch?";
          case 108:
            return "Dynamit, mein ganz spezielles Heilmittelchen - fuer alles, was schmerzt.";
          case 109:
            return "Schau dir meine Waren an - mit hochexplosiven Preisen!";
          case 110:
            return "Ich erinnere mich vage an eine Frau, die ich fesselte und in den Dungeon warf.";
          case 111:
            return "... wir haben ein Problem! Es ist Blutmond!";
          case 112:
            return "Wenn ich juenger waere, wuerde ich mit " + str1 + " ausgehen wollen. Ich war mal ein Womanizer.";
          case 113:
            return "Dein roter Hut kommt mir bekannt vor ...";
          case 114:
            return "Danke nochmals, dass du mich vom Fluch befreit hast. Es fuehlte sich an, als wenn mich etwas angesprungen und gebissen hat.";
          case 115:
            return "Mama sagte immer, dass ich einen guten Schneider abgeben wuerde.";
          case 116:
            return "Das Leben ist wie ein Kleiderschrank; du weisst nie, was du tragen wirst!";
          case 117:
            return "Natuerlich ist die Stickerei schwierig! Wenn es nicht schwierig waere, wuerde es niemand machen! Das macht es so grossartig.";
          case 118:
            return "Ich weiss alles, was man ueber das Kleidergeschaeft wissen muss.";
          case 119:
            return "Das Leben mit dem Fluch war einsam, deshalb fertigte ich mir aus Leder einen Freund. Ich nannte ihn Wilson.";
          case 120:
            return "Danke fuer die Befreiung, Mensch. Ich wurde gefesselt und von den anderen Goblins hier zurueckgelassen. Man kann sagen, dass wir nicht besonders gut miteinander auskamen.";
          case 121:
            return "Ich kann nicht glauben, dass sie mich fesselten und hier liessen, nur um anzuzeigen, dass sie nicht nach Osten gehen.";
          case 122:
            return "Nun da ich zu den Verstossenen gehoere, darf ich doch meine Stachelkugeln wegwerfen? Es piekt durch die Taschen.";
          case 123:
            return "Suchst du einen Bastelexperten? Dann bin ich dein Goblin!";
          case 124:
            return "Danke fuer deine Hilfe. Jetzt muss ich erst mal aufhoeren, hier ziellos herumzuschreiten. Wir begegnen uns sicher wieder.";
          case 125:
            return "Ich hielt dich fuer groesser.";
          case 126:
            return "Heh ... was macht " + str10 + " so? Hast du ... hast du vielleicht mit ihr gesprochen?";
          case (int) sbyte.MaxValue:
            return "Waer ein Motor fuer deinen Hut nicht schick? Ich glaube, ich habe einen Motor, der genau hineinpasst.";
          case 128:
            return "Ja, ich hab schon gehoert, dass du Raketen und Laufstiefel magst. Deshalb habe ich ein paar Raketen in deine Laufstiefel montiert.";
          case 129:
            return "Schweigen ist Gold. Klebeband ist Silber.";
          case 130:
            return "Ja! Gold ist staerker als Eisen. Was bringt man den Menschen heutzutage eigentlich bei?";
          case 131:
            return "Diese Helm-Flossen-Kombination sah auf dem Papier viel besser aus.";
          case 132:
            return "Goblins kann man erstaunlich leicht auf die Palme bringen. Die wuerden sogar wegen Kleidern einen Krieg anfangen.";
          case 133:
            return "Um die Wahrheit zu sagen, Goblins sind nicht gerade Genies oder Astroforscher. Aber einige schon.";
          case 134:
            return "Weisst du eigentlich, warum wir alle diese Stachelkugeln mit uns herumtragen? Ich weiss es jedenfalls nicht.";
          case 135:
            return "Meine neuste Erfindung ist fertig! Diese Version explodiert nicht, wenn du sie  heftig anhauchst.";
          case 136:
            return "Goblin-Diebe sind nicht besonders gut in ihrem Job. Sie koennen nicht mal aus einer unverschlossenen Truhe klauen.";
          case 137:
            return "Danke fuer die Rettung, mein Freund! Die Fesseln fingen an, zu scheuern.";
          case 138:
            return "Oh, mein Held!";
          case 139:
            return "Oh, wie heroisch! Danke fuer die Rettung, Lady!";
          case 140:
            return "Oh, wie heroisch! Danke fuer die Rettung, mein Herr!";
          case 141:
            return "Nun da wir uns kennen, kann ich doch bei dir einziehen?";
          case 142:
            return "Hallo, " + str7 + "! Was kann ich heute fuer dich tun?";
          case 143:
            return "Hallo, " + str5 + "! Was kann ich heute fuer dich tun?";
          case 144:
            return "Hallo, " + str9 + "! Was kann ich heute fuer dich tun?";
          case 145:
            return "Hallo, " + str1 + "! Was kann ich heute fuer dich tun?";
          case 146:
            return "Hallo, " + str10 + "! Was kann ich heute fuer dich tun?";
          case 147:
            return "Hallo, " + str4 + "! Was kann ich heute fuer dich tun?";
          case 148:
            return "Moechtest du, dass ich eine Muenze hinter deinem Ohr hervorziehe? Nein? Gut.";
          case 149:
            return "Moechtest du vielleicht magische Suessigkeiten? Nein? Gut.";
          case 150:
            return "Ich braue eine heisse Zauber-Schokolade, wenn du inter ... Nein? Gut.";
          case 151:
            return "Bist du hier, um einen Blick in meine Kristallkugel zu werfen?";
          case 152:
            return "Hast du dir je einen verzauberten Ring gewuenscht, der Steine in Schleimis verwandelt? Ich auch nicht.";
          case 153:
            return "Jemand sagte mir mal, Freundschaft sei magisch. Das ist laecherlich. Du kannst mit Freundschaft nicht Menschen in Froesche verwandeln.";
          case 154:
            return "Jetzt kann ich deine Zukunft sehen ... Du wirst mir eine Menge Items abkaufen!";
          case 155:
            return "Ich habe mal versucht, eine Engelsstatue zu beleben. Hat ueberhaupt nichts gebracht!";
          case 156:
            return "Danke! Es waere nur eine Frage Zeit gewesen, bis aus mir eines der Skelette hier geworden waere.";
          case 157:
            return "Pass auf, wo du hingehst! Ich war vor einer Weile dort drueben.";
          case 158:
            return "Warte, ich habe es fast geschafft, hier unten Wifi zu installieren.";
          case 159:
            return "Aber ich habe es fast geschafft, hier oben blinkende Lichter anzubringen.";
          case 160:
            return "BEWEGE DICH NICHT. ICH HABE MEINE KONTAKTLINSE VERLOREN.";
          case 161:
            return "Ich moechte nur den Schalter ... Was?!";
          case 162:
            return "Oh, lass mich raten. Nicht genuegend Kabel gekauft, Idiot.";
          case 163:
            return "Koenntest du vielleicht ... bitte? Ja? Gut. Uff!";
          case 164:
            return "Mir gefaellt nicht, wie du mich anschaust. Ich ARBEITE gerade.";
          case 165:
            return "Sag, " + Main.player[Main.myPlayer].name + ", kommst du gerade von " + str9 + "? Hat er vielleicht etwas ueber mich gesagt?";
          case 166:
            return str3 + " spricht immer davon, auf meine Druckplatten zu druecken. Ich habe ihm gesagt, die ist zum Drauftreten.";
          case 167:
            return "Kaufe immer etwas mehr Kabel als benoetigt!";
          case 168:
            return "Hast du dich vergewissert, dass dein Geraet angeschlossen ist?";
          case 169:
            return "Oh, weisst du was dieses Haus noch braucht? Mehr blinkende Lichter.";
          case 170:
            return "Du erkennst den Blutmond an der Rotfaerbung des Himmels. Irgendetwas daran laesst Monster ausschwaermen.";
          case 171:
            return "Weisst du vielleicht, wo Todeskraut ist? Nein, es hat keinen Grund. Ich frag  mich das bloss.";
          case 172:
            return "Wenn du mal hochschauen wuerdest, wuerdest du bemerken, dass der Mond rot ist.";
          case 173:
            return "Du solltest in der Nacht drinnen bleiben. Es ist sehr gefaehrlich, in der Dunkelheit umherzustreifen.";
          case 174:
            return "Sei gegruesst, " + Main.player[Main.myPlayer].name + ". Gibt es etwas, das ich fuer dich tun kann?";
          case 175:
            return "Ich bin hier, um dir zu raten, was du als Naechstes tust. Du solltest immer zu mir kommen, wenn du feststeckst.";
          case 176:
            return "Man sagt, es gibt jemanden, der dir erklaert, wie man in diesem Land ueberlebt ... oh, Moment. Das bin ja ich.";
          case 177:
            return "Du kannst deine Spitzhacke zum Graben im Dreck verwenden und deine Axt zum Holz faellen. Bewege einfach deinen Zeiger ueber das Feld und klicke!";
          case 178:
            return "Wenn du ueberleben willst, musst du Waffen und Zufluchten bauen.  Faelle dazu Baeume und sammele das Holz.";
          case 179:
            return "Druecke ESC zum Aufrufen des Handwerksmenues. Wenn du genuegend Holz hast, stelle eine Werkbank zusammen. Damit kannst du komplexere Sachen herstellen, solange du nahe genug bei ihr   stehst. ";
          case 180:
            return "Du kannst durch Platzieren von Holz oder anderen Bloecken in der Welt eine Zuflucht bauen. Vergiss dabei nicht, auch Waende zu bauen und aufzustellen.";
          case 181:
            return "Wenn du einmal ein Holzschwert hast, kannst du versuchen, etwas Glibber von den Schleimis zu sammeln. Kombiniere Holz und Glibber zur Herstellung einer Fackel.";
          case 182:
            return "Zum Interagieren mit Hintergruenden und platzierten Objekten verwende einen Hammer!";
          case 183:
            return "Du solltest ein bisschen Bergbau betreiben, um Gold zu finden. Du kannst sehr nuetzliche Dinge damit herstellen.";
          case 184:
            return "Jetzt, da du etwas Gold hast, musst du es in einen Barren verwandeln, um damit Items zu erschaffen. Dazu brauchst du einen Hochofen!";
          case 185:
            return "Du kannst einen Hochofen aus Fackeln, Holz und Steinen herstellen. Achte dabei darauf, dass du neben einer Werkbank stehst.";
          case 186:
            return "Zum Herstellen der meisten Sachen aus einem Metallbarren wirst du einen Amboss brauchen.";
          case 187:
            return "Ambosse koennen aus Eisen hergestellt oder von einem Haendler gekauft werden.";
          case 188:
            return "Unterirdisch finden sich Kristallherzen, die verwendet werden koennen, um deine maximale Lebensspanne zu erhoehen. Um sie zu erhalten, benoetigst du einen Hammer.";
          case 189:
            return "Wenn du 10 Sternschnuppen gesammelt hast, koennen sie zur Herstellung eines Items kombiniert werden. Dieses Item erhoeht deine magische Faehigkeit.";
          case 190:
            return "Sterne fallen nachts auf der ganzen Welt herunter. Sie koennen fuer alle moeglichen nuetzlichen Dinge verwendet werden. Wenn du einen erspaeht hast, dann greif ihn dir schnell - sie verschwinden nach Sonnenaufgang.";
          case 191:
            return "Es gibt viele Moeglichkeiten, wie du Menschen dazu bewegen kannst, in unsere Stadt zu ziehen. Sie brauchen zuallererst ein Zuhause.";
          case 192:
            return "Damit ein Raum wie ein Heim wirkt, braucht es eine Tuer, einen Stuhl, einen Tisch und eine Lichtquelle. Achte darauf, dass das Haus auch Waende hat.";
          case 193:
            return "Zwei Menschen werden nicht im selben Haus leben wollen. Ausserdem brauchen sie ein neues Zuhause, wenn ihr Heim zerstoert wurde.";
          case 194:
            return "Du kannst das Behausungsinterface verwenden, um ein Haus zuzuweisen und anzuschauen. Oeffne dein Inventar und klicke auf das Haus-Symbol.";
          case 195:
            return "Wenn du willst, dass ein Haendler einzieht, brauchst du eine Menge Geld. 50 Silbermuenzen sollten aber reichen.";
          case 196:
            return "Damit eine Krankenschwester einzieht, solltest du deine maximale Lebensspanne erhoehen.";
          case 197:
            return "Wenn du ein Gewehr hast, sollte ein Waffenhaendler auftauchen, um dir Munition zu verkaufen.";
          case 198:
            return "Du solltest dich selbst testen, indem du ein starkes Monster besiegst. Das wird die Aufmerksamkeit eines Dryaden erregen.";
          case 199:
            return "Erforsche den Dungeon wirklich sorgfaeltig. Tief unten koennte sich ein Gefangener befinden.";
          case 200:
            return "Vielleicht hat der Greis vom Dungeon Lust, bei uns mitzumachen - jetzt da sein Fluch aufgehoben wurde.";
          case 201:
            return "Behalte alle Bomben, die du findest. Ein Sprengmeister moechte vielleicht einen Blick darauf werfen.";
          case 202:
            return "Sind Goblins wirklich so anders als wir, dass wir nicht in Frieden zusammenleben koennen?";
          case 203:
            return "Ich hoerte, dass ein maechtiger Zauberer in diesen Gebieten lebt. Achte bei deiner naechsten unterirdischen Expedition auf ihn.";
          case 204:
            return "Wenn du Linsen an einem Daemonenaltar kombinieren moechtest, solltest du einen Weg finden koennen, ein maechtiges Monster herbeizurufen. Du solltest jedoch bis zur Nacht warten, bevor du es verwendest.";
          case 205:
            return "Du kannst einen Wurmkoeder mit Verfaultem und Ekelpulver erzeugen. Achte aber darauf, dass du dich vor der Verwendung in einem verderbten Gebiet befindest.";
          case 206:
            return "Daemonenaltaere sind gewoehnlich im Verderben zu finden. Du musst aber nahe bei ihnen stehen, um Items herstellen zu koennen.";
          case 207:
            return "Du kannst einen Enterhaken aus einem Haken und 3 Ketten herstellen.  Die Skelette tief unter der Erde tragen gewoehnlich Haken bei sich. Die Ketten dazu koennen aus Eisenbarren gefertigt werden.";
          case 208:
            return "Wenn du einen Topf siehst, so schlage ihn auf. Toepfe enthalten alle moeglichen Sorten von nuetzlichem Zubehoer.";
          case 209:
            return "Verborgene Schaetze sind auf der ganzen Welt zu finden! Einige erstaunliche Dinge sind auch tief unter der Erde aufzuspueren!";
          case 210:
            return "Beim Zerschlagen einer Schattenkugel faellt mitunter ein Meteor vom Himmel. Schattenkugeln koennen normalerweise in den Schluchten bei verderbten Gebieten gefunden werden.";
          case 211:
            return "Du solltest dich darauf konzentrieren, mehr Kristallherzen zur Erhoehung deiner maximalen Lebensspanne zu sammeln.";
          case 212:
            return "Deine jetzige Ausruestung wird einfach nicht ausreichen. Du musst eine bessere Ruestung fertigen.";
          case 213:
            return "Ich denke, du bist bereit fuer deinen ersten grossen Kampf. Sammele in der Nacht ein paar Linsen von den Augaepfeln und bringe sie zum Daemonenaltar.";
          case 214:
            return "Du solltest dein Leben verlaengern, bevor du die naechste Herausforderung annimmst. 15 Herzen sollten ausreichen.";
          case 215:
            return "Der Ebenstein im Verderben kann durch Verwendung von etwas Pulver des Dryaden gereinigt werden oder er kann durch Explosiva zerstoert werden.";
          case 216:
            return "Dein naechster Schritt ist, die verderbten Schluchten zu untersuchen. Suche nach Schattenkugeln und zerstoere sie!";
          case 217:
            return "Nicht weit von hier gibt es einen alten Dungeon. Jetzt waere ein guter Zeitpunkt, um ihn zu untersuchen.";
          case 218:
            return "Du solltest versuchen, deine Lebensspanne auf das Maximum anzuheben. Versuche, 20 Herzen zu finden.";
          case 219:
            return "Im Dschungel lassen sich viele Schaetze finden, wenn du bereit bist, tief genug zu graben.";
          case 220:
            return "Die Unterwelt entstand aus einem Material, welches sich Hoellenstein nennt. Es ist perfekt geeignet fuer die Produktion von Waffen und Ruestungen.";
          case 221:
            return "Wenn du bereit bist, den Waechter der Unterwelt herauszufordern, musst du ein Opfer bringen. Alles was du brauchst, findest du in der Unterwelt.";
          case 222:
            return "Zerschlage jeden Daemonenaltar, den du findest. Etwas Gutes wird sich ereignen!";
          case 223:
            return "Seelen koennen manchmal von gefallenen Kreaturen an Orten extremen Lichts oder Finsternis aufgesammelt werden.";
          case 224:
            return "Ho ho ho, und eine Flasche ... Egg Nog!";
          case 225:
            return "Pflege zu backen mir ein paar Kekse?";
          case 226:
            return "Was? Sie dachte, ich wäre nicht real?";
          case 227:
            return "Es gelang mir, dein Gesicht wieder annähen. Vorsichtiger sein beim nächsten Mal.";
          case 228:
            return "Das ist wahrscheinlich eine Narbe hinterlassen.";
          case 229:
            return "Alle besser. Ich will nicht, dass du springen mehr Klippen.";
          case 230:
            return "Das tat nicht weh zu schlecht, jetzt hat es getan?";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 1:
            return "Spero che tra noi e l'Occhio di Cthulhu non ci sia solo un bimbo scarno come te.";
          case 2:
            return "Guarda la pessima armatura che indossi. Faresti meglio a comprare più pozioni curative.";
          case 3:
            return "Ho la sensazione che una presenza malvagia mi stia guardando.";
          case 4:
            return "Spada batte carta! Prendine una oggi.";
          case 5:
            return "Desideri mele? Carote? Ananas? Abbiamo delle fiaccole.";
          case 6:
            return "Bella mattina, no? C'era qualcosa di cui avevi bisogno?";
          case 7:
            return "Presto si farà notte, amico. Fai le tue scelte finché puoi.";
          case 8:
            return "Non immagini quanti blocchi di terra si vendono oltreoceano.";
          case 9:
            return "Ah, racconteranno storie di " + Main.player[Main.myPlayer].name + " un giorno... belle storie ovviamente.";
          case 10:
            return "Guarda i miei blocchi di terra: sono super terrosi.";
          case 11:
            return "Ragazzo, quel sole scotta! Ho un'armatura perfettamente ventilata.";
          case 12:
            return "Il sole è alto, ma i miei prezzi no.";
          case 13:
            return "Fantastico. Sento " + str10 + " e " + str1 + " discutere da qui.";
          case 14:
            return "Hai visto Chith... Shith... Chat... Il grande occhio?";
          case 15:
            return "Ehi, questa casa è sicura, no? Giusto? " + Main.player[Main.myPlayer].name + "?";
          case 16:
            return "Nemmeno una luna di sangue può arrestare il capitalismo. Facciamo un po' di affari.";
          case 17:
            return "Tieni d'occhio il premio, compra una lente!";
          case 18:
            return "Kosh, kapleck Mog. Oh scusa, in klingon significa 'Compra qualcosa o muori.'";
          case 19:
            return "Sei, " + Main.player[Main.myPlayer].name + ", vero? Ho sentito belle cose su di te!";
          case 20:
            return "Sento che c'è un tesoro segreto... non importa.";
          case 21:
            return "Una statua d'angelo, dici? Scusa, non tratto cianfrusaglie.";
          case 22:
            return "L'ultimo ragazzo venuto qui mi lasciò delle cianfrusaglie... o meglio... tesori!";
          case 23:
            return "Mi chiedo se la luna sia fatta di formaggio... Uhm, cosa? Oh sì, compra qualcosa!";
          case 24:
            return "Hai detto oro? Te lo tolgo io.";
          case 25:
            return "Niente sangue su di me.";
          case 26:
            return "Sbrigati e smettila di sanguinare.";
          case 27:
            return "Se stai per morire, fallo fuori.";
          case 28:
            return "Cosa vorresti insinuare?!";
          case 29:
            return "Quel tuo tono non mi piace.";
          case 30:
            return "Che ci fai qui? Se non sanguini, non devi stare qui. Via.";
          case 31:
            return "COSA?!";
          case 32:
            return "Hai visto il vecchio che gira intorno alla segreta? Sembra agitato.";
          case 33:
            return "Vorrei che " + str5 + " fosse più attento.  Mi sto stancando di dovergli ricucire gli arti ogni giorno.";
          case 34:
            return "Ehi, " + str3 + " ha detto di dover andare dal dottore per qualche ragione? Solo per chiedere.";
          case 35:
            return "Devo parlare seriamente con " + str7 + ". Quante volte a settimana si può venire con gravi ustioni da lava?";
          case 36:
            return "Penso che tu stia meglio così.";
          case 37:
            return "Ehm... Che ti è successo alla faccia?";
          case 38:
            return "SANTO CIELO! Sono brava, ma non fino a questo punto.";
          case 39:
            return "Cari amici, siamo qui riuniti, oggi, per congedarci... Oh, ti riprenderai.";
          case 40:
            return "Hai lasciato il braccio laggiù. Te lo prendo io...";
          case 41:
            return "Smettila di fare il bambino! Ho visto di peggio.";
          case 42:
            return "Serviranno dei punti!";
          case 43:
            return "Di nuovo problemi con quei bulli?";
          case 44:
            return "Aspetta, ho i cerotti con i cartoni animati da qualche parte.";
          case 45:
            return "Cammina, " + Main.player[Main.myPlayer].name + " starai bene. Fiuu.";
          case 46:
            return "Ti fa male quando lo fai? Non farlo.";
          case 47:
            return "Sembri mezzo digerito. Hai di nuovo inseguito gli slime?";
          case 48:
            return "Gira la testa e tossisci.";
          case 49:
            return "Non è la più grande ferita che abbia mai visto... Ne ho viste certamente di più grandi.";
          case 50:
            return "Vuoi un lecca-lecca?";
          case 51:
            return "Dimmi dove ti fa male.";
          case 52:
            return "Scusa, ma non puoi permetterti di avermi.";
          case 53:
            return "Avrò bisogno di più soldi.";
          case 54:
            return "Sai che non lavoro gratis.";
          case 55:
            return "Non faccio lieti fini.";
          case 56:
            return "Non posso fare più nulla per te senza chirurgia plastica.";
          case 57:
            return "Smettila di sprecare il mio tempo.";
          case 58:
            return "Ho sentito che c'è una bambola molto simile a " + str7 + " nel sottomondo. Vorrei metterci dei proiettili.";
          case 59:
            return "Veloce! Ho un appuntamento con " + str1 + " tra un'ora.";
          case 60:
            return "Voglio quello che vende " + str1 + ". In che senso, non vende niente?";
          case 61:
            return str4 + " è uno spettacolo. Peccato sia così bigotta.";
          case 62:
            return "Lascia stare " + str5 + ", ho tutto ciò che ti serve qui.";
          case 63:
            return "Qual è il problema di " + str5 + "? Almeno lo sa che vendiamo oggetti diversi?";
          case 64:
            return "Beh, è una bella notte per non parlare con nessuno, non credi, " + Main.player[Main.myPlayer].name + "?";
          case 65:
            return "Mi piacciono le notti come questa. Non mancano mai cose da demolire!";
          case 66:
            return "Vedo che stai addocchiando il Minishark... Meglio che non ti dica di cosa è fatto.";
          case 67:
            return "Ehi, non è un film, amico. Le munizioni sono extra.";
          case 68:
            return "Giù le mani dalla mia pistola, amico!";
          case 69:
            return "Hai provato a usare la polvere purificatrice sulla pietra d'ebano della distruzione?";
          case 70:
            return "Vorrei che " + str3 + " la smettesse di flirtare con me. Non sa che ho 500 anni?";
          case 71:
            return "Perché " + str2 + " continua a vendermi statue d'angelo? Lo sanno tutti che non servono a nulla.";
          case 72:
            return "Hai visto il vecchio che gira intorno alla segreta? Non ha per niente un bell'aspetto...";
          case 73:
            return "Vendo ciò che voglio! Se non ti piace, pazienza.";
          case 74:
            return "Perché devi essere così conflittuale in un momento come questo?";
          case 75:
            return "Non voglio che tu compri la mia roba. Voglio che tu desideri comprarla, ok?";
          case 76:
            return "Amico, sbaglio o ci sono tipo un milione di zombi in giro, stanotte?";
          case 77:
            return "Devi purificare il mondo da questa empietà.";
          case 78:
            return "Sii cauto: Terraria ha bisogno di te!";
          case 79:
            return "Il tempo vola e tu, ahimé, non stai invecchiando molto bene.";
          case 80:
            return "Cos'è questa storia di me che abbaio, ma non mordo?";
          case 81:
            return "Due goblin entrano in un bar e uno dice all'altro: 'Vuoi un calice di birra?!' ";
          case 82:
            return "Non posso farti entrare finché non mi libererai dalla maledizione.";
          case 83:
            return "Torna di notte se vuoi entrare.";
          case 84:
            return "Il mio capo non può essere convocato di giorno.";
          case 85:
            return "Sei decisamente troppo debole per sconfiggere la mia maledizione. Torna quando sarai più forte.";
          case 86:
            return "Tu, pazzo patetico. Non puoi sperare di affrontare il mio padrone ora come ora.";
          case 87:
            return "Spero che tu abbia almeno sei amici dietro di te.";
          case 88:
            return "No, ti prego, straniero. Finirai per essere ucciso.";
          case 89:
            return "Potresti essere abbastanza forte da liberarmi dalla mia maledizione...";
          case 90:
            return "Straniero, hai la forza per sconfiggere il mio padrone?";
          case 91:
            return "Ti prego! Sconfiggi chi mi ha catturato e liberami, ti supplico!";
          case 92:
            return "Sconfiggi il mio padrone e ti farò passare nella segreta.";
          case 93:
            return "Stai provando a superare quella pietra d'ebano, eh? Perché non metterci questi esplosivi!";
          case 94:
            return "Ehi, hai visto un clown in giro?";
          case 95:
            return "C'era una bomba qui e ora non riesco a trovarla...";
          case 96:
            return "Ho qualcosa per quegli zombi, altroché!";
          case 97:
            return "Persino " + str3 + " vuole ciò che sto vendendo!";
          case 98:
            return "Preferisci avere un buco da proiettile o granata? Ecco ciò che pensavo.";
          case 99:
            return "Sono sicuro che " + str1 + " ti aiuterà se per caso perderai un arto.";
          case 100:
            return "Perché purificare il mondo quando potresti farlo saltare in aria?";
          case 101:
            return "Se verserai questo nella vasca da bagno e chiuderai tutte le finestre, ti pulirà le cavità nasali e ti sturerà le orecchie.";
          case 102:
            return "Vuoi giocare a Esplodi-Pollo?";
          case 103:
            return "Ehi, potresti firmare questa rinuncia al dolore?";
          case 104:
            return "VIETATO FUMARE QUI DENTRO!!";
          case 105:
            return "Gli esplosivi vanno a ruba di questi tempi. Comprane un po'!";
          case 106:
            return "È un buon giorno per morire!";
          case 107:
            return "Mi chiedo cosa succederà se io... (BUM!) ... Oh, scusa, ti serviva quella gamba?";
          case 108:
            return "La dinamite, la mia cura speciale per tutto ciò che ti affligge.";
          case 109:
            return "Guarda i miei prodotti: hanno prezzi esplosivi!";
          case 110:
            return "Continuo ad avere vaghi ricordi di aver legato una donna e averla gettata in una segreta.";
          case 111:
            return "... abbiamo un problema! C'è una luna di sangue là fuori!";
          case 112:
            return "Fossi più giovane, chiederei a NURSE di uscire. Avevo un successone con le ragazze.";
          case 113:
            return "Quel tuo cappello rosso mi sembra familiare...";
          case 114:
            return "Grazie ancora per avermi liberato dalla maledizione. Sentivo come qualcosa che saltava e mi mordeva.";
          case 115:
            return "Mia mamma mi diceva sempre che sarei stato un grande sarto.";
          case 116:
            return "La vita è come una scatola di vestiti; non sai mai ciò che indosserai!";
          case 117:
            return "Ricamare è difficile! Se non fosse così, nessuno lo farebbe! È ciò che lo rende fantastico.";
          case 118:
            return "So tutto ciò che c'è da sapere riguardo alle attività di sartoria.";
          case 119:
            return "Nella maledizione ero solo, perciò una volta mi creai un amico di pelle. Lo chiamai Wilson.";
          case 120:
            return "Grazie per avermi liberato, umano. Sono stato legato e lasciato qui da altri goblin. Si potrebbe dire che non andavamo proprio d'accordo.";
          case 121:
            return "Non posso credere che mi hanno legato e lasciato qui soltanto per far notare che non andavano verso est!";
          case 122:
            return "Ora che sono un escluso, posso buttar via le palle chiodate? Mi fanno male le tasche.";
          case 123:
            return "Cerchi un esperto di gadget? Sono il tuo goblin!";
          case 124:
            return "Grazie per l'aiuto. Ora devo smetterla di gironzolare senza scopo qui attorno. Sono sicuro che ci incontreremo di nuovo.";
          case 125:
            return "Pensavo fossi più alto.";
          case 126:
            return "Ehi... cosa sta combinando " + str10 + "? Hai... hai parlato con lei, per caso?";
          case (int) sbyte.MaxValue:
            return "Ehi, il tuo cappello ha bisogno di un motore? Credo di averne uno perfettamente adatto.";
          case 128:
            return "Ciao, ho sentito che ti piacciono i razzi e gli stivali da corsa, così ho messo dei missili nei tuoi stivali.";
          case 129:
            return "Il silenzio è d'oro. Il nastro adesivo è d'argento.";
          case 130:
            return "SÌ, l'oro è più forte del ferro. Cosa insegnano al giorno d'oggi a questi umani?";
          case 131:
            return "Sai, quella combinazione casco da minatore-pinne era un'idea molto migliore sulla carta.";
          case 132:
            return "I goblin si irritano molto facilmente. Potrebbero persino scatenare una guerra per i tessuti!";
          case 133:
            return "A dire il vero, la maggior parte dei goblin non sono ingegneri aerospaziali. Beh, alcuni sì.";
          case 134:
            return "Sai perché noi tutti ci portiamo dietro queste palle chiodate? Perché io non lo faccio.";
          case 135:
            return "Ho appena finito la mia ultima creazione! Questa versione non esplode violentemente se ci si respira troppo forte sopra.";
          case 136:
            return "I ladri goblin non sono molto furbi. Non sanno nemmeno rubare da una cassa aperta!";
          case 137:
            return "Grazie per avermi salvato, amico! Questi legacci iniziavano a irritarmi.";
          case 138:
            return "Ohh, mio eroe!";
          case 139:
            return "Oh, eroica! Grazie per avermi salvato, ragazza!";
          case 140:
            return "Oh, eroico!  Grazie per avermi salvato, ragazzo!";
          case 141:
            return "Ora che ci conosciamo, posso trasferirmi da te?";
          case 142:
            return "Bene, ciao, " + str7 + "! Cosa posso fare per te oggi?";
          case 143:
            return "Bene, ciao, " + str5 + "! Cosa posso fare per te oggi?";
          case 144:
            return "Bene, ciao, " + str9 + "! Cosa posso fare per te oggi?";
          case 145:
            return "Bene, ciao, " + str1 + "! Cosa posso fare per te oggi?";
          case 146:
            return "Bene, ciao, " + str10 + "! Cosa posso fare per te oggi?";
          case 147:
            return "Bene, ciao, " + str4 + "! Cosa posso fare per te oggi?";
          case 148:
            return "Vuoi che tiri fuori una moneta da dietro il tuo orecchio? No? Ok.";
          case 149:
            return "Vuoi dei dolci magici? No? Ok.";
          case 150:
            return "Posso preparare una cioccalata calda proprio deliziosa se sei inter...No? Ok.";
          case 151:
            return "Sei qui per dare un'ochiata alla mia sfera di cristallo?";
          case 152:
            return "Mai desiderato un anello incantato che trasforma le rocce in slime? Neanch'io.";
          case 153:
            return "Una volta qualcuno mi disse che l'amicizia è magica. Sciocchezze. Non puoi trasformare le persone in rane con l'amicizia.";
          case 154:
            return "Ora vedo il tuo futuro... Comprerai molti prodotti da me!";
          case 155:
            return "Una volta ho provato a dare la vita a una statua d'angelo. Invano.";
          case 156:
            return "Grazie! Era solo questione di tempo prima che facessi la stessa fine degli scheletri laggiù.";
          case 157:
            return "Ehi, guarda dove stai andando! Ero laggiù un attimo fa!";
          case 158:
            return "Resisti, sono quasi riuscita a portare fin qui il wifi.";
          case 159:
            return "Ma ero quasi riuscita a mettere luci intermettenti quassù!";
          case 160:
            return "NON MUOVERTI. MI È CADUTA UNA LENTE A CONTATTO.";
          case 161:
            return "Tutto ciò che voglio è che l'interruttore faccia... Cosa?!";
          case 162:
            return "Oh, fammi indovinare. Non hai comprato abbastanza filo metallico. Idiota.";
          case 163:
            return "Soltanto-potresti soltanto... Per favore? Ok? Ok. Puah.";
          case 164:
            return "Non apprezzo il modo in cui mi guardi. Sto LAVORANDO ora.";
          case 165:
            return "Ehi, " + Main.player[Main.myPlayer].name + ", sei appena stato da " + str9 + "? Ha detto qualcosa di me, per caso?";
          case 166:
            return str3 + " continua a dire di aver schiacciato la mia piastra a pressione. Gli ho spiegato che serve proprio a quello.";
          case 167:
            return "Compra sempre più filo metallico di quello necessario!";
          case 168:
            return "Ti sei assicurato che il tuo dispositivo fosse collegato?";
          case 169:
            return "Oh, sai di cosa ha bisogno questa casa? Di più luci intermittenti.";
          case 170:
            return "Si può dire che appare una luna di sangue quando il cielo si fa rosso.  C'è qualcosa in lei che ridesta i mostri.";
          case 171:
            return "Ehi, amico, sai dov'è un po' di erba della morte? Scusa, me lo stavo solo chiedendo, tutto qua.";
          case 172:
            return "Se dovessi alzare lo sguardo, vedresti che la luna è rossa ora.";
          case 173:
            return "Dovresti stare dentro di notte. Sai, è molto pericoloso girare al buio.";
          case 174:
            return "Saluti, " + Main.player[Main.myPlayer].name + ". Come posso esserti utile?";
          case 175:
            return "Sono qui per darti consigli su cosa fare dopo. Ti consiglio di parlare con me ogni volta che sarai nei guai.";
          case 176:
            return "Si dice ci sia una persona che ti dirà come sopravvivere in questa terra... Aspetta. Sono io.";
          case 177:
            return "Puoi utilizzare il piccone per scavare nell'immondizia e l'ascia per abbattere gli alberi. Posiziona il cursore  sulla mattonella e clicca!";
          case 178:
            return "Se vuoi sopravvivere, dovrai creare armi e un riparo. Inizia abbattendo gli alberi e raccogliendo legna.";
          case 179:
            return "Clicca su ESC per accedere al menu artigianato. Quando avrai abbastanza legna, crea un banco di lavoro. Così potrai creare oggetti più sofisticati, finché sarai vicino ad esso.";
          case 180:
            return "Puoi costruirti un riparo con legna o altri blocchi nel mondo. Non dimenticare di creare e sistemare le pareti.";
          case 181:
            return "Una volta che possiederai una spada di legno, puoi provare a raccogliere gel dagli slime. Metti assieme legna e gel per creare una fiaccola!";
          case 182:
            return "Per interagire con gli ambienti e gli oggetti posizionati, usa un martello!";
          case 183:
            return "Devi praticare un po' di estrazione per trovare minerale metallico. Puoi crearci oggetti molto utili.";
          case 184:
            return "Ora che hai un po' di minerale, dovrai trasformarlo in una sbarra per poterci fare degli oggetti. Per questo serve un forno!";
          case 185:
            return "Puoi creare una forno con fiaccole, legna e pietra. Assicurati di essere vicino a un banco di lavoro.";
          case 186:
            return "Avrai bisogno di un'incudine per creare la maggior parte degli oggetti dalle sbarre metalliche.";
          case 187:
            return "Le incudini possono essere create con del ferro o acquistate da un mercante.";
          case 188:
            return "Sottoterra vi sono cuori di cristallo che possono essere utilizzati per allungare la tua vita massima. Dovrai avere un martello per ottenerli.";
          case 189:
            return "Se raccoglierai 10 stelle cadenti, potrai combinarle per creare un oggetto che aumenterà le tue abilità magiche.";
          case 190:
            return "Le stelle cadono sul mondo di notte. Possono essere utilizzate per ogni tipo di oggetto utile.  Se ne vedi una, cerca di afferrarla, poiché scomparirà dopo l'alba.";
          case 191:
            return "Ci sono diversi modi per convincere le persone a trasferirsi nella tua città. Di sicuro dovranno avere una casa in cui vivere.";
          case 192:
            return "Perché una stanza sia considerata una casa, ha bisogno di una porta, una sedia, un tavolo e una fonte luminosa. Assicurati che la casa abbia anche delle pareti.";
          case 193:
            return "Due persone non possono vivere nella stessa casa. Inoltre, se la loro casa verrà distrutta, cercheranno un nuovo posto in cui vivere.";
          case 194:
            return "Puoi utilizzare l'interfaccia abitazioni per visualizzare e assegnare gli alloggi. Apri l'inventario e clicca sull'icona della casa.";
          case 195:
            return "Se vuoi che un mercante si trasferisca, dovrai raccogliere molto denaro. Servono 50 monete d'argento!";
          case 196:
            return "Se vuoi che un'infermiera si traferisca, dovrai essere intenzionato ad allungare la tua vita massima.";
          case 197:
            return "Se avessi una pistola, scommetto che potrebbe apparire un mercante d'armi per venderti munizioni!";
          case 198:
            return "Dovresti metterti alla prova sconfiggendo un mostro forte. Così attirerai l'attenzione di una driade.";
          case 199:
            return "Esplora attentamente tutta la segreta. Potrebbero esserci prigionieri nelle zone più profonde.";
          case 200:
            return "Forse il vecchio della segreta vorrebbe unirsi a noi, ora che la maledizione è terminata.";
          case 201:
            return "Arraffa tutte le bombe che potresti trovare. Un esperto in demolizioni potrebbe volerci dare un'occhiata.";
          case 202:
            return "I goblin sono così diversi da noi che non possiamo convivere in maniera pacifica?";
          case 203:
            return "Ho sentito che c'era un potente stregone da queste parti. Tienilo d'occhio la prossima volta che scenderai sottoterra.";
          case 204:
            return "Se combinerai le lenti a un altare demoniaco, potresti trovare un modo per chiamare un mostro potente. Ma aspetta che si faccia buio prima di utilizzarlo.";
          case 205:
            return "Puoi creare un'esca di vermi con pezzi marci e polvere disgustosa. Assicurati di essere in una zona distrutta prima di utilizzarla.";
          case 206:
            return "Gli altari demoniaci si trovano generalmente nella distruzione. Dovrai essere vicino ad essi per creare oggetti.";
          case 207:
            return "Puoi creare un rampino con un uncino e tre catene. Gli scheletri sottoterra di solito trasportano gli uncini, mentre le catene possono essere ricavate dalle sbarre di ferro.";
          case 208:
            return "Se vedi un vaso, demoliscilo e aprilo. Contiene una serie di utili provviste.";
          case 209:
            return "Vi sono tesori nascosti in tutto il mondo. Alcuni oggetti fantastici si possono trovare nelle zone sotterranee più profonde.";
          case 210:
            return "Demolire un'orbita d'ombra provocherà a volte la caduta di un meteorite dal cielo. Le orbite d'ombra si possono generalmente trovare negli abissi attorno alle zone distrutte.";
          case 211:
            return "Dovresti cercare di raccogliere più cuori di cristallo per allungare la tua vita massima.";
          case 212:
            return "La tua attrezzatura attuale non è sufficiente. Hai bisogno di un'armatura migliore.";
          case 213:
            return "Credo tu sia pronto per la tua prima grande battaglia. Raccogli lenti dai bulbi oculari di notte e portale a un altare demoniaco.";
          case 214:
            return "Allunga la tua vita prima di affrontare la prossima sfida. Quindici cuori dovrebbero bastare.";
          case 215:
            return "La pietra d'ebano nella distruzione può essere purificata con polvere di driade o distrutta con esplosivi.";
          case 216:
            return "La prossima tappa consiste nell'esplorazione degli abissi distrutti. Trova e distruggi ogni orbita d'ombra che incontrerai.";
          case 217:
            return "C'è una vecchia segreta non lontano da qui. Sarebbe il momento giusto per visitarla.";
          case 218:
            return "Dovresti tentare di massimizzare la vita disponibile. Prova a raccogliere venti cuori.";
          case 219:
            return "Ci sono molti tesori da scroprire nella giungla, se sei disposto a scavare abbastanza in profondità.";
          case 220:
            return "Il sottomondo è composto da un materiale detto pietra infernale, perfetto per creare armi e armatura.";
          case 221:
            return "Quando sarai pronto a sfidare il custode del sottomondo, dovrai fare un enorme sacrificio. Tutto ciò che ti serve si trova nel mondo di sotto.";
          case 222:
            return "Assicurati di demolire ogni altare demoniaco che incontri. Se lo farai, ti succederà qualcosa di bello!";
          case 223:
            return "A volte è possibile riunire le anime delle creature morte in luoghi estremamente luminosi o bui.";
          case 224:
            return "Ho ho ho e una bottiglia di ... Egg Nog!";
          case 225:
            return "Cura di cuocere dei biscotti me?";
          case 226:
            return "Che cosa? Credevi che non era reale?";
          case 227:
            return "Sono riuscito a cucire la tua faccia di nuovo. Essere più attento la prossima volta.";
          case 228:
            return "Che probabilmente lascerà una cicatrice.";
          case 229:
            return "Tutti i migliori. Non voglio vederti saltare fuori più scogliere.";
          case 230:
            return "Che non ha fatto male troppo male, ora lo ha fatto?";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 1:
            return "Rassurez-moi, on ne doit pas compter que sur vous pour nous protéger de l'œil de Cthulhu.";
          case 2:
            return "Regardez-moi cette armure bas de gamme que vous avez sur le dos. Vous avez intérêt à acheter davantage de potions de soin.";
          case 3:
            return "Je sens une présence maléfique m'observer.";
          case 4:
            return "L'épée est plus forte que la plume. Achetez-en une dès aujourd'hui.";
          case 5:
            return "Vous voulez des pommes ? Vous voulez des poires ? Vous voulez des scoubidous ? Nous avons des torches.";
          case 6:
            return "Quelle belle matinée, n'est-ce pas ? Vous voulez quelque chose?";
          case 7:
            return "La nuit va bientôt tomber, alors faites votre choix tant qu'il est encore temps.";
          case 8:
            return "Vous n'avez pas idée du nombre de blocs de terre qui sont vendus à l'étranger.";
          case 9:
            return "Un jour, des légendes étonnantes circuleront sur " + Main.player[Main.myPlayer].name + ".";
          case 10:
            return "Jetez un œil à mes blocs de terre, c'est de la terre de premier choix.";
          case 11:
            return "Voyez comme le soleil tape. J'ai des armures parfaitement ventilées.";
          case 12:
            return "Le soleil est haut dans le ciel, mais mes prix sont bas.";
          case 13:
            return "Oh, génial ! J'entends " + str10 + " et " + str1 + " se disputer d'ici.";
          case 14:
            return "Avez-vous vu Chult... Cthuch... Le truc avec le gros œil?";
          case 15:
            return "Cette maison est sûre, n'est-ce pas ? Hein, " + Main.player[Main.myPlayer].name + "?";
          case 16:
            return "Même la Lune de Sang ne peut arrêter le capitalisme. Alors, faisons affaires.";
          case 17:
            return "Pour garder un œil sur les prix, achetez une lentille.";
          case 18:
            return "Kosh, kapleck Mog. Oh désolé, ça veut dire « Achetez-moi quelque chose ou allez au diable » en klingon.";
          case 19:
            return "Vous êtes " + Main.player[Main.myPlayer].name + ", n'est-ce pas ? J'ai entendu de bonnes choses à votre sujet.";
          case 20:
            return "J'ai entendu dire qu'il y avait un trésor caché... Bon, laissez tomber.";
          case 21:
            return "Une statue d'ange, dites-vous ? Désolé, ce n'est pas une boutique de souvenirs ici.";
          case 22:
            return "Le dernier type qui est venu m'a vendu quelques sales... Je veux dire, de vrais trésors.";
          case 23:
            return "Je me demande si la lune est un gros fromage... Hein, quoi ? Oh , bien sûr, achetez ce que vous voulez!";
          case 24:
            return "Vous avez dit or ? Je vais vous en débarrasser.";
          case 25:
            return "Faites attention de ne pas me mettre du sang partout.";
          case 26:
            return "Dépêchez-vous et arrêtez de saigner.";
          case 27:
            return "Si vous comptez mourir, faites-le dehors.";
          case 28:
            return "Qu'est-ce que ça veut dire ?";
          case 29:
            return "Je n'aime pas beaucoup votre ton.";
          case 30:
            return "Qu'est-ce que vous faites là ? Si vous ne saignez pas, sortez d'ici. Dehors !";
          case 31:
            return "Quoi ?";
          case 32:
            return "Vous avez vu ce vieil homme qui se pressait autour du donjon ? Il semblait avoir des ennuis.";
          case 33:
            return "J'aimerais bien que " + str5 + " fasse plus attention. J'en ai assez de lui faire des points de suture chaque jour.";
          case 34:
            return "Je me demande si " + str3 + " a dit qu'il avait besoin d'un docteur.";
          case 35:
            return "Il va falloir que je discute sérieusement avec " + str7 + ". Combien de fois par semaine allez-vous revenir ici avec des brûlures au second degré ?";
          case 36:
            return "Vous avez meilleure mine comme ça.";
          case 37:
            return "Que vous est-il arrivé au visage ?";
          case 38:
            return "Bon sang, je suis une bonne infirmière, mais pas à ce point.";
          case 39:
            return "Mes chers amis, nous sommes rassemblés aujourd'hui pour faire nos adieux... Bon, tout se passera bien.";
          case 40:
            return "Vous avez laissé votre bras là-bas. Laissez-moi arranger ça.";
          case 41:
            return "Arrêtez de vous comporter comme une mauviette. J'ai déjà vu bien pire.";
          case 42:
            return "Cela va demander quelques points de suture.";
          case 43:
            return "Encore des soucis avec ces brutes ?";
          case 44:
            return "Attendez, je dois avoir quelques pansements pour enfants quelque part.";
          case 45:
            return "Allez faire quelques pas, " + Main.player[Main.myPlayer].name + ", ça devrait aller. Allez, ouste !";
          case 46:
            return "Ça vous fait mal quand vous faites ça ? Eh bien, ne le faites pas.";
          case 47:
            return "On dirait qu'on a commencé à vous digérer. Vous avez encore chassé des slimes ?";
          case 48:
            return "Tournez votre tête et toussez.";
          case 49:
            return "Ce n'est pas la plus grave blessure que j'ai vue... Oui, j'ai déjà vu des blessures bien plus graves que ça.";
          case 50:
            return "Vous voulez une sucette ?";
          case 51:
            return "Montrez-moi où vous avez mal.";
          case 52:
            return "Je suis désolée, mais vous n'avez pas les moyens.";
          case 53:
            return "Il va me falloir plus d'or que cela.";
          case 54:
            return "Je ne travaille pas gratuitement, vous savez.";
          case 55:
            return "Je ne vous garantis pas le résultat.";
          case 56:
            return "Je ne peux rien faire de plus pour vous sans chirurgie esthétique.";
          case 57:
            return "Arrêtez de me faire perdre mon temps.";
          case 58:
            return "J'ai entendu dire qu'il y aurait une poupée qui ressemblerait beaucoup à " + str7 + " dans le monde inférieur. J'aimerais bien lui coller quelques pruneaux.";
          case 59:
            return "Dépêchez-vous, j'ai un rencard avec " + str1 + " d'ici une heure.";
          case 60:
            return "Je veux ce que vend" + str1 + ". Comment ça, elle ne vend rien !";
          case 61:
            return str4 + " est vraiment canon. Dommage qu'elle soit aussi prude.";
          case 62:
            return "Ne vous embêtez pas avec " + str5 + ", j'ai tout ce qu'il vous faut ici.";
          case 63:
            return "C'est quoi le problème de " + str5 + " ? Est-ce qu'il réalise seulement que l'on vend du matériel complètement différent ?";
          case 64:
            return "Eh bien, c'est la nuit idéale pour ne pas parler à n'importe qui, n'est-ce pas, " + Main.player[Main.myPlayer].name + " ?";
          case 65:
            return "J'adore les nuits comme celle-ci, car il y a toujours des choses à tuer.";
          case 66:
            return "Je vois que vous êtes en train de zieuter le minishark... Mieux vaut ne pas savoir comment c'est fabriqué.";
          case 67:
            return "Eh, c'est pas du cinéma. Les munitions sont superflues.";
          case 68:
            return "Retirez les mains de mon flingue.";
          case 69:
            return "Avez-vous essayé d'utiliser de la poudre de purification sur la pierre d'ébène de corruption ?";
          case 70:
            return "Ce serait bien si " + str3 + " cessait de me courtiser. J'ai quand même 500 ans, mais ça n'a pas l'air de lui faire peur.";
          case 71:
            return "Pourquoi " + str2 + " essaie-t-il toujours de me vendre des statues d'ange ? Tout le monde sait qu'elles sont sans intérêt.";
          case 72:
            return "Avez-vous vu le vieil homme en train de marcher autour du donjon ? Il n'avait vraiment pas l'air bien.";
          case 73:
            return "Je vends ce que je veux, et si cela ne vous plaît pas, tant pis pour vous.";
          case 74:
            return "Pourquoi adopter un comportement aussi conflictuel en cette période ?";
          case 75:
            return "Je ne veux pas que vous achetiez mes marchandises, je veux que vous vouliez acheter mes marchandises, vous saisissez la nuance ?";
          case 76:
            return "Dites, c'est moi ou il y a un million de zombies qui déambulent cette nuit ?";
          case 77:
            return "Je veux que vous purifiiez le monde de la corruption.";
          case 78:
            return "Soyez prudent, Terraria a besoin de vous.";
          case 79:
            return "Les sables du temps s'écoulent et il faut bien avouer que vous vieillissez plutôt mal.";
          case 80:
            return "Comment ça, j'aboie plus que je ne mords ?";
          case 81:
            return "C'est l'histoire de deux gobelins qui entrent dans une taverne et l'un dit à l'autre : « Tu veux un gobelet de bière ? »";
          case 82:
            return "Je ne peux pas vous laisser entrer tant que vous ne m'aurez pas débarrassé de ma malédiction.";
          case 83:
            return "Revenez à la nuit tombée si vous voulez entrer.";
          case 84:
            return "Mon maître ne peut pas être invoqué à la lumière du jour.";
          case 85:
            return "Vous êtes bien trop faible pour me débarrasser de ma malédiction. Revenez quand vous serez de taille.";
          case 86:
            return "C'est pathétique ! Vous n'espérez quand même pas affronter mon maître pour l'instant dans votre état.";
          case 87:
            return "J'espère que vous avez au moins six amis pour vous épauler.";
          case 88:
            return "Je vous en prie, ne faites pas ça. Vous allez vous faire tuer.";
          case 89:
            return "Votre puissance semble suffisante pour me débarrasser de ma malédiction.";
          case 90:
            return "Disposez-vous de la force nécessaire pour vaincre mon maître ?";
          case 91:
            return "S'il vous plaît, je vous en conjure, affrontez mon ravisseur et libérez-moi.";
          case 92:
            return "Terrassez mon maître et je vous ouvrirai la voie du donjon.";
          case 93:
            return "Vous essayez d'écouler cette pierre d'ébène, hein ? Pourquoi ne pas l'intégrer à l'un de ces explosifs ?";
          case 94:
            return "Dites donc, vous n'auriez pas vu un clown dans le coin ?";
          case 95:
            return "Il y avait une bombe juste là et je n'arrive plus à remettre la main dessus.";
          case 96:
            return "J'ai quelque chose dont les zombies raffolent.";
          case 97:
            return "Même " + str3 + " raffole de mes marchandises.";
          case 98:
            return "Vous préférez un trou de balle ou un trou de grenade ? C'est bien ce que je pensais.";
          case 99:
            return str1 + " vous aidera si jamais vous perdez un membre avec ça.";
          case 100:
            return "Pourquoi purifier le monde alors que vous pouvez tout faire sauter ?";
          case 101:
            return "Si vous lancez ça dans votre baignoire et que vous fermez les fenêtres, ça vous débouchera les sinus et les oreilles en moins de deux.";
          case 102:
            return "Vous voulez jouer au poulet-fusée ?";
          case 103:
            return "Pourriez-vous signer cette clause de non-responsabilité ?";
          case 104:
            return "INTERDICTION FORMELLE DE FUMER.";
          case 105:
            return "Les explosifs, c'est de la bombe en ce moment. Achetez-en dès maintenant.";
          case 106:
            return "C'est un bon jour pour mourir.";
          case 107:
            return "Je me demande ce qui va se passer si je... (BOUM !)... Désolé, vous aviez besoin de cette jambe ?";
          case 108:
            return "La dynamite, c'est mon remède spécial à tous vos petits problèmes.";
          case 109:
            return "Jetez un œil à mes marchandises, mes prix sont explosifs.";
          case 110:
            return "J'ai encore le vague souvenir d'avoir attaché une femme et de l'avoir balancée dans un donjon.";
          case 111:
            return "Il y a un problème, c'est la lune de sang.";
          case 112:
            return "Si j'avais été plus jeune, j'aurais proposé un rencard à " + str1 + ". J'étais un bourreau des cœurs dans le temps.";
          case 113:
            return "Ce chapeau rouge que vous portez me dit quelque chose.";
          case 114:
            return "Merci de m'avoir débarrassé de cette malédiction. J'avais l'impression que quelque chose m'avait mordu et ne me lâchait plus.";
          case 115:
            return "Ma mère m'a toujours dit que je ferais un bon tailleur.";
          case 116:
            return "La vie est comme le chapeau d'un magicien, on ne sait jamais ce qui va en sortir.";
          case 117:
            return "La broderie, c'est très difficile. Si ça ne l'était pas, personne n'en ferait. C'est ce qui la rend si intéressante.";
          case 118:
            return "Le commerce du prêt-à-porter n'a aucun secret pour moi.";
          case 119:
            return "Quand on est maudit, ça n’aide pas à se faire des amis. Alors un jour, je m'en suis fait un avec un morceau de cuir et je l'ai appelé Wilson.";
          case 120:
            return "Merci de m'avoir libéré, humain. J'ai été attaché et laissé ici par les autres gobelins. On peut dire qu'on ne s'entendait pas très bien, eux et moi.";
          case 121:
            return "Je n'arrive pas à croire qu'ils m'aient attaché et planté ici juste pour montrer qu'ils ne voulaient pas aller vers l'est.";
          case 122:
            return "Puisque je suis devenu un paria, puis-je jeter mes boules piquantes ? Mes poches me font mal.";
          case 123:
            return "Vous cherchez un expert en gadgets ? Je suis votre gobelin.";
          case 124:
            return "Merci de votre aide. À présent, je dois continuer à errer sans but dans les environs. Je suis sûr qu'on se reverra.";
          case 125:
            return "Je ne vous imaginais pas comme ça.";
          case 126:
            return "Et comment va " + str10 + "? Lui auriez-vous parlé, par hasard ?";
          case (int) sbyte.MaxValue:
            return "Est-ce que votre chapeau a besoin d'un moteur ? Je crois en avoir un en stock qui ferait parfaitement l'affaire.";
          case 128:
            return "J'ai entendu dire que vous aimiez les bottes de course et les roquettes, du coup, j'ai installé des roquettes dans vos bottes de course.";
          case 129:
            return "Le silence est d'or, mais le chatterton reste très efficace.";
          case 130:
            return "Oui, l'or est plus précieux que le fer. Mais qu'est-ce qu'ils vous apprennent chez les humains ?";
          case 131:
            return "C'est vrai que ce casque de mineur combiné à une palme rendait mieux sur le papier.";
          case 132:
            return "Les gobelins sont étonnamment soupe au lait. Ils pourraient déclencher une guerre pour un mot de travers.";
          case 133:
            return "Il faut bien avouer que les gobelins n'ont pas inventé la poudre, mais il y a des exceptions à la règle.";
          case 134:
            return "Savez-vous pourquoi on trimballe toujours ces boules piquantes ? Parce que moi, je n'en sais fichtre rien.";
          case 135:
            return "Je viens de mettre la touche finale à ma dernière invention. Et ce modèle n'explosera pas si vous soufflez trop fort dessus.";
          case 136:
            return "Les voleurs gobelins sont des vrais manchots. Ils ne sont même pas capables de dérober le contenu d'un coffre non verrouillé.";
          case 137:
            return "Merci de m'avoir secouru. Ces liens commençaient à m'irriter la peau.";
          case 138:
            return "Mon héros !";
          case 139:
            return "Quel héroïsme ! Merci de m'avoir sauvé, belle dame.";
          case 140:
            return "Quel héroïsme ! Merci de m'avoir sauvé, fringant jeune homme.";
          case 141:
            return "Maintenant que nous avons fait connaissance, je peux venir avec vous, n'est-ce pas ?";
          case 142:
            return "Bonjour, " + str7 + "! Que puis-je pour vous, aujourd'hui ?";
          case 143:
            return "Bonjour, " + str5 + "! Que puis-je pour vous, aujourd'hui ?";
          case 144:
            return "Bonjour, " + str9 + "! Que puis-je pour vous, aujourd'hui ?";
          case 145:
            return "Bonjour, " + str1 + "! Que puis-je pour vous, aujourd'hui ?";
          case 146:
            return "Bonjour, " + str10 + "! Que puis-je pour vous, aujourd'hui ?";
          case 147:
            return "Bonjour, " + str4 + "! Que puis-je pour vous, aujourd'hui ?";
          case 148:
            return "Voulez-vous que je fasse apparaître une pièce de monnaie de derrière votre oreille ? Non ? Bon.";
          case 149:
            return "Est-ce qu'un berlingot magique vous ferait plaisir ? Non ? Bon.";
          case 150:
            return "Je peux concocter un merveilleux chocolat chaud magique, si cela vous intéresse... Non ? OK.";
          case 151:
            return "Souhaitez-vous jeter un œil à ma boule de cristal ?";
          case 152:
            return "N'avez-vous jamais rêvé de posséder un anneau magique qui transformerait les rochers en vase ? Moi non plus, à vrai dire.";
          case 153:
            return "Un jour, quelqu'un m'a dit que l'amitié était quelque chose de magique. C'est n'importe quoi. On ne peut pas transformer quelqu'un en grenouille avec l'amitié.";
          case 154:
            return "À présent, votre avenir m'apparaît clairement... Vous allez m'acheter de nombreux objets.";
          case 155:
            return "Une fois, j'ai tenté de ramener une statue d'ange à la vie. Il ne s'est rien passé.";
          case 156:
            return "Merci. C'était moins une, j'ai failli terminer comme tous ces squelettes.";
          case 157:
            return "Attention où vous mettez les pieds. J'étais encore là-bas il y a peu.";
          case 158:
            return "Attendez, je suis en train de perdre ma connexion Wi-Fi par ici.";
          case 159:
            return "Mais j'avais presque terminé d'installer des stroboscopes ici.";
          case 160:
            return "Que personne ne bouge ! J'ai perdu une lentille.";
          case 161:
            return "Tout ce que je veux, c'est que l'interrupteur... Quoi ?";
          case 162:
            return "Je parie que vous n'avez pas acheté assez de câbles. Décidément, vous n'êtes vraiment pas une lumière.";
          case 163:
            return "Est-ce que vous pourriez juste... S'il vous plaît ? OK ? OK.";
          case 164:
            return "Je n'aime pas trop la façon dont vous me regardez. Je suis en train de travailler, moi.";
          case 165:
            return "Au fait, " + Main.player[Main.myPlayer].name + ", vous venez de voir  " + str9 + " ? Est-ce qu'il aurait parlé de moi, par hasard ?";
          case 166:
            return str3 + " parle toujours de pressuriser mes plaques de pression. Je lui ai dit que c'était pour marcher dessus.";
          case 167:
            return "Il faut toujours acheter plus de câbles que prévu.";
          case 168:
            return "Vous vous êtes assuré que votre matériel était bien branché ?";
          case 169:
            return "Vous savez ce qu'il faudrait à cette maison ? Plus de stroboscopes.";
          case 170:
            return "La lune de sang se remarque lorsque le ciel vire au rouge et quelque chose fait que les monstres pullulent.";
          case 171:
            return "Dites donc, vous savez où je peux trouver de la mauvaise herbe morte. Non, pour rien, je me demandais, c'est tout.";
          case 172:
            return "Si vous regardiez en l'air, vous verriez que là,  la lune est toute rouge.";
          case 173:
            return "La nuit, vous devriez rester à l'intérieur. C'est très dangereux de se balader dans le noir.";
          case 174:
            return "Bienvenue, " + Main.player[Main.myPlayer].name + ". Je peux faire quelque chose pour vous ?";
          case 175:
            return "Je suis là pour vous conseiller et vous aider dans vos prochaines actions. Vous devriez venir me parler au moindre problème.";
          case 176:
            return "On dit qu'il y a une personne capable de vous aider à survivre sur ces terres... Oh, attendez, c'est moi.";
          case 177:
            return "Vous pouvez utiliser votre pioche pour creuser dans la terre, et votre hache pour abattre des arbres. Placez simplement le curseur à l'emplacement souhaité et cliquez.";
          case 178:
            return "Si vous voulez survivre, vous allez devoir fabriquer des armes et un abri. Commencez par abattre des arbres et récolter du bois.";
          case 179:
            return "Appuyez sur ÉCHAP pour accéder au menu d'artisanat. Lorsque vous avez assez de bois, créez un établi. Tant que vous vous tiendrez à proximité, il vous permettra de fabriquer des objets plus complexes.";
          case 180:
            return "Vous pouvez construire un abri en plaçant du bois ou d'autres blocs dans le monde. N'oubliez pas de créer des murs et de les placer.";
          case 181:
            return "Une fois que vous aurez une épée de bois, vous pourriez essayer de récupérer du gel grâce aux slimes. Combinez ensuite le bois et le gel pour faire une torche.";
          case 182:
            return "Pour interagir avec les arrière-plans et les objets placés, utilisez un marteau.";
          case 183:
            return "Vous devriez creuser pour trouver du minerai. Cela vous permet de fabriquer des objets très utiles.";
          case 184:
            return "Maintenant que vous avez du minerai, vous allez devoir le transformer en lingot pour pouvoir en faire des objets. Il vous faut un fourneau.";
          case 185:
            return "Vous pouvez fabriquer un fourneau avec des torches, du bois et de la pierre. Assurez-vous de vous tenir près d'un établi.";
          case 186:
            return "Vous aurez besoin d'une enclume pour pouvoir fabriquer la plupart des choses à partir des lingots de métal.";
          case 187:
            return "Une enclume peut être fabriquée avec du fer ou bien achetée chez les marchands.";
          case 188:
            return "Le souterrain est un cœur de cristal utilisé pour augmenter votre maximum de vie. Il vous faudra un marteau pour pouvoir en extraire.";
          case 189:
            return "Si vous récupérez dix étoiles filantes, elles peuvent être combinées pour fabriquer un objet qui augmentera votre capacité de magie.";
          case 190:
            return "Les étoiles tombent sur le monde durant la nuit. Elles peuvent être utilisées pour toutes sortes de choses utiles. Si vous en voyez une, dépêchez-vous de la ramasser, car elles disparaissent l'aube venue.";
          case 191:
            return "Il existe de nombreux moyens pour attirer du monde dans notre ville. Bien sûr, une fois sur place, ces nouveaux arrivants auront besoin d'une maison pour s'abriter.";
          case 192:
            return "Pour qu'une pièce puisse être considérée comme un foyer, elle doit comporter une porte, une chaise, une table et une source de lumière. Assurez-vous que la maison dispose également de murs.";
          case 193:
            return "Deux personnes distinctes ne vivront pas dans le même foyer. De plus, si leur foyer est détruit, ils chercheront un nouveau lieu où habiter.";
          case 194:
            return "Vous pouvez utiliser l'interface de logement pour attribuer des logements et les visualiser. Ouvrez votre inventaire et cliquez sur l'icône de maison.";
          case 195:
            return "Si vous souhaitez qu'un marchand emménage, vous devrez avoir une quantité d'argent suffisante. 50 pièces d'argent devraient suffire.";
          case 196:
            return "Pour qu'une infirmière emménage, vous pourriez augmenter votre maximum de vie.";
          case 197:
            return "Si vous avez un mousquet, il se peut qu'un marchand d'armes fasse son apparition pour vous vendre des munitions.";
          case 198:
            return "Vous devriez montrer de quoi vous êtes capable en triomphant d'un monstre. Cela attirera l'attention d'une dryade.";
          case 199:
            return "Assurez-vous d'explorer minutieusement les donjons. Il pourrait y avoir des prisonniers retenus captifs dans les profondeurs.";
          case 200:
            return "Peut-être que le vieil homme du donjon voudra se joindre à nous maintenant que sa malédiction a été levée.";
          case 201:
            return "Récupérez toutes les bombes que vous pourrez trouver. Un démolisseur voudra sûrement y jeter un œil.";
          case 202:
            return "Les gobelins sont-ils si différents de nous pour que nous ne puissions pas vivre ensemble de manière paisible ?";
          case 203:
            return "J'ai entendu dire qu'un puissant magicien vivait dans les environs. Assurez-vous de le trouver la prochaine fois que vous irez dans le souterrain.";
          case 204:
            return "Si vous combinez des lentilles à un autel de démon, vous pourrez trouver un moyen d'invoquer un monstre très puissant. Cependant, il vous faudra attendre la tombée de la nuit avant de pouvoir l'utiliser.";
          case 205:
            return "Vous pouvez fabriquer de la nourriture pour ver avec des morceaux pourris et de la poudre infecte. Assurez-vous de vous trouver dans une zone corrompue avant de l'utiliser.";
          case 206:
            return "Les autels démoniaques peuvent généralement être trouvés dans la corruption. Il vous faudra vous tenir près d'eux pour fabriquer certains objets.";
          case 207:
            return "Vous pouvez fabriquer un grappin avec un crochet et trois chaînes. Les squelettes trouvés dans les profondeurs portent souvent des crochets sur eux. Les chaînes peuvent être fabriquées à l'aide de lingots de fer.";
          case 208:
            return "Si vous voyez des pots, détruisez-les pour les ouvrir, car ils contiennent souvent des objets très utiles.";
          case 209:
            return "Des trésors sont disséminés un peu partout dans le monde et vous pouvez trouver des objets fantastiques dans les profondeurs.";
          case 210:
            return "Lorsqu'on écrase un orbe d'ombre, il arrive qu'une météorite tombe du ciel. Les orbes d'ombre peuvent généralement être trouvés dans les gouffres des zones corrompues.";
          case 211:
            return "Vous devriez vous employer à récolter davantage de cœurs de cristal pour augmenter votre maximum de vie.";
          case 212:
            return "Votre équipement actuel ne suffira pas. Il vous faut une meilleure armure.";
          case 213:
            return "Je crois que vous pouvez maintenant prendre part à votre première grande bataille. De nuit, rassemblez des lentilles récupérées à la mort des démons et portez-les sur un autel de démon.";
          case 214:
            return "Vous devriez augmenter votre vie avant votre prochaine épreuve. Quinze cœurs devraient suffire.";
          case 215:
            return "La pierre d'ébène dans la corruption peut être purifiée en utilisant de la poudre issue d'une dryade, ou bien peut être détruite avec des explosifs.";
          case 216:
            return "Votre prochaine épreuve sera d'explorer les gouffres corrompus. Trouvez et détruisez tous les orbes d'ombre que vous trouverez.";
          case 217:
            return "Il existe un vieux donjon situé pas très loin d'ici. Vous devriez aller y faire un tour dès maintenant.";
          case 218:
            return "Vous devriez essayer d'augmenter votre vie maximum. Essayez de rassembler vingt cœurs.";
          case 219:
            return "Si vous pouvez creuser assez profondément, il y a de nombreux trésors à découvrir dans la jungle.";
          case 220:
            return "Le monde inférieur est fait d'un matériau appelé pierre de l'enfer. Ce matériau est parfait pour la fabrication d'armes et d'armures.";
          case 221:
            return "Lorsque vous voudrez affronter le gardien du monde inférieur, vous devrez faire le sacrifice d'un être vivant. Tout ce dont vous avez besoin pour cela se trouve dans le monde inférieur.";
          case 222:
            return "Assurez-vous d'écraser tous les autels de démon que vous trouverez. Vous pourrez en tirer quelque chose de bénéfique.";
          case 223:
            return "Des âmes peuvent être parfois récupérées des créatures déchues dans des lieux de lumière ou d'ombre extrême.";
          case 224:
            return "Ho ho ho et une bouteille de ... Egg Nog!";
          case 225:
            return "Soins pour cuire des biscuits moi?";
          case 226:
            return "Qu'est-ce? Vous pensiez que je n'étais pas réel?";
          case 227:
            return "J'ai réussi à coudre votre visage sur le dos. Soyez plus prudent la prochaine fois.";
          case 228:
            return "Cela va probablement laisser une cicatrice.";
          case 229:
            return "Toutes les meilleures. Je ne veux pas vous voir sauter plus falaises.";
          case 230:
            return "Cela n'a pas fait trop de mal, maintenant c'est fait?";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 1:
            return "Espero que un canijo como tú no sea lo único que se interpone entre nosotros y el Ojo de Cthulu.";
          case 2:
            return "Vaya un arma más mal hecha que llevas. Te conviene comprar más pociones curativas.";
          case 3:
            return "Siento como si una presencia maligna me observara.";
          case 4:
            return "¡La espada siempre gana! Cómprate una ahora.";
          case 5:
            return "¿Quieres manzanas? ¿Zanahorias? ¿Unas piñas? Tenemos antorchas.";
          case 6:
            return "Una mañana estupenda, ¿verdad? ¿No necesitas nada?";
          case 7:
            return "La noche caerá pronto, amigo. Haz tus compras mientras puedas.";
          case 8:
            return "Ni te imaginas lo bien que se venden los Bloques de tierra en el extranjero.";
          case 9:
            return "Oh, algún día narrarán las aventuras de " + Main.player[Main.myPlayer].name + "... y seguro que acaban bien.";
          case 10:
            return "Echa un vistazo a estos Bloques de tierra; tienen extra de tierra.";
          case 11:
            return "¡Oye, cómo pega el sol! Pero yo tengo una armadura totalmente ventilada.";
          case 12:
            return "El sol está alto, al contrario que mis precios.";
          case 13:
            return "¡Vaya! Desde aquí se oye cómo discuten " + str10 + " y " + str1 + ".";
          case 14:
            return "¿Has visto a Chith... esto... Shith... eh... Chat...? Vamos, ¿al gran Ojo?";
          case 15:
            return "Oye, esta casa es segura, ¿verdad? ¿Verdad? " + Main.player[Main.myPlayer].name + "...";
          case 16:
            return "Ni siquiera una luna sangrienta detendría el capitalismo. Así que vamos a hacer negocios.";
          case 17:
            return "¡Fíjate bien en el premio, compra una lente!";
          case 18:
            return "Kosh, kapleck Mog. Lo siento, hablaba en klingon... quiere decir \"Compra algo o muere\".";
          case 19:
            return "¿Eres tú, " + Main.player[Main.myPlayer].name + "? ¡Me han hablado bien de ti, amigo!";
          case 20:
            return "Dicen que aquí hay un tesoro escondido... oh, olvídalo...";
          case 21:
            return "¿La estatua de un ángel? Lo siento pero no vendo cosas de segunda mano.";
          case 22:
            return "El último tipo que estuvo aquí me dejó algunos trastos viejos... ¡bueno, en realidad eran tesoros!";
          case 23:
            return "Me pregunto si la luna estará hecha de queso... Eh... esto. ¡Ah, claro, compre aquí!";
          case 24:
            return "¿Has dicho oro? Me lo quedo.";
          case 25:
            return "Será mejor que no me manches de sangre.";
          case 26:
            return "Date prisa... y deja ya de sangrar.";
          case 27:
            return "Si te vas a morir, hazlo fuera por favor.";
          case 28:
            return "¿Y eso qué quiere decir?";
          case 29:
            return "No me gusta el tono que empleas.";
          case 30:
            return "¿Por qué sigues aquí? Si no te estás desangrando, aquí no pintas nada. Lárgate.";
          case 31:
            return "¡CÓMO!";
          case 32:
            return "¿Has visto a ese anciano deambulando por la mazmorra? Parece que tiene problemas.";
          case 33:
            return "Ojalá " + str5 + " tuviera más cuidado. Ya me estoy hartando de tener que coserle las extremidades todos los días.";
          case 34:
            return "Oye, por curiosidad, ¿ha dicho " + str3 + " por qué tiene que ir al médico?";
          case 35:
            return "Debo hablar en serio con " + str7 + ". ¿Cuántas veces crees que puedes venir en una semana con quemaduras de lava graves?";
          case 36:
            return "Creo que así estarás mejor.";
          case 37:
            return "Eh... ¿Qué te ha pasado en la cara?";
          case 38:
            return "¡DIOS MÍO! Soy buena, pero no tanto.";
          case 39:
            return "Queridos amigos, nos hemos reunido hoy aquí para decir adiós a... Vaya, te vas a poner bien.";
          case 40:
            return "Te dejaste el brazo por ahí. Deja que te ayude...";
          case 41:
            return "¡Deja de comportarte como un bebé! He visto cosas peores.";
          case 42:
            return "¡Voy a tener que darte puntos!";
          case 43:
            return "¿Ya te has vuelto a meter en líos?";
          case 44:
            return "Aguanta, por aquí tengo unas tiritas infantiles chulísimas.";
          case 45:
            return "Anda ya, " + Main.player[Main.myPlayer].name + ", te pondrás bien. Serás nenaza...";
          case 46:
            return "¿Así que te duele cuando haces eso? ... Pues no lo hagas.";
          case 47:
            return "Parece un corte de digestión. ¿Has estado cazando babosas otra vez?";
          case 48:
            return "Gira la cabeza y tose.";
          case 49:
            return "No es de las peores heridas que he visto... Sin duda, he visto heridas más grandes que esta.";
          case 50:
            return "¿Quieres una piruleta, chiquitín?";
          case 51:
            return "A ver... ¿dónde te duele?";
          case 52:
            return "Lo siento, pero no puedes pagarme.";
          case 53:
            return "Vas a necesitar más oro del que traes.";
          case 54:
            return "Oye, yo no trabajo gratis.";
          case 55:
            return "No tengo una varita mágica.";
          case 56:
            return "Esto es todo lo que puedo hacer por ti... necesitas cirugía plástica.";
          case 57:
            return "No me hagas perder el tiempo.";
          case 58:
            return "Dicen que en alguna parte del Inframundo hay una muñeca que se parece mucho a" + str7 + " Me gustaría dejarme caer por ahí.";
          case 59:
            return "¡Date prisa! Tengo una cita con " + str1 + " dentro de una hora.";
          case 60:
            return "Quiero lo que vende " + str1 + ". ¿Cómo dices? ¿Que no vende nada?";
          case 61:
            return str4 + " es una monada. Es una lástima que sea tan mojigata.";
          case 62:
            return "Olvídate de " + str5 + ", yo tengo todo lo que necesitas aquí y ahora.";
          case 63:
            return "¿Qué mosca le ha picado a " + str5 + "? ¿Aún no sabe que vendemos cosas totalmente distintas?";
          case 64:
            return "Oye, hace una noche magnífica para no hablar con nadie, ¿no crees, " + Main.player[Main.myPlayer].name + "?";
          case 65:
            return "Me encantan estas noches. ¡Siempre encuentras algo que matar!";
          case 66:
            return "Sé que le has echado el ojo al Minitiburón. Será mejor que no sepas de qué está hecho.";
          case 67:
            return "Eh, amigo, que esto no es una película. La munición va aparte.";
          case 68:
            return "¡Aparta esas manos de mi pistola, colega!";
          case 69:
            return "¿Has probado a usar polvos de purificación sobre la piedra de ébano corrupta?";
          case 70:
            return "Ojalá " + str3 + " dejara de flirtear conmigo. ¿No se da cuenta de que tengo 500 años?";
          case 71:
            return "¿Por qué se empeña " + str2 + " en intentar venderme una estatua de ángel? Todo el mundo sabe que no hacen nada.";
          case 72:
            return "¿Has visto a ese anciano deambulando por la mazmorra? No tiene muy buen aspecto...";
          case 73:
            return "¡Yo vendo lo que quiero! Si no te gusta, mala suerte.";
          case 74:
            return "¿Por qué tienes que ser tan polémico en estos tiempos que corren?";
          case 75:
            return "No quiero que compres mis artículos. Quiero que desees comprar mis artículos, ¿entiendes?";
          case 76:
            return "Tío, ¿soy yo o esta noche han salido de juerga un millón de zombis?";
          case 77:
            return "Debes erradicar la corrupción de este mundo.";
          case 78:
            return "Ponte a salvo; ¡Terraria te necesita!";
          case 79:
            return "Fluyen las arenas del tiempo. Y la verdad... no estás envejeciendo con mucha elegancia.";
          case 80:
            return "¿Qué tiene que ver conmigo eso de perro ladrador?";
          case 81:
            return "Entra un duende en un bar y dice el dueño: \"A ver, quiero control, ¿eh?\". Y dice el duende: \"No, sin trol, sin trol\".";
          case 82:
            return "No puedo dejarte entrar hasta que me liberes de esta maldición.";
          case 83:
            return "Si quieres entrar, vuelve por la noche.";
          case 84:
            return "No se puede invocar al maestro a la luz del día.";
          case 85:
            return "Eres demasiado débil para romper esta maldición. Vuelve cuando seas de más utilidad.";
          case 86:
            return "Eres patético. No esperes presentarte ante el maestro tal como eres.";
          case 87:
            return "Espero que hayas venido con varios amigos...";
          case 88:
            return "Extraño, no, por favor. Esto es un suicidio.";
          case 89:
            return "Debes ser lo bastante fuerte para poder librarme de esta maldición...";
          case 90:
            return "Extraño, ¿te crees con fuerzas para derrotar al maestro?";
          case 91:
            return "¡Por favor! ¡Lucha con mi raptor y libérame! ¡Te lo suplico!";
          case 92:
            return "Derrota al maestro y te garantizaré la entrada a la Mazmorra.";
          case 93:
            return "¿Conque intentando dominar esa piedra de ébano, eh? ¿Por qué no la metes en uno de estos explosivos?";
          case 94:
            return "Eh, ¿has visto a un payaso por aquí?";
          case 95:
            return "Había una bomba aquí mismo, y ahora no soy capaz de encontrarla...";
          case 96:
            return "¡Yo les daré a esos zombis lo que necesitan!";
          case 97:
            return "¡Incluso " + str3 + " quiere lo que vendo!";
          case 98:
            return "Y pensé: ¿Qué prefieres? ¿Un agujero de bala o de granada?";
          case 99:
            return "Seguro que " + str1 + " te ayudará si pierdes una extremidad con uno de estos por accidente.";
          case 100:
            return "¿Por qué purificar el mundo cuando puedes volarlo en pedazos?";
          case 101:
            return "¡Si los lanzas a la bañera y cierras todas las ventanas, te despejará la nariz y los oídos!";
          case 102:
            return "¿Quieres jugar con fuego, gallina?";
          case 103:
            return "Oye, ¿firmarías esta renuncia de daños y perjuicios?";
          case 104:
            return "¡AQUÍ NO SE PUEDE FUMAR!";
          case 105:
            return "Los explosivos están de moda hoy en día. ¡Llévate algunos!";
          case 106:
            return "¡Es un buen día para morir!";
          case 107:
            return "Y qué pasa si... (¡BUM!)... Oh, lo siento, ¿usabas mucho esa pierna?";
          case 108:
            return "Dinamita, mi propia panacea para todos los males.";
          case 109:
            return "Echa un vistazo a este género; ¡los precios son una bomba!";
          case 110:
            return "Recuerdo vagamente haber atado a una mujer y haberla arrojado a una mazmorra.";
          case 111:
            return "¡Tenemos un problema! ¡Hoy tenemos luna sangrienta!";
          case 112:
            return "Si fuera más joven, invitaría a " + str1 + " a salir. Yo antes era todo un galán.";
          case 113:
            return "Ese sombrero rojo me resulta familiar...";
          case 114:
            return "Gracias otra vez por librarme de esta maldición. Sentí como si algo me hubiera saltado encima y me hubiera mordido.";
          case 115:
            return "Mamá siempre dijo que yo sería un buen sastre.";
          case 116:
            return "La vida es como un cajón de la ropa; ¡nunca sabes qué te vas a poner!";
          case 117:
            return "¡Desde luego bordar es una tarea difícil! ¡Si no fuera así, nadie lo haría! Eso es lo que la hace tan genial.";
          case 118:
            return "Sé todo lo que hay que saber sobre el negocio de la confección.";
          case 119:
            return "La maldición me ha convertido en un ser solitario; una vez me hice amigo de un muñeco de cuero. Lo llamaba Wilson.";
          case 120:
            return "Gracias por liberarme, humano. Otros duendes me ataron y me dejaron aquí. Te puedes imaginar que no nos llevamos muy bien.";
          case 121:
            return "¡No puedo creer que me ataran y me dejaran aquí solo por decirles que no se dirigían al este!";
          case 122:
            return "Ahora que soy un proscrito, ¿puedo tirar ya estas bolas de pinchos? Tengo los bolsillos destrozados.";
          case 123:
            return "¿Buscas un experto en artilugios? ¡Yo soy tu duende!";
          case 124:
            return "Gracias por tu ayuda. Tengo que dejar de vagar por ahí sin rumbo. Seguro que nos volvemos a ver.";
          case 125:
            return "Creía que eras más alto.";
          case 126:
            return "Oye... ¿Qué trama " + str10 + "? ¿Tú... has hablado con ella, por un casual?";
          case (int) sbyte.MaxValue:
            return "Eh, ¿quieres un motor para tu sombrero? Creo que tengo un motor que quedaría de perlas en ese sombrero.";
          case 128:
            return "Ey, he oído que te gustan los cohetes y las bota de correr, ¿por qué no te pongo unos cohetes en las botas?";
          case 129:
            return "El silencio es oro. Lo que daría por un poco de cinta adhesiva...";
          case 130:
            return "Pues claro, el oro es más resistente que el hierro. ¿Pero qué os enseñan estos humanos de hoy?";
          case 131:
            return "En fin, la idea de un casco de minero con alas quedaba mucho mejor sobre el papel.";
          case 132:
            return "Los duendes tienen un increíble predisposición al enfado. ¡De hecho, podrían declarar una guerra por una discusión sobre ropa!";
          case 133:
            return "Sinceramente, la mayoría de los duendes no son precisamente ingenieros de cohetes. Bueno, algunos sí.";
          case 134:
            return "¿Tú sabes por qué llevamos estas bolas con pinchos? Porque yo no.";
          case 135:
            return "¡Acabo de terminar mi última creación! Esta versión no explota con violencia si respiras encima con fuerza.";
          case 136:
            return "Los duendes ladrones no son muy buenos en lo suyo. ¡Ni siquiera saben robar un cofre abierto!";
          case 137:
            return "¡Gracias por salvarme, amigo! Estas ataduras me estaban haciendo rozaduras.";
          case 138:
            return "¡Oh, mi héroe!";
          case 139:
            return "¡Oh, qué heroico! ¡Gracias por salvarme, jovencita!";
          case 140:
            return "¡Oh, qué heroico por su parte! ¡Gracias por salvarme, jovencito!";
          case 141:
            return "Ahora que nos conocemos, ¿me puedo ir a vivir contigo, verdad?";
          case 142:
            return "¡Eh, hola, " + str7 + " ! ¿Qué puedo hacer hoy por ti?";
          case 143:
            return "¡Eh, hola, " + str5 + "! ¿Qué puedo hacer hoy por ti?";
          case 144:
            return "¡Eh, hola, " + str9 + "! ¿Qué puedo hacer hoy por ti?";
          case 145:
            return "¡Eh, hola, " + str1 + "! ¿Qué puedo hacer hoy por ti?";
          case 146:
            return "¡Eh, hola, " + str10 + "! ¿Qué puedo hacer hoy por ti?";
          case 147:
            return "¡Eh, hola, " + str4 + "! ¿Qué puedo hacer hoy por ti?";
          case 148:
            return "¿Quieres que saque una moneda de detrás de tu oreja? ¿No? Está bien.";
          case 149:
            return "¿Quieres un caramelo mágico? ¿No? Vale.";
          case 150:
            return "Si te gusta, mejor te hago un delicioso chocolate calentito... ¿Tampoco? Vale, está bien.";
          case 151:
            return "¿Has venido a echar un ojo a mi bola de cristal?";
          case 152:
            return "¿Nunca has deseado tener un anillo mágico que convierta las piedras en babosas? La verdad es que yo tampoco.";
          case 153:
            return "Una vez me dijeron que la amistad es algo mágico. ¡Ridículo! No puedes convertir a nadie en rana con la amistad.";
          case 154:
            return "Veo tu futuro... ¡Vas a comprarme un montón de artículos!";
          case 155:
            return "En cierta ocasión intenté devolverle la vida a una estatua de ángel. Pero no pasó nada.";
          case 156:
            return "¡Gracias! Era cuestión de tiempo que acabar como los demás esqueletos de ahí abajo.";
          case 157:
            return "¡Eh, mira por donde vas! ¡Llevo ahí desde hace... un rato!";
          case 158:
            return "Espera un momento, más abajo tengo wifi.";
          case 159:
            return "¡Casi había acabado de poner luces intermitentes aquí arriba!";
          case 160:
            return "NO TE MUEVAS. DEJÉ CAER MI LENTE DE CONTACTO.";
          case 161:
            return "Lo único que quiero es que el conmutador haga... ¿Qué?";
          case 162:
            return "A ver si lo adivino. No has comprado suficiente cable. ¡Serás tonto!";
          case 163:
            return "¿Podrías...? Solo... ¿Por favor...? ¿Vale? Está bien. Arrg.";
          case 164:
            return "No me gusta cómo me miras. Ahora estoy TRABAJANDO.";
          case 165:
            return "Eh, " + Main.player[Main.myPlayer].name + "¿acabas de llegar de la casa de " + str9 + "? ¿Por casualidad no te hablaría de mí?";
          case 166:
            return str3 + " sigue insistiendo en pulir mi chapa de presión. Ya le he dicho que funciona pisándola.";
          case 167:
            return "¡Siempre compras más cable del que necesitas!";
          case 168:
            return "¿Has comprobado que ese dispositivo esté enchufado?";
          case 169:
            return "Oh, ¿sabes lo que necesita esta casa? Más luces intermitentes.";
          case 170:
            return "Sabrás que se avecina una luna sangrienta cuando el cielo se tiña de rojo. Hay algo en ella que hace que los monstruos ataquen en grupo.";
          case 171:
            return "Eh, amigo, ¿sabes dónde hay por aquí malahierba? Oh, no es por nada, solo preguntaba, nada más.";
          case 172:
            return "Si miraras hacia arriba, verías que ahora mismo la luna está roja.";
          case 173:
            return "Deberías quedarte en casa por la noche. Es muy peligroso andar por ahí en la oscuridad.";
          case 174:
            return "Saludos, " + Main.player[Main.myPlayer].name + ". ¿Te puedo ayudar en algo?";
          case 175:
            return "Estoy aquí para aconsejarte sobre lo que debes ir haciendo. Te aconsejo que hables conmigo cuando estés atascado.";
          case 176:
            return "Dicen que hay una persona que te dirá cómo sobrevivir en esta tierra... oh, espera, sí soy yo.";
          case 177:
            return "Puedes usar el pico para cavar en la tierra y el hacha para talar árboles. Sitúa el cursor sobre el ladrillo y haz clic.";
          case 178:
            return "Si quieres sobrevivir, tendrás que crear armas y un refugio. Empieza talando árboles y recogiendo madera.";
          case 179:
            return "Pulsa ESC para acceder al menú de producción. Cuando tengas suficiente madera, crea un banco de trabajo, de este modo podrás crear otros objetos más elaborados siempre que permanezcas cerca del banco.";
          case 180:
            return "Puedes construir un refugio juntando madera y otros bloques que hay por el mundo. No olvides levantar y colocar paredes.";
          case 181:
            return "En cuanto tengas una espada de madera, puedes intentar recoger la baba de las babosas. Mezcla madera y baba para hacer una antorcha.";
          case 182:
            return "Para interactuar con el entorno y colocar objetos usa un martillo.";
          case 183:
            return "Deberías cavar una mina para encontrar mena de oro, con ella puedes crear objetos muy útiles.";
          case 184:
            return "Ahora que tienes un poco de oro, tendrás que convertirlo en un lingote para poder hacer objetos con él. Para ello necesitas un horno.";
          case 185:
            return "Puedes construir un horno con antorchas, madera y piedra. Asegúrate de no alejarte del banco de trabajo.";
          case 186:
            return "Necesitarás un yunque para crear objetos con los lingotes de metal.";
          case 187:
            return "Los yunques se pueden hacer de hierro o bien comprarse a un mercader.";
          case 188:
            return "En el Subsuelo hay corazones de cristal que puedes usar para aumentar al máximo tu vida. Para recogerlos, necesitarás un martillo.";
          case 189:
            return "Si recoges 10 estrellas caídas, podrás combinarlas para crear un objeto que aumente tu poder mágico.";
          case 190:
            return "Las estrellas caen del cielo a la tierra por la noche. Se pueden utilizar para toda clase de objetos útiles. Si ves una, date prisa en cogerla ya que desaparecen al amanecer.";
          case 191:
            return "Hay muchas formas de hacer que los demás se muden a nuestra ciudad. Por supuesto, necesitarán una casa en la que vivir.";
          case 192:
            return "Para que una habitación pueda ser considerada un hogar, debe tener una puerta, una silla, una mesa y una fuente de luz. No te olvides de las paredes de la casa.";
          case 193:
            return "En la misma casa no pueden vivir dos personas. Además, si se destruye una casa, esa persona deberá buscar un nuevo lugar donde vivir.";
          case 194:
            return "En la interfaz de vivienda puedes ver y asignar viviendas. Abre tu inventario y haz clic en el icono de casa.";
          case 195:
            return "Si quieres que un mercader se mude a una casa, deberás recoger una gran cantidad de dinero. Bastarán con 50 monedas de plata.";
          case 196:
            return "Para que se mude una enfermera, tendrías que aumentar al máximo tu nivel de vida.";
          case 197:
            return "Si tuvieras alguna pistola, seguro que aparecería algún traficante de armas para venderte municiones.";
          case 198:
            return "Deberías ponerte a prueba y derrotar a un monstruo corpulento. Eso llamaría la atención de una dríada.";
          case 199:
            return "Asegúrate de explorar la mazmorra a fondo. Podría haber prisioneros retenidos en la parte más profunda.";
          case 200:
            return "Quizás el anciano de la mazmorra quiera unirse a nosotros ahora que su maldición ha desaparecido.";
          case 201:
            return "Guarda bien las bombas que encuentres. Algún dinamitero querrá echarles un vistazo.";
          case 202:
            return "¿En realidad los duendes son tan distintos a nosotros que no podríamos vivir juntos en paz?";
          case 203:
            return "He oído que por esta región vive un poderoso mago. Estate muy atento por si lo ves la próxima vez que viajes al Subsuelo.";
          case 204:
            return "Si juntas varios lentes en un altar demoníaco, probablemente encuentres la forma de invocar a un monstruo poderoso. Aunque te conviene esperar hasta la noche para hacerlo.";
          case 205:
            return "Puedes hacer cebo de gusanos con trozos podridos y polvo vil. Asegúrate de estar en una zona corrompida antes de usarlo.";
          case 206:
            return "Los altares demoníacos se suelen encontrar en La Corrupción. Deberás estar cerca de los altares para crear objetos nuevos.";
          case 207:
            return "Puedes hacerte un garfio extensible con un garfio y 3 cadenas. Los esqueletos se encuentran en las profundidades del Subsuelo y suelen llevar garfios; se pueden hacer cadenas con lingotes de hierro.";
          case 208:
            return "Si ves un jarron, ábrelo aunque sea a golpes. Contienen toda clase de suministros de utilidad.";
          case 209:
            return "Hay un tesoro escondido por el mundo. ¡En las profundidades del Subsuelo se pueden encontrar objetos maravillosos!";
          case 210:
            return "Romper un orbe de las sombras a veces provoca la caída de un meteorito del cielo. Los orbes de las sombras se suelen encontrar en los abismos que rodean las zonas corrompidas";
          case 211:
            return "Deberías dedicarte a recoger más corazones de cristal para aumentar tu nivel de vida hasta el máximo.";
          case 212:
            return "El equipo que llevas sencillamente no sirve. Debes mejorar tu armadura.";
          case 213:
            return "Creo que ya estás listo para tu primer gran batalla. Recoge de noche algunas lentes de los ojos y llévalas a un altar demoníaco.";
          case 214:
            return "Te conviene aumentar tu nivel de vida antes de enfrentarte al siguiente desafío. Con 15 corazones bastará.";
          case 215:
            return "La piedra de ébano que se encuentra en La Corrupción se puede purificar usando un poco de polvo de una dríada, o bien puedes destruirla con explosivos.";
          case 216:
            return "El siguiente paso debería ser explorar los abismos corrompidos. Encuentra y destruye todos los orbes de las sombras que encuentres.";
          case 217:
            return "No muy lejos de aquí hay una antigua mazmorra. Ahora sería un buen momento para ir a echar un vistazo.";
          case 218:
            return "Deberías intentar aumentar al máximo el nivel de vida que te queda. Prueba con 20 corazones.";
          case 219:
            return "Hay muchos tesoros por descubrir en la selva si estás dispuesto a cavar a suficiente profundidad.";
          case 220:
            return "El Inframundo se compone de un material llamado piedra infernal, perfecta para hacer armas y armaduras.";
          case 221:
            return "Cuando estés preparado para desafiar al guardián del Inframundo, tendrás que hacer un sacrificio viviente. Todo lo que necesitas para hacerlo lo encontrarás en el Inframundo.";
          case 222:
            return "No dejes de destruir todos los altares demoníacos que encuentres. ¡Algo bueno te sucederá si lo haces!";
          case 223:
            return "A veces las almas se congregan en las criaturas caídas, en lugares de extrema luminosidad u oscuridad.";
          case 224:
            return "Ho ho ho y una botella de ... Ponche de huevo!";
          case 225:
            return "Cuidado que me galletitas?";
          case 226:
            return "¿Qué? Pensaste que no era real?";
          case 227:
            return "Me las arreglé para coser la cara de nuevo. Tener más cuidado la próxima vez.";
          case 228:
            return "Que probablemente va a dejar una cicatriz.";
          case 229:
            return "Todos los mejores. No quiero verte saltar ya los acantilados.";
          case 230:
            return "Que no le dolía demasiado malo, ya lo hizo?";
        }
      }
      return "";
    }

    public static string setBonus(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 0:
            return "2 defense";
          case 1:
            return "3 defense";
          case 2:
            return "15% increased movement speed";
          case 3:
            return "Space Gun costs 0 mana";
          case 4:
            return "20% chance to not consume ammo";
          case 5:
            return "16% reduced mana usage";
          case 6:
            return "17% extra melee damage";
          case 7:
            return "20% increased mining speed";
          case 8:
            return "14% reduced mana usage";
          case 9:
            return "15% increased melee speed";
          case 10:
            return "20% chance to not consume ammo";
          case 11:
            return "17% reduced mana usage";
          case 12:
            return "5% increased melee critical strike chance";
          case 13:
            return "20% chance to not consume ammo";
          case 14:
            return "19% reduced mana usage";
          case 15:
            return "18% increased melee and movement speed";
          case 16:
            return "25% chance to not consume ammo";
          case 17:
            return "20% reduced mana usage";
          case 18:
            return "19% increased melee and movement speed";
          case 19:
            return "25% chance to not consume ammo";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 0:
            return "2 Abwehr";
          case 1:
            return "3 Abwehr";
          case 2:
            return "Um 15% erhoehtes Bewegungstempo";
          case 3:
            return "Astralpistole kostet 0 Mana";
          case 4:
            return "20%ige Chance, Munition nicht zu verbrauchen";
          case 5:
            return "Um 16% reduzierte Mananutzung";
          case 6:
            return "17% Extra Nahkampfschaden";
          case 7:
            return "Um 20% erhoehtes Abbautempo";
          case 8:
            return "Um 14% reduzierte Mananutzung";
          case 9:
            return "Um 15% erhoehtes Nahkampftempo";
          case 10:
            return "20%ige Chance, Munition nicht zu verbrauchen";
          case 11:
            return "Um 17% reduzierte Mananutzung";
          case 12:
            return "5% Erhoehte kritische Nahkampf-Trefferchance";
          case 13:
            return "20%ige Chance, Munition nicht zu verbrauchen";
          case 14:
            return "Um 19% reduzierte Mananutzung";
          case 15:
            return "18% Erhoehtes Nahkampf-und Bewegungstempo";
          case 16:
            return "25%ige Chance, Munition nicht zu verbrauchen";
          case 17:
            return "Um 20% reduzierte Mananutzung";
          case 18:
            return "19% Erhoehtes Nahkampf-und Bewegungstempo";
          case 19:
            return "25%ige Chance, Munition nicht zu verbrauchen";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 0:
            return "2 difesa";
          case 1:
            return "3 difesa";
          case 2:
            return "Velocità di movimento aumentata del 15%";
          case 3:
            return "La pistola spaziale costa 0 mana";
          case 4:
            return "20% di possibilità di non consumare munizioni";
          case 5:
            return "Consumo mana ridotto del 16%";
          case 6:
            return "17% i danni melee in più";
          case 7:
            return "Velocità di estrazione aumentata del 20%";
          case 8:
            return "Consumo mana ridotto del 14%";
          case 9:
            return "Velocità del corpo a corpo aumentata del 15%";
          case 10:
            return "20% di possibilità di non consumare munizioni";
          case 11:
            return "Consumo mana ridotto del 17%";
          case 12:
            return "5% Possibilità di colpo critico nel corpo a corpo aumentata";
          case 13:
            return "20% di possibilità di non consumare munizioni";
          case 14:
            return "Consumo mana ridotto del 19%";
          case 15:
            return "18% Velocità di corpo a corpo e movimento aumentata";
          case 16:
            return "25% di possibilità di non consumare munizioni";
          case 17:
            return "Consumo mana ridotto del 20%";
          case 18:
            return "19% Velocità di corpo a corpo e movimento aumentata";
          case 19:
            return "25% di possibilità di non consumare munizioni";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 0:
            return "2 de défense";
          case 1:
            return "3 de défense";
          case 2:
            return "Vitesse de déplacement augmentée de 15 %";
          case 3:
            return "Le fusil de l'espace coûte 0 mana";
          case 4:
            return "20 % de chance de n'utiliser aucune munition";
          case 5:
            return "Utilisation de mana réduite de 16 %";
          case 6:
            return "17% de dégâts de mêlée supplémentaires";
          case 7:
            return "Vitesse d'extraction minière augmentée de 20 %";
          case 8:
            return "Utilisation de mana réduite de 14 %";
          case 9:
            return "Vitesse de mêlée augmentée de 15 %";
          case 10:
            return "20 % de chance de n'utiliser aucune munition";
          case 11:
            return "Utilisation de mana réduite de 17 %";
          case 12:
            return "5% Chance de coup critique de mêlée augmentée";
          case 13:
            return "20 % de chance de n'utiliser aucune munition";
          case 14:
            return "Utilisation de mana réduite de 19 %";
          case 15:
            return "18% Vitesse de mouvement et de mêlée augmentée";
          case 16:
            return "25 % de chance de n'utiliser aucune munition";
          case 17:
            return "Utilisation de mana réduite de 20 %";
          case 18:
            return "19% Vitesse de mouvement et de mêlée augmentée";
          case 19:
            return "25 % de chance de n'utiliser aucune munition";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 0:
            return "2 defensa";
          case 1:
            return "3 defensa";
          case 2:
            return "Aumenta en un 15% la velocidad de movimiento";
          case 3:
            return "La pistola espacial no cuesta maná";
          case 4:
            return "Probabilidad del 20% de no gastar munición";
          case 5:
            return "Reduce el uso de maná en un 16%";
          case 6:
            return "17% de daño cuerpo a cuerpo adicional";
          case 7:
            return "Aumenta en un 20% la velocidad de excavación";
          case 8:
            return "Reduce el uso de maná en un 14%";
          case 9:
            return "Aumenta un 15% la velocidad en el cuerpo a cuerpo";
          case 10:
            return "Probabilidad del 20% de no gastar munición";
          case 11:
            return "Reduce el uso de maná en un 17%";
          case 12:
            return "Aumenta la probabilidad de ataque crítico en el cuerpo a cuerpo";
          case 13:
            return "Probabilidad del 20% de no gastar munición";
          case 14:
            return "Reduce el uso de maná en un 19%";
          case 15:
            return "18% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
          case 16:
            return "Probabilidad del 25% de no gastar munición";
          case 17:
            return "Reduce el uso de maná en un 20%";
          case 18:
            return "19% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
          case 19:
            return "Probabilidad del 25% de no gastar munición";
        }
      }
      return "";
    }

    public static string npcName(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case -17:
            return "Big Stinger";
          case -16:
            return "Little Stinger";
          case -15:
            return "Heavy Skeleton";
          case -14:
            return "Big Boned";
          case -13:
            return "Short Bones";
          case -12:
            return "Big Eater";
          case -11:
            return "Little Eater";
          case -10:
            return "Jungle Slime";
          case -9:
            return "Yellow Slime";
          case -8:
            return "Red Slime";
          case -7:
            return "Purple Slime";
          case -6:
            return "Black Slime";
          case -5:
            return "Baby Slime";
          case -4:
            return "Pinky";
          case -3:
            return "Green Slime";
          case -2:
            return "Slimer";
          case -1:
            return "Slimeling";
          case 1:
            return "Blue Slime";
          case 2:
            return "Demon Eye";
          case 3:
            return "Zombie";
          case 4:
            return "Eye of Cthulhu";
          case 5:
            return "Servant of Cthulhu";
          case 6:
            return "Eater of Souls";
          case 7:
            return "Devourer";
          case 8:
            return "Devourer";
          case 9:
            return "Devourer";
          case 10:
            return "Giant Worm";
          case 11:
            return "Giant Worm";
          case 12:
            return "Giant Worm";
          case 13:
            return "Eater of Worlds";
          case 14:
            return "Eater of Worlds";
          case 15:
            return "Eater of Worlds";
          case 16:
            return "Mother Slime";
          case 17:
            return "Merchant";
          case 18:
            return "Nurse";
          case 19:
            return "Arms Dealer";
          case 20:
            return "Dryad";
          case 21:
            return "Skeleton";
          case 22:
            return "Guide";
          case 23:
            return "Meteor Head";
          case 24:
            return "Fire Imp";
          case 25:
            return "Burning Sphere";
          case 26:
            return "Goblin Peon";
          case 27:
            return "Goblin Thief";
          case 28:
            return "Goblin Warrior";
          case 29:
            return "Goblin Sorcerer";
          case 30:
            return "Chaos Ball";
          case 31:
            return "Angry Bones";
          case 32:
            return "Dark Caster";
          case 33:
            return "Water Sphere";
          case 34:
            return "Cursed Skull";
          case 35:
            return "Skeletron";
          case 36:
            return "Skeletron";
          case 37:
            return "Old Man";
          case 38:
            return "Demolitionist";
          case 39:
            return "Bone Serpent";
          case 40:
            return "Bone Serpent";
          case 41:
            return "Bone Serpent";
          case 42:
            return "Hornet";
          case 43:
            return "Man Eater";
          case 44:
            return "Undead Miner";
          case 45:
            return "Tim";
          case 46:
            return "Bunny";
          case 47:
            return "Corrupt Bunny";
          case 48:
            return "Harpy";
          case 49:
            return "Cave Bat";
          case 50:
            return "King Slime";
          case 51:
            return "Jungle Bat";
          case 52:
            return "Doctor Bones";
          case 53:
            return "The Groom";
          case 54:
            return "Clothier";
          case 55:
            return "Goldfish";
          case 56:
            return "Snatcher";
          case 57:
            return "Corrupt Goldfish";
          case 58:
            return "Piranha";
          case 59:
            return "Lava Slime";
          case 60:
            return "Hellbat";
          case 61:
            return "Vulture";
          case 62:
            return "Demon";
          case 63:
            return "Blue Jellyfish";
          case 64:
            return "Pink Jellyfish";
          case 65:
            return "Shark";
          case 66:
            return "Voodoo Demon";
          case 67:
            return "Crab";
          case 68:
            return "Dungeon Guardian";
          case 69:
            return "Antlion";
          case 70:
            return "Spike Ball";
          case 71:
            return "Dungeon Slime";
          case 72:
            return "Blazing Wheel";
          case 73:
            return "Goblin Scout";
          case 74:
            return "Bird";
          case 75:
            return "Pixie";
          case 77:
            return "Armored Skeleton";
          case 78:
            return "Mummy";
          case 79:
            return "Dark Mummy";
          case 80:
            return "Light Mummy";
          case 81:
            return "Corrupt Slime";
          case 82:
            return "Wraith";
          case 83:
            return "Cursed Hammer";
          case 84:
            return "Enchanted Sword";
          case 85:
            return "Mimic";
          case 86:
            return "Unicorn";
          case 87:
            return "Wyvern";
          case 88:
            return "Wyvern";
          case 89:
            return "Wyvern";
          case 90:
            return "Wyvern";
          case 91:
            return "Wyvern";
          case 92:
            return "Wyvern";
          case 93:
            return "Giant Bat";
          case 94:
            return "Corruptor";
          case 95:
            return "Digger";
          case 96:
            return "Digger";
          case 97:
            return "Digger";
          case 98:
            return "World Feeder";
          case 99:
            return "World Feeder";
          case 100:
            return "World Feeder";
          case 101:
            return "Clinger";
          case 102:
            return "Angler Fish";
          case 103:
            return "Green Jellyfish";
          case 104:
            return "Werewolf";
          case 105:
            return "Bound Goblin";
          case 106:
            return "Bound Wizard";
          case 107:
            return "Goblin Tinkerer";
          case 108:
            return "Wizard";
          case 109:
            return "Clown";
          case 110:
            return "Skeleton Archer";
          case 111:
            return "Goblin Archer";
          case 112:
            return "Vile Spit";
          case 113:
            return "Wall of Flesh";
          case 114:
            return "Wall of Flesh";
          case 115:
            return "The Hungry";
          case 116:
            return "The Hungry";
          case 117:
            return "Leech";
          case 118:
            return "Leech";
          case 119:
            return "Leech";
          case 120:
            return "Chaos Elemental";
          case 121:
            return "Slimer";
          case 122:
            return "Gastropod";
          case 123:
            return "Bound Mechanic";
          case 124:
            return "Mechanic";
          case 125:
            return "Retinazer";
          case 126:
            return "Spazmatism";
          case (int) sbyte.MaxValue:
            return "Skeletron Prime";
          case 128:
            return "Prime Cannon";
          case 129:
            return "Prime Saw";
          case 130:
            return "Prime Vice";
          case 131:
            return "Prime Laser";
          case 132:
            return "Zombie";
          case 133:
            return "Wandering Eye";
          case 134:
            return "The Destroyer";
          case 135:
            return "The Destroyer";
          case 136:
            return "The Destroyer";
          case 137:
            return "Illuminant Bat";
          case 138:
            return "Illuminant Slime";
          case 139:
            return "Probe";
          case 140:
            return "Possessed Armor";
          case 141:
            return "Toxic Sludge";
          case 142:
            return "Santa Claus";
          case 143:
            return "Snowman Gangsta";
          case 144:
            return "Mister Stabby";
          case 145:
            return "Snow Balla";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case -17:
            return "Riesenhornisse";
          case -16:
            return "Minihornisse";
          case -15:
            return "Mammutskelett";
          case -14:
            return "Grossknochen";
          case -13:
            return "Kleinknochen";
          case -12:
            return "Maxifresser";
          case -11:
            return "Minifresser";
          case -10:
            return "Dschungelschleimi";
          case -9:
            return "Gelbschleimi";
          case -8:
            return "Rotschleimi";
          case -7:
            return "Lila Schleimi";
          case -6:
            return "Schwarzschleimi";
          case -5:
            return "Schleimbaby";
          case -4:
            return "Pinky";
          case -3:
            return "Gruenschleimi";
          case -2:
            return "Flugschleimi";
          case -1:
            return "Schleimling";
          case 1:
            return "Blauschleimi";
          case 2:
            return "Daemonenauge";
          case 3:
            return "Zombie";
          case 4:
            return "Auge von Cthulhu";
          case 5:
            return "Diener von Cthulhu";
          case 6:
            return "Seelenfresser";
          case 7:
            return "Verschlinger";
          case 8:
            return "Verschlinger";
          case 9:
            return "Verschlinger";
          case 10:
            return "Riesenwurm";
          case 11:
            return "Riesenwurm";
          case 12:
            return "Riesenwurm";
          case 13:
            return "Weltenfresser";
          case 14:
            return "Weltenfresser";
          case 15:
            return "Weltenfresser";
          case 16:
            return "Schleimmami";
          case 17:
            return "Haendler";
          case 18:
            return "Krankenschwester";
          case 19:
            return "Waffenhaendler";
          case 20:
            return "Dryade";
          case 21:
            return "Skelett";
          case 22:
            return "Fremdenfuehrer";
          case 23:
            return "Meteorenkopf";
          case 24:
            return "Feuer-Imp";
          case 25:
            return "Flammenkugel";
          case 26:
            return "Goblin-Arbeiter";
          case 27:
            return "Goblin-Dieb";
          case 28:
            return "Goblin-Krieger";
          case 29:
            return "Goblin-Hexer";
          case 30:
            return "Chaoskugel";
          case 31:
            return "Wutknochen";
          case 32:
            return "Duestermagier";
          case 33:
            return "Wasserkugel";
          case 34:
            return "Fluchschaedel";
          case 35:
            return "Skeletron";
          case 36:
            return "Skeletron";
          case 37:
            return "Greis";
          case 38:
            return "Sprengmeister";
          case 39:
            return "Knochenschlange";
          case 40:
            return "Knochenschlange";
          case 41:
            return "Knochenschlange";
          case 42:
            return "Hornisse";
          case 43:
            return "Menschenfresser";
          case 44:
            return "Bergmann-Untoter";
          case 45:
            return "Tim";
          case 46:
            return "Haeschen";
          case 47:
            return "Verderbnishaeschen";
          case 48:
            return "Harpyie";
          case 49:
            return "Hoehlenfledermaus";
          case 50:
            return "Schleimi-Koenig";
          case 51:
            return "Dschungelfledermaus";
          case 52:
            return "Doktor Bones";
          case 53:
            return "Braeutigam";
          case 54:
            return "Kleiderhaendler";
          case 55:
            return "Goldfisch";
          case 56:
            return "Schnapper";
          case 57:
            return "Verderbnisgoldfisch";
          case 58:
            return "Piranha";
          case 59:
            return "Lava-Schleimi";
          case 60:
            return "Hoellenfledermaus";
          case 61:
            return "Geier";
          case 62:
            return "Daemon";
          case 63:
            return "Blauqualle";
          case 64:
            return "Pinkqualle";
          case 65:
            return "Hai";
          case 66:
            return "Voodoo-Daemon";
          case 67:
            return "Krabbe";
          case 68:
            return "Dungeon-Waechter";
          case 69:
            return "Ameisenloewe";
          case 70:
            return "Nagelball";
          case 71:
            return "Dungeon-Schleimi";
          case 72:
            return "Flammenrad";
          case 73:
            return "Goblin-Spaeher";
          case 74:
            return "Vogel";
          case 75:
            return "Pixie";
          case 76:
            return "";
          case 77:
            return "Ruestungsskelett";
          case 78:
            return "Mumie";
          case 79:
            return "Finstermumie";
          case 80:
            return "Lichtmumie";
          case 81:
            return "Verderbnisschleimi";
          case 82:
            return "Monstergeist";
          case 83:
            return "Fluchhammer";
          case 84:
            return "Zauberschwert";
          case 85:
            return "Imitator";
          case 86:
            return "Einhorn";
          case 87:
            return "Lindwurm";
          case 88:
            return "Lindwurm";
          case 89:
            return "Lindwurm";
          case 90:
            return "Lindwurm";
          case 91:
            return "Lindwurm";
          case 92:
            return "Lindwurm";
          case 93:
            return "Riesenfledermaus";
          case 94:
            return "Verderber";
          case 95:
            return "Wuehler";
          case 96:
            return "Wuehler";
          case 97:
            return "Wuehler";
          case 98:
            return "Weltspeiser";
          case 99:
            return "Weltspeiser";
          case 100:
            return "Weltspeiser";
          case 101:
            return "Klette";
          case 102:
            return "Seeteufel";
          case 103:
            return "Gruenqualle";
          case 104:
            return "Werwolf";
          case 105:
            return "Gebundener Goblin";
          case 106:
            return "Gebundener Zauberer";
          case 107:
            return "Goblin-Tueftler";
          case 108:
            return "Zauberer";
          case 109:
            return "Clown";
          case 110:
            return "Skelettbogenschuetze";
          case 111:
            return "Goblin-Bogenschuetze";
          case 112:
            return "Ekelspeichel";
          case 113:
            return "Fleischwand";
          case 114:
            return "Fleischwand";
          case 115:
            return "Fressmaul";
          case 116:
            return "Fressmaul";
          case 117:
            return "Blutegel";
          case 118:
            return "Blutegel";
          case 119:
            return "Blutegel";
          case 120:
            return "Elementarchaos";
          case 121:
            return "Flugschleimi";
          case 122:
            return "Bauchfuessler";
          case 123:
            return "Gebundene Mechanikerin";
          case 124:
            return "Mechanikerin";
          case 125:
            return "Retinator";
          case 126:
            return "Spasmator";
          case (int) sbyte.MaxValue:
            return "Super-Skeletron";
          case 128:
            return "Super-Kanone";
          case 129:
            return "Super-Saege";
          case 130:
            return "Super-Zange";
          case 131:
            return "Super-Laser";
          case 132:
            return "Zombie";
          case 133:
            return "Wanderauge";
          case 134:
            return "Zerstoerer";
          case 135:
            return "Zerstoerer";
          case 136:
            return "Zerstoerer";
          case 137:
            return "Leuchtledermaus";
          case 138:
            return "Leuchtschleimi";
          case 139:
            return "Sonde";
          case 140:
            return "Geisterruestung";
          case 141:
            return "Giftschlamm";
          case 142:
            return "Weihnachtsmann";
          case 143:
            return "Snowman Gangsta";
          case 144:
            return "Herr Stabby";
          case 145:
            return "Schnee Balla";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case -17:
            return "Vespa grande";
          case -16:
            return "Vespa piccola";
          case -15:
            return "Scheletro pesante";
          case -14:
            return "Disossato";
          case -13:
            return "Ossa corte";
          case -12:
            return "Grande mangiatore";
          case -11:
            return "Piccolo mangiatore";
          case -10:
            return "Slime della giungla";
          case -9:
            return "Slime giallo";
          case -8:
            return "Slime rosso";
          case -7:
            return "Slime viola";
          case -6:
            return "Slime nero";
          case -5:
            return "Slime baby";
          case -4:
            return "Mignolo";
          case -3:
            return "Slime verde";
          case -2:
            return "Slimer";
          case -1:
            return "Slimeling";
          case 1:
            return "Slime blu";
          case 2:
            return "Occhio demoniaco";
          case 3:
            return "Zombi";
          case 4:
            return "Occhio di Cthulhu";
          case 5:
            return "Servo di Cthulhu";
          case 6:
            return "Mangiatore di anime";
          case 7:
            return "Divoratore";
          case 8:
            return "Divoratore";
          case 9:
            return "Divoratore";
          case 10:
            return "Verme gigante";
          case 11:
            return "Verme gigante";
          case 12:
            return "Verme gigante";
          case 13:
            return "Mangiatore di mondi";
          case 14:
            return "Mangiatore di mondi";
          case 15:
            return "Mangiatore di mondi";
          case 16:
            return "Slime madre";
          case 17:
            return "Mercante";
          case 18:
            return "Infermiera";
          case 19:
            return "Mercante di armi";
          case 20:
            return "Driade";
          case 21:
            return "Scheletro";
          case 22:
            return "Guida";
          case 23:
            return "Testa di meteorite";
          case 24:
            return "Diavoletto di fuoco";
          case 25:
            return "Sfera infuocata";
          case 26:
            return "Goblin operaio";
          case 27:
            return "Goblin ladro";
          case 28:
            return "Goblin guerriero";
          case 29:
            return "Goblin stregone";
          case 30:
            return "Palla del caos";
          case 31:
            return "Ossa arrabbiate";
          case 32:
            return "Lanciatore oscuro";
          case 33:
            return "Sfera d'acqua";
          case 34:
            return "Teschio maledetto";
          case 35:
            return "Skeletron";
          case 36:
            return "Skeletron";
          case 37:
            return "Vecchio";
          case 38:
            return "Esperto in demolizioni";
          case 39:
            return "Serpente di ossa";
          case 40:
            return "Serpente di ossa";
          case 41:
            return "Serpente di ossa";
          case 42:
            return "Calabrone";
          case 43:
            return "Mangiauomini";
          case 44:
            return "Minatore non-morto";
          case 45:
            return "Tim";
          case 46:
            return "Coniglio";
          case 47:
            return "Coniglio distrutto";
          case 48:
            return "Arpia";
          case 49:
            return "Pipistrello della caverna";
          case 50:
            return "Slime re";
          case 51:
            return "Pipistrello della giungla";
          case 52:
            return "Dottor ossa";
          case 53:
            return "Lo sposo";
          case 54:
            return "Mercante di abiti";
          case 55:
            return "Pesce rosso";
          case 56:
            return "Pianta afferratrice";
          case 57:
            return "Pesce rosso distrutto";
          case 58:
            return "Piranha";
          case 59:
            return "Slime di lava";
          case 60:
            return "Pipistrello dell'inferno";
          case 61:
            return "Avvoltoio";
          case 62:
            return "Demone";
          case 63:
            return "Medusa blu";
          case 64:
            return "Medusa rosa";
          case 65:
            return "Squalo";
          case 66:
            return "Demone voodoo";
          case 67:
            return "Granchio";
          case 68:
            return "Guardiano delle segrete";
          case 69:
            return "Formicaleone";
          case 70:
            return "Sfera con spuntoni";
          case 71:
            return "Slime delle segrete";
          case 72:
            return "Ruota ardente";
          case 73:
            return "Goblin ricognitore";
          case 74:
            return "Uccello";
          case 75:
            return "Folletto";
          case 76:
            return "";
          case 77:
            return "Scheletro corazzato";
          case 78:
            return "Mummia";
          case 79:
            return "Mummia oscura";
          case 80:
            return "Mummia chiara";
          case 81:
            return "Slime distrutto";
          case 82:
            return "Fantasma";
          case 83:
            return "Martello maledetto";
          case 84:
            return "Spada incantata";
          case 85:
            return "Sosia";
          case 86:
            return "Unicorno";
          case 87:
            return "Viverna";
          case 88:
            return "Viverna";
          case 89:
            return "Viverna";
          case 90:
            return "Viverna";
          case 91:
            return "Viverna";
          case 92:
            return "Viverna";
          case 93:
            return "Pipistrello gigante";
          case 94:
            return "Distruttore";
          case 95:
            return "Scavatore";
          case 96:
            return "Scavatore";
          case 97:
            return "Scavatore";
          case 98:
            return "Alimentatore del mondo";
          case 99:
            return "Alimentatore del mondo";
          case 100:
            return "Alimentatore del mondo";
          case 101:
            return "Appiccicoso";
          case 102:
            return "Rana pescatrice";
          case 103:
            return "Medusa verde";
          case 104:
            return "Lupo mannaro";
          case 105:
            return "Goblin legato";
          case 106:
            return "Stregone legato";
          case 107:
            return "Goblin inventore";
          case 108:
            return "Stregone";
          case 109:
            return "Clown";
          case 110:
            return "Scheletro arciere";
          case 111:
            return "Goblin arciere";
          case 112:
            return "Bava disgustosa";
          case 113:
            return "Muro di carne";
          case 114:
            return "Muro di carne";
          case 115:
            return "L'Affamato";
          case 116:
            return "L'Affamato";
          case 117:
            return "Sanguisuga";
          case 118:
            return "Sanguisuga";
          case 119:
            return "Sanguisuga";
          case 120:
            return "Elementale del caos";
          case 121:
            return "Slimer";
          case 122:
            return "Gasteropodo";
          case 123:
            return "Meccanico legata";
          case 124:
            return "Meccanico";
          case 125:
            return "Retinazer";
          case 126:
            return "Spazmatism";
          case (int) sbyte.MaxValue:
            return "Skeletron primario";
          case 128:
            return "Cannone primario";
          case 129:
            return "Sega primaria";
          case 130:
            return "Morsa primaria";
          case 131:
            return "Laser primario";
          case 132:
            return "Zombi";
          case 133:
            return "Occhio errante";
          case 134:
            return "Il Distruttore";
          case 135:
            return "Il Distruttore";
          case 136:
            return "Il Distruttore";
          case 137:
            return "Pipistrello illuminante";
          case 138:
            return "Slime illuminante";
          case 139:
            return "Sonda";
          case 140:
            return "Armatura posseduta";
          case 141:
            return "Fango tossico";
          case 142:
            return "Babbo Natale";
          case 143:
            return "pupazzo di neve Gangsta";
          case 144:
            return "signor Stabby";
          case 145:
            return "neve Balla";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case -17:
            return "Gros frelon";
          case -16:
            return "Petit frelon";
          case -15:
            return "Squelette lourd";
          case -14:
            return "Grand squelette";
          case -13:
            return "Petit squelette";
          case -12:
            return "Grand dévoreur";
          case -11:
            return "Petit dévoreur";
          case -10:
            return "Slime de la jungle";
          case -9:
            return "Slime jaune";
          case -8:
            return "Slime rouge";
          case -7:
            return "Slime violet";
          case -6:
            return "Slime noir";
          case -5:
            return "Bébé slime";
          case -4:
            return "Pinky";
          case -3:
            return "Slime vert";
          case -2:
            return "Slimer";
          case -1:
            return "Slimeling";
          case 1:
            return "Slime bleu";
          case 2:
            return "Œil de démon";
          case 3:
            return "Zombie";
          case 4:
            return "Œil de Cthulhu";
          case 5:
            return "Servant de Cthulhu";
          case 6:
            return "Dévoreur d'âmes";
          case 7:
            return "Dévoreur";
          case 8:
            return "Dévoreur";
          case 9:
            return "Dévoreur";
          case 10:
            return "Ver géant";
          case 11:
            return "Ver géant";
          case 12:
            return "Ver géant";
          case 13:
            return "Dévoreur de mondes";
          case 14:
            return "Dévoreur de mondes";
          case 15:
            return "Dévoreur de mondes";
          case 16:
            return "Mère slime";
          case 17:
            return "Marchand";
          case 18:
            return "Infirmière";
          case 19:
            return "Marchand d'armes";
          case 20:
            return "Dryade";
          case 21:
            return "Squelette";
          case 22:
            return "Guide";
          case 23:
            return "Tête de météorite";
          case 24:
            return "Diablotin de feu";
          case 25:
            return "Sphère brûlante";
          case 26:
            return "Péon gobelin";
          case 27:
            return "Voleur gobelin";
          case 28:
            return "Guerrier gobelin";
          case 29:
            return "Sorcier gobelin";
          case 30:
            return "Boule de chaos";
          case 31:
            return "Squelette furieux";
          case 32:
            return "Magicien noir";
          case 33:
            return "Sphère d'eau";
          case 34:
            return "Crâne maudit";
          case 35:
            return "Squeletron";
          case 36:
            return "Squeletron";
          case 37:
            return "Vieil homme";
          case 38:
            return "Démolisseur";
          case 39:
            return "Serpent d'os";
          case 40:
            return "Serpent d'os";
          case 41:
            return "Serpent d'os";
          case 42:
            return "Frelon";
          case 43:
            return "Mangeur d'hommes";
          case 44:
            return "Mineur mort-vivant";
          case 45:
            return "Tim";
          case 46:
            return "Lapin";
          case 47:
            return "Lapin corrompu";
          case 48:
            return "Harpie";
          case 49:
            return "Chauve-souris";
          case 50:
            return "Roi slime";
          case 51:
            return "Chauve-souris de la jungle";
          case 52:
            return "Docteur Bones";
          case 53:
            return "Le jeune marié";
          case 54:
            return "Tailleur";
          case 55:
            return "Poisson doré";
          case 56:
            return "Ravisseur";
          case 57:
            return "Poisson doré corrompu";
          case 58:
            return "Piranha";
          case 59:
            return "Slime de l'enfer";
          case 60:
            return "Chauve-souris de l'enfer";
          case 61:
            return "Vautour";
          case 62:
            return "Démon";
          case 63:
            return "Méduse bleue";
          case 64:
            return "Méduse rose";
          case 65:
            return "Requin";
          case 66:
            return "Démon vaudou";
          case 67:
            return "Crabe";
          case 68:
            return "Gardien du donjon";
          case 69:
            return "Fourmilion";
          case 70:
            return "Boule piquante";
          case 71:
            return "Slime des donjons";
          case 72:
            return "Roue de feu";
          case 73:
            return "Scout gobelin";
          case 74:
            return "Oiseau";
          case 75:
            return "Lutin";
          case 76:
            return "";
          case 77:
            return "Squelette en armure";
          case 78:
            return "Momie";
          case 79:
            return "Momie de l'ombre";
          case 80:
            return "Momie de lumière";
          case 81:
            return "Slime corrompu";
          case 82:
            return "Spectre";
          case 83:
            return "Marteau maudit";
          case 84:
            return "Épée enchantée";
          case 85:
            return "Imitateur";
          case 86:
            return "Licorne";
          case 87:
            return "Wyverne";
          case 88:
            return "Wyverne";
          case 89:
            return "Wyverne";
          case 90:
            return "Wyverne";
          case 91:
            return "Wyverne";
          case 92:
            return "Wyverne";
          case 93:
            return "Chauve-souris géante";
          case 94:
            return "Corrupteur";
          case 95:
            return "Fouisseur";
          case 96:
            return "Fouisseur";
          case 97:
            return "Fouisseur";
          case 98:
            return "Nourricier";
          case 99:
            return "Nourricier";
          case 100:
            return "Nourricier";
          case 101:
            return "Cracheur";
          case 102:
            return "Baudroie";
          case 103:
            return "Méduse verte";
          case 104:
            return "Loup-garou";
          case 105:
            return "Gobelin attaché";
          case 106:
            return "Magicien attaché";
          case 107:
            return "Gobelin bricoleur";
          case 108:
            return "Magicien";
          case 109:
            return "Clown";
          case 110:
            return "Archer squelette";
          case 111:
            return "Archer gobelin";
          case 112:
            return "Immonde crachat";
          case 113:
            return "Mur de chair";
          case 114:
            return "Mur de chair";
          case 115:
            return "L'affamé";
          case 116:
            return "L'affamé";
          case 117:
            return "Sangsue";
          case 118:
            return "Sangsue";
          case 119:
            return "Sangsue";
          case 120:
            return "Élémentaire du chaos";
          case 121:
            return "Slimer";
          case 122:
            return "Gastropode";
          case 123:
            return "Mécanicienne attachée";
          case 124:
            return "Mécanicienne";
          case 125:
            return "Rétinazer";
          case 126:
            return "Spazmatisme";
          case (int) sbyte.MaxValue:
            return "Squeletron primaire";
          case 128:
            return "Canon primaire";
          case 129:
            return "Scie primaire";
          case 130:
            return "Étau principal";
          case 131:
            return "Laser principal";
          case 132:
            return "Zombie";
          case 133:
            return "Œil vagabond";
          case 134:
            return "Le destructeur";
          case 135:
            return "Le destructeur";
          case 136:
            return "Le destructeur";
          case 137:
            return "Chauve-souris illuminée";
          case 138:
            return "Slime illuminé";
          case 139:
            return "Sonde";
          case 140:
            return "Armure possédée";
          case 141:
            return "Boue toxique";
          case 142:
            return "Père Noël";
          case 143:
            return "Snowman Gangsta";
          case 144:
            return "Monsieur Stabby";
          case 145:
            return "neige Balla";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case -17:
            return "Gran avispa";
          case -16:
            return "Avispa pequeña";
          case -15:
            return "Esqueleto pesado";
          case -14:
            return "Gran deshuesado";
          case -13:
            return "Pequeño deshuesado";
          case -12:
            return "Gran devorador";
          case -11:
            return "Pequeño devorador";
          case -10:
            return "Babosa de selva";
          case -9:
            return "Babosa amarilla";
          case -8:
            return "Babosa roja";
          case -7:
            return "Babosa morada";
          case -6:
            return "Babosa negra";
          case -5:
            return "Bebé babosa";
          case -4:
            return "Babosa rosa";
          case -3:
            return "Babosa verde";
          case -2:
            return "Baboseadora";
          case -1:
            return "Babosas";
          case 1:
            return "Babosa azul";
          case 2:
            return "Ojo demoníaco";
          case 3:
            return "Zombi";
          case 4:
            return "Ojo Cthulhu";
          case 5:
            return "Siervo de Cthulhu";
          case 6:
            return "Devoraalmas";
          case 7:
            return "Gusano devorador";
          case 8:
            return "Gusano devorador";
          case 9:
            return "Gusano devorador";
          case 10:
            return "Gusano gigante";
          case 11:
            return "Gusano gigante";
          case 12:
            return "Gusano gigante";
          case 13:
            return "Devoramundos";
          case 14:
            return "Devoramundos";
          case 15:
            return "Devoramundos";
          case 16:
            return "Mamá babosa";
          case 17:
            return "Mercader";
          case 18:
            return "Enfermera";
          case 19:
            return "Traficante de armas";
          case 20:
            return "Dríada";
          case 21:
            return "Esqueleto";
          case 22:
            return "Guía";
          case 23:
            return "Cabeza meteorito";
          case 24:
            return "Diablillo de fuego";
          case 25:
            return "Esfera ardiente";
          case 26:
            return "Duende Peón";
          case 27:
            return "Duende ladrón";
          case 28:
            return "Duende guerrero";
          case 29:
            return "Duende hechicero";
          case 30:
            return "Bola del caos";
          case 31:
            return "Deshuesado furioso";
          case 32:
            return "Fundidor siniestro";
          case 33:
            return "Esfera de agua";
          case 34:
            return "Cráneo maldito";
          case 35:
            return "Esqueletrón";
          case 36:
            return "Esqueletrón";
          case 37:
            return "Anciano";
          case 38:
            return "Dinamitero";
          case 39:
            return "Esqueleto de serpiente";
          case 40:
            return "Esqueleto de serpiente";
          case 41:
            return "Esqueleto de serpiente";
          case 42:
            return "Avispón";
          case 43:
            return "Devorahombres";
          case 44:
            return "Minero zombi";
          case 45:
            return "Tim";
          case 46:
            return "Conejito";
          case 47:
            return "Conejito corrompido";
          case 48:
            return "Arpía";
          case 49:
            return "Murciélago de cueva";
          case 50:
            return "Babosa rey";
          case 51:
            return "Murciélago de selva";
          case 52:
            return "Doctor Látigo";
          case 53:
            return "El novio zombi";
          case 54:
            return "Buhonero";
          case 55:
            return "Pececillo";
          case 56:
            return "Atrapadora";
          case 57:
            return "Pececillo corrompido";
          case 58:
            return "Piraña";
          case 59:
            return "Babosa de lava";
          case 60:
            return "Murciélago infernal";
          case 61:
            return "Buitre";
          case 62:
            return "Demonio";
          case 63:
            return "Medusa azul";
          case 64:
            return "Medusa rosa";
          case 65:
            return "Tiburón";
          case 66:
            return "Demonio vudú";
          case 67:
            return "Cangrejo";
          case 68:
            return "Guardián de la mazmorra";
          case 69:
            return "Hormiga león";
          case 70:
            return "Bola Gancho";
          case 71:
            return "Babosa de la mazmorra";
          case 72:
            return "Rueda ardiente";
          case 73:
            return "Duende explorador";
          case 74:
            return "Pájaro";
          case 75:
            return "Duendecillo";
          case 76:
            return "";
          case 77:
            return "Esqueleto con armadura";
          case 78:
            return "Momia";
          case 79:
            return "Momia de la oscuridad";
          case 80:
            return "Momia de la luz";
          case 81:
            return "Babosa corrompida";
          case 82:
            return "Espectro";
          case 83:
            return "Martillo maldito";
          case 84:
            return "Espada encantada";
          case 85:
            return "Cofre falso";
          case 86:
            return "Unicornio";
          case 87:
            return "Guiverno";
          case 88:
            return "Guiverno";
          case 89:
            return "Guiverno";
          case 90:
            return "Guiverno";
          case 91:
            return "Guiverno";
          case 92:
            return "Guiverno";
          case 93:
            return "Murciélago gigante";
          case 94:
            return "Corruptor";
          case 95:
            return "Excavador";
          case 96:
            return "Excavador";
          case 97:
            return "Excavador";
          case 98:
            return "Tragamundos";
          case 99:
            return "Tragamundos";
          case 100:
            return "Tragamundos";
          case 101:
            return "Lapa";
          case 102:
            return "Rape";
          case 103:
            return "Medusa verde";
          case 104:
            return "Hombre lobo";
          case 105:
            return "Duende cautivo";
          case 106:
            return "Mago cautivo";
          case 107:
            return "Duende reparador";
          case 108:
            return "Mago";
          case 109:
            return "Payaso";
          case 110:
            return "Esqueleto arquero";
          case 111:
            return "Duende arquero";
          case 112:
            return "Escupitajo vil";
          case 113:
            return "Muro carnoso";
          case 114:
            return "Muro carnoso";
          case 115:
            return "El Famélico";
          case 116:
            return "El Famélico";
          case 117:
            return "Sanguijuela";
          case 118:
            return "Sanguijuela";
          case 119:
            return "Sanguijuela";
          case 120:
            return "Caos elemental";
          case 121:
            return "Baboseadora";
          case 122:
            return "Gasterópodo";
          case 123:
            return "Mecánico cautivo";
          case 124:
            return "Mecánico";
          case 125:
            return "Retinator";
          case 126:
            return "Espasmatizador";
          case (int) sbyte.MaxValue:
            return "Esqueleto mayor";
          case 128:
            return "Cañón mayor";
          case 129:
            return "Sierra mayor";
          case 130:
            return "Torno mayor";
          case 131:
            return "Láser mayor";
          case 132:
            return "Zombi";
          case 133:
            return "Ojo errante";
          case 134:
            return "El Destructor";
          case 135:
            return "El Destructor";
          case 136:
            return "El Destructor";
          case 137:
            return "Murciélago luminoso";
          case 138:
            return "Babosa luminosa";
          case 139:
            return "Sonda";
          case 140:
            return "Armadura poseída";
          case 141:
            return "Fango tóxico";
          case 142:
            return "Papá Noel";
          case 143:
            return "muñeco de nieve Gangsta";
          case 144:
            return "señor Stabby";
          case 145:
            return "Balla nieve";
        }
      }
      return "";
    }

    public static void tTip()
    {
      for (int Type = 1; Type < 604; ++Type)
      {
        Item obj = new Item();
        obj.SetDefaults(Type);
        if (obj.toolTip2 != "" && obj.toolTip2 != null)
          "case " + (object) Type + ": return \"" + obj.toolTip2 + "\";";
      }
    }

    public static string toolTip(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case -1:
            return "Can mine Meteorite";
          case 8:
            return "Provides light";
          case 15:
            return "Tells the time";
          case 16:
            return "Tells the time";
          case 17:
            return "Tells the time";
          case 18:
            return "Shows depth";
          case 23:
            return "'Both tasty and flammable'";
          case 29:
            return "Permanently increases maximum life by 20";
          case 33:
            return "Used for smelting ore";
          case 35:
            return "Used to craft items from metal bars";
          case 36:
            return "Used for basic crafting";
          case 43:
            return "Summons the Eye of Cthulhu";
          case 49:
            return "Slowly regenerates life";
          case 50:
            return "Gaze in the mirror to return home";
          case 53:
            return "Allows the holder to double jump";
          case 54:
            return "The wearer can run super fast";
          case 56:
            return "'Pulsing with dark energy'";
          case 57:
            return "'Pulsing with dark energy'";
          case 64:
            return "Summons a vile thorn";
          case 65:
            return "Causes stars to rain from the sky";
          case 66:
            return "Cleanses the corruption";
          case 67:
            return "Removes the Hallow";
          case 68:
            return "'Looks tasty!'";
          case 70:
            return "Summons the Eater of Worlds";
          case 75:
            return "Disappears after the sunrise";
          case 84:
            return "'Get over here!'";
          case 88:
            return "Provides light when worn";
          case 98:
            return "33% chance to not consume ammo";
          case 100:
            return "7% increased melee speed";
          case 101:
            return "7% increased melee speed";
          case 102:
            return "7% increased melee speed";
          case 103:
            return "Able to mine Hellstone";
          case 109:
            return "Permanently increases maximum mana by 20";
          case 111:
            return "Increases maximum mana by 20";
          case 112:
            return "Throws balls of fire";
          case 113:
            return "Casts a controllable missile";
          case 114:
            return "Magically moves dirt";
          case 115:
            return "Creates a magical orb of light";
          case 117:
            return "'Warm to the touch'";
          case 118:
            return "Sometimes dropped by Skeletons and Piranha";
          case 120:
            return "Lights wooden arrows ablaze";
          case 121:
            return "'It's made out of fire!'";
          case 123:
            return "5% increased magic damage";
          case 124:
            return "5% increased magic damage";
          case 125:
            return "5% increased magic damage";
          case 128:
            return "Allows flight";
          case 148:
            return "Holding this may attract unwanted attention";
          case 149:
            return "'It contains strange symbols'";
          case 151:
            return "4% increased ranged damage.";
          case 152:
            return "4% increased ranged damage.";
          case 153:
            return "4% increased ranged damage.";
          case 156:
            return "Grants immunity to knockback";
          case 157:
            return "Sprays out a shower of water";
          case 158:
            return "Negates fall damage";
          case 159:
            return "Increases jump height";
          case 165:
            return "Casts a slow moving bolt of water";
          case 166:
            return "A small explosion that will destroy some tiles";
          case 167:
            return "A large explosion that will destroy most tiles";
          case 168:
            return "A small explosion that will not destroy tiles";
          case 175:
            return "'Hot to the touch'";
          case 186:
            return "'Because not drowning is kinda nice'";
          case 187:
            return "Grants the ability to swim";
          case 193:
            return "Grants immunity to fire blocks";
          case 197:
            return "Shoots fallen stars";
          case 208:
            return "'It's pretty, oh so pretty'";
          case 211:
            return "12% increased melee speed";
          case 212:
            return "10% increased movement speed";
          case 213:
            return "Creates grass on dirt";
          case 215:
            return "'May annoy others'";
          case 218:
            return "Summons a controllable ball of fire";
          case 222:
            return "Grows plants";
          case 223:
            return "6% reduced mana usage";
          case 228:
            return "Increases maximum mana by 20";
          case 229:
            return "Increases maximum mana by 20";
          case 230:
            return "Increases maximum mana by 20";
          case 235:
            return "'Tossing may be difficult.'";
          case 237:
            return "'Makes you look cool!'";
          case 238:
            return "15% increased magic damage";
          case 261:
            return "'It's smiling, might be a good snack'";
          case 266:
            return "'This is a good idea!'";
          case 267:
            return "'You are a terrible person.'";
          case 268:
            return "Greatly extends underwater breathing";
          case 272:
            return "Casts a demon scythe";
          case 281:
            return "Allows the collection of seeds for ammo";
          case 282:
            return "Works when wet";
          case 283:
            return "For use with Blowpipe";
          case 285:
            return "5% increased movement speed";
          case 288:
            return "Provides immunity to lava";
          case 289:
            return "Provides life regeneration";
          case 290:
            return "25% increased movement speed";
          case 291:
            return "Breathe water instead of air";
          case 292:
            return "Increase defense by 8";
          case 293:
            return "Increased mana regeneration";
          case 294:
            return "20% increased magic damage";
          case 295:
            return "Slows falling speed";
          case 296:
            return "Shows the location of treasure and ore";
          case 297:
            return "Grants invisibility";
          case 298:
            return "Emits an aura of light";
          case 299:
            return "Increases night vision";
          case 300:
            return "Increases enemy spawn rate";
          case 301:
            return "Attackers also take damage";
          case 302:
            return "Allows the ability to walk on water";
          case 303:
            return "20% increased arrow speed and damage";
          case 304:
            return "Shows the location of enemies";
          case 305:
            return "Allows the control of gravity";
          case 324:
            return "'Banned in most places'";
          case 327:
            return "Opens one Gold Chest";
          case 329:
            return "Opens all Shadow Chests";
          case 332:
            return "Used for crafting cloth";
          case 352:
            return "Used for brewing ale";
          case 357:
            return "Minor improvements to all stats";
          case 361:
            return "Summons a Goblin Army";
          case 363:
            return "Used for advanced wood crafting";
          case 367:
            return "Strong enough to destroy Demon Altars";
          case 371:
            return "Increases maximum mana by 40";
          case 372:
            return "7% increased movement speed";
          case 373:
            return "10% increased ranged damage";
          case 376:
            return "Increases maximum mana by 60";
          case 377:
            return "5% increased melee critical strike chance";
          case 378:
            return "12% increased ranged damage";
          case 385:
            return "Can mine Mythril";
          case 386:
            return "Can mine Adamantite";
          case 389:
            return "Has a chance to confuse";
          case 393:
            return "Shows horizontal position";
          case 394:
            return "Grants the ability to swim";
          case 395:
            return "Shows position";
          case 396:
            return "Negates fall damage";
          case 397:
            return "Grants immunity to knockback";
          case 398:
            return "Allows the combining of some accessories";
          case 399:
            return "Allows the holder to double jump";
          case 400:
            return "Increases maximum mana by 80";
          case 401:
            return "7% increased melee critical strike chance";
          case 402:
            return "14% increased ranged damage";
          case 403:
            return "6% increased damage";
          case 404:
            return "4% increased critical strike chance";
          case 405:
            return "Allows flight";
          case 407:
            return "Increases block placement range";
          case 422:
            return "Spreads the Hallow to some blocks";
          case 423:
            return "Spreads the corruption to some blocks";
          case 425:
            return "Summons a magical fairy";
          case 434:
            return "Three round burst";
          case 485:
            return "Turns the holder into a werewolf on full moons";
          case 486:
            return "Creates a grid on screen for block placement";
          case 489:
            return "15% increased magic damage";
          case 490:
            return "15% increased melee damage";
          case 491:
            return "15% increased ranged damage";
          case 492:
            return "Allows flight and slow fall";
          case 493:
            return "Allows flight and slow fall";
          case 495:
            return "Casts a controllable rainbow";
          case 496:
            return "Summons a block of ice";
          case 497:
            return "Transforms the holder into merfolk when entering water";
          case 506:
            return "Uses gel for ammo";
          case 509:
            return "Places wire";
          case 510:
            return "Removes wire";
          case 515:
            return "Creates several crystal shards on impact";
          case 516:
            return "Summons falling stars on impact";
          case 517:
            return "A magical returning dagger";
          case 518:
            return "Summons rapid fire crystal shards";
          case 519:
            return "Summons unholy fire balls";
          case 520:
            return "'The essence of light creatures'";
          case 521:
            return "'The essence of dark creatures'";
          case 522:
            return "'Not even water can put the flame out'";
          case 523:
            return "Can be placed in water";
          case 524:
            return "Used to smelt adamantite ore";
          case 525:
            return "Used to craft items from mythril and adamantite bars";
          case 526:
            return "'Sharp and magical!'";
          case 527:
            return "'Sometimes carried by creatures in corrupt deserts'";
          case 528:
            return "'Sometimes carried by creatures in light deserts'";
          case 529:
            return "Activates when stepped on";
          case 531:
            return "Can be enchanted";
          case 532:
            return "Causes stars to fall when injured";
          case 533:
            return "50% chance to not consume ammo";
          case 534:
            return "Fires a spread of bullets";
          case 535:
            return "Reduces the cooldown of healing potions";
          case 536:
            return "Increases melee knockback";
          case 541:
            return "Activates when stepped on";
          case 542:
            return "Activates when stepped on";
          case 543:
            return "Activates when stepped on";
          case 544:
            return "Summons The Twins";
          case 547:
            return "'The essence of pure terror'";
          case 548:
            return "'The essence of the destroyer'";
          case 549:
            return "'The essence of omniscient watchers'";
          case 551:
            return "7% increased critical strike chance";
          case 552:
            return "7% increased damage";
          case 553:
            return "15% increased ranged damage";
          case 554:
            return "Increases length of invincibility after taking damage";
          case 555:
            return "8% reduced mana usage";
          case 556:
            return "Summons Destroyer";
          case 557:
            return "Summons Skeletron Prime";
          case 558:
            return "Increases maximum mana by 100";
          case 559:
            return "10% increased melee damage and critical strike chance";
          case 560:
            return "Summons King Slime";
          case 561:
            return "Stacks up to 5";
          case 575:
            return "'The essence of powerful flying creatures'";
          case 576:
            return "Has a chance to record songs";
          case 579:
            return "'Not to be confused with a hamsaw'";
          case 580:
            return "Explodes when activated";
          case 581:
            return "Sends water to outlet pumps";
          case 582:
            return "Receives water from inlet pumps";
          case 583:
            return "Activates every second";
          case 584:
            return "Activates every 3 seconds";
          case 585:
            return "Activates every 5 seconds";
          case 599:
            return "Right click to open";
          case 600:
            return "Right click to open";
          case 601:
            return "Right click to open";
          case 602:
            return "Summons the Frost Legion";
          case 603:
            return "Summons a pet bunny";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case -1:
            return "Kann Meteorite abbauen";
          case 8:
            return "Verstroemt Licht";
          case 15:
            return "Zeigt die Zeit an";
          case 16:
            return "Zeigt die Zeit an";
          case 17:
            return "Zeigt die Zeit an";
          case 18:
            return "Zeigt die Tiefe an";
          case 23:
            return "'Lecker und brennbar'";
          case 29:
            return "Erhoeht dauerhaft die maximale Lebensspanne um 20";
          case 33:
            return "Wird fuer die Verhuettung von Erz verwendet";
          case 35:
            return "Wird verwendet, um Items aus Metallbarren herzustellen";
          case 36:
            return "Wird zur einfachen Herstellung verwendet";
          case 43:
            return "Ruft das Auge von Cthulhu herbei";
          case 49:
            return "Belebt langsam wieder";
          case 50:
            return "Ein Blick in den Spiegel bringt einen nach Hause zurueck";
          case 53:
            return "Berechtigt den Inhaber zum Doppelsprung";
          case 54:
            return "Der Traeger kann superschnell rennen";
          case 56:
            return "'Durchpulst von dunkler Energie'";
          case 57:
            return "'Durchpulst von dunkler Energie'";
          case 64:
            return "Ruft einen Ekeldorn herbei";
          case 65:
            return "Laesst Sterne vom Himmel regen";
          case 66:
            return "Reinigt das Verderben";
          case 67:
            return "Entfernt den Segen";
          case 68:
            return "'Sieht lecker aus!'";
          case 70:
            return "Ruft den Weltenfresser herbei";
          case 75:
            return "Verschwindet nach Sonnenaufgang";
          case 84:
            return "'Komm hier rueber!'";
          case 88:
            return "Verstroemt beim Tragen Licht";
          case 98:
            return "33%ige Chance, Munition nicht zu verbrauchen";
          case 100:
            return "Um 7% erhoehtes Nahkampftempo";
          case 101:
            return "Um 7% erhoehtes Nahkampftempo";
          case 102:
            return "Um 7% erhoehtes Nahkampftempo";
          case 103:
            return "Kann Hoellenstein abbauen";
          case 109:
            return "Erhoeht maximales Mana um 20";
          case 111:
            return "Erhoeht die maximale Mana um 20";
          case 112:
            return "Schiesst Feuerbaelle ab";
          case 113:
            return "Wirft eine steuerbare Rakete aus";
          case 114:
            return "Bewegt magisch Dreck";
          case 115:
            return "Erschafft eine magische Lichtkugel";
          case 117:
            return "'Fuehlt sich warm an'";
          case 118:
            return "Faellt mitunter von Skeletten und Piranhas herab";
          case 120:
            return "Entfacht lodernde Holzpfeile";
          case 121:
            return "'Ist ganz aus Feuer!'";
          case 123:
            return "Um 5% erhoehter magischer Schaden";
          case 124:
            return "Um 5% erhoehter magischer Schaden";
          case 125:
            return "Um 5% erhoehter magischer Schaden";
          case 128:
            return "Laesst fliegen";
          case 148:
            return "Kann unerwuenschte Aufmerksamkeit erwecken";
          case 149:
            return "'Es enthaelt seltsame Symbole'";
          case 151:
            return "Um 4% erhoehter Fernkampf-Schaden";
          case 152:
            return "Um 4% erhoehter Fernkampf-Schaden";
          case 153:
            return "Um 4% erhoehter Fernkampf-Schaden";
          case 156:
            return "Macht immun gegen Rueckstoss";
          case 157:
            return "Versprueht eine Wasserdusche";
          case 158:
            return "Hebt Sturzschaden auf";
          case 159:
            return "Vergroessert die Sprunghoehe";
          case 165:
            return "Wirft einen sich langsam bewegenden Wasserbolzen aus";
          case 166:
            return "Eine kleine Explosion, die einige Felder zerstoeren wird";
          case 167:
            return "Eine grosse Explosion, die die meisten Felder zerstoert";
          case 168:
            return "Eine kleine Explosion, die keine Felder zerstoert";
          case 175:
            return "'Heiss, heiss, heiss!'";
          case 186:
            return "'Ganz nett, nicht ertrinken zu muessen'";
          case 187:
            return "Befaehigt zum Schwimmen";
          case 193:
            return "Macht immun gegen Feuer-Bloecke";
          case 197:
            return "Schiesst Sternschnuppen herunter";
          case 208:
            return "'Oh, ist die huebsch!'";
          case 211:
            return "Um 12% erhoehtes Nahkampftempo";
          case 212:
            return "Um 10% erhoehtes Bewegungstempo";
          case 213:
            return "Laesst Gras auf Schmutz wachsen";
          case 215:
            return "'Kann Aerger erregen'";
          case 218:
            return "Ruft einen steuerbaren Feuerball herbei";
          case 222:
            return "Laesst Pflanzen wachsen";
          case 223:
            return "Um 6% reduzierte Mana-Nutzung";
          case 228:
            return "Erhoeht die maximale Mana um 20";
          case 229:
            return "Erhoeht die maximale Mana um 20";
          case 230:
            return "Erhoeht die maximale Mana um 20";
          case 235:
            return "'Werfen koennte schwierig werden.'";
          case 237:
            return "'Damit siehst du cool aus!'";
          case 238:
            return "Um 15% erhoehter magischer Schaden";
          case 261:
            return "'Er laechelt - vielleicht schmeckt er auch gut...'";
          case 266:
            return "'Das ist eine gute Idee!'";
          case 267:
            return "'Du bist ein schrecklicher Mensch.'";
          case 268:
            return "Verlaengert das Atmen unter Wasser deutlich";
          case 272:
            return "Wirft eine Daemonensense aus";
          case 281:
            return "Zum Erstellen einer Saatsammlung als Munition";
          case 282:
            return "Funktioniert bei Naesse";
          case 283:
            return "Zur Verwendung im Blasrohr";
          case 285:
            return "Um 5% erhoehtes Bewegungstempo";
          case 288:
            return "Macht immun gegen Lava";
          case 289:
            return "Belebt wieder";
          case 290:
            return "Erhoeht Bewegungstempo um 25%";
          case 291:
            return "Wasser statt Luft atmen";
          case 292:
            return "Erhoeht die Abwehr um 8";
          case 293:
            return "Erhoehte Mana-Wiederherstellung";
          case 294:
            return "Erhoeht magischen Schaden um 20%";
          case 295:
            return "Verlangsamt das Sturztempo";
          case 296:
            return "Zeigt den Fundort von Schatz und Erz";
          case 297:
            return "Macht unsichtbar";
          case 298:
            return "Verstroemt eine Aura aus Licht";
          case 299:
            return "Erhoeht die Nachtsicht";
          case 300:
            return "Erhoeht Feind-Spawnquote";
          case 301:
            return "Auch die Angreifer erleiden Schaden";
          case 302:
            return "Befaehigt, auf dem Wasser zu gehen";
          case 303:
            return "Erhoeht Pfeiltempo und Schaden um 20%";
          case 304:
            return "Zeigt die Position von Feinden";
          case 305:
            return "Zur Steuerung der Schwerkraft";
          case 324:
            return "'An den meisten Orten verboten'";
          case 327:
            return "Oeffnet eine Goldtruhe";
          case 329:
            return "Oeffnet alle Schattentruhen";
          case 332:
            return "Verwendet fuer die Tuchherstellung ";
          case 352:
            return "Zum Bierbrauen";
          case 357:
            return "Geringe Anhebung aller Werte";
          case 361:
            return "Ruft eine Goblin-Armee herbei";
          case 363:
            return "Fuer fortgeschrittene Holzherstellung";
          case 367:
            return "Stark genug, um Daemonenaltaere zu zerstoeren";
          case 371:
            return "Erhoeht die maximale Mana um 40";
          case 372:
            return "Um 7% erhoehtes Bewegungstempo";
          case 373:
            return "Um 10% erhoehter Fernkampfschaden";
          case 376:
            return "Erhoeht die maximale Mana um 60";
          case 377:
            return "Um 5% erhoehte kritische Nahkampf-Trefferchance";
          case 378:
            return "Um 12% erhoehter Fernkampf-Schaden";
          case 385:
            return "Kann Mithril abbauen";
          case 386:
            return "Kann Adamantit abbauen";
          case 389:
            return "Kann Verwirrung stiften";
          case 393:
            return "Zeigt horizontale Position";
          case 394:
            return "Befaehigt zum Schwimmen";
          case 395:
            return "Zeigt Position an";
          case 396:
            return "Hebt Sturzschaden auf";
          case 397:
            return "Macht immun gegen Rueckstoss";
          case 398:
            return "Ermoeglicht die Kombination von Zubehoer";
          case 399:
            return "Berechtigt den Inhaber zum Doppelsprung";
          case 400:
            return "Erhoeht die maximale Mana um 80";
          case 401:
            return "Um 7% erhoehte kritische Nahkampf-Trefferchance";
          case 402:
            return "Um 14% erhoehter Fernkampfschaden";
          case 403:
            return "Um 6% erhoehter Schaden";
          case 404:
            return "Um 4% erhoehte kritische Trefferchance";
          case 405:
            return "Laesst fliegen";
          case 407:
            return "Erweitert den Platzierbereich von Bloecken";
          case 422:
            return "Verspritzt Segen auf einige Bloecke";
          case 423:
            return "Verteilt Verderben auf einige Bloecke";
          case 425:
            return "Ruft eine magische Fee herbei";
          case 434:
            return "Dreifachschuss";
          case 485:
            return "Verwandelt den Inhaber bei Vollmond in einen Werwolf";
          case 486:
            return "Erstellt ein Raster auf dem Bildschirm zum Platzieren der Bloecke";
          case 489:
            return "Um 15% erhoehter magischer Schaden";
          case 490:
            return "Um 15% erhoehter Nahkampfschaden";
          case 491:
            return "Um 15% erhoehter Fernkampfschaden";
          case 492:
            return "Ermoeglicht Flug und langsamen Fall";
          case 493:
            return "Ermoeglicht Flug und langsamen Fall";
          case 495:
            return "Wirft einen steuerbaren Regenbogen aus";
          case 496:
            return "Ruft einen Eisblock herbei";
          case 497:
            return "Verwandelt den Besitzer beim Hineingehen ins Wasser in Meermenschen";
          case 506:
            return "Verwendet Glibber als Munition";
          case 509:
            return "Platziert Kabel";
          case 510:
            return "Entfernt Kabel";
          case 515:
            return "Erzeugt beim Aufprall mehrere Kristallscherben";
          case 516:
            return "Ruft beim Aufprall Sternschnuppen herbei";
          case 517:
            return "Ein Dolch, der magisch zurueckkehrt";
          case 518:
            return "Ruft schnelle Feuerkristallscherben herbei";
          case 519:
            return "Ruft unheilige Feuerbaelle herbei";
          case 520:
            return "'Die Essenz von Lichtkreaturen'";
          case 521:
            return "'Die Essenz von Finsterkreaturen'";
          case 522:
            return "'Nicht einmal Wasser loescht diese Flamme'";
          case 523:
            return "Kann in Wasser platziert werden";
          case 524:
            return "Zum Schmelzen von Adamantiterz";
          case 525:
            return "Zur Herstellung von Items aus Mithril- und Adamantitbarren";
          case 526:
            return "'Scharf und magisch!'";
          case 527:
            return "'Kreaturen in verderbten Wuesten tragen sie mitunter'";
          case 528:
            return "'Werden mitunter von Kreaturen in Lichtwuesten getragen'";
          case 529:
            return "Wird beim Betreten aktiviert";
          case 531:
            return "Zum Zaubern";
          case 532:
            return "Laesst Sterne bei Verletzung herabfallen";
          case 533:
            return "50%ige Chance, Munition nicht zu verbrauchen";
          case 534:
            return "Feuert einen Kugelregen ab";
          case 535:
            return "Verringert die Abklingzeit von Heiltraenken";
          case 536:
            return "Erhoeht Nahkampf-Rueckstoss";
          case 541:
            return "Wird beim Betreten aktiviert";
          case 542:
            return "Wird beim Betreten aktiviert";
          case 543:
            return "Wird beim Betreten aktiviert";
          case 544:
            return "Ruft die Zwillinge herbei";
          case 547:
            return "'Die Essenz reinen Schreckens'";
          case 548:
            return "'Die Essenz des Zerstoerers'";
          case 549:
            return "'Die Essenz der allwissenden Beobachter'";
          case 551:
            return "Um 7% erhoehte kritische Trefferchance";
          case 552:
            return "Um 7% erhoehter Schaden";
          case 553:
            return "Um 15% erhoehter Fernkampfschaden";
          case 554:
            return "Verlaengert die Unbesiegbarkeit nach erlittenem Schaden";
          case 555:
            return "Um 8% reduzierte Mananutzung";
          case 556:
            return "Ruft den Zerstoerer";
          case 557:
            return "Ruft Super-Skeletron herbei";
          case 558:
            return "Erhoeht die maximale Mana um 100";
          case 559:
            return "Nahkampfschaden und kritische Trefferchance um 10% erhoeht";
          case 560:
            return "Ruft Schleimi-Koenig herbei";
          case 561:
            return "Kann bis zu 5 stapeln";
          case 575:
            return "'Essenz maechtiger fliegender Kreaturen'";
          case 576:
            return "Kann Songs aufzeichnen";
          case 579:
            return "'Nicht mit einer Hamsaege zu verwechseln'";
          case 580:
            return "Explodiert bei Aktivierung";
          case 581:
            return "Sendet Wasser zu Auslasspumpen";
          case 582:
            return "Empfaengt Wasser vom Einlasspumpen";
          case 583:
            return "Aktiviert jede Sekunde";
          case 584:
            return "Aktiviert alle 3 Sekunden";
          case 585:
            return "Aktiviert alle 5 Sekunden";
          case 599:
            return "Rechter Mausklick zu öffnen";
          case 600:
            return "Rechter Mausklick zu öffnen";
          case 601:
            return "Rechter Mausklick zu öffnen";
          case 602:
            return "Beschwört den Frost Legion";
          case 603:
            return "Vorladung ein Haustier Hase";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case -1:
            return "Può estrarre meteorite";
          case 8:
            return "Fornisce luce";
          case 15:
            return "Indica il tempo";
          case 16:
            return "Indica il tempo";
          case 17:
            return "Indica il tempo";
          case 18:
            return "Mostra la profondità";
          case 23:
            return "'Sia gustoso che infiammabile'";
          case 29:
            return "Aumenta in maniera permanente la vita massima di 20";
          case 33:
            return "Usato per fondere il minerale";
          case 35:
            return "Usata per creare oggetti dalle sbarre di metallo";
          case 36:
            return "Usato per l'artigianato di base";
          case 43:
            return "Evoca l'Occhio di Cthulhu";
          case 49:
            return "Rigenera la vita lentamente";
          case 50:
            return "Guarda nello specchio per tornare a casa";
          case 53:
            return "Permette il salto doppio";
          case 54:
            return "Colui che li indossa può correre velocissimo";
          case 56:
            return "'Pulsa di energia oscura'";
          case 57:
            return "'Pulsa di energia oscura'";
          case 64:
            return "Evoca una spina vile";
          case 65:
            return "Fa piovere le stelle dal cielo";
          case 66:
            return "Ripulisce la distruzione";
          case 67:
            return "Rimuove il sacro";
          case 68:
            return "'Gustoso!'";
          case 70:
            return "Evoca il Mangiatore di mondi";
          case 75:
            return "Sparisce dopo l'alba";
          case 84:
            return "'Vieni qui!'";
          case 88:
            return "Fa luce una volta indossato";
          case 98:
            return "33% di possibilità di non consumare munizioni";
          case 100:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 101:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 102:
            return "Velocità del corpo a corpo aumentata del 7%";
          case 103:
            return "In grado di estrarre la pietra infernale";
          case 109:
            return "Aumenta in maniera permanente il mana massimo di 20";
          case 111:
            return "Aumenta il mana massimo di 20";
          case 112:
            return "Tira palle di fuoco";
          case 113:
            return "Scaglia un missile guidato";
          case 114:
            return "Muovi magicamente la terra";
          case 115:
            return "Crea una sfera di luce magica";
          case 117:
            return "'Calda al tocco'";
          case 118:
            return "Lanciato a volte da Scheletri e Piranha";
          case 120:
            return "Incendia le frecce di legno";
          case 121:
            return "'Creato dal fuoco!'";
          case 123:
            return "Danno magico aumentato del 5%";
          case 124:
            return "Danno magico aumentato del 5%";
          case 125:
            return "Danno magico aumentato del 5%";
          case 128:
            return "Permettono il volo";
          case 148:
            return "Avere questo oggetto potrebbe attirare attenzione non desiderata";
          case 149:
            return "'Contiene simboli strani'";
          case 151:
            return "Danno a distanza  aumentato del 4%";
          case 152:
            return "Danno a distanza  aumentato del 4%";
          case 153:
            return "Danno a distanza  aumentato del 4%";
          case 156:
            return "Permette immunità allo spintone";
          case 157:
            return "Spruzza una cascata d'acqua";
          case 158:
            return "Annulla i danni da caduta";
          case 159:
            return "Aumenta l'altezza del salto";
          case 165:
            return "Lancia un dardo di acqua lento";
          case 166:
            return "Una piccola esplosione che distruggerà alcune mattonelle";
          case 167:
            return "Una grande esplosione che distruggerà molte mattonelle";
          case 168:
            return "Una piccola esplosione che non distruggerà mattonelle";
          case 175:
            return "'Calda al tocco'";
          case 186:
            return "'Perché non annegare è alquanto piacevole'";
          case 187:
            return "Abilita al nuoto";
          case 193:
            return "Permette immunità ai blocchi di fuoco";
          case 197:
            return "Spara stelle cadenti";
          case 208:
            return "'Graziosa, oh com'è graziosa'";
          case 211:
            return "Velocità del corpo a corpo aumentata del 12%";
          case 212:
            return "Velocità di movimento aumentata del 10%";
          case 213:
            return "Crea erba dalla terra";
          case 215:
            return "'Può disturbare gli altri'";
          case 218:
            return "Evoca una palla di fuoco guidata";
          case 222:
            return "Fa crescere le piante";
          case 223:
            return "Consumo mana ridotto del 6%";
          case 228:
            return "Aumenta il mana massimo di 20";
          case 229:
            return "Aumenta il mana massimo di 20";
          case 230:
            return "Aumenta il mana massimo di 20";
          case 235:
            return "'Lanciare potrebbe essere difficile.'";
          case 237:
            return "'Migliora il tuo look!'";
          case 238:
            return "Danno magico aumentato del 15%";
          case 261:
            return "'Sta ridendo, potrebbe essere uno spuntino appetitoso'";
          case 266:
            return "'Buona idea!'";
          case 267:
            return "'Sei una persona terribile.'";
          case 268:
            return "Aumenta moltissimo il respiro sott'acqua";
          case 272:
            return "Evoca una falce demoniaca";
          case 281:
            return "Permette la raccolta di semi come munizioni";
          case 282:
            return "Funziona da bagnato";
          case 283:
            return "Da usare con la cerbottana";
          case 285:
            return "Velocità di movimento aumentata del 5%";
          case 288:
            return "Dà immunità alla lava";
          case 289:
            return "Rigenera la vita";
          case 290:
            return "Velocità di movimento aumentata del 25%";
          case 291:
            return "Respira acqua invece di aria";
          case 292:
            return "Aumenta la difesa di 8";
          case 293:
            return "Aumenta la rigenerazione del mana";
          case 294:
            return "Danno magico aumentato del 20%";
          case 295:
            return "Velocità di caduta lenta";
          case 296:
            return "Mostra l'ubicazione di tesori e minerale";
          case 297:
            return "Rende invisibili";
          case 298:
            return "Emette un'aura di luce";
          case 299:
            return "Migliora la visione notturna";
          case 300:
            return "Aumenta il ritmo di generazone dei nemici";
          case 301:
            return "Anche gli aggressori subiscono danni";
          case 302:
            return "Consente di camminare sull'acqua";
          case 303:
            return "Velocità e danni della freccia aumentati del 20%";
          case 304:
            return "Mostra la posizione dei nemici";
          case 305:
            return "Permette il controllo della gravità";
          case 324:
            return "'Bandita in molti luoghi'";
          case 327:
            return "Apre una cassa d'oro";
          case 329:
            return "Apre tutte le casse ombra";
          case 332:
            return "Usato per fabbricare abiti";
          case 352:
            return "Usato per produrre birra";
          case 357:
            return "Migliorie minori a tutti i parametri";
          case 361:
            return "Evoca un esercito di goblin";
          case 363:
            return "Usata per un'avanzata lavorazione del legno";
          case 367:
            return "Abbastanza forte per distruggere gli Altari dei demoni";
          case 371:
            return "Aumenta il mana massimo di 40";
          case 372:
            return "Velocità di movimento aumentata del 7%";
          case 373:
            return "Danno a distanza aumentato del 10%";
          case 376:
            return "Aumenta il mana massimo di 60";
          case 377:
            return "Possibilità di colpo critico nel corpo a corpo aumentata del 5%";
          case 378:
            return "Danno a distanza aumentato del 12%";
          case 385:
            return "Può estrarre mitrilio";
          case 386:
            return "Può estrarre adamantio";
          case 389:
            return "Può confondere";
          case 393:
            return "Mostra posizione orizzontale";
          case 394:
            return "Abilita al nuoto";
          case 395:
            return "Mostra posizione";
          case 396:
            return "Annulla i danni da caduta";
          case 397:
            return "Permette immunità allo spintone";
          case 398:
            return "Permette la combinazione di alcuni accessori";
          case 399:
            return "Permette il salto doppio";
          case 400:
            return "Aumenta il mana massimo di 80";
          case 401:
            return "Possibilità di colpo critico nel corpo a corpo aumentata del 7%";
          case 402:
            return "Danno a distanza aumentato del 14%";
          case 403:
            return "Danno aumentato del 6%";
          case 404:
            return "Possibilità di colpo critico aumetata del 4%";
          case 405:
            return "Permettono il volo";
          case 407:
            return "Aumenta la possibilità di collocamento dei blocchi";
          case 422:
            return "Spruzza acquasanta su alcuni blocchi";
          case 423:
            return "Diffonde la distruzione su alcuni blocchi";
          case 425:
            return "Evoca una fata magica";
          case 434:
            return "Tre raffiche";
          case 485:
            return "Durante la luna piena trasforma il portatore in un lupo mannaro";
          case 486:
            return "Crea una griglia sullo schermo per sistemare i blocchi";
          case 489:
            return "Danno magico aumentato del 15%";
          case 490:
            return "Danno nel corpo a corpo aumentato del 15%";
          case 491:
            return "Danno a distanza aumentato del 15%";
          case 492:
            return "Permettono il volo e la caduta lenta";
          case 493:
            return "Permettono il volo e la caduta lenta";
          case 495:
            return "Genera un arcobaleno guidato";
          case 496:
            return "Evoca un blocco di ghiaccio";
          case 497:
            return "Trasforma il portatore in Tritone quando entra in acqua";
          case 506:
            return "Usa il gel come munizione";
          case 509:
            return "Sistema i cavi";
          case 510:
            return "Rimuove i cavi";
          case 515:
            return "Crea svariati frammenti di cristallo all'impatto";
          case 516:
            return "Evoca stelle cadenti all'impatto";
          case 517:
            return "Un pugnale magico che ritorna";
          case 518:
            return "Evoca veloci frammenti di cristallo infuocati";
          case 519:
            return "Evoca sfere di fuoco profane";
          case 520:
            return "'L'essenza delle creature della luce'";
          case 521:
            return "'L'essenza delle creature oscure'";
          case 522:
            return "'Neanche l'acqua può spegnere la fiamma'";
          case 523:
            return "Può essere messa in acqua";
          case 524:
            return "Usata per fondere il minerale adamantio";
          case 525:
            return "Usata per creare oggetti da sbarre di mitrilio e adamantio";
          case 526:
            return "'Appuntito e magico!'";
          case 527:
            return "'A volte portato dalle creature nei deserti distrutti'";
          case 528:
            return "'A volte portato dalle creature nei deserti di luce'";
          case 529:
            return "Si attiva quando calpestata";
          case 531:
            return "Può essere incantato";
          case 532:
            return "Causa la caduta delle stelle quando colpito";
          case 533:
            return "50% di possibilità di non consumare munizioni";
          case 534:
            return "Spara una rosa di proiettili";
          case 535:
            return "Riduce la ricarica della pozione curativa";
          case 536:
            return "Aumenta lo spintone in corpo a corpo";
          case 541:
            return "Si attiva quando calpestata";
          case 542:
            return "Si attiva quando calpestata";
          case 543:
            return "Si attiva quando calpestata";
          case 544:
            return "Evoca i gemelli";
          case 547:
            return "'L'essenza del terrore puro'";
          case 548:
            return "'L'essenza del distruttore'";
          case 549:
            return "'L'essenza degli osservatori onniscienti'";
          case 551:
            return "Possibilità di colpo critico aumentata del 7%";
          case 552:
            return "Danno aumentato del 7%";
          case 553:
            return "Danno a distanza aumentato del 15%";
          case 554:
            return "Aumenta la durata dell'invincibilità dopo aver subito danni";
          case 555:
            return "Consumo mana ridotto del 8%";
          case 556:
            return "Evoca l'Distruttore";
          case 557:
            return "Evoca lo Skeletron primario";
          case 558:
            return "Aumenta il mana massimo di 100";
          case 559:
            return "Possibilità di danno corpo a corpo e colpo critico aumentata del 10%";
          case 560:
            return "Evoca lo slime re";
          case 561:
            return "Raccoglie fino a 5";
          case 575:
            return "'L'essenza delle potenti creature volanti'";
          case 576:
            return "Ha una possibilità di registrare canzoni";
          case 579:
            return "'Da non confondere con il Segartello'";
          case 580:
            return "Esplodono quando attivati";
          case 581:
            return "Invia acqua alle pompe esterne";
          case 582:
            return "Riceve acqua dalle pompe interne";
          case 583:
            return "Si attiva ogni secondo";
          case 584:
            return "Si attiva ogni 3 secondi";
          case 585:
            return "Si attiva ogni 5 secondi";
          case 599:
            return "Tasto destro del mouse per aprire";
          case 600:
            return "Tasto destro del mouse per aprire";
          case 601:
            return "Tasto destro del mouse per aprire";
          case 602:
            return "Evoca la Legione di Frost";
          case 603:
            return "Evoca un coniglio domestico";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case -1:
            return "Permet d'extraire la météorite";
          case 8:
            return "Procure de la lumière";
          case 15:
            return "Donne l'heure";
          case 16:
            return "Donne l'heure";
          case 17:
            return "Donne l'heure";
          case 18:
            return "Mesure l'altitude";
          case 23:
            return "'À la fois savoureux et inflammable'";
          case 29:
            return "Augmente le maximum de vie de 20 de façon permanente";
          case 33:
            return "Utilisé pour fondre le minerai";
          case 35:
            return "Permet de forger des objets à partir de métal";
          case 36:
            return "Utilisé pour l'artisanat de base";
          case 43:
            return "Invoque l'œil de Cthulhu";
          case 49:
            return "Régénère lentement la vie";
          case 50:
            return "Fixer le miroir pour regagner son foyer";
          case 53:
            return "Permet de faire un double saut";
          case 54:
            return "Le porteur peur courir super vite";
          case 56:
            return "'Vibre d'une énergie sombre'";
          case 57:
            return "'Vibre d'une énergie sombre'";
          case 64:
            return "Invoque une vileronce";
          case 65:
            return "Provoque une pluie d'étoiles";
          case 66:
            return "Purifie la corruption";
          case 67:
            return "Corrompt la sainteté";
          case 68:
            return "'Ça a l'air bon !'";
          case 70:
            return "Invoque le dévoreur de mondes";
          case 75:
            return "Disparaît au coucher du soleil";
          case 84:
            return "'Pour grimper tout là-haut'";
          case 88:
            return "Procure de la lumière lorsqu'il est porté";
          case 98:
            return "33 % de chance de n'utiliser aucune munition";
          case 100:
            return "Vitesse de mêlée augmentée de 7 %";
          case 101:
            return "Vitesse de mêlée augmentée de 7 %";
          case 102:
            return "Vitesse de mêlée augmentée de 7 %";
          case 103:
            return "Permet d'extraire de la pierre de l'enfer";
          case 109:
            return "Augmente le maximum de mana de 20 de façon permanente";
          case 111:
            return "Augmente le maximum de mana de 20";
          case 112:
            return "Lance des boules de feu";
          case 113:
            return "Lance un missile contrôlable";
          case 114:
            return "Déplace la terre par magie";
          case 115:
            return "Crée un orbe magique de lumière";
          case 117:
            return "'Chaude au toucher'";
          case 118:
            return "Trouvé parfois sur les squelettes et les piranhas";
          case 120:
            return "Transforme les flèches en bois tirées en flèches enflammées";
          case 121:
            return "'Elle pète le feu !'";
          case 123:
            return "Dégâts magiques accrus de 5 %";
          case 124:
            return "Dégâts magiques accrus de 5 %";
          case 125:
            return "Dégâts magiques accrus de 5 %";
          case 128:
            return "Permet de voler";
          case 148:
            return "Cet objet peut attirer une attention non désirée";
          case 149:
            return "'Il contient d'étranges symboles'";
          case 151:
            return "Dégâts à distance augmentés de 4 %";
          case 152:
            return "Dégâts à distance augmentés de 4 %";
          case 153:
            return "Dégâts à distance augmentés de 4 %";
          case 156:
            return "Annule tout effet de recul";
          case 157:
            return "Lance de l'eau en continu";
          case 158:
            return "Annule les dégâts de chute";
          case 159:
            return "Augmente la hauteur des sauts";
          case 165:
            return "Invoque une boule d'eau se déplaçant lentement";
          case 166:
            return "Une petite explosion détruisant quelques blocs";
          case 167:
            return "Une grosse explosion détruisant la plupart des blocs";
          case 168:
            return "Une petite explosion ne détruisant pas de blocs";
          case 175:
            return "'Chaud au toucher'";
          case 186:
            return "'Ne pas se noyer, c'est quand même cool !'";
          case 187:
            return "Permet de nager";
          case 193:
            return "Permet de résister aux blocs de feu";
          case 197:
            return "Tire des étoiles filantes";
          case 208:
            return "'Comme c'est joli !'";
          case 211:
            return "La vitesse de mêlée est augmentée de 12 %";
          case 212:
            return "La vitesse de déplacement est augmentée de 10 %";
          case 213:
            return "Fait pousser de l'herbe sur la terre";
          case 215:
            return "'Peut être incommodant'";
          case 218:
            return "Invoque une boule de feu contrôlable";
          case 222:
            return "Fait pousser les plantes";
          case 223:
            return "Réduit le coût de mana de 6 %";
          case 228:
            return "Augmente le maximum de mana de 20";
          case 229:
            return "Augmente le maximum de mana de 20";
          case 230:
            return "Augmente le maximum de mana de 20";
          case 235:
            return "'Peut s'avérer difficile à lancer'";
          case 237:
            return "'Pour un look de star !'";
          case 238:
            return "Augmente les dégâts magiques de 15 %";
          case 261:
            return "'Il sourit, ça ferait un casse-croûte sympa.'";
          case 266:
            return "'Super idée !'";
          case 267:
            return "'Vous êtes vraiment terrible.'";
          case 268:
            return "Améliore grandement la respiration sous l'eau";
          case 272:
            return "Lance une faux de démon";
          case 281:
            return "Permet de récupérer des graines comme munitions";
          case 282:
            return "Fonctionne même humide";
          case 283:
            return "Utilisable avec la sarbacane";
          case 285:
            return "La vitesse de déplacement est augmentée de 5 %";
          case 288:
            return "Procure l'immunité à la lave";
          case 289:
            return "Régénère la vie";
          case 290:
            return "Augmente la vitesse de déplacement de 25 %";
          case 291:
            return "Permet de respirer sous l'eau comme dans l'air";
          case 292:
            return "Augmente la défense de 8";
          case 293:
            return "Augmente la régénération de mana";
          case 294:
            return "Augmente les dégâts de magie de 20 %";
          case 295:
            return "Réduit la vitesse de chute";
          case 296:
            return "Indique l'emplacement des trésors et du minerai";
          case 297:
            return "Procure l'invisibilité";
          case 298:
            return "Émet une aura de lumière";
          case 299:
            return "Augmente la vision nocturne";
          case 300:
            return "Augmente la fréquence d'apparition des ennemis";
          case 301:
            return "Les attaquants subissent aussi des dégâts";
          case 302:
            return "Permet de marcher sur l'eau";
          case 303:
            return "La vitesse des flèches et leurs dégâts sont augmentés de 20 %";
          case 304:
            return "Indique l'emplacement des ennemis";
          case 305:
            return "Permet de contrôler la gravité";
          case 324:
            return "'Interdit quasiment partout'";
          case 327:
            return "Ouvre un coffre d'or";
          case 329:
            return "Ouvre tous les coffres sombres";
          case 332:
            return "Utilisé pour la fabrication de vêtements";
          case 352:
            return "Utilisé pour brasser la bière.";
          case 357:
            return "Amélioration mineure de toutes les stats.";
          case 361:
            return "Invoque une armée de gobelins";
          case 363:
            return "Permet un travail avancé du bois";
          case 367:
            return "Suffisamment puissant pour détruire les autels démoniaques";
          case 371:
            return "Augmente le maximum de mana de 40";
          case 372:
            return "La vitesse de déplacement est augmentée de 7 %";
          case 373:
            return "Les dégâts à distance sont augmentés de 10 %";
          case 376:
            return "Augmente le maximum de mana de 60";
          case 377:
            return "Les chances de coup critique de mêler sont augmentées de 5 %";
          case 378:
            return "Les dégâts à distance sont augmentés de 12 %";
          case 385:
            return "Permet d'extraire du mythril";
          case 386:
            return "Permet d'extraire de l'adamantine";
          case 389:
            return "Peut étourdir les ennemis";
          case 393:
            return "Indique la position horizontale";
          case 394:
            return "Permet de nager";
          case 395:
            return "Indique la position";
          case 396:
            return "Annule les dégâts de chute";
          case 397:
            return "Annule tout effet de recul";
          case 398:
            return "Permet de combiner certains accessoires";
          case 399:
            return "Permet de faire un double saut";
          case 400:
            return "Augmente le maximum de mana de 80";
          case 401:
            return "Les chances de coup critique de mêlée sont augmentées de 7 %";
          case 402:
            return "Les dégâts à distance sont augmentés de 14 %";
          case 403:
            return "Les dégâts sont augmentés de 6 %";
          case 404:
            return "Les chances de coup critique sont augmentées de 4 %";
          case 405:
            return "Permet de voler";
          case 407:
            return "Permet de construire un bloc plus loin";
          case 422:
            return "Purifie certains blocs";
          case 423:
            return "Corrompt certains blocs";
          case 425:
            return "Invoque une fée magique";
          case 434:
            return "Tire des rafales de trois coups";
          case 485:
            return "Transforme le porteur en loup-garou à la pleine lune";
          case 486:
            return "Crée une grille à l'écran pour le placement des blocs";
          case 489:
            return "Augmente les dégâts magiques de 15 %";
          case 490:
            return "Augmente les dégâts de mêlée de 15 %";
          case 491:
            return "Dégâts à distance augmentés de 15 %";
          case 492:
            return "Permet de voler et de ralentir la chute";
          case 493:
            return "Permet de voler et de ralentir la chute";
          case 495:
            return "Lance un arc-en-ciel contrôlable";
          case 496:
            return "Invoque un bloc de glace";
          case 497:
            return "Transforme le porteur en sirène lorsqu'il entre dans l'eau";
          case 506:
            return "Utilise du gel comme carburant";
          case 509:
            return "Joint les câbles";
          case 510:
            return "Coupe les câbles";
          case 515:
            return "Crée plusieurs éclats de cristal à l'impact";
          case 516:
            return "Invoque des étoiles déchues à l'impact";
          case 517:
            return "Une dague qui revient magiquement à son possesseur";
          case 518:
            return "Invoque des éclats rapides de cristal de feu";
          case 519:
            return "Invoque des boules de feu maudites";
          case 520:
            return "'L'essence des créatures de lumière'";
          case 521:
            return "'L'essence des créatures sombres'";
          case 522:
            return "'Même l'eau ne peut l'éteindre'";
          case 523:
            return "Peut être placée dans l'eau";
          case 524:
            return "Utilisée pour fondre le minerai d'adamantine";
          case 525:
            return "Utilisée pour forger des objets avec du mythril et de l'adamantite";
          case 526:
            return "'Magique et coupante'";
          case 527:
            return "'Porté parfois par les créatures dans le désert corrompu'";
          case 528:
            return "'Porté parfois par les créatures dans le désert de lumière'";
          case 529:
            return "S'active en marchant dessus";
          case 531:
            return "Peut être enchanté";
          case 532:
            return "Des étoiles tombent lorsque le porteur est blessé";
          case 533:
            return "50 % de chance de n'utiliser aucune munition";
          case 534:
            return "Disperse une salve de balles";
          case 535:
            return "Réduit le temps d'utilisation entre les potions de soin";
          case 536:
            return "Accroît le recul en mêlée";
          case 541:
            return "S'active en marchant dessus";
          case 542:
            return "S'active en marchant dessus";
          case 543:
            return "S'active en marchant dessus";
          case 544:
            return "Invoque les jumeaux";
          case 547:
            return "'L'essence de la terreur pure'";
          case 548:
            return "'L'essence du destructeur'";
          case 549:
            return "'L'essence des observateurs omniscients'";
          case 551:
            return "Augmente les chances de coup critique de 7 %";
          case 552:
            return "Dégâts augmentés de 7 %";
          case 553:
            return "Dégâts à distance augmentés de 15 %";
          case 554:
            return "Augmente la durée d'invincibilité après avoir subi des dégâts";
          case 555:
            return "Utilisation de mana réduite de 8 %";
          case 556:
            return "Invoque l'destructeur";
          case 557:
            return "Invoque le squeletron primaire";
          case 558:
            return "Augmente le maximum de mana de 100";
          case 559:
            return "Les chances de coup critique et les dégâts de mêlée sont augmentés de 10 %";
          case 560:
            return "Invoque le roi slime";
          case 561:
            return "Possibilité d'en lancer jusqu'à 5";
          case 575:
            return "'L'essence des puissantes créatures volantes'";
          case 576:
            return "A une chance d'enregistrer un morceau";
          case 579:
            return "'À ne pas confondre avec le marteau-scie'";
          case 580:
            return "Explosent lorsqu'ils sont activés";
          case 581:
            return "Envoie de l'eau aux sorties de pompage";
          case 582:
            return "Reçoit de l'eau des postes de pompage";
          case 583:
            return "S'active chaque seconde";
          case 584:
            return "S'active toutes les 3 secondes";
          case 585:
            return "S'active toutes les 5 secondes";
          case 599:
            return "Faites un clic droit pour ouvrir";
          case 600:
            return "Faites un clic droit pour ouvrir";
          case 601:
            return "Faites un clic droit pour ouvrir";
          case 602:
            return "Invoque la Légion gel";
          case 603:
            return "Convocation d'un lapin de compagnie";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case -1:
            return "Puede abrir meteoritos";
          case 8:
            return "Da luz";
          case 15:
            return "Da la hora";
          case 16:
            return "Da la hora";
          case 17:
            return "Da la hora";
          case 18:
            return "indica la profundidad";
          case 23:
            return "'Repugnante a la vez que inflamable'";
          case 29:
            return "Aumenta al máximo la vida (20) de forma definitiva";
          case 33:
            return "Se usa para fundir mineral";
          case 35:
            return "Se usa para fabricar objetos con lingotes de metal";
          case 36:
            return "Se usa para creaciones básicas";
          case 43:
            return "Invoca al Ojo de Cthulhu";
          case 49:
            return "Regenera la vida poco a poco";
          case 50:
            return "Al mirarse en él se regresa al hogar";
          case 53:
            return "Su portador salta el doble";
          case 54:
            return "Permite correr superrápido";
          case 56:
            return "'Late de energía oscura'";
          case 57:
            return "'Late de energía oscura'";
          case 64:
            return "Lanza una espina vil";
          case 65:
            return "Hace que lluevan estrellas del cielo";
          case 66:
            return "Limpia la corrupción";
          case 67:
            return "Elimina la bendición";
          case 68:
            return "'¡Sabe asqueroso!'";
          case 70:
            return "Invoca al Devoramundos";
          case 75:
            return "Desaparece al amanecer";
          case 84:
            return "'¡Te atrapé!'";
          case 88:
            return "Da luz a su portador";
          case 98:
            return "Probabilidad del 33% de no gastar munición";
          case 100:
            return "Aumenta un 7% la velocidad en el cuerpo a cuerpo";
          case 101:
            return "Aumenta un 7% la velocidad en el cuerpo a cuerpo";
          case 102:
            return "Aumenta un 7% la velocidad en el cuerpo a cuerpo";
          case 103:
            return "Puede abrir la piedra infernal";
          case 109:
            return "Aumenta al máximo el maná (20) de forma definitiva";
          case 111:
            return "Aumenta al máximo el maná (20)";
          case 112:
            return "Arroja bolas de fuego";
          case 113:
            return "Lanza un misil dirigido";
          case 114:
            return "Remueve la tierra por arte de magia";
          case 115:
            return "Crea un orbe mágico de luz";
          case 117:
            return "'Calienta la antorcha'";
          case 118:
            return "A veces lo sueltan esqueletos y pirañas";
          case 120:
            return "Enciende las flechas de madera";
          case 121:
            return "'¡Hecha de fuego!'";
          case 123:
            return "Aumenta el daño mágico en un 5%";
          case 124:
            return "Aumenta el daño mágico en un 5%";
          case 125:
            return "Aumenta el daño mágico en un 5%";
          case 128:
            return "Permite volar";
          case 148:
            return "Su portador llamará la atención de indeseables";
          case 149:
            return "'Contiene extraños símbolos'";
          case 151:
            return "Aumenta el daño a distancia en un 4%";
          case 152:
            return "Aumenta el daño a distancia en un 4%";
          case 153:
            return "Aumenta el daño a distancia en un 4%";
          case 156:
            return "Ofrece inmunidad ante el retroceso";
          case 157:
            return "Pulveriza un chorro de agua";
          case 158:
            return "Anula el daño al caer";
          case 159:
            return "Aumenta la altura al saltar";
          case 165:
            return "Lanza un rayo de agua a baja velocidad";
          case 166:
            return "Pequeña explosión que rompe varios ladrillos";
          case 167:
            return "Gran explosión que rompe casi todos los ladrillos";
          case 168:
            return "Pequeña explosión que no rompe ningún ladrillo";
          case 175:
            return "'Enciende la antorcha'";
          case 186:
            return "'Está bien eso de no ahogarse'";
          case 187:
            return "Permite nadar";
          case 193:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 197:
            return "Dispara estrellas caídas";
          case 208:
            return "'Hermosa, muy hermosa'";
          case 211:
            return "Aumenta un 12% la velocidad en el cuerpo a cuerpo";
          case 212:
            return "Aumenta en un 10% la velocidad de movimiento";
          case 213:
            return "Genera césped sobre la tierra";
          case 215:
            return "'Una molestia para los demás'";
          case 218:
            return "Lanza una bola de fuego dirigida";
          case 222:
            return "Cultiva plantas";
          case 223:
            return "Reduce el uso de maná en un 6%";
          case 228:
            return "Aumenta al máximo el maná (20)";
          case 229:
            return "Aumenta al máximo el maná (20)";
          case 230:
            return "Aumenta al máximo el maná (20)";
          case 235:
            return "'Puede costar lanzarla'";
          case 237:
            return "'¡Te quedan muy bien!'";
          case 238:
            return "Aumenta el daño mágico en un 15%";
          case 261:
            return "'Sonríe y además es un buen aperitivo'";
          case 266:
            return "'¡Una buena idea!'";
          case 267:
            return "'Eres mala persona'";
          case 268:
            return "Permite respirar bajo el agua mucho más tiempo";
          case 272:
            return "Lanza una guadaña demoníaca";
          case 281:
            return "Permite recoger semillas como munición";
          case 282:
            return "Funciona con humedad";
          case 283:
            return "Para la cerbatana";
          case 285:
            return "Aumenta en un 5% la velocidad de movimiento";
          case 288:
            return "Ofrece inmunidad ante la lava";
          case 289:
            return "Regenera la vida";
          case 290:
            return "Aumenta en un 25% la velocidad de movimiento";
          case 291:
            return "Permite respirar agua en lugar de aire";
          case 292:
            return "Aumenta la defensa en 8";
          case 293:
            return "Aumenta la regeneración de maná";
          case 294:
            return "Aumenta el daño mágico en un 20%";
          case 295:
            return "Disminuye la velocidad de caída";
          case 296:
            return "Muestra la ubicación de tesoros y minerales";
          case 297:
            return "Proporciona invisibilidad";
          case 298:
            return "Emite un aura de luz";
          case 299:
            return "Aumenta la visión nocturna";
          case 300:
            return "Aumenta el porcentaje de regeneración del enemigo";
          case 301:
            return "Los atacantes también sufren daños";
          case 302:
            return "Permite caminar sobre el agua";
          case 303:
            return "Aumenta en un 20% la velocidad y el daño de las flechas";
          case 304:
            return "Muestra la ubicación de los enemigos";
          case 305:
            return "Permite controlar la gravedad";
          case 324:
            return "'Prohibidos en casi todas partes'";
          case 327:
            return "Abre un cofre de oro";
          case 329:
            return "Abre todos los cofres de las sombras";
          case 332:
            return "Se usa para confeccionar ropa";
          case 352:
            return "Se usa para elaborar cerveza";
          case 357:
            return "Pequeñas mejoras de todas las estadísticas";
          case 361:
            return "Invoca a un ejército de duendes";
          case 363:
            return "Se usa para realizar trabajos de madera avanzados";
          case 367:
            return "Lo bastante sólido para destruir los altares demoníacos";
          case 371:
            return "Aumenta al máximo el maná (40)";
          case 372:
            return "Aumenta en un 7% la velocidad de movimiento";
          case 373:
            return "Aumenta el daño a distancia en un 10%";
          case 376:
            return "Aumenta al máximo el maná (60)";
          case 377:
            return "Aumenta un 5% la probabilidad de ataque crítico en el cuerpo a cuerpo";
          case 378:
            return "Aumenta el daño a distancia en un 12%";
          case 385:
            return "Puede abrir el mithril";
          case 386:
            return "Puede abrir la adamantita";
          case 389:
            return "Puede llegar a confundir";
          case 393:
            return "Indica el horizonte";
          case 394:
            return "Permite nadar";
          case 395:
            return "Indica la posición";
          case 396:
            return "Anula el daño al caer";
          case 397:
            return "Ofrece inmunidad ante el retroceso";
          case 398:
            return "Permite combinar varios accesorios";
          case 399:
            return "Su portador salta el doble";
          case 400:
            return "Aumenta al máximo el maná (80)";
          case 401:
            return "Aumenta un 7% la probabilidad de ataque crítico en el cuerpo a cuerpo";
          case 402:
            return "Aumenta el daño a distancia en un 14%";
          case 403:
            return "Aumenta el daño en un 6%";
          case 404:
            return "Aumenta la probabilidad de ataque crítico en un 4%";
          case 405:
            return "Permite volar";
          case 407:
            return "Aumenta la distancia de colocación de bloques";
          case 422:
            return "Extiende la bendición a algunos bloques";
          case 423:
            return "Extiende la corrupción a algunos bloques";
          case 425:
            return "Invoca a una hada mágica";
          case 434:
            return "Dispara tres ráfagas";
          case 485:
            return "Convierte a su portador en hombre lobo durante la luna llena";
          case 486:
            return "Dibuja una rejilla en pantalla para colocar los bloques";
          case 489:
            return "Aumenta el daño mágico en un 15%";
          case 490:
            return "Aumenta un 15% el daño en el cuerpo a cuerpo";
          case 491:
            return "Aumenta el daño a distancia en un 15%";
          case 492:
            return "Permite volar y caer lentamente";
          case 493:
            return "Permite volar y caer lentamente";
          case 495:
            return "Lanza un arco iris dirigido";
          case 496:
            return "Lanza un bloque de hielo";
          case 497:
            return "Transforma a su portador en un tritón al sumergirse en el agua";
          case 506:
            return "Utiliza baba como munición";
          case 509:
            return "Permite colocar alambre";
          case 510:
            return "Permite cortar alambre";
          case 515:
            return "Crea varios fragmentos de cristal al impactar";
          case 516:
            return "Lanza estrellas caídas al impactar";
          case 517:
            return "Una daga mágica que vuelve al arrojarse";
          case 518:
            return "Lanza fragmentos de cristal a toda velocidad";
          case 519:
            return "Lanza bolas de fuego impuras";
          case 520:
            return "'La esencia de las criaturas de la luz'";
          case 521:
            return "'La esencia de las criaturas de la oscuridad'";
          case 522:
            return "'Ni siquiera el agua puede apagarla'";
          case 523:
            return "Se puede meter en el agua";
          case 524:
            return "Se usa para fundir mineral de adamantita";
          case 525:
            return "Se usa para fabricar objetos con lingotes de mithril y adamantita";
          case 526:
            return "'¡Puntiagudo y mágico!'";
          case 527:
            return "'A veces lo llevan las criaturas de los desiertos corrompidos'";
          case 528:
            return "'A veces lo llevan las criaturas de los desiertos de luz'";
          case 529:
            return "Se activa al pisarla";
          case 531:
            return "Se puede hechizar";
          case 532:
            return "Hace que las estrellas caigan cuando te hieren";
          case 533:
            return "Probabilidad del 50% de no gastar munición";
          case 534:
            return "Dispara una ráfaga de balas";
          case 535:
            return "Reduce el tiempo de espera para las pociones curativas";
          case 536:
            return "Aumenta el retroceso en el cuerpo a cuerpo";
          case 541:
            return "Se activa al pisarla";
          case 542:
            return "Se activa al pisarla";
          case 543:
            return "Se activa al pisarla";
          case 544:
            return "Invoca a los Gemelos";
          case 547:
            return "'La esencia del terror en estado puro'";
          case 548:
            return "'La esencia del Destructor'";
          case 549:
            return "'La esencia de los observadores omniscientes'";
          case 551:
            return "Aumenta la probabilidad de ataque crítico en un 7%";
          case 552:
            return "Aumenta el daño en un 7%";
          case 553:
            return "Aumenta el daño a distancia en un 15%";
          case 554:
            return "Aumenta el tiempo de invencibilidad tras recibir daños";
          case 555:
            return "Reduce el uso de maná en un 8%";
          case 556:
            return "Invoca El Destructor";
          case 557:
            return "Invoca al Esqueleto mayor";
          case 558:
            return "Aumenta al máximo el maná (100)";
          case 559:
            return "Aumenta un 10% la probabilidad de ataque crítico y daño en el cuerpo a cuerpo";
          case 560:
            return "Invoca a la Babosa rey";
          case 561:
            return "No apilar más de 5";
          case 575:
            return "'La esencia de poderosas criaturas que vuelan'";
          case 576:
            return "Puedes grabar canciones";
          case 579:
            return "'No confundir con un cuchillo jamonero'";
          case 580:
            return "Explota al activarse";
          case 581:
            return "Envía agua a los colectores de salida";
          case 582:
            return "Recibe agua de los colectores de entrada";
          case 583:
            return "Se activa cada segundo";
          case 584:
            return "Se activa cada 3 segundos";
          case 585:
            return "Se activa cada 5 segundos";
          case 599:
            return "Haga clic derecho para abrir";
          case 600:
            return "Haga clic derecho para abrir";
          case 601:
            return "Haga clic derecho para abrir";
          case 602:
            return "Convoca a la Legión de Frost";
          case 603:
            return "Convoca a un conejo de mascota";
        }
      }
      return "";
    }

    public static string toolTip2(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case 65:
            return "'Forged with the fury of heaven'";
          case 98:
            return "'Half shark, half gun, completely awesome.'";
          case 228:
            return "3% increased magic critical strike chance";
          case 229:
            return "3% increased magic critical strike chance";
          case 230:
            return "3% increased magic critical strike chance";
          case 371:
            return "9% increased magic critical strike chance";
          case 372:
            return "12% increased melee speed";
          case 373:
            return "6% increased ranged critical strike chance";
          case 374:
            return "3% increased critical strike chance";
          case 375:
            return "10% increased movement speed";
          case 376:
            return "15% increased magic damage";
          case 377:
            return "10% increased melee damage";
          case 378:
            return "7% increased ranged critical strike chance";
          case 379:
            return "5% increased damage";
          case 380:
            return "3% increased critical strike chance";
          case 389:
            return "'Find your inner pieces'";
          case 394:
            return "Greatly extends underwater breathing";
          case 395:
            return "Tells the time";
          case 396:
            return "Grants immunity to fire blocks";
          case 397:
            return "Grants immunity to fire blocks";
          case 399:
            return "Increases jump height";
          case 400:
            return "11% increased magic damage and critical strike chance";
          case 401:
            return "14% increased melee damage";
          case 402:
            return "8% increased ranged critical strike chance";
          case 404:
            return "5% increased movement speed";
          case 405:
            return "The wearer can run super fast";
          case 434:
            return "Only the first shot consumes ammo";
          case 533:
            return "'Minishark's older brother'";
          case 552:
            return "8% increased movement speed";
          case 553:
            return "8% increased ranged critical strike chance";
          case 555:
            return "Automatically use mana potions when needed";
          case 558:
            return "12% increased magic damage and critical strike chance";
          case 559:
            return "10% increased melee haste";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case 65:
            return "'Geschmiedet mit Himmelswut'";
          case 98:
            return "'Halb Hai, halb Pistole - einfach toll!'";
          case 228:
            return "Um 3% erhoehte kritische Magietrefferchance";
          case 229:
            return "Um 3% erhoehte kritische Magietrefferchance";
          case 230:
            return "Um 3% erhoehte kritische Magietrefferchance";
          case 371:
            return "Um 9% erhoehte kritische Magietrefferchance";
          case 372:
            return "Um 12% erhoehtes Nahkampftempo";
          case 373:
            return "Um 6% erhoehte kritische Fernkampf-Trefferchance";
          case 374:
            return "Um 3% erhoehte kritische Trefferchance";
          case 375:
            return "Um 10% erhoehtes Bewegungstempo";
          case 376:
            return "Um 15% erhoehter magischer Schaden";
          case 377:
            return "Um 10% erhoehter Nahkampfschaden";
          case 378:
            return "Um 7% erhoehte kritische Fernkampf-Trefferchance";
          case 379:
            return "Um 5% erhoehter Schaden";
          case 380:
            return "Um 3% erhoehte kritische Trefferchance";
          case 389:
            return "'Sammele dich!'";
          case 394:
            return "Verlaengert das Atmen unter Wasser deutlich";
          case 395:
            return "Zeigt die Zeit an";
          case 396:
            return "Macht immun gegen Feuer-Bloecke";
          case 397:
            return "Macht immun gegen Feuer-Bloecke";
          case 399:
            return "Vergroessert die Sprunghoehe";
          case 400:
            return "Magischer Schaden und kritische Trefferchance um 11% erhoeht";
          case 401:
            return "Um 14% erhoehter Nahkampfschaden";
          case 402:
            return "Um 8% erhoehte kritische Fernkampf-Trefferchance";
          case 404:
            return "Um 5% erhoehtes Bewegungstempo";
          case 405:
            return "Der Traeger kann superschnell rennen";
          case 434:
            return "Nur der erste Schuss verbraucht Munition ";
          case 533:
            return "'Minihais grosser Bruder'";
          case 552:
            return "Um 8% erhoehtes Bewegungstempo";
          case 553:
            return "Um 8% erhoehte kritische Fernkampf-Trefferchance";
          case 555:
            return "Bei Bedarf automatisch Manatraenke verwenden";
          case 558:
            return "Magischer Schaden und kritische Trefferchance um 12% erhoeht";
          case 559:
            return "Um 10% erhoehtes Nahkampftempo";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case 65:
            return "'Forgiato con la furia del cielo'";
          case 98:
            return "'Mezzo squalo, mezza arma, assolutamente terrificante.'";
          case 228:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 229:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 230:
            return "Aumenta la possibilità di colpo critico magico del 3%";
          case 371:
            return "Possibilità colpo critico magico aumentate del 9%";
          case 372:
            return "Velocità del corpo a corpo aumentata del 12%";
          case 373:
            return "Possibilità di colpo critico magico aumentata del 6%";
          case 374:
            return "Possibilità di colpo critico aumentata del 3%";
          case 375:
            return "Velocità di movimento aumentata del 10%";
          case 376:
            return "Danno magico aumentato del 15%";
          case 377:
            return "Danno nel corpo a corpo aumentato del 10%";
          case 378:
            return "Possibilità di colpo critico a distanza aumentata del 7%";
          case 379:
            return "Danno aumentato del 5%";
          case 380:
            return "Possibilità di colpo critico aumentata del 3%";
          case 389:
            return "'Trova i pezzi interni'";
          case 394:
            return "Aumenta moltissimo il respiro sott'acqua";
          case 395:
            return "Indica il tempo";
          case 396:
            return "Permette immunità ai blocchi di fuoco";
          case 397:
            return "Permette immunità ai blocchi di fuoco";
          case 399:
            return "Aumenta l'altezza del salto";
          case 400:
            return "Possibilità di colpo critico e danno magico aumentata del 11%";
          case 401:
            return "Danno del corpo a corpo aumentato del 14%";
          case 402:
            return "Possibilità di colpo critico a distanza aumentata dell'8%";
          case 404:
            return "Velocità di movimento aumentata del 5%";
          case 405:
            return "Colui che li indossa può correre velocissimo";
          case 434:
            return "Solo il primo colpo consuma munizioni";
          case 533:
            return "'Fratello maggiore del Minishark'";
          case 552:
            return "Velocità di movimento aumentata del 8%";
          case 553:
            return "Possibilità di colpo critico a distanza aumentata dell'8%";
          case 555:
            return "Usa le pozioni mana automaticamente in caso di bisogno";
          case 558:
            return "Possibilità di danno magico e colpo critico aumentata del 12%";
          case 559:
            return "Velocità del corpo a corpo aumentata del 10%";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case 65:
            return "'Forgée dans la furie du ciel'";
          case 98:
            return "'Moitié requin, moitié fusil, c'est de la balle !'";
          case 228:
            return "Chance de coup critique magique augmenté de 3 %";
          case 229:
            return "Chance de coup critique magique augmenté de 3 %";
          case 230:
            return "Chance de coup critique magique augmenté de 3 %";
          case 371:
            return "Les chances de coup critique magique sont augmentées de 9 %";
          case 372:
            return "La vitesse de mêlée est augmentée de 12 %";
          case 373:
            return "Les chances de coup critique des attaques à distance sont augmentées de 6 %";
          case 374:
            return "Les chances de coup critique sont augmentées de 3 %";
          case 375:
            return "La vitesse de déplacement est augmentée de 10 %";
          case 376:
            return "Augmente les dégâts magiques de 15 %";
          case 377:
            return "Les dégâts de mêlée sont augmentés de 10 %";
          case 378:
            return "Les chances de coup critique des attaques à distance sont augmentées de 7 %";
          case 379:
            return "Les dégâts sont augmentés de 5 %";
          case 380:
            return "Les chances de coup critique sont augmentées de 3 %";
          case 389:
            return "'Pour trouver la paix intérieure'";
          case 394:
            return "Améliore grandement la respiration sous l'eau";
          case 395:
            return "Donne l'heure";
          case 396:
            return "Permet de résister aux blocs de feu";
          case 397:
            return "Permet de résister aux blocs de feu";
          case 399:
            return "Augmente la hauteur des sauts";
          case 400:
            return "Les dégâts et les chances de coup critique de magie sont augmentés de 11 %";
          case 401:
            return "Les dégâts de mêlée sont augmentés de 14 %";
          case 402:
            return "Chances de coup critique des attaques à distance augmentées de 8 %";
          case 404:
            return "La vitesse de déplacement est augmentée de 5 %";
          case 405:
            return "Le porteur peur courir super vite";
          case 434:
            return "Seul le premier tir utilise des munitions";
          case 533:
            return "'La version améliorée du minishark'";
          case 552:
            return "Vitesse de mouvement augmentée de 8 %";
          case 553:
            return "Chances de coup critique des attaques à distance augmentées de 8 %";
          case 555:
            return "Utilise des potions de mana automatiquement si besoin";
          case 558:
            return "Les chances de coup critique et les dégâts magiques sont augmentés de 12 %";
          case 559:
            return "Vitesse de mêlée augmentée de 10 %";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case 65:
            return "'Forjada por la furia del cielo'";
          case 98:
            return "'Mitad tiburón, mitad arma; realmente asombroso'";
          case 228:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 229:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 230:
            return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
          case 371:
            return "Aumenta la probabilidad de ataque mágico crítico en un 9%";
          case 372:
            return "Aumenta un 12% la velocidad en el cuerpo a cuerpo";
          case 373:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 6%";
          case 374:
            return "Aumenta la probabilidad de ataque crítico en un 3%";
          case 375:
            return "Aumenta en un 10% la velocidad de movimiento";
          case 376:
            return "Aumenta el daño mágico en un 15%";
          case 377:
            return "Aumenta un 10% el daño en el cuerpo a cuerpo";
          case 378:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 7%";
          case 379:
            return "Aumenta el daño en un 5%";
          case 380:
            return "Aumenta la probabilidad de ataque crítico en un 3%";
          case 389:
            return "'Busca en tu interior'";
          case 394:
            return "Permite respirar bajo el agua mucho más tiempo";
          case 395:
            return "Da la hora";
          case 396:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 397:
            return "Ofrece inmunidad ante los bloques de fuego";
          case 399:
            return "Aumenta la altura al saltar";
          case 400:
            return "Aumenta la probabilidad de ataque crítico y daño mágico en un 11%";
          case 401:
            return "Aumenta un 14% el daño en el cuerpo a cuerpo";
          case 402:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
          case 404:
            return "Aumenta en un 5% la velocidad de movimiento";
          case 405:
            return "Permite correr superrápido";
          case 434:
            return "Solo gasta munición el primer disparo";
          case 533:
            return "'El hermano mayor del minitiburón'";
          case 552:
            return "Aumenta en un 8% la velocidad de movimiento";
          case 553:
            return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
          case 555:
            return "Usa de forma automática pociones de maná cuando se necesitan";
          case 558:
            return "Aumenta la probabilidad de ataque crítico y daño mágico en un 12%";
          case 559:
            return "Aumenta un 10% la anticipación en el cuerpo a cuerpo";
        }
      }
      return "";
    }

    public static string itemName(int l)
    {
      if (Lang.lang <= 1)
      {
        switch (l)
        {
          case -24:
            return "Yellow Phasesaber";
          case -23:
            return "White Phasesaber";
          case -22:
            return "Purple Phasesaber";
          case -21:
            return "Green Phasesaber";
          case -20:
            return "Red Phasesaber";
          case -19:
            return "Blue Phasesaber";
          case -18:
            return "Copper Bow";
          case -17:
            return "Copper Hammer";
          case -16:
            return "Copper Axe";
          case -15:
            return "Copper Shortsword";
          case -14:
            return "Copper Broadsword";
          case -13:
            return "Copper Pickaxe";
          case -12:
            return "Silver Bow";
          case -11:
            return "Silver Hammer";
          case -10:
            return "Silver Axe";
          case -9:
            return "Silver Shortsword";
          case -8:
            return "Silver Broadsword";
          case -7:
            return "Silver Pickaxe";
          case -6:
            return "Gold Bow";
          case -5:
            return "Gold Hammer";
          case -4:
            return "Gold Axe";
          case -3:
            return "Gold Shortsword";
          case -2:
            return "Gold Broadsword";
          case -1:
            return "Gold Pickaxe";
          case 1:
            return "Iron Pickaxe";
          case 2:
            return "Dirt Block";
          case 3:
            return "Stone Block";
          case 4:
            return "Iron Broadsword";
          case 5:
            return "Mushroom";
          case 6:
            return "Iron Shortsword";
          case 7:
            return "Iron Hammer";
          case 8:
            return "Torch";
          case 9:
            return "Wood";
          case 10:
            return "Iron Axe";
          case 11:
            return "Iron Ore";
          case 12:
            return "Copper Ore";
          case 13:
            return "Gold Ore";
          case 14:
            return "Silver Ore";
          case 15:
            return "Copper Watch";
          case 16:
            return "Silver Watch";
          case 17:
            return "Gold Watch";
          case 18:
            return "Depth Meter";
          case 19:
            return "Gold Bar";
          case 20:
            return "Copper Bar";
          case 21:
            return "Silver Bar";
          case 22:
            return "Iron Bar";
          case 23:
            return "Gel";
          case 24:
            return "Wooden Sword";
          case 25:
            return "Wooden Door";
          case 26:
            return "Stone Wall";
          case 27:
            return "Acorn";
          case 28:
            return "Lesser Healing Potion";
          case 29:
            return "Life Crystal";
          case 30:
            return "Dirt Wall";
          case 31:
            return "Bottle";
          case 32:
            return "Wooden Table";
          case 33:
            return "Furnace";
          case 34:
            return "Wooden Chair";
          case 35:
            return "Iron Anvil";
          case 36:
            return "Work Bench";
          case 37:
            return "Goggles";
          case 38:
            return "Lens";
          case 39:
            return "Wooden Bow";
          case 40:
            return "Wooden Arrow";
          case 41:
            return "Flaming Arrow";
          case 42:
            return "Shuriken";
          case 43:
            return "Suspicious Looking Eye";
          case 44:
            return "Demon Bow";
          case 45:
            return "War Axe of the Night";
          case 46:
            return "Light's Bane";
          case 47:
            return "Unholy Arrow";
          case 48:
            return "Chest";
          case 49:
            return "Band of Regeneration";
          case 50:
            return "Magic Mirror";
          case 51:
            return "Jester's Arrow";
          case 52:
            return "Angel Statue";
          case 53:
            return "Cloud in a Bottle";
          case 54:
            return "Hermes Boots";
          case 55:
            return "Enchanted Boomerang";
          case 56:
            return "Demonite Ore";
          case 57:
            return "Demonite Bar";
          case 58:
            return "Heart";
          case 59:
            return "Corrupt Seeds";
          case 60:
            return "Vile Mushroom";
          case 61:
            return "Ebonstone Block";
          case 62:
            return "Grass Seeds";
          case 63:
            return "Sunflower";
          case 64:
            return "Vilethorn";
          case 65:
            return "Starfury";
          case 66:
            return "Purification Powder";
          case 67:
            return "Vile Powder";
          case 68:
            return "Rotten Chunk";
          case 69:
            return "Worm Tooth";
          case 70:
            return "Worm Food";
          case 71:
            return "Copper Coin";
          case 72:
            return "Silver Coin";
          case 73:
            return "Gold Coin";
          case 74:
            return "Platinum Coin";
          case 75:
            return "Fallen Star";
          case 76:
            return "Copper Greaves";
          case 77:
            return "Iron Greaves";
          case 78:
            return "Silver Greaves";
          case 79:
            return "Gold Greaves";
          case 80:
            return "Copper Chainmail";
          case 81:
            return "Iron Chainmail";
          case 82:
            return "Silver Chainmail";
          case 83:
            return "Gold Chainmail";
          case 84:
            return "Grappling Hook";
          case 85:
            return "Iron Chain";
          case 86:
            return "Shadow Scale";
          case 87:
            return "Piggy Bank";
          case 88:
            return "Mining Helmet";
          case 89:
            return "Copper Helmet";
          case 90:
            return "Iron Helmet";
          case 91:
            return "Silver Helmet";
          case 92:
            return "Gold Helmet";
          case 93:
            return "Wood Wall";
          case 94:
            return "Wood Platform";
          case 95:
            return "Flintlock Pistol";
          case 96:
            return "Musket";
          case 97:
            return "Musket Ball";
          case 98:
            return "Minishark";
          case 99:
            return "Iron Bow";
          case 100:
            return "Shadow Greaves";
          case 101:
            return "Shadow Scalemail";
          case 102:
            return "Shadow Helmet";
          case 103:
            return "Nightmare Pickaxe";
          case 104:
            return "The Breaker";
          case 105:
            return "Candle";
          case 106:
            return "Copper Chandelier";
          case 107:
            return "Silver Chandelier";
          case 108:
            return "Gold Chandelier";
          case 109:
            return "Mana Crystal";
          case 110:
            return "Lesser Mana Potion";
          case 111:
            return "Band of Starpower";
          case 112:
            return "Flower of Fire";
          case 113:
            return "Magic Missile";
          case 114:
            return "Dirt Rod";
          case 115:
            return "Orb of Light";
          case 116:
            return "Meteorite";
          case 117:
            return "Meteorite Bar";
          case 118:
            return "Hook";
          case 119:
            return "Flamarang";
          case 120:
            return "Molten Fury";
          case 121:
            return "Fiery Greatsword";
          case 122:
            return "Molten Pickaxe";
          case 123:
            return "Meteor Helmet";
          case 124:
            return "Meteor Suit";
          case 125:
            return "Meteor Leggings";
          case 126:
            return "Bottled Water";
          case (int) sbyte.MaxValue:
            return "Space Gun";
          case 128:
            return "Rocket Boots";
          case 129:
            return "Gray Brick";
          case 130:
            return "Gray Brick Wall";
          case 131:
            return "Red Brick";
          case 132:
            return "Red Brick Wall";
          case 133:
            return "Clay Block";
          case 134:
            return "Blue Brick";
          case 135:
            return "Blue Brick Wall";
          case 136:
            return "Chain Lantern";
          case 137:
            return "Green Brick";
          case 138:
            return "Green Brick Wall";
          case 139:
            return "Pink Brick";
          case 140:
            return "Pink Brick Wall";
          case 141:
            return "Gold Brick";
          case 142:
            return "Gold Brick Wall";
          case 143:
            return "Silver Brick";
          case 144:
            return "Silver Brick Wall";
          case 145:
            return "Copper Brick";
          case 146:
            return "Copper Brick Wall";
          case 147:
            return "Spike";
          case 148:
            return "Water Candle";
          case 149:
            return "Book";
          case 150:
            return "Cobweb";
          case 151:
            return "Necro Helmet";
          case 152:
            return "Necro Breastplate";
          case 153:
            return "Necro Greaves";
          case 154:
            return "Bone";
          case 155:
            return "Muramasa";
          case 156:
            return "Cobalt Shield";
          case 157:
            return "Aqua Scepter";
          case 158:
            return "Lucky Horseshoe";
          case 159:
            return "Shiny Red Balloon";
          case 160:
            return "Harpoon";
          case 161:
            return "Spiky Ball";
          case 162:
            return "Ball O' Hurt";
          case 163:
            return "Blue Moon";
          case 164:
            return "Handgun";
          case 165:
            return "Water Bolt";
          case 166:
            return "Bomb";
          case 167:
            return "Dynamite";
          case 168:
            return "Grenade";
          case 169:
            return "Sand Block";
          case 170:
            return "Glass";
          case 171:
            return "Sign";
          case 172:
            return "Ash Block";
          case 173:
            return "Obsidian";
          case 174:
            return "Hellstone";
          case 175:
            return "Hellstone Bar";
          case 176:
            return "Mud Block";
          case 177:
            return "Sapphire";
          case 178:
            return "Ruby";
          case 179:
            return "Emerald";
          case 180:
            return "Topaz";
          case 181:
            return "Amethyst";
          case 182:
            return "Diamond";
          case 183:
            return "Glowing Mushroom";
          case 184:
            return "Star";
          case 185:
            return "Ivy Whip";
          case 186:
            return "Breathing Reed";
          case 187:
            return "Flipper";
          case 188:
            return "Healing Potion";
          case 189:
            return "Mana Potion";
          case 190:
            return "Blade of Grass";
          case 191:
            return "Thorn Chakram";
          case 192:
            return "Obsidian Brick";
          case 193:
            return "Obsidian Skull";
          case 194:
            return "Mushroom Grass Seeds";
          case 195:
            return "Jungle Grass Seeds";
          case 196:
            return "Wooden Hammer";
          case 197:
            return "Star Cannon";
          case 198:
            return "Blue Phaseblade";
          case 199:
            return "Red Phaseblade";
          case 200:
            return "Green Phaseblade";
          case 201:
            return "Purple Phaseblade";
          case 202:
            return "White Phaseblade";
          case 203:
            return "Yellow Phaseblade";
          case 204:
            return "Meteor Hamaxe";
          case 205:
            return "Empty Bucket";
          case 206:
            return "Water Bucket";
          case 207:
            return "Lava Bucket";
          case 208:
            return "Jungle Rose";
          case 209:
            return "Stinger";
          case 210:
            return "Vine";
          case 211:
            return "Feral Claws";
          case 212:
            return "Anklet of the Wind";
          case 213:
            return "Staff of Regrowth";
          case 214:
            return "Hellstone Brick";
          case 215:
            return "Whoopie Cushion";
          case 216:
            return "Shackle";
          case 217:
            return "Molten Hamaxe";
          case 218:
            return "Flamelash";
          case 219:
            return "Phoenix Blaster";
          case 220:
            return "Sunfury";
          case 221:
            return "Hellforge";
          case 222:
            return "Clay Pot";
          case 223:
            return "Nature's Gift";
          case 224:
            return "Bed";
          case 225:
            return "Silk";
          case 226:
            return "Lesser Restoration Potion";
          case 227:
            return "Restoration Potion";
          case 228:
            return "Jungle Hat";
          case 229:
            return "Jungle Shirt";
          case 230:
            return "Jungle Pants";
          case 231:
            return "Molten Helmet";
          case 232:
            return "Molten Breastplate";
          case 233:
            return "Molten Greaves";
          case 234:
            return "Meteor Shot";
          case 235:
            return "Sticky Bomb";
          case 236:
            return "Black Lens";
          case 237:
            return "Sunglasses";
          case 238:
            return "Wizard Hat";
          case 239:
            return "Top Hat";
          case 240:
            return "Tuxedo Shirt";
          case 241:
            return "Tuxedo Pants";
          case 242:
            return "Summer Hat";
          case 243:
            return "Bunny Hood";
          case 244:
            return "Plumber's Hat";
          case 245:
            return "Plumber's Shirt";
          case 246:
            return "Plumber's Pants";
          case 247:
            return "Hero's Hat";
          case 248:
            return "Hero's Shirt";
          case 249:
            return "Hero's Pants";
          case 250:
            return "Fish Bowl";
          case 251:
            return "Archaeologist's Hat";
          case 252:
            return "Archaeologist's Jacket";
          case 253:
            return "Archaeologist's Pants";
          case 254:
            return "Black Dye";
          case (int) byte.MaxValue:
            return "Green Dye";
          case 256:
            return "Ninja Hood";
          case 257:
            return "Ninja Shirt";
          case 258:
            return "Ninja Pants";
          case 259:
            return "Leather";
          case 260:
            return "Red Hat";
          case 261:
            return "Goldfish";
          case 262:
            return "Robe";
          case 263:
            return "Robot Hat";
          case 264:
            return "Gold Crown";
          case 265:
            return "Hellfire Arrow";
          case 266:
            return "Sandgun";
          case 267:
            return "Guide Voodoo Doll";
          case 268:
            return "Diving Helmet";
          case 269:
            return "Familiar Shirt";
          case 270:
            return "Familiar Pants";
          case 271:
            return "Familiar Wig";
          case 272:
            return "Demon Scythe";
          case 273:
            return "Night's Edge";
          case 274:
            return "Dark Lance";
          case 275:
            return "Coral";
          case 276:
            return "Cactus";
          case 277:
            return "Trident";
          case 278:
            return "Silver Bullet";
          case 279:
            return "Throwing Knife";
          case 280:
            return "Spear";
          case 281:
            return "Blowpipe";
          case 282:
            return "Glowstick";
          case 283:
            return "Seed";
          case 284:
            return "Wooden Boomerang";
          case 285:
            return "Aglet";
          case 286:
            return "Sticky Glowstick";
          case 287:
            return "Poisoned Knife";
          case 288:
            return "Obsidian Skin Potion";
          case 289:
            return "Regeneration Potion";
          case 290:
            return "Swiftness Potion";
          case 291:
            return "Gills Potion";
          case 292:
            return "Ironskin Potion";
          case 293:
            return "Mana Regeneration Potion";
          case 294:
            return "Magic Power Potion";
          case 295:
            return "Featherfall Potion";
          case 296:
            return "Spelunker Potion";
          case 297:
            return "Invisibility Potion";
          case 298:
            return "Shine Potion";
          case 299:
            return "Night Owl Potion";
          case 300:
            return "Battle Potion";
          case 301:
            return "Thorns Potion";
          case 302:
            return "Water Walking Potion";
          case 303:
            return "Archery Potion";
          case 304:
            return "Hunter Potion";
          case 305:
            return "Gravitation Potion";
          case 306:
            return "Gold Chest";
          case 307:
            return "Daybloom Seeds";
          case 308:
            return "Moonglow Seeds";
          case 309:
            return "Blinkroot Seeds";
          case 310:
            return "Deathweed Seeds";
          case 311:
            return "Waterleaf Seeds";
          case 312:
            return "Fireblossom Seeds";
          case 313:
            return "Daybloom";
          case 314:
            return "Moonglow";
          case 315:
            return "Blinkroot";
          case 316:
            return "Deathweed";
          case 317:
            return "Waterleaf";
          case 318:
            return "Fireblossom";
          case 319:
            return "Shark Fin";
          case 320:
            return "Feather";
          case 321:
            return "Tombstone";
          case 322:
            return "Mime Mask";
          case 323:
            return "Antlion Mandible";
          case 324:
            return "Illegal Gun Parts";
          case 325:
            return "The Doctor's Shirt";
          case 326:
            return "The Doctor's Pants";
          case 327:
            return "Golden Key";
          case 328:
            return "Shadow Chest";
          case 329:
            return "Shadow Key";
          case 330:
            return "Obsidian Brick Wall";
          case 331:
            return "Jungle Spores";
          case 332:
            return "Loom";
          case 333:
            return "Piano";
          case 334:
            return "Dresser";
          case 335:
            return "Bench";
          case 336:
            return "Bathtub";
          case 337:
            return "Red Banner";
          case 338:
            return "Green Banner";
          case 339:
            return "Blue Banner";
          case 340:
            return "Yellow Banner";
          case 341:
            return "Lamp Post";
          case 342:
            return "Tiki Torch";
          case 343:
            return "Barrel";
          case 344:
            return "Chinese Lantern";
          case 345:
            return "Cooking Pot";
          case 346:
            return "Safe";
          case 347:
            return "Skull Lantern";
          case 348:
            return "Trash Can";
          case 349:
            return "Candelabra";
          case 350:
            return "Pink Vase";
          case 351:
            return "Mug";
          case 352:
            return "Keg";
          case 353:
            return "Ale";
          case 354:
            return "Bookcase";
          case 355:
            return "Throne";
          case 356:
            return "Bowl";
          case 357:
            return "Bowl of Soup";
          case 358:
            return "Toilet";
          case 359:
            return "Grandfather Clock";
          case 360:
            return "Armor Statue";
          case 361:
            return "Goblin Battle Standard";
          case 362:
            return "Tattered Cloth";
          case 363:
            return "Sawmill";
          case 364:
            return "Cobalt Ore";
          case 365:
            return "Mythril Ore";
          case 366:
            return "Adamantite Ore";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Hallowed Seeds";
          case 370:
            return "Ebonsand Block";
          case 371:
            return "Cobalt Hat";
          case 372:
            return "Cobalt Helmet";
          case 373:
            return "Cobalt Mask";
          case 374:
            return "Cobalt Breastplate";
          case 375:
            return "Cobalt Leggings";
          case 376:
            return "Mythril Hood";
          case 377:
            return "Mythril Helmet";
          case 378:
            return "Mythril Hat";
          case 379:
            return "Mythril Chainmail";
          case 380:
            return "Mythril Greaves";
          case 381:
            return "Cobalt Bar";
          case 382:
            return "Mythril Bar";
          case 383:
            return "Cobalt Chainsaw";
          case 384:
            return "Mythril Chainsaw";
          case 385:
            return "Cobalt Drill";
          case 386:
            return "Mythril Drill";
          case 387:
            return "Adamantite Chainsaw";
          case 388:
            return "Adamantite Drill";
          case 389:
            return "Dao of Pow";
          case 390:
            return "Mythril Halberd";
          case 391:
            return "Adamantite Bar";
          case 392:
            return "Glass Wall";
          case 393:
            return "Compass";
          case 394:
            return "Diving Gear";
          case 395:
            return "GPS";
          case 396:
            return "Obsidian Horseshoe";
          case 397:
            return "Obsidian Shield";
          case 398:
            return "Tinkerer's Workshop";
          case 399:
            return "Cloud in a Balloon";
          case 400:
            return "Adamantite Headgear";
          case 401:
            return "Adamantite Helmet";
          case 402:
            return "Adamantite Mask";
          case 403:
            return "Adamantite Breastplate";
          case 404:
            return "Adamantite Leggings";
          case 405:
            return "Spectre Boots";
          case 406:
            return "Adamantite Glaive";
          case 407:
            return "Toolbelt";
          case 408:
            return "Pearlsand Block";
          case 409:
            return "Pearlstone Block";
          case 410:
            return "Mining Shirt";
          case 411:
            return "Mining Pants";
          case 412:
            return "Pearlstone Brick";
          case 413:
            return "Iridescent Brick";
          case 414:
            return "Mudstone Block";
          case 415:
            return "Cobalt Brick";
          case 416:
            return "Mythril Brick";
          case 417:
            return "Pearlstone Brick Wall";
          case 418:
            return "Iridescent Brick Wall";
          case 419:
            return "Mudstone Brick Wall";
          case 420:
            return "Cobalt Brick Wall";
          case 421:
            return "Mythril Brick Wall";
          case 422:
            return "Holy Water";
          case 423:
            return "Unholy Water";
          case 424:
            return "Silt Block";
          case 425:
            return "Fairy Bell";
          case 426:
            return "Breaker Blade";
          case 427:
            return "Blue Torch";
          case 428:
            return "Red Torch";
          case 429:
            return "Green Torch";
          case 430:
            return "Purple Torch";
          case 431:
            return "White Torch";
          case 432:
            return "Yellow Torch";
          case 433:
            return "Demon Torch";
          case 434:
            return "Clockwork Assault Rifle";
          case 435:
            return "Cobalt Repeater";
          case 436:
            return "Mythril Repeater";
          case 437:
            return "Dual Hook";
          case 438:
            return "Star Statue";
          case 439:
            return "Sword Statue";
          case 440:
            return "Slime Statue";
          case 441:
            return "Goblin Statue";
          case 442:
            return "Shield Statue";
          case 443:
            return "Bat Statue";
          case 444:
            return "Fish Statue";
          case 445:
            return "Bunny Statue";
          case 446:
            return "Skeleton Statue";
          case 447:
            return "Reaper Statue";
          case 448:
            return "Woman Statue";
          case 449:
            return "Imp Statue";
          case 450:
            return "Gargoyle Statue";
          case 451:
            return "Gloom Statue";
          case 452:
            return "Hornet Statue";
          case 453:
            return "Bomb Statue";
          case 454:
            return "Crab Statue";
          case 455:
            return "Hammer Statue";
          case 456:
            return "Potion Statue";
          case 457:
            return "Spear Statue";
          case 458:
            return "Cross Statue";
          case 459:
            return "Jellyfish Statue";
          case 460:
            return "Bow Statue";
          case 461:
            return "Boomerang Statue";
          case 462:
            return "Boot Statue";
          case 463:
            return "Chest Statue";
          case 464:
            return "Bird Statue";
          case 465:
            return "Axe Statue";
          case 466:
            return "Corrupt Statue";
          case 467:
            return "Tree Statue";
          case 468:
            return "Anvil Statue";
          case 469:
            return "Pickaxe Statue";
          case 470:
            return "Mushroom Statue";
          case 471:
            return "Eyeball Statue";
          case 472:
            return "Pillar Statue";
          case 473:
            return "Heart Statue";
          case 474:
            return "Pot Statue";
          case 475:
            return "Sunflower Statue";
          case 476:
            return "King Statue";
          case 477:
            return "Queen Statue";
          case 478:
            return "Pirahna Statue";
          case 479:
            return "Planked Wall";
          case 480:
            return "Wooden Beam";
          case 481:
            return "Adamantite Repeater";
          case 482:
            return "Adamantite Sword";
          case 483:
            return "Cobalt Sword";
          case 484:
            return "Mythril Sword";
          case 485:
            return "Moon Charm";
          case 486:
            return "Ruler";
          case 487:
            return "Crystal Ball";
          case 488:
            return "Disco Ball";
          case 489:
            return "Sorcerer Emblem";
          case 490:
            return "Warrior Emblem";
          case 491:
            return "Ranger Emblem";
          case 492:
            return "Demon Wings";
          case 493:
            return "Angel Wings";
          case 494:
            return "Magical Harp";
          case 495:
            return "Rainbow Rod";
          case 496:
            return "Ice Rod";
          case 497:
            return "Neptune's Shell";
          case 498:
            return "Mannequin";
          case 499:
            return "Greater Healing Potion";
          case 500:
            return "Greater Mana Potion";
          case 501:
            return "Pixie Dust";
          case 502:
            return "Crystal Shard";
          case 503:
            return "Clown Hat";
          case 504:
            return "Clown Shirt";
          case 505:
            return "Clown Pants";
          case 506:
            return "Flamethrower";
          case 507:
            return "Bell";
          case 508:
            return "Harp";
          case 509:
            return "Wrench";
          case 510:
            return "Wire Cutter";
          case 511:
            return "Active Stone Block";
          case 512:
            return "Inactive Stone Block";
          case 513:
            return "Lever";
          case 514:
            return "Laser Rifle";
          case 515:
            return "Crystal Bullet";
          case 516:
            return "Holy Arrow";
          case 517:
            return "Magic Dagger";
          case 518:
            return "Crystal Storm";
          case 519:
            return "Cursed Flames";
          case 520:
            return "Soul of Light";
          case 521:
            return "Soul of Night";
          case 522:
            return "Cursed Flame";
          case 523:
            return "Cursed Torch";
          case 524:
            return "Adamantite Forge";
          case 525:
            return "Mythril Anvil";
          case 526:
            return "Unicorn Horn";
          case 527:
            return "Dark Shard";
          case 528:
            return "Light Shard";
          case 529:
            return "Red Pressure Plate";
          case 530:
            return "Wire";
          case 531:
            return "Spell Tome";
          case 532:
            return "Star Cloak";
          case 533:
            return "Megashark";
          case 534:
            return "Shotgun";
          case 535:
            return "Philosopher's Stone";
          case 536:
            return "Titan Glove";
          case 537:
            return "Cobalt Naginata";
          case 538:
            return "Switch";
          case 539:
            return "Dart Trap";
          case 540:
            return "Boulder";
          case 541:
            return "Green Pressure Plate";
          case 542:
            return "Gray Pressure Plate";
          case 543:
            return "Brown Pressure Plate";
          case 544:
            return "Mechanical Eye";
          case 545:
            return "Cursed Arrow";
          case 546:
            return "Cursed Bullet";
          case 547:
            return "Soul of Fright";
          case 548:
            return "Soul of Might";
          case 549:
            return "Soul of Sight";
          case 550:
            return "Gungnir";
          case 551:
            return "Hallowed Plate Mail";
          case 552:
            return "Hallowed Greaves";
          case 553:
            return "Hallowed Helmet";
          case 554:
            return "Cross Necklace";
          case 555:
            return "Mana Flower";
          case 556:
            return "Mechanical Worm";
          case 557:
            return "Mechanical Skull";
          case 558:
            return "Hallowed Headgear";
          case 559:
            return "Hallowed Mask";
          case 560:
            return "Slime Crown";
          case 561:
            return "Light Disc";
          case 562:
            return "Music Box (Overworld Day)";
          case 563:
            return "Music Box (Eerie)";
          case 564:
            return "Music Box (Night)";
          case 565:
            return "Music Box (Title)";
          case 566:
            return "Music Box (Underground)";
          case 567:
            return "Music Box (Boss 1)";
          case 568:
            return "Music Box (Jungle)";
          case 569:
            return "Music Box (Corruption)";
          case 570:
            return "Music Box (Underground Corruption)";
          case 571:
            return "Music Box (The Hallow)";
          case 572:
            return "Music Box (Boss 2)";
          case 573:
            return "Music Box (Underground Hallow)";
          case 574:
            return "Music Box (Boss 3)";
          case 575:
            return "Soul of Flight";
          case 576:
            return "Music Box";
          case 577:
            return "Demonite Brick";
          case 578:
            return "Hallowed Repeater";
          case 579:
            return "Hamdrax";
          case 580:
            return "Explosives";
          case 581:
            return "Inlet Pump";
          case 582:
            return "Outlet Pump";
          case 583:
            return "1 Second Timer";
          case 584:
            return "3 Second Timer";
          case 585:
            return "5 Second Timer";
          case 586:
            return "Candy Cane Block";
          case 587:
            return "Candy Cane Wall";
          case 588:
            return "Santa Hat";
          case 589:
            return "Santa Shirt";
          case 590:
            return "Santa Pants";
          case 591:
            return "Green Candy Cane Block";
          case 592:
            return "Green Candy Cane Wall";
          case 593:
            return "Snow Block";
          case 594:
            return "Snow Brick";
          case 595:
            return "Snow Brick Wall";
          case 596:
            return "Blue Light";
          case 597:
            return "Red Light";
          case 598:
            return "Green Light";
          case 599:
            return "Blue Present";
          case 600:
            return "Green Present";
          case 601:
            return "Yellow Present";
          case 602:
            return "Snow Globe";
          case 603:
            return "Carrot";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (l)
        {
          case -24:
            return "Gelbes Laserschwert";
          case -23:
            return "Weisses Laserschwert";
          case -22:
            return "Lila Laserschwert";
          case -21:
            return "Gruenes Laserschwert";
          case -20:
            return "Rotes Laserschwert";
          case -19:
            return "Blaues Laserschwert";
          case -18:
            return "Kupferbogen";
          case -17:
            return "Kupferhammer";
          case -16:
            return "Kupferaxt";
          case -15:
            return "Kupferkurzschwert";
          case -14:
            return "Kupferbreitschwert";
          case -13:
            return "Kupferspitzhacke";
          case -12:
            return "Silberbogen";
          case -11:
            return "Silberhammer";
          case -10:
            return "Silberaxt";
          case -9:
            return "Silberkurzschwert";
          case -8:
            return "Silberbreitschwert";
          case -7:
            return "Silberspitzhacke";
          case -6:
            return "Goldbogen";
          case -5:
            return "Goldhammer";
          case -4:
            return "Goldaxt";
          case -3:
            return "Goldkurzschwert";
          case -2:
            return "Goldbreitschwert";
          case -1:
            return "Goldspitzhacke";
          case 1:
            return "Eisenspitzhacke";
          case 2:
            return "Dreckblock";
          case 3:
            return "Steinblock";
          case 4:
            return "Eisenbreitschwert";
          case 5:
            return "Pilz";
          case 6:
            return "Eisenkurzschwert";
          case 7:
            return "Eisenhammer";
          case 8:
            return "Fackel";
          case 9:
            return "Holz";
          case 10:
            return "Eisenaxt";
          case 11:
            return "Eisenerz";
          case 12:
            return "Kupfererz";
          case 13:
            return "Golderz";
          case 14:
            return "Silbererz";
          case 15:
            return "Kupferuhr";
          case 16:
            return "Silberuhr";
          case 17:
            return "Golduhr";
          case 18:
            return "Taucheruhr";
          case 19:
            return "Goldbarren";
          case 20:
            return "Kupferbarren";
          case 21:
            return "Silberbarren";
          case 22:
            return "Eisenbarren";
          case 23:
            return "Glibber";
          case 24:
            return "Holzschwert";
          case 25:
            return "Holztuer";
          case 26:
            return "Steinwand";
          case 27:
            return "Eichel";
          case 28:
            return "Schwacher Heiltrank";
          case 29:
            return "Lebenskristall";
          case 30:
            return "Dreckwand";
          case 31:
            return "Flasche";
          case 32:
            return "Holztisch";
          case 33:
            return "Ofen";
          case 34:
            return "Holzstuhl";
          case 35:
            return "Eisenamboss";
          case 36:
            return "Werkbank";
          case 37:
            return "Schutzbrille";
          case 38:
            return "Linse";
          case 39:
            return "Holzbogen";
          case 40:
            return "Holzpfeil";
          case 41:
            return "Flammenpfeil";
          case 42:
            return "Shuriken";
          case 43:
            return "Verdaechtig ausschauendes Auge";
          case 44:
            return "Daemonenbogen";
          case 45:
            return "Kriegsaxt der Nacht";
          case 46:
            return "Schrecken des Tages";
          case 47:
            return "Unheiliger Pfeil";
          case 48:
            return "Truhe";
          case 49:
            return "Wiederbelebungsband";
          case 50:
            return "Magischer Spiegel";
          case 51:
            return "Dominopfeil";
          case 52:
            return "Engelsstatue";
          case 53:
            return "Wolke in einer Flasche";
          case 54:
            return "Hermes-Stiefel";
          case 55:
            return "Verzauberter Bumerang";
          case 56:
            return "Daemoniterz";
          case 57:
            return "Daemonitbarren";
          case 58:
            return "Herz";
          case 59:
            return "Verderbte Saat";
          case 60:
            return "Ekelpilz";
          case 61:
            return "Ebensteinblock";
          case 62:
            return "Grassaat";
          case 63:
            return "Sonnenblume";
          case 64:
            return "Ekeldorn";
          case 65:
            return "Sternenwut";
          case 66:
            return "Reinigungspulver";
          case 67:
            return "Ekelpulver";
          case 68:
            return "Verfaultes";
          case 69:
            return "Wurmzahn";
          case 70:
            return "Wurmkoeder";
          case 71:
            return "Kupfermuenze";
          case 72:
            return "Silbermuenze";
          case 73:
            return "Goldmuenze";
          case 74:
            return "Platinmuenze";
          case 75:
            return "Sternschnuppe";
          case 76:
            return "Kupferbeinschuetzer";
          case 77:
            return "Eisenbeinschuetzer";
          case 78:
            return "Silberbeinschuetzer";
          case 79:
            return "Goldbeinschuetzer";
          case 80:
            return "Kupferkettenhemd";
          case 81:
            return "Eisenkettenhemd";
          case 82:
            return "Silberkettenhemd";
          case 83:
            return "Goldkettenhemd";
          case 84:
            return "Enterhaken";
          case 85:
            return "Eisenkette";
          case 86:
            return "Schattenschuppe";
          case 87:
            return "Sparschwein";
          case 88:
            return "Bergmannshelm";
          case 89:
            return "Kupferhelm";
          case 90:
            return "Eisenhelm";
          case 91:
            return "Silberhelm";
          case 92:
            return "Goldhelm";
          case 93:
            return "Holzwand";
          case 94:
            return "Holzklappe";
          case 95:
            return "Steinschlosspistole";
          case 96:
            return "Muskete";
          case 97:
            return "Musketenkugel";
          case 98:
            return "Minihai";
          case 99:
            return "Eisenbogen";
          case 100:
            return "Schattenbeinschuetzer";
          case 101:
            return "Schattenschuppenhemd";
          case 102:
            return "Schattenhelm";
          case 103:
            return "Albtraum-Spitzhacke";
          case 104:
            return "Zerschmetterer";
          case 105:
            return "Kerze";
          case 106:
            return "Kupferkronleuchter";
          case 107:
            return "Silberkronleuchter";
          case 108:
            return "Goldkronleuchter";
          case 109:
            return "Mana-Kristall";
          case 110:
            return "Schwacher Manatrank";
          case 111:
            return "Sternenkraftband";
          case 112:
            return "Feuerblume";
          case 113:
            return "Magische Rakete";
          case 114:
            return "Dreckrute";
          case 115:
            return "Lichtkugel";
          case 116:
            return "Meteorit";
          case 117:
            return "Meteoritenbarren";
          case 118:
            return "Haken";
          case 119:
            return "Flamarang";
          case 120:
            return "Geschmolzene Wut";
          case 121:
            return "Feuriges Grossschwert";
          case 122:
            return "Geschmolzene Spitzhacke";
          case 123:
            return "Meteorhelm";
          case 124:
            return "Meteoranzug";
          case 125:
            return "Meteor Leggings";
          case 126:
            return "Flaschenwasser";
          case (int) sbyte.MaxValue:
            return "Raum Gun";
          case 128:
            return "Raketenstiefel";
          case 129:
            return "Grauer Ziegel";
          case 130:
            return "Graue Ziegelsteinwand";
          case 131:
            return "Roter Ziegel";
          case 132:
            return "Rote Ziegelwand";
          case 133:
            return "Lehmblock";
          case 134:
            return "Blauer Ziegel";
          case 135:
            return "Blaue Ziegelwand";
          case 136:
            return "Haengelaterne";
          case 137:
            return "Gruener Ziegel";
          case 138:
            return "Gruene Ziegelwand";
          case 139:
            return "Rosa Ziegel";
          case 140:
            return "Rosa Ziegelwand";
          case 141:
            return "Goldziegel";
          case 142:
            return "Goldziegelwand";
          case 143:
            return "Silberziegel";
          case 144:
            return "Silberziegelwand";
          case 145:
            return "Kupferziegel";
          case 146:
            return "Kupferziegelwand";
          case 147:
            return "Stachel";
          case 148:
            return "Wasserkerze";
          case 149:
            return "Buch";
          case 150:
            return "Spinnennetz";
          case 151:
            return "Necrohelm";
          case 152:
            return "Necro-Brustplatte";
          case 153:
            return "Necro-Beinschuetzer";
          case 154:
            return "Knochen";
          case 155:
            return "Muramasa";
          case 156:
            return "Kobaltschild";
          case 157:
            return "Aqua-Zepter";
          case 158:
            return "Glueckshufeisen";
          case 159:
            return "Leuchtend roter Ballon";
          case 160:
            return "Harpune";
          case 161:
            return "Stachelball";
          case 162:
            return "Ball des Schmerzes";
          case 163:
            return "Blauer Mond";
          case 164:
            return "Pistole";
          case 165:
            return "Wasserbolzen";
          case 166:
            return "Bombe";
          case 167:
            return "Dynamit";
          case 168:
            return "Granate";
          case 169:
            return "Sandblock";
          case 170:
            return "Glas";
          case 171:
            return "Spruchschild";
          case 172:
            return "Aschenblock";
          case 173:
            return "Obsidian";
          case 174:
            return "HOeLLENSTEIN";
          case 175:
            return "HOeLLENSTEIN-Barren";
          case 176:
            return "Matschblock";
          case 177:
            return "Saphir";
          case 178:
            return "Rubin";
          case 179:
            return "Smaragd";
          case 180:
            return "Topas";
          case 181:
            return "Amethyst";
          case 182:
            return "Diamant";
          case 183:
            return "Gluehender Pilz";
          case 184:
            return "Stern";
          case 185:
            return "Efeupeitsche";
          case 186:
            return "Schnorchelschilf";
          case 187:
            return "Flosse";
          case 188:
            return "Heiltrank";
          case 189:
            return "Manatrank";
          case 190:
            return "Grasklinge";
          case 191:
            return "Dornen-Chakram";
          case 192:
            return "Obsidianziegel";
          case 193:
            return "Obsidianschaedel";
          case 194:
            return "Pilzgras-Saat";
          case 195:
            return "Dschungelgras-Saat";
          case 196:
            return "Holzhammer";
          case 197:
            return "Sternenkanone";
          case 198:
            return "Blaue Laserklinge";
          case 199:
            return "Rote Laserklinge";
          case 200:
            return "Gruene Laserklinge";
          case 201:
            return "Lila Laserklinge";
          case 202:
            return "Weisse Laserklinge";
          case 203:
            return "Gelbe Laserklinge";
          case 204:
            return "Meteor-Hamaxt";
          case 205:
            return "Leerer Eimer";
          case 206:
            return "Wassereimer";
          case 207:
            return "Lavaeimer";
          case 208:
            return "Dschungelrose";
          case 209:
            return "Hornissenstachel";
          case 210:
            return "Weinrebe";
          case 211:
            return "Wilde Klauen";
          case 212:
            return "Fusskette des Windes";
          case 213:
            return "Stab des Nachwachsens";
          case 214:
            return "Hoellensteinziegel";
          case 215:
            return "Furzkissen";
          case 216:
            return "Fessel";
          case 217:
            return "Geschmolzene Hamaxt";
          case 218:
            return "Flammenpeitsche";
          case 219:
            return "Phoenix-Blaster";
          case 220:
            return "Sonnenwut";
          case 221:
            return "Hoellenschmiede";
          case 222:
            return "Tontopf";
          case 223:
            return "Geschenk der Natur";
          case 224:
            return "Bett";
          case 225:
            return "Seide";
          case 226:
            return "Schwacher Wiederherstellungstrank";
          case 227:
            return "Wiederherstellungstrank";
          case 228:
            return "Dschungelhut";
          case 229:
            return "Dschungelhemd";
          case 230:
            return "Dschungelhosen";
          case 231:
            return "Geschmolzener Helm";
          case 232:
            return "Geschmolzene Brustplatte";
          case 233:
            return "Geschmolzene Beinschuetzer";
          case 234:
            return "Meteorenschuss";
          case 235:
            return "Haftbombe";
          case 236:
            return "Schwarze Linsen";
          case 237:
            return "Sonnenbrille";
          case 238:
            return "Zaubererhut";
          case 239:
            return "Zylinderhut";
          case 240:
            return "Smokinghemd";
          case 241:
            return "Smokinghosen";
          case 242:
            return "Sommerhut";
          case 243:
            return "Hasenkapuze";
          case 244:
            return "Klempnerhut";
          case 245:
            return "Klempnerhemd";
          case 246:
            return "Klempnerhosen";
          case 247:
            return "Heldenhut";
          case 248:
            return "Heldenhemd";
          case 249:
            return "Heldenhosen";
          case 250:
            return "Fischglas";
          case 251:
            return "Archaeologenhut";
          case 252:
            return "Archaeologenjacke";
          case 253:
            return "Archaeologenhosen";
          case 254:
            return "Schwarzer Farbstoff";
          case (int) byte.MaxValue:
            return "Gruener Farbstoff";
          case 256:
            return "Ninja-Kapuze";
          case 257:
            return "Ninjahemd";
          case 258:
            return "Ninjahosen";
          case 259:
            return "Leder";
          case 260:
            return "Roter Hut";
          case 261:
            return "Goldfisch";
          case 262:
            return "Robe";
          case 263:
            return "Roboterhut";
          case 264:
            return "Goldkrone";
          case 265:
            return "Hoellenfeuer-Pfeil";
          case 266:
            return "Sandgewehr";
          case 267:
            return "Fremdenfuehrer-Voodoo-Puppe";
          case 268:
            return "Taucherhelm";
          case 269:
            return "Vertrautes Hemd";
          case 270:
            return "Vertraute Hosen";
          case 271:
            return "Vertraute Frisur";
          case 272:
            return "Daemonensense";
          case 273:
            return "Klinge der Nacht";
          case 274:
            return "Dunkle Lanze";
          case 275:
            return "Koralle";
          case 276:
            return "Kaktus";
          case 277:
            return "Dreizack";
          case 278:
            return "Silberkugel";
          case 279:
            return "Wurfmesser";
          case 280:
            return "Speer";
          case 281:
            return "Blasrohr";
          case 282:
            return "Leuchtstab";
          case 283:
            return "Saat";
          case 284:
            return "Holzbumerang";
          case 285:
            return "Schnuersenkelkappe";
          case 286:
            return "Klebriger Leuchtstab";
          case 287:
            return "Giftmesser";
          case 288:
            return "Obsidianhaut-Trank";
          case 289:
            return "Wiederbelebungstrank";
          case 290:
            return "Flinkheitstrank";
          case 291:
            return "Kiementrank";
          case 292:
            return "Eisenhaut-Trank";
          case 293:
            return "Mana-Wiederherstellungstrank";
          case 294:
            return "Magiekraft-Trank";
          case 295:
            return "Federsturz-Trank";
          case 296:
            return "Hoehlenforschertrank";
          case 297:
            return "Unsichtbarkeitstrank";
          case 298:
            return "Strahlentrank";
          case 299:
            return "Nachteulentrank";
          case 300:
            return "Kampftrank";
          case 301:
            return "Dornentrank";
          case 302:
            return "Wasserlauftrank";
          case 303:
            return "Bogenschiessrank";
          case 304:
            return "Jaegertrank";
          case 305:
            return "Gravitationstrank";
          case 306:
            return "Goldtruhe";
          case 307:
            return "Tagesblumensaat";
          case 308:
            return "Mondscheinsaat";
          case 309:
            return "Leuchtwurzel-Saat";
          case 310:
            return "Todeskraut-Saat";
          case 311:
            return "Wasserblatt-Saat";
          case 312:
            return "Feuerblueten-Saat";
          case 313:
            return "Tagesblume";
          case 314:
            return "Mondglanz";
          case 315:
            return "Leuchtwurzel";
          case 316:
            return "Todeskraut";
          case 317:
            return "Wasserblatt";
          case 318:
            return "Feuerbluete";
          case 319:
            return "Haifinne";
          case 320:
            return "Feder";
          case 321:
            return "Grabstein";
          case 322:
            return "Imitatormaske";
          case 323:
            return "Ameisenloewenkiefer";
          case 324:
            return "Illegale Gewehrteile";
          case 325:
            return "Hemd des Arztes";
          case 326:
            return "Hosen des Arztes";
          case 327:
            return "Goldener Schluessel";
          case 328:
            return "Schattentruhe";
          case 329:
            return "Schattenschluessel";
          case 330:
            return "Obsidianziegelwand";
          case 331:
            return "Dschungelsporen";
          case 332:
            return "Webstuhl";
          case 333:
            return "Piano";
          case 334:
            return "Kommode";
          case 335:
            return "Sitzbank";
          case 336:
            return "Badewanne";
          case 337:
            return "Rotes Dekoband";
          case 338:
            return "Gruenes Dekoband";
          case 339:
            return "Blaues Dekoband";
          case 340:
            return "Gelbes Dekoband";
          case 341:
            return "Laternenpfahl";
          case 342:
            return "Petroleumfackel";
          case 343:
            return "Fass";
          case 344:
            return "Chinesische Laterne";
          case 345:
            return "Kochtopf";
          case 346:
            return "Tresor";
          case 347:
            return "Schaedellaterne";
          case 348:
            return "Muelleimer";
          case 349:
            return "Kandelaber";
          case 350:
            return "Rosa Vase";
          case 351:
            return "Masskrug";
          case 352:
            return "Gaerbottich";
          case 353:
            return "Bier";
          case 354:
            return "Buecherregal";
          case 355:
            return "Thron";
          case 356:
            return "Schuessel";
          case 357:
            return "Schuessel mit Suppe";
          case 358:
            return "Toilette";
          case 359:
            return "Standuhr";
          case 360:
            return "Ruestungsstatue";
          case 361:
            return "Goblin-Kampfstandarte";
          case 362:
            return "Zerfetzter Stoff";
          case 363:
            return "Saegewerk";
          case 364:
            return "Kobalterz";
          case 365:
            return "Mithrilerz";
          case 366:
            return "Adamantiterz";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Gesegnete Saat";
          case 370:
            return "Ebensandblock";
          case 371:
            return "Kobalthut";
          case 372:
            return "Kobalthelm";
          case 373:
            return "Kobalt-Maske";
          case 374:
            return "Kobalt-Brustplatte";
          case 375:
            return "Kobalt-Gamaschen";
          case 376:
            return "Mithril-Kapuze";
          case 377:
            return "Mithril-Helm";
          case 378:
            return "Mithrilhut";
          case 379:
            return "Mithril-Kettenhemd";
          case 380:
            return "Mithril-Beinschuetzer";
          case 381:
            return "Kobaltbarren";
          case 382:
            return "Mithrilbarren";
          case 383:
            return "Kobalt-Kettensaege";
          case 384:
            return "Mithril-Kettensaege";
          case 385:
            return "Kobaltbohrer";
          case 386:
            return "Mithrilbohrer";
          case 387:
            return "Adamantit-Kettensaege";
          case 388:
            return "Adamantitbohrer";
          case 389:
            return "Dao von Pow";
          case 390:
            return "Mithril-Hellebarde";
          case 391:
            return "Adamantitbarren";
          case 392:
            return "Glaswand";
          case 393:
            return "Kompass";
          case 394:
            return "Tauchausruestung";
          case 395:
            return "GPS";
          case 396:
            return "Obsidian-Hufeisen";
          case 397:
            return "Obsidianschild";
          case 398:
            return "Tueftler-Werkstatt";
          case 399:
            return "Wolke in einem Ballon";
          case 400:
            return "Adamantitkopfschutz";
          case 401:
            return "Adamantithelm";
          case 402:
            return "Adamantitmaske";
          case 403:
            return "Adamantitbrustplatte";
          case 404:
            return "Adamantitgamaschen";
          case 405:
            return "Geisterstiefel";
          case 406:
            return "Adamantitgleve";
          case 407:
            return "Werkzeugguertel";
          case 408:
            return "Perlsandblock";
          case 409:
            return "Perlsteinblock";
          case 410:
            return "Bergbauhemd";
          case 411:
            return "Bergbauhosen";
          case 412:
            return "Perlsteinziegel";
          case 413:
            return "Schillernder Ziegel";
          case 414:
            return "Schlammsteinblock";
          case 415:
            return "Kobaltziegel";
          case 416:
            return "Mithrilziegel";
          case 417:
            return "Perlsteinziegelwand";
          case 418:
            return "Schillernde Ziegelwand";
          case 419:
            return "Schlammsteinziegelwand";
          case 420:
            return "Kobaltziegelwand";
          case 421:
            return "Mithrilziegelwand";
          case 422:
            return "Heiliges Wasser";
          case 423:
            return "Unheiliges Wasser";
          case 424:
            return "Schlickblock";
          case 425:
            return "Feenglocke";
          case 426:
            return "Schmetterklinge";
          case 427:
            return "Blaue Fackel";
          case 428:
            return "Rote Fackel";
          case 429:
            return "Gruene Fackel";
          case 430:
            return "Lila Fackel";
          case 431:
            return "Weisse Fackel";
          case 432:
            return "Gelbe Fackel";
          case 433:
            return "Daemonenfackel";
          case 434:
            return "Automatiksturmwaffe";
          case 435:
            return "Kobaltrepetierer";
          case 436:
            return "Mithrilrepetierer";
          case 437:
            return "Dual-Haken";
          case 438:
            return "Sternstatue";
          case 439:
            return "Schwertstatue";
          case 440:
            return "Schleimistatue";
          case 441:
            return "Goblinstatue";
          case 442:
            return "Schildstatue";
          case 443:
            return "Fledermausstatue";
          case 444:
            return "Fischstatue";
          case 445:
            return "Haeschenstatue";
          case 446:
            return "Skelettstatue";
          case 447:
            return "Sensenmannstatue";
          case 448:
            return "Frauenstatue";
          case 449:
            return "Impstatue";
          case 450:
            return "Wasserspeier-Statue";
          case 451:
            return "Vanitasstatue";
          case 452:
            return "Hornissenstatue";
          case 453:
            return "Bombenstatue";
          case 454:
            return "Krabbenstatue";
          case 455:
            return "Hammerstatue";
          case 456:
            return "Trankstatue";
          case 457:
            return "Speerstatue";
          case 458:
            return "Kreuzstatue";
          case 459:
            return "Quallenstatue";
          case 460:
            return "Bogenstatue";
          case 461:
            return "Bumerangstatue";
          case 462:
            return "Stiefelstatue";
          case 463:
            return "Truhenstatue";
          case 464:
            return "Vogelstatue";
          case 465:
            return "Axtstatue";
          case 466:
            return "Verderbnisstatue";
          case 467:
            return "Baumstatue";
          case 468:
            return "Amboss-Statue";
          case 469:
            return "Spitzhackenstatue";
          case 470:
            return "Pilzstatue";
          case 471:
            return "Augapfelstatue";
          case 472:
            return "Saeulenstatue";
          case 473:
            return "Herzstatue";
          case 474:
            return "Topfstatue";
          case 475:
            return "Sonnenblumenstatue";
          case 476:
            return "Koenigstatue";
          case 477:
            return "Koeniginstatue";
          case 478:
            return "Pirahnastatue";
          case 479:
            return "Plankenwand";
          case 480:
            return "Holzbalken";
          case 481:
            return "Adamantitrepetierer";
          case 482:
            return "Adamantitschwert";
          case 483:
            return "Kobaltschwert";
          case 484:
            return "Mithrilschwert";
          case 485:
            return "Mondzauber";
          case 486:
            return "Massgitter";
          case 487:
            return "Kristallkugel";
          case 488:
            return "Diskokugel";
          case 489:
            return "Hexeremblem";
          case 490:
            return "Kriegeremblem";
          case 491:
            return "Waldlaeufer-Emblem";
          case 492:
            return "Daemonenfluegel";
          case 493:
            return "Engelsfluegel";
          case 494:
            return "Magische Harfe";
          case 495:
            return "Regenbogenrute";
          case 496:
            return "Eisrute";
          case 497:
            return "Neptuns Muschel";
          case 498:
            return "Mannequin";
          case 499:
            return "Grosser Heiltrank";
          case 500:
            return "Grosser Manatrank";
          case 501:
            return "Pixie-Staub";
          case 502:
            return "Kristallscherbe";
          case 503:
            return "Clownshut";
          case 504:
            return "Clownshemd";
          case 505:
            return "Clownshosen";
          case 506:
            return "Flammenwerfer";
          case 507:
            return "Glocke";
          case 508:
            return "Harfe";
          case 509:
            return "Schraubenschluessel";
          case 510:
            return "Kabelcutter";
          case 511:
            return "Aktiver Steinblock";
          case 512:
            return "Inaktiver Steinblock";
          case 513:
            return "Hebel";
          case 514:
            return "Lasergewehr";
          case 515:
            return "Kristallgeschoss";
          case 516:
            return "Heiliger Pfeil";
          case 517:
            return "Magischer Dolch";
          case 518:
            return "Kristallsturm";
          case 519:
            return "Verfluchte Flammen";
          case 520:
            return "Seele des Lichts";
          case 521:
            return "Seele der Nacht";
          case 522:
            return "Verfluchte Flamme";
          case 523:
            return "Verfluchte Fackel";
          case 524:
            return "Adamantitschmiede";
          case 525:
            return "Mithrilamboss";
          case 526:
            return "Horn des Einhorns";
          case 527:
            return "Dunkle Scherbe";
          case 528:
            return "Lichtscherbe";
          case 529:
            return "Rote Druckplatte";
          case 530:
            return "Kabel";
          case 531:
            return "Buch der Flueche";
          case 532:
            return "Sternenumhang";
          case 533:
            return "Maxihai";
          case 534:
            return "Schrotflinte";
          case 535:
            return "Stein der Weisen";
          case 536:
            return "Titanhandschuh";
          case 537:
            return "Kobalt-Naginata";
          case 538:
            return "Schalter";
          case 539:
            return "Pfeilfalle";
          case 540:
            return "Felsbrocken";
          case 541:
            return "Gruene Druckplatte";
          case 542:
            return "Graue Druckplatte";
          case 543:
            return "Braune Druckplatte";
          case 544:
            return "Mechanisches Auge";
          case 545:
            return "Verfluchter Pfeil";
          case 546:
            return "Verfluchte Kugel";
          case 547:
            return "Seele des Schreckens";
          case 548:
            return "Seele der Macht";
          case 549:
            return "Seele der Einsicht";
          case 550:
            return "Gungnir";
          case 551:
            return "Gesegneter Plattenpanzer";
          case 552:
            return "Geheiligte Beinschuetzer";
          case 553:
            return "Gesegneter Helm";
          case 554:
            return "Kreuzhalskette";
          case 555:
            return "Mana-Blume";
          case 556:
            return "Mechanischer Wurm";
          case 557:
            return "Mechanischer Schaedel";
          case 558:
            return "Gesegneter Kopfschutz";
          case 559:
            return "Gesegnete Maske";
          case 560:
            return "Schleimikrone";
          case 561:
            return "Lichtscheibe";
          case 562:
            return "Musikbox (Tag auf der Oberwelt)";
          case 563:
            return "Musikbox (Gespenstisch)";
          case 564:
            return "Musikbox (Nacht)";
          case 565:
            return "Musikbox (Titel)";
          case 566:
            return "Musikbox (Unterirdisch)";
          case 567:
            return "Musikbox (Boss 1)";
          case 568:
            return "Musikbox (Dschungel)";
          case 569:
            return "Musikbox (Verderben)";
          case 570:
            return "Musikbox(Unterirdisches Verderben)";
          case 571:
            return "Musikbox (Das Gesegnete)";
          case 572:
            return "Musikbox (Boss 2)";
          case 573:
            return "Musikbox (Unterirdisches Gesegnetes)";
          case 574:
            return "Musikbox (Boss 3)";
          case 575:
            return "Seele des Flugs";
          case 576:
            return "Musikbox";
          case 577:
            return "Daemonitziegel";
          case 578:
            return "Gesegneter Repetierer";
          case 579:
            return "Hamdrax";
          case 580:
            return "Explosiva";
          case 581:
            return "Einlasspumpe";
          case 582:
            return "Auslasspumpe";
          case 583:
            return "1-Sekunden-Timer";
          case 584:
            return "3-Sekunden-Timer";
          case 585:
            return "5-Sekunden-Timer";
          case 586:
            return "Candy Cane-Block";
          case 587:
            return "Candy Cane Wand";
          case 588:
            return "Weihnachtsmütze";
          case 589:
            return "Santa Shirt";
          case 590:
            return "von Santa Pants";
          case 591:
            return "Grüne Candy Cane-Block";
          case 592:
            return "Grüne Candy Cane Wand";
          case 593:
            return "Schnee-Block";
          case 594:
            return "Schnee Brick";
          case 595:
            return "Schnee Brick Wall";
          case 596:
            return "Blue Light";
          case 597:
            return "Rotlicht";
          case 598:
            return "Green Light";
          case 599:
            return "blaue Gegenwart";
          case 600:
            return "grüne Gegenwart";
          case 601:
            return "Yellow Gegenwart";
          case 602:
            return "Snow Globe";
          case 603:
            return "Karotte";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (l)
        {
          case -24:
            return "Spada laser gialla";
          case -23:
            return "Spada laser bianca";
          case -22:
            return "Spada laser viola";
          case -21:
            return "Spada laser verde";
          case -20:
            return "Spada laser rossa";
          case -19:
            return "Spada laser blu";
          case -18:
            return "Arco di rame";
          case -17:
            return "Martello di rame";
          case -16:
            return "Ascia di rame";
          case -15:
            return "Spada corta di rame";
          case -14:
            return "Spadone di rame";
          case -13:
            return "Piccone di rame";
          case -12:
            return "Arco d'argento";
          case -11:
            return "Martello d'argento";
          case -10:
            return "Ascia d'argento";
          case -9:
            return "Spada corta d'argento";
          case -8:
            return "Spadone d'argento";
          case -7:
            return "Piccone d'argento";
          case -6:
            return "Arco d'oro";
          case -5:
            return "Martello d'oro";
          case -4:
            return "Ascia d'oro";
          case -3:
            return "Spada corta d'oro";
          case -2:
            return "Spadone d'oro";
          case -1:
            return "Piccone d'oro";
          case 1:
            return "Piccone di ferro";
          case 2:
            return "Blocco di terra";
          case 3:
            return "Blocco di pietra";
          case 4:
            return "Spadone di ferro";
          case 5:
            return "Fungo";
          case 6:
            return "Spada corta di ferro";
          case 7:
            return "Martello di ferro";
          case 8:
            return "Fiaccola";
          case 9:
            return "Legno";
          case 10:
            return "Ascia di ferro";
          case 11:
            return "Minerale di ferro";
          case 12:
            return "Minerale di rame";
          case 13:
            return "Minerale d'oro";
          case 14:
            return "Minerale d'argento";
          case 15:
            return "Orologio di rame";
          case 16:
            return "Orologio d'argento";
          case 17:
            return "Orologio d'oro";
          case 18:
            return "Misuratore di profondità";
          case 19:
            return "Sbarra d'oro";
          case 20:
            return "Sbarra di rame";
          case 21:
            return "Sbarra d'argento";
          case 22:
            return "Sbarra di ferro";
          case 23:
            return "Gel";
          case 24:
            return "Spada di legno";
          case 25:
            return "Porta di legno";
          case 26:
            return "Muro di pietra";
          case 27:
            return "Ghianda";
          case 28:
            return "Pozione curativa inferiore";
          case 29:
            return "Cristallo di vita";
          case 30:
            return "Muro di terra";
          case 31:
            return "Bottiglia";
          case 32:
            return "Tavolo di legno";
          case 33:
            return "Forno";
          case 34:
            return "Sedia di legno";
          case 35:
            return "Incudine di ferro";
          case 36:
            return "Banco di lavoro";
          case 37:
            return "Occhiali protettivi";
          case 38:
            return "Lenti";
          case 39:
            return "Arco di legno";
          case 40:
            return "Freccia di legno";
          case 41:
            return "Freccia infuocata";
          case 42:
            return "Shuriken";
          case 43:
            return "Occhio diffidente";
          case 44:
            return "Arco demoniaco";
          case 45:
            return "Ascia da guerra della notte";
          case 46:
            return "Flagello di luce";
          case 47:
            return "Freccia empia";
          case 48:
            return "Cassa";
          case 49:
            return "Benda di rigenerazione";
          case 50:
            return "Specchio magico";
          case 51:
            return "Freccia del giullare";
          case 52:
            return "Statua dell'angelo";
          case 53:
            return "Nuvola in bottiglia";
          case 54:
            return "Stivali di Ermes";
          case 55:
            return "Boomerang incantato";
          case 56:
            return "Minerale demoniaco";
          case 57:
            return "Sbarra demoniaca";
          case 58:
            return "Cuore";
          case 59:
            return "Semi distrutti";
          case 60:
            return "Fungo disgustoso";
          case 61:
            return "Blocco pietra d'ebano";
          case 62:
            return "Semi d'erba";
          case 63:
            return "Girasole";
          case 64:
            return "Spina vile";
          case 65:
            return "Furia stellare";
          case 66:
            return "Polvere purificatrice";
          case 67:
            return "Polvere disgustosa";
          case 68:
            return "Ceppo marcio";
          case 69:
            return "Dente di verme";
          case 70:
            return "Esca di verme";
          case 71:
            return "Moneta di rame";
          case 72:
            return "Moneta d'argento";
          case 73:
            return "Moneta d'oro";
          case 74:
            return "Moneta di platino";
          case 75:
            return "Stella cadente";
          case 76:
            return "Gambali di rame";
          case 77:
            return "Gambali di ferro";
          case 78:
            return "Gambali d'argento";
          case 79:
            return "Gambali d'oro";
          case 80:
            return "Maglia metallica di rame";
          case 81:
            return "Maglia metallica di ferro";
          case 82:
            return "Maglia metallica d'argento";
          case 83:
            return "Maglia metallica d'oro";
          case 84:
            return "Rampino";
          case 85:
            return "Catena di ferro";
          case 86:
            return "Scaglia d'ombra";
          case 87:
            return "Salvadanaio";
          case 88:
            return "Casco da minatore";
          case 89:
            return "Casco di rame";
          case 90:
            return "Casco di ferro";
          case 91:
            return "Casco d'argento";
          case 92:
            return "Casco d'oro";
          case 93:
            return "Muro di legno";
          case 94:
            return "Piattaforma di legno";
          case 95:
            return "Pistola a pietra focaia";
          case 96:
            return "Moschetto";
          case 97:
            return "Palla di moschetto";
          case 98:
            return "Minishark";
          case 99:
            return "Arco di ferro";
          case 100:
            return "Gambali ombra";
          case 101:
            return "Armatura a scaglie ombra";
          case 102:
            return "Casco ombra";
          case 103:
            return "Piccone dell'incubo";
          case 104:
            return "Il Distruttore";
          case 105:
            return "Candela";
          case 106:
            return "Lampadario di rame";
          case 107:
            return "Lampadario d'argento";
          case 108:
            return "Lampadario d'oro";
          case 109:
            return "Cristallo mana";
          case 110:
            return "Pozione mana inferiore";
          case 111:
            return "Benda della forza stellare";
          case 112:
            return "Fiore di fuoco";
          case 113:
            return "Missile magico";
          case 114:
            return "Bastone di terra";
          case 115:
            return "Orbita di luce";
          case 116:
            return "Meteorite";
          case 117:
            return "Sbarra di meteorite";
          case 118:
            return "Uncino";
          case 119:
            return "Flamarang";
          case 120:
            return "Furia fusa";
          case 121:
            return "Spadone di fuoco";
          case 122:
            return "Piccone fuso";
          case 123:
            return "Casco meteorite";
          case 124:
            return "Tunica di meteorite";
          case 125:
            return "Meteora pantaloni";
          case 126:
            return "Acqua imbottigliata";
          case (int) sbyte.MaxValue:
            return "Spazio pistola";
          case 128:
            return "Stivali razzo";
          case 129:
            return "Mattone grigio";
          case 130:
            return "Muro grigio";
          case 131:
            return "Mattone rosso";
          case 132:
            return "Muro rosso";
          case 133:
            return "Blocco d'argilla";
          case 134:
            return "Mattone blu";
          case 135:
            return "Muro blu";
          case 136:
            return "Lanterna con catena";
          case 137:
            return "Mattone verde";
          case 138:
            return "Muro verde";
          case 139:
            return "Mattone rosa";
          case 140:
            return "Muro rosa";
          case 141:
            return "Mattone dorato";
          case 142:
            return "Muro dorato";
          case 143:
            return "Mattone argentato";
          case 144:
            return "Muro argentato";
          case 145:
            return "Mattone di rame";
          case 146:
            return "Muro di rame";
          case 147:
            return "Spina";
          case 148:
            return "Candela d'acqua";
          case 149:
            return "Libro";
          case 150:
            return "Ragnatela";
          case 151:
            return "Casco funebre";
          case 152:
            return "Pettorale funebre";
          case 153:
            return "Gambali funebri";
          case 154:
            return "Osso";
          case 155:
            return "Muramasa";
          case 156:
            return "Scudo di cobalto";
          case 157:
            return "Scettro d'acqua";
          case 158:
            return "Ferro di cavallo fortunato";
          case 159:
            return "Palloncino rosso splendente";
          case 160:
            return "Arpione";
          case 161:
            return "Palla chiodata";
          case 162:
            return "Palla del dolore";
          case 163:
            return "Luna blu";
          case 164:
            return "Pistola";
          case 165:
            return "Dardo d'acqua";
          case 166:
            return "Bomba";
          case 167:
            return "Dinamite";
          case 168:
            return "Granata";
          case 169:
            return "Blocco di sabbia";
          case 170:
            return "Vetro";
          case 171:
            return "Cartello";
          case 172:
            return "Blocco di cenere";
          case 173:
            return "Ossidiana";
          case 174:
            return "Pietra infernale";
          case 175:
            return "Sbarra di pietra infernale";
          case 176:
            return "Blocco di fango";
          case 177:
            return "Zaffiro";
          case 178:
            return "Rubino";
          case 179:
            return "Smeraldo";
          case 180:
            return "Topazio";
          case 181:
            return "Ametista";
          case 182:
            return "Diamante";
          case 183:
            return "Fungo luminoso";
          case 184:
            return "Stella";
          case 185:
            return "Frusta di edera";
          case 186:
            return "Canna per la respirazione";
          case 187:
            return "Pinna";
          case 188:
            return "Pozione curativa";
          case 189:
            return "Pozione mana";
          case 190:
            return "Spada di erba";
          case 191:
            return "Artiglio di Chakram";
          case 192:
            return "Mattone di ossidiana";
          case 193:
            return "Teschio di ossidiana";
          case 194:
            return "Semi di fungo";
          case 195:
            return "Semi dell'erba della giungla";
          case 196:
            return "Martello di legno";
          case 197:
            return "Cannone stellare";
          case 198:
            return "Spada laser blu";
          case 199:
            return "Spada laser rossa";
          case 200:
            return "Spada laser verde";
          case 201:
            return "Spada laser viola";
          case 202:
            return "Spada laser bianca";
          case 203:
            return "Spada laser gialla";
          case 204:
            return "Maglio di meteorite";
          case 205:
            return "Secchio vuoto";
          case 206:
            return "Secchio d'acqua";
          case 207:
            return "Secchio di lava";
          case 208:
            return "Rosa della giungla";
          case 209:
            return "Artiglio";
          case 210:
            return "Vite";
          case 211:
            return "Artigli bestiali";
          case 212:
            return "Cavigliera del vento";
          case 213:
            return "Bastone della ricrescita";
          case 214:
            return "Mattone di pietra infernale";
          case 215:
            return "Cuscino rumoroso";
          case 216:
            return "Grillo";
          case 217:
            return "Maglio fuso";
          case 218:
            return "Lanciatore di fiamma";
          case 219:
            return "Blaster della fenice";
          case 220:
            return "Furia del sole";
          case 221:
            return "Creazione degli inferi";
          case 222:
            return "Vaso di argilla";
          case 223:
            return "Dono della natura";
          case 224:
            return "Letto";
          case 225:
            return "Seta";
          case 226:
            return "Pozione di ripristino inferiore";
          case 227:
            return "Pozione di ripristino";
          case 228:
            return "Cappello della giungla";
          case 229:
            return "Camicia della giungla";
          case 230:
            return "Pantaloni della giungla";
          case 231:
            return "Casco fuso";
          case 232:
            return "Pettorale fuso";
          case 233:
            return "Gambali fusi";
          case 234:
            return "Sparo di meteorite";
          case 235:
            return "Bomba appiccicosa";
          case 236:
            return "Lenti nere";
          case 237:
            return "Occhiali da sole";
          case 238:
            return "Cappello dello stregone";
          case 239:
            return "Cilindro";
          case 240:
            return "Camicia da smoking";
          case 241:
            return "Pantaloni smoking";
          case 242:
            return "Cappello estivo";
          case 243:
            return "Cappuccio da coniglio";
          case 244:
            return "Cappello da idraulico";
          case 245:
            return "Camicia da idraulico";
          case 246:
            return "Pantaloni da idraulico";
          case 247:
            return "Cappello da eroe";
          case 248:
            return "Camicia da eroe";
          case 249:
            return "Pantaloni da eroe";
          case 250:
            return "Boccia dei pesci rossi";
          case 251:
            return "Cappello da archeologo";
          case 252:
            return "Giacca da archeologo";
          case 253:
            return "Pantaloni da archeologo";
          case 254:
            return "Tintura nera";
          case (int) byte.MaxValue:
            return "Tintura verde";
          case 256:
            return "Cappuccio ninja";
          case 257:
            return "Camicia ninja";
          case 258:
            return "Pantaloni ninja";
          case 259:
            return "Pelle";
          case 260:
            return "Cappello rosso";
          case 261:
            return "Pesce rosso";
          case 262:
            return "Mantello";
          case 263:
            return "Cappello da robot";
          case 264:
            return "Corona d'oro";
          case 265:
            return "Freccia di fuoco infernale";
          case 266:
            return "Pistola di sabbia";
          case 267:
            return "Bambola voodoo guida";
          case 268:
            return "Casco da palombaro";
          case 269:
            return "Camicia comune";
          case 270:
            return "Pantaloni comuni";
          case 271:
            return "Parrucca comune";
          case 272:
            return "Falce demoniaca";
          case 273:
            return "Confine della notte";
          case 274:
            return "Lancia oscura";
          case 275:
            return "Corallo";
          case 276:
            return "Cactus";
          case 277:
            return "Tridente";
          case 278:
            return "Proiettile d'argento";
          case 279:
            return "Coltello da lancio";
          case 280:
            return "Lancia";
          case 281:
            return "Cerbottana";
          case 282:
            return "Bastone luminoso";
          case 283:
            return "Seme";
          case 284:
            return "Boomerang di legno";
          case 285:
            return "Aghetto";
          case 286:
            return "Bastone luminoso appiccicoso";
          case 287:
            return "Coltello avvelenato";
          case 288:
            return "Pozione pelle di ossidiana";
          case 289:
            return "Pozione rigeneratrice";
          case 290:
            return "Pozione della rapidità";
          case 291:
            return "Pozione branchie";
          case 292:
            return "Pozione pelle di ferro";
          case 293:
            return "Pozione rigenerazione mana";
          case 294:
            return "Pozione potenza magica";
          case 295:
            return "Pozione caduta dolce";
          case 296:
            return "Pozione speleologo";
          case 297:
            return "Pozione invisibilità";
          case 298:
            return "Pozione splendore";
          case 299:
            return "Pozione civetta";
          case 300:
            return "Pozione battaglia";
          case 301:
            return "Pozione spine";
          case 302:
            return "Pozione per camminare sull'acqua";
          case 303:
            return "Pozione arciere";
          case 304:
            return "Pozione cacciatore";
          case 305:
            return "Pozione gravità";
          case 306:
            return "Cassa d'oro";
          case 307:
            return "Semi Fiordigiorno";
          case 308:
            return "Semi Splendiluna";
          case 309:
            return "Semi Lampeggiaradice";
          case 310:
            return "Semi Erbamorte";
          case 311:
            return "Semi Acquafoglia";
          case 312:
            return "Semi Fiordifuoco";
          case 313:
            return "Fiordigiorno";
          case 314:
            return "Splendiluna";
          case 315:
            return "Lampeggiaradice";
          case 316:
            return "Erbamorte";
          case 317:
            return "Acquafoglia";
          case 318:
            return "Fiordifuoco";
          case 319:
            return "Pinna di squalo";
          case 320:
            return "Piuma";
          case 321:
            return "Lapide";
          case 322:
            return "Maschera sosia";
          case 323:
            return "Mandibola di formicaleone";
          case 324:
            return "Parti di pistola illegale";
          case 325:
            return "Camicia da medico";
          case 326:
            return "Pantaloni da medico";
          case 327:
            return "Chiave dorata";
          case 328:
            return "Cassa ombra";
          case 329:
            return "Chiave ombra";
          case 330:
            return "Muro di ossidiana";
          case 331:
            return "Spore della giungla";
          case 332:
            return "Telaio";
          case 333:
            return "Pianoforte";
          case 334:
            return "Cassettone";
          case 335:
            return "Panca";
          case 336:
            return "Vasca da bagno";
          case 337:
            return "Stendardo rosso";
          case 338:
            return "Stendardo verde";
          case 339:
            return "Stendardo blu";
          case 340:
            return "Stendardo giallo";
          case 341:
            return "Lampione";
          case 342:
            return "Torcia tiki";
          case 343:
            return "Barile";
          case 344:
            return "Lanterna cinese";
          case 345:
            return "Pentola";
          case 346:
            return "Caveau";
          case 347:
            return "Lanterna-teschio";
          case 348:
            return "Bidone";
          case 349:
            return "Candelabro";
          case 350:
            return "Vaso rosa";
          case 351:
            return "Boccale";
          case 352:
            return "Barilotto";
          case 353:
            return "Birra";
          case 354:
            return "Scaffale";
          case 355:
            return "Trono";
          case 356:
            return "Ciotola";
          case 357:
            return "Ciotola di zuppa";
          case 358:
            return "Toilette";
          case 359:
            return "Pendola";
          case 360:
            return "Statua armatura";
          case 361:
            return "Insegna di battaglia dei goblin";
          case 362:
            return "Abito a brandelli";
          case 363:
            return "Segheria";
          case 364:
            return "Minerale cobalto";
          case 365:
            return "Minerale mitrilio";
          case 366:
            return "Minerale adamantio";
          case 367:
            return "Martellone";
          case 368:
            return "Excalibur";
          case 369:
            return "Semi consacrati";
          case 370:
            return "Blocco sabbia d'ebano";
          case 371:
            return "Cappello di cobalto";
          case 372:
            return "Casco di cobalto";
          case 373:
            return "Maschera di cobalto";
          case 374:
            return "Corrazza di cobalto";
          case 375:
            return "Calzamaglia di cobalto";
          case 376:
            return "Cappuccio di mitrilio";
          case 377:
            return "Casco di mitrilio";
          case 378:
            return "Cappello di mitrilio";
          case 379:
            return "Maglia metallica di mitrilio";
          case 380:
            return "Gambali di mitrilio";
          case 381:
            return "Sbarra di cobalto";
          case 382:
            return "Sbarra di mitrilio";
          case 383:
            return "Motosega di cobalto";
          case 384:
            return "Motosega di mitrilio";
          case 385:
            return "Perforatrice di cobalto";
          case 386:
            return "Perforatrice di mitrilio";
          case 387:
            return "Motosega di adamantio";
          case 388:
            return "Perforatrice di adamantio";
          case 389:
            return "Frustona";
          case 390:
            return "Alabarda di mitrilio";
          case 391:
            return "Sbarra di adamantio";
          case 392:
            return "Muro di vetro";
          case 393:
            return "Bussola";
          case 394:
            return "Muta da sub";
          case 395:
            return "GPS";
          case 396:
            return "Ferro di cavallo di ossidiana";
          case 397:
            return "Scudo di ossidiana";
          case 398:
            return "Laboratorio dell'inventore";
          case 399:
            return "Nuvola in un palloncino";
          case 400:
            return "Copricapo di adamantio";
          case 401:
            return "Casco di adamantio";
          case 402:
            return "Maschera di adamantio";
          case 403:
            return "Corrazza di adamantio";
          case 404:
            return "Calzamaglia di adamantio";
          case 405:
            return "Stivali da fantasma";
          case 406:
            return "Alabarda di adamantio";
          case 407:
            return "Cintura porta attrezzi";
          case 408:
            return "Blocco sabbiaperla";
          case 409:
            return "Blocco pietraperla";
          case 410:
            return "Camicia da minatore";
          case 411:
            return "Pantaloni da minatore";
          case 412:
            return "Mattone pietraperla";
          case 413:
            return "Mattone iridescente";
          case 414:
            return "Blocco pietrafango";
          case 415:
            return "Mattone cobalto";
          case 416:
            return "Mattone mitrilio";
          case 417:
            return "Muro di pietraperla";
          case 418:
            return "Muro di mattoni iridescenti";
          case 419:
            return "Muro di pietrafango";
          case 420:
            return "Muro di mattoni di cobalto";
          case 421:
            return "Muro di mattoni di mitrilio";
          case 422:
            return "Acquasanta";
          case 423:
            return "Acqua profana";
          case 424:
            return "Blocco insabbiato";
          case 425:
            return "Campana della fata";
          case 426:
            return "Lama del distruttore";
          case 427:
            return "Torcia blu";
          case 428:
            return "Torcia rossa";
          case 429:
            return "Torcia verde";
          case 430:
            return "Torcia viola";
          case 431:
            return "Torcia bianca";
          case 432:
            return "Torcia gialla";
          case 433:
            return "Torcia demoniaca";
          case 434:
            return "Fucile d'assalto automatico";
          case 435:
            return "Balestra automatica di cobalto";
          case 436:
            return "Balestra automatica di mitrilio";
          case 437:
            return "Gancio doppio";
          case 438:
            return "Statua stella";
          case 439:
            return "Statua spada";
          case 440:
            return "Statua slime";
          case 441:
            return "Statua goblin";
          case 442:
            return "Statua scudo";
          case 443:
            return "Statua pipistrello";
          case 444:
            return "Statua pesce";
          case 445:
            return "Statua coniglio";
          case 446:
            return "Statua scheletro";
          case 447:
            return "Statua mietitore";
          case 448:
            return "Statua donna";
          case 449:
            return "Statua diavoletto";
          case 450:
            return "Statua gargoyle";
          case 451:
            return "Statua tenebre";
          case 452:
            return "Statua calabrone";
          case 453:
            return "Statua bomba";
          case 454:
            return "Statua granchio";
          case 455:
            return "Statua martello";
          case 456:
            return "Statua pozione";
          case 457:
            return "Statua arpione";
          case 458:
            return "Statua croce";
          case 459:
            return "Statua medusa";
          case 460:
            return "Statua arco";
          case 461:
            return "Statua boomerang";
          case 462:
            return "Statua stivali";
          case 463:
            return "Statua cassa";
          case 464:
            return "Statua Uucello";
          case 465:
            return "Statua ascia";
          case 466:
            return "Statua distruzione";
          case 467:
            return "Statua albero";
          case 468:
            return "Staua incudine";
          case 469:
            return "Statua piccone";
          case 470:
            return "Statua fungo";
          case 471:
            return "Statua bulbo oculare";
          case 472:
            return "Statua colonna";
          case 473:
            return "Statua cuore";
          case 474:
            return "Statua pentola";
          case 475:
            return "Statua girasole";
          case 476:
            return "Statua re";
          case 477:
            return "Statua regina";
          case 478:
            return "Statua piranha";
          case 479:
            return "Muro impalcato";
          case 480:
            return "Trave di legno";
          case 481:
            return "Mietitore di adamantio";
          case 482:
            return "Spada di adamantio";
          case 483:
            return "Spada di cobalto";
          case 484:
            return "Spada di mitrilio";
          case 485:
            return "Amuleto della luna";
          case 486:
            return "Righello";
          case 487:
            return "Sfera di cristallo";
          case 488:
            return "Palla disco";
          case 489:
            return "Emblema dell'incantatore";
          case 490:
            return "Emblema del guerriero";
          case 491:
            return "Emblema del guardiaboschi";
          case 492:
            return "Ali del demone";
          case 493:
            return "Ali dell'angelo";
          case 494:
            return "Arpa magica";
          case 495:
            return "Bastone dell'arcobaleno";
          case 496:
            return "Bastone di ghiaccio";
          case 497:
            return "Conchiglia di Nettuno";
          case 498:
            return "Manichino";
          case 499:
            return "Pozione curativa superiore";
          case 500:
            return "Pozione mana superiore";
          case 501:
            return "Polvere di fata";
          case 502:
            return "Frammento di cristallo";
          case 503:
            return "Cappello da clown";
          case 504:
            return "Camicia da clown";
          case 505:
            return "Pantaloni da clown";
          case 506:
            return "Lanciafiamme";
          case 507:
            return "Campana";
          case 508:
            return "Arpa";
          case 509:
            return "Chiave inglese";
          case 510:
            return "Tagliacavi";
          case 511:
            return "Blocco di pietra attivo";
          case 512:
            return "Blocco di pietra non attivo";
          case 513:
            return "Leva";
          case 514:
            return "Fucile laser";
          case 515:
            return "Proiettile di cristallo";
          case 516:
            return "Freccia sacra";
          case 517:
            return "Pugnale magico";
          case 518:
            return "Tempesta di cristallo";
          case 519:
            return "Fiamme maledette";
          case 520:
            return "Anima della luce";
          case 521:
            return "Anima della notte";
          case 522:
            return "Fiamma maledetta";
          case 523:
            return "Torcia maledetta";
          case 524:
            return "Fornace di adamantio";
          case 525:
            return "Incudine di mitrilio";
          case 526:
            return "Corno di unicorno";
          case 527:
            return "Frammento oscuro";
          case 528:
            return "Frammento di luce";
          case 529:
            return "Piastra a pressione rossa";
          case 530:
            return "Cavo";
          case 531:
            return "Tomo incantato";
          case 532:
            return "Mantello stellato";
          case 533:
            return "Megashark";
          case 534:
            return "Fucile";
          case 535:
            return "Pietra filosofale";
          case 536:
            return "Guanto del Titano";
          case 537:
            return "Naginata di cobalto";
          case 538:
            return "Interruttore";
          case 539:
            return "Trappola dardi";
          case 540:
            return "Masso";
          case 541:
            return "Piastra a pressione verde";
          case 542:
            return "Piastra a pressione grigia";
          case 543:
            return "Piastra a pressione marrone";
          case 544:
            return "Occhio meccanico";
          case 545:
            return "Freccia maledetta";
          case 546:
            return "Proiettile maledetto";
          case 547:
            return "Anima del terrore";
          case 548:
            return "Anima del potere";
          case 549:
            return "Anima della visione";
          case 550:
            return "Gungnir";
          case 551:
            return "Armatura sacra";
          case 552:
            return "Gambali sacri";
          case 553:
            return "Casco sacro";
          case 554:
            return "Collana con croce";
          case 555:
            return "Fiore di mana";
          case 556:
            return "Verme meccanico";
          case 557:
            return "Teschio meccanico";
          case 558:
            return "Copricapo sacro";
          case 559:
            return "Maschera sacra";
          case 560:
            return "Corona slime";
          case 561:
            return "Disco di luce";
          case 562:
            return "Musica (Giornata mondiale)";
          case 563:
            return "Musica (Mistero)";
          case 564:
            return "Musica (Notte)";
          case 565:
            return "Musica (Titolo)";
          case 566:
            return "Musica (Sottosuolo)";
          case 567:
            return "Musica (Boss 1)";
          case 568:
            return "Musica (Giungla)";
          case 569:
            return "Musica (Distruzione)";
          case 570:
            return "Musica (Distruzione sotterranea)";
          case 571:
            return "Musica (Il sacro)";
          case 572:
            return "Musica (Boss 2)";
          case 573:
            return "Musica (Sacro sotterraneo)";
          case 574:
            return "Musica (Boss 3)";
          case 575:
            return "Anima del volo";
          case 576:
            return "Musica";
          case 577:
            return "Mattone demoniaco";
          case 578:
            return "Balestra automatica sacra";
          case 579:
            return "Perforascia";
          case 580:
            return "Esplosivi";
          case 581:
            return "Pompa interna";
          case 582:
            return "Pompa esterna";
          case 583:
            return "Timer 2 secondo";
          case 584:
            return "Timer 3 secondi";
          case 585:
            return "Timer 5 secondi";
          case 586:
            return "Candy Cane Block";
          case 587:
            return "Candy Cane parete";
          case 588:
            return "Cappello da Babbo Natale";
          case 589:
            return "S. Shirt";
          case 590:
            return "Pantaloni di Santa";
          case 591:
            return "Blocco verde Candy Cane";
          case 592:
            return "Green Candy Cane Wall";
          case 593:
            return "Blocca neve";
          case 594:
            return "neve Brick";
          case 595:
            return "Neve Muro di mattoni";
          case 596:
            return "azzurro";
          case 597:
            return "Red Light";
          case 598:
            return "verde chiaro";
          case 599:
            return "Presente blu";
          case 600:
            return "Presente verde";
          case 601:
            return "Presente giallo";
          case 602:
            return "Snow Globe";
          case 603:
            return "Carota";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (l)
        {
          case -24:
            return "Sabre laser jaune";
          case -23:
            return "Sabre laser blanc";
          case -22:
            return "Sabre laser violet";
          case -21:
            return "Sabre laser vert";
          case -20:
            return "Sabre laser rouge";
          case -19:
            return "Sabre laser bleu";
          case -18:
            return "Arc en cuivre";
          case -17:
            return "Marteau en cuivre";
          case -16:
            return "Hache en cuivre";
          case -15:
            return "Épée courte en cuivre";
          case -14:
            return "Épée longue en cuivre";
          case -13:
            return "Pioche en cuivre";
          case -12:
            return "Arc en argent";
          case -11:
            return "Marteau en argent";
          case -10:
            return "Hache en argent";
          case -9:
            return "Épée courte en argent";
          case -8:
            return "Épée longue en argent";
          case -7:
            return "Pioche en argent";
          case -6:
            return "Arc en or";
          case -5:
            return "Marteau en or";
          case -4:
            return "Hache en or";
          case -3:
            return "Épée courte en or";
          case -2:
            return "Épée longue en or";
          case -1:
            return "Pioche en or";
          case 1:
            return "Pioche en fer";
          case 2:
            return "Bloc de terre";
          case 3:
            return "Bloc de pierre";
          case 4:
            return "Épée longue en fer";
          case 5:
            return "Champignon";
          case 6:
            return "Épée courte en fer";
          case 7:
            return "Marteau en fer";
          case 8:
            return "Torche";
          case 9:
            return "Bois";
          case 10:
            return "Hache en fer";
          case 11:
            return "Minerai de fer";
          case 12:
            return "Minerai de cuivre";
          case 13:
            return "Minerai d'or";
          case 14:
            return "Minerai d'argent";
          case 15:
            return "Montre en cuivre";
          case 16:
            return "Montre en argent";
          case 17:
            return "Montre en or";
          case 18:
            return "Altimètre";
          case 19:
            return "Lingot d'or";
          case 20:
            return "Lingot de cuivre";
          case 21:
            return "Lingot d'argent";
          case 22:
            return "Lingot de fer";
          case 23:
            return "Gel";
          case 24:
            return "Épée en bois";
          case 25:
            return "Porte en bois";
          case 26:
            return "Mur en pierre";
          case 27:
            return "Gland";
          case 28:
            return "Faible potion de soin";
          case 29:
            return "Cristal de vie";
          case 30:
            return "Mur en terre";
          case 31:
            return "Bouteille";
          case 32:
            return "Table en bois";
          case 33:
            return "Four";
          case 34:
            return "Chaise en bois";
          case 35:
            return "Enclume";
          case 36:
            return "Établi";
          case 37:
            return "Lunettes";
          case 38:
            return "Lentille";
          case 39:
            return "Arc en bois";
          case 40:
            return "Flèche en bois";
          case 41:
            return "Flèche enflammée";
          case 42:
            return "Shuriken";
          case 43:
            return "Œil observateur suspicieux";
          case 44:
            return "Arc démoniaque";
          case 45:
            return "Hache de guerre de la nuit";
          case 46:
            return "Fléau de lumière";
          case 47:
            return "Flèche impie";
          case 48:
            return "Coffre";
          case 49:
            return "Anneau de régénération";
          case 50:
            return "Miroir magique";
          case 51:
            return "Flèche du bouffon";
          case 52:
            return "Statue d'ange";
          case 53:
            return "Nuage en bouteille";
          case 54:
            return "Bottes d'Hermès";
          case 55:
            return "Boomerang enchanté";
          case 56:
            return "Barre de démonite";
          case 57:
            return "Lingot de démonite";
          case 58:
            return "Pilier";
          case 59:
            return "Graines corrompues";
          case 60:
            return "Champignon infect";
          case 61:
            return "Bloc d'ébonite";
          case 62:
            return "Graines d'herbe";
          case 63:
            return "Tournesols";
          case 64:
            return "Vileronce";
          case 65:
            return "Furie stellaire";
          case 66:
            return "Poudre de purification";
          case 67:
            return "Poudre infecte";
          case 68:
            return "Morceau pourri";
          case 69:
            return "Dent de ver";
          case 70:
            return "Nourriture pour ver";
          case 71:
            return "Pièce de cuivre";
          case 72:
            return "Pièce d'argent";
          case 73:
            return "Pièce d'or";
          case 74:
            return "Pièce de platine";
          case 75:
            return "Étoile filante";
          case 76:
            return "Jambières en cuivre";
          case 77:
            return "Jambières en fer";
          case 78:
            return "Jambières en argent";
          case 79:
            return "Jambière en or";
          case 80:
            return "Cotte de mailles en cuivre";
          case 81:
            return "Cotte de mailles en fer";
          case 82:
            return "Cotte de mailles en argent";
          case 83:
            return "Cotte de mailles en or";
          case 84:
            return "Grappin";
          case 85:
            return "Chaîne en fer";
          case 86:
            return "Écaille sombre";
          case 87:
            return "Tirelire";
          case 88:
            return "Casque de mineur";
          case 89:
            return "Casque en cuivre";
          case 90:
            return "Casque en fer";
          case 91:
            return "Casque en argent";
          case 92:
            return "Casque en or";
          case 93:
            return "Mur en bois";
          case 94:
            return "Plateforme en bois";
          case 95:
            return "Pistolet à silex";
          case 96:
            return "Mousquet";
          case 97:
            return "Balle de mousquet";
          case 98:
            return "Minishark";
          case 99:
            return "Arc en fer";
          case 100:
            return "Jambières de l'ombre";
          case 101:
            return "Armure d'écailles de l'ombre";
          case 102:
            return "Casque de l'ombre";
          case 103:
            return "Pioche cauchemardesque";
          case 104:
            return "Le briseur";
          case 105:
            return "Bougie";
          case 106:
            return "Chandelier en cuivre";
          case 107:
            return "Chandelier en argent";
          case 108:
            return "Chandelier en or";
          case 109:
            return "Cristal de mana";
          case 110:
            return "Potion de mana inférieure";
          case 111:
            return "Anneau de pouvoir stellaire";
          case 112:
            return "Fleur de feu";
          case 113:
            return "Missile magique";
          case 114:
            return "Bâtonnet de terre";
          case 115:
            return "Orbe de lumière";
          case 116:
            return "Météorite";
          case 117:
            return "Barre de météorite";
          case 118:
            return "Crochet";
          case 119:
            return "Flamarang";
          case 120:
            return "Furie en fusion";
          case 121:
            return "Grande épée ardente";
          case 122:
            return "Pioche en fusion";
          case 123:
            return "Casque de météore";
          case 124:
            return "Costume de météore";
          case 125:
            return "Leggings de météores";
          case 126:
            return "Eau en bouteille";
          case (int) sbyte.MaxValue:
            return "Arme d'espace";
          case 128:
            return "Bottes roquettes";
          case 129:
            return "Brique grise";
          case 130:
            return "Mur en briques grises";
          case 131:
            return "Brique rouge";
          case 132:
            return "Mur de briques rouges";
          case 133:
            return "Bloc d'argile";
          case 134:
            return "Brique bleue";
          case 135:
            return "Mur en briques bleues";
          case 136:
            return "Lanterne à chaîne";
          case 137:
            return "Brique verte";
          case 138:
            return "Mur de briques vertes";
          case 139:
            return "Brique rose";
          case 140:
            return "Mur de briques roses";
          case 141:
            return "Brique dorée";
          case 142:
            return "Mur de briques dorées";
          case 143:
            return "Brique argentée";
          case 144:
            return "Mur de briques argentées";
          case 145:
            return "Brique cuivrée";
          case 146:
            return "Mur de briques cuivrées";
          case 147:
            return "Pointe";
          case 148:
            return "Bougie d'eau";
          case 149:
            return "Livre";
          case 150:
            return "Toile d'araignée";
          case 151:
            return "Casque nécro";
          case 152:
            return "Plastron nécro";
          case 153:
            return "Jambières nécro";
          case 154:
            return "Os";
          case 155:
            return "Muramasa";
          case 156:
            return "Bouclier de cobalt";
          case 157:
            return "Sceptre aquatique";
          case 158:
            return "Fer à cheval porte-bonheur";
          case 159:
            return "Ballon rouge brillant";
          case 160:
            return "Harpon";
          case 161:
            return "Balle hérissée";
          case 162:
            return "Ball O' Hurt";
          case 163:
            return "Lune bleue";
          case 164:
            return "Pistolet";
          case 165:
            return "Trait d'eau";
          case 166:
            return "Bombe";
          case 167:
            return "Dynamite";
          case 168:
            return "Grenade";
          case 169:
            return "Bloc de sable";
          case 170:
            return "Verre";
          case 171:
            return "Panneau";
          case 172:
            return "Bloc de cendre";
          case 173:
            return "Obsidienne";
          case 174:
            return "Pierre de l'enfer";
          case 175:
            return "Barre de pierre de l'enfer";
          case 176:
            return "Bloc de boue";
          case 177:
            return "Saphir";
          case 178:
            return "Rubis";
          case 179:
            return "Émeraude";
          case 180:
            return "Topaze";
          case 181:
            return "Améthyste";
          case 182:
            return "Diamant";
          case 183:
            return "Champignon lumineux";
          case 184:
            return "Étoile";
          case 185:
            return "Grappin à lianes";
          case 186:
            return "Tuba";
          case 187:
            return "Palmes";
          case 188:
            return "Potion de soins";
          case 189:
            return "Potion de mana";
          case 190:
            return "Lame de l'herbe";
          case 191:
            return "Chakram d'épines";
          case 192:
            return "Brique d'obsidienne";
          case 193:
            return "Crâne d'obsidienne";
          case 194:
            return "Graines de champignon";
          case 195:
            return "Graines de la jungle";
          case 196:
            return "Marteau en bois";
          case 197:
            return "Canon à étoiles";
          case 198:
            return "Sabre laser bleu";
          case 199:
            return "Sabre laser rouge";
          case 200:
            return "Sabre laser vert";
          case 201:
            return "Sabre laser violet";
          case 202:
            return "Sabre laser blanc";
          case 203:
            return "Sabre laser jaune";
          case 204:
            return "Martache en météorite";
          case 205:
            return "Seau vide";
          case 206:
            return "Seau d'eau";
          case 207:
            return "Seau de lave";
          case 208:
            return "Rose de la jungle";
          case 209:
            return "Dard";
          case 210:
            return "Vigne";
          case 211:
            return "Griffes sauvages";
          case 212:
            return "Bracelet du vent";
          case 213:
            return "Crosse de repousse";
          case 214:
            return "Brique de pierre de l'enfer";
          case 215:
            return "Coussin péteur";
          case 216:
            return "Manille";
          case 217:
            return "Martache en fusion";
          case 218:
            return "Mèche enflammée";
          case 219:
            return "Blaster phénix";
          case 220:
            return "Furie solaire";
          case 221:
            return "Forge infernale";
          case 222:
            return "Pot d'argile";
          case 223:
            return "Don de la nature";
          case 224:
            return "Lit";
          case 225:
            return "Soie";
          case 226:
            return "Potion de restauration inférieure";
          case 227:
            return "Potion de restauration";
          case 228:
            return "Casque de la jungle";
          case 229:
            return "Plastron de la jungle";
          case 230:
            return "Jambières de la jungle";
          case 231:
            return "Casque en fusion";
          case 232:
            return "Plastron en fusion";
          case 233:
            return "Jambières en fusion";
          case 234:
            return "Balle météore";
          case 235:
            return "Bombe collante";
          case 236:
            return "Lentille noire";
          case 237:
            return "Lunettes de soleil";
          case 238:
            return "Chapeau de magicien";
          case 239:
            return "Haut de forme";
          case 240:
            return "Veste de smoking";
          case 241:
            return "Pantalon de smoking";
          case 242:
            return "Chapeau d'été";
          case 243:
            return "Capuche de lapin";
          case 244:
            return "Casquette de plombier";
          case 245:
            return "Veste de plombier";
          case 246:
            return "Pantalon de plombier";
          case 247:
            return "Capuche de héros";
          case 248:
            return "Veste de héros";
          case 249:
            return "Pantalon de héros";
          case 250:
            return "Bocal à poissons";
          case 251:
            return "Chapeau d'archéologue";
          case 252:
            return "Veste d'archéologue";
          case 253:
            return "Pantalon d'archéologue";
          case 254:
            return "Teinture noire";
          case (int) byte.MaxValue:
            return "Teinture verte";
          case 256:
            return "Cagoule de ninja";
          case 257:
            return "Veste de ninja";
          case 258:
            return "Pantalon de ninja";
          case 259:
            return "Cuir";
          case 260:
            return "Chapeau rouge";
          case 261:
            return "Poisson doré";
          case 262:
            return "Robe";
          case 263:
            return "Chapeau de robot";
          case 264:
            return "Couronne d'or";
          case 265:
            return "Flèche du feu de l'enfer";
          case 266:
            return "Canon à sable";
          case 267:
            return "Poupée vaudou du guide";
          case 268:
            return "Casque de plongée";
          case 269:
            return "Chemise familière";
          case 270:
            return "Pantalon familier";
          case 271:
            return "Perruque familière";
          case 272:
            return "Faux de démon";
          case 273:
            return "Fil des Ténèbres";
          case 274:
            return "Lance sombre";
          case 275:
            return "Corail";
          case 276:
            return "Cactus";
          case 277:
            return "Trident";
          case 278:
            return "Balle d'argent";
          case 279:
            return "Couteau de lancer";
          case 280:
            return "Lance";
          case 281:
            return "Sarbacane";
          case 282:
            return "Bâton lumineux";
          case 283:
            return "Graine";
          case 284:
            return "Boomerang en bois";
          case 285:
            return "Embout de lacet";
          case 286:
            return "Bâton lumineux collant";
          case 287:
            return "Couteau empoisonné";
          case 288:
            return "Potion de peau d'obsidienne";
          case 289:
            return "Potion de régénération";
          case 290:
            return "Potion de rapidité";
          case 291:
            return "Potion de branchies";
          case 292:
            return "Potion de peau de fer";
          case 293:
            return "Potion de régénération de mana";
          case 294:
            return "Potion de pouvoir magique";
          case 295:
            return "Potion de poids plume";
          case 296:
            return "Potion de spéléologue";
          case 297:
            return "Potion d'invisibilité";
          case 298:
            return "Potion de brillance";
          case 299:
            return "Potion de vision nocturne";
          case 300:
            return "Potion de bataille";
          case 301:
            return "Potion d'épines";
          case 302:
            return "Potion de marche sur l'eau";
          case 303:
            return "Potion de tir à l'arc";
          case 304:
            return "Potion du chasseur";
          case 305:
            return "Potion de gravité";
          case 306:
            return "Coffre d'or";
          case 307:
            return "Graines de floraison du jour";
          case 308:
            return "Graines de lueur de lune";
          case 309:
            return "Graines de racine clignotante";
          case 310:
            return "Graines de mauvaise herbe morte";
          case 311:
            return "Graines de feuilles de l'eau";
          case 312:
            return "Graines de fleur de feu";
          case 313:
            return "Floraison du jour";
          case 314:
            return "Lueur de lune";
          case 315:
            return "Racine clignotante";
          case 316:
            return "Mauvaise herbe morte";
          case 317:
            return "Feuille de l'eau";
          case 318:
            return "Fleur de feu";
          case 319:
            return "Aileron de requin";
          case 320:
            return "Plume";
          case 321:
            return "Pierre tombale";
          case 322:
            return "Masque du mime";
          case 323:
            return "Mandibule de fourmilion";
          case 324:
            return "Pièces détachées";
          case 325:
            return "Veste du docteur";
          case 326:
            return "Pantalon du docteur";
          case 327:
            return "Clé dorée";
          case 328:
            return "Coffre sombre";
          case 329:
            return "Clé sombre";
          case 330:
            return "Mur de briques d'obsidienne";
          case 331:
            return "Spores de la jungle";
          case 332:
            return "Métier à tisser";
          case 333:
            return "Piano";
          case 334:
            return "Commode";
          case 335:
            return "Banc";
          case 336:
            return "Baignoire";
          case 337:
            return "Bannière rouge";
          case 338:
            return "Bannière verte";
          case 339:
            return "Bannière bleue";
          case 340:
            return "Bannière jaune";
          case 341:
            return "Lampadaire";
          case 342:
            return "Torche de tiki";
          case 343:
            return "Baril";
          case 344:
            return "Lanterne chinoise";
          case 345:
            return "Marmite";
          case 346:
            return "Coffre-fort";
          case 347:
            return "Lanterne crâne";
          case 348:
            return "Poubelle";
          case 349:
            return "Candélabre";
          case 350:
            return "Vase rose";
          case 351:
            return "Chope";
          case 352:
            return "Tonnelet";
          case 353:
            return "Bière";
          case 354:
            return "Bibliothèque";
          case 355:
            return "Trône";
          case 356:
            return "Bol";
          case 357:
            return "Bol de soupe";
          case 358:
            return "Toilettes";
          case 359:
            return "Horloge de grand-père";
          case 360:
            return "Statue d'armure";
          case 361:
            return "Étendard de bataille gobelin";
          case 362:
            return "Vêtements en lambeaux";
          case 363:
            return "Scierie";
          case 364:
            return "Minerai de cobalt";
          case 365:
            return "Minerai de mythril";
          case 366:
            return "Minerai d'adamantine";
          case 367:
            return "Pwnhammer";
          case 368:
            return "Excalibur";
          case 369:
            return "Graines sacrées";
          case 370:
            return "Bloc de sable d'ébène";
          case 371:
            return "Chapeau de cobalt";
          case 372:
            return "Casque de cobalt";
          case 373:
            return "Masque de cobalt";
          case 374:
            return "Plastron de cobalt";
          case 375:
            return "Jambières de cobalt";
          case 376:
            return "Capuche de mythril";
          case 377:
            return "Casque de mythril";
          case 378:
            return "Chapeau de mythril";
          case 379:
            return "Cotte de mailles de mythril";
          case 380:
            return "Jambières de mythril";
          case 381:
            return "Barre de cobalt";
          case 382:
            return "Barre de mythril";
          case 383:
            return "Tronçonneuse de cobalt";
          case 384:
            return "Tronçonneuse de mythril";
          case 385:
            return "Perceuse de cobalt";
          case 386:
            return "Perceuse de mythril";
          case 387:
            return "Tronçonneuse d'adamantine";
          case 388:
            return "Perceuse d'adamantine";
          case 389:
            return "Dao de Pow";
          case 390:
            return "Hallebarde de mythril";
          case 391:
            return "Barre d'amantine";
          case 392:
            return "Mur de verre";
          case 393:
            return "Boussole";
          case 394:
            return "Équipement de plongée";
          case 395:
            return "GPS";
          case 396:
            return "Fer à cheval d'obsidienne";
          case 397:
            return "Bouclier d'obsidienne";
          case 398:
            return "Atelier du bricoleur";
          case 399:
            return "Nuage dans un ballon";
          case 400:
            return "Coiffe d'adamantine";
          case 401:
            return "Casque d'adamantine";
          case 402:
            return "Masque d'adamantine";
          case 403:
            return "Plastron d'adamantine";
          case 404:
            return "Jambières en adamantine";
          case 405:
            return "Bottes spectrales";
          case 406:
            return "Glaive d'adamantine";
          case 407:
            return "Ceinture d'outils";
          case 408:
            return "Bloc de sable de perle";
          case 409:
            return "Bloc de pierre de perle";
          case 410:
            return "Veste de mineur";
          case 411:
            return "Pantalon de mineur";
          case 412:
            return "Brique de pierre de perle";
          case 413:
            return "Brique iridescente";
          case 414:
            return "Bloc de pierre de terre";
          case 415:
            return "Brique de cobalt";
          case 416:
            return "Brique de mythril";
          case 417:
            return "Mur de briques de pierre de perle";
          case 418:
            return "Mur de briques iridescentes";
          case 419:
            return "Mur de briques de pierre de terre";
          case 420:
            return "Mur de briques de cobalt";
          case 421:
            return "Mur de briques de mythril";
          case 422:
            return "Eau bénite";
          case 423:
            return "Eau impie";
          case 424:
            return "Bloc de limon";
          case 425:
            return "Clochette de fée";
          case 426:
            return "Lame du briseur";
          case 427:
            return "Torche bleue";
          case 428:
            return "Torche rouge";
          case 429:
            return "Torche verte";
          case 430:
            return "Torche violette";
          case 431:
            return "Torche blanche";
          case 432:
            return "Torche jaune";
          case 433:
            return "Torche du démon";
          case 434:
            return "Fusil d'assaut mécanique";
          case 435:
            return "Arbalète en cobalt";
          case 436:
            return "Arbalète en mythril";
          case 437:
            return "Crochet Double";
          case 438:
            return "Statue d'étoile";
          case 439:
            return "Statue d'épée";
          case 440:
            return "Statue de slime";
          case 441:
            return "Statue de gobelin";
          case 442:
            return "Statue de bouclier";
          case 443:
            return "Statue de chauve-souris";
          case 444:
            return "Statue de poisson";
          case 445:
            return "Statue de lapin";
          case 446:
            return "Statue de squelette";
          case 447:
            return "Statue de faucheur";
          case 448:
            return "Statue de femme";
          case 449:
            return "Statue de diablotin";
          case 450:
            return "Statue de gargouille";
          case 451:
            return "Statue de morosité";
          case 452:
            return "Statue de frelon";
          case 453:
            return "Statue de bombe";
          case 454:
            return "Statue de crabe";
          case 455:
            return "Statue de marteau";
          case 456:
            return "Statue de potion";
          case 457:
            return "Statue de lance";
          case 458:
            return "Statue de croix";
          case 459:
            return "Statue de méduse";
          case 460:
            return "Statue d'arc";
          case 461:
            return "Statue de boomerang";
          case 462:
            return "Statue de botte";
          case 463:
            return "Statue de coffre";
          case 464:
            return "Statue d'oiseau";
          case 465:
            return "Statue de hache";
          case 466:
            return "Statue corrompue";
          case 467:
            return "Statue d'arbre";
          case 468:
            return "Statue d'enclume";
          case 469:
            return "Statue de pioche";
          case 470:
            return "Statue de champignon";
          case 471:
            return "Statue d'œil";
          case 472:
            return "Statue de pilier";
          case 473:
            return "Statue de cœur";
          case 474:
            return "Statue de pot";
          case 475:
            return "Statue de tournesol";
          case 476:
            return "Statue de roi";
          case 477:
            return "Statue de reine";
          case 478:
            return "Statue de piranha";
          case 479:
            return "Mur de planches";
          case 480:
            return "Poutre de bois";
          case 481:
            return "Arbalète d'adamantine";
          case 482:
            return "Épée d'adamantine";
          case 483:
            return "Épée de cobalt";
          case 484:
            return "Épée de mythril";
          case 485:
            return "Sortilège lunaire";
          case 486:
            return "Règle";
          case 487:
            return "Boule de cristal";
          case 488:
            return "Boule à facettes";
          case 489:
            return "Emblème sorcier";
          case 490:
            return "Emblème guerrier";
          case 491:
            return "Emblème ranger";
          case 492:
            return "Ailes de démon";
          case 493:
            return "Ailes d'ange";
          case 494:
            return "Harpe magique";
          case 495:
            return "Bâton d'arc-en-ciel";
          case 496:
            return "Bâton de glace";
          case 497:
            return "Coquillage de Neptune";
          case 498:
            return "Mannequin";
          case 499:
            return "Potion de soins supérieure";
          case 500:
            return "Potion de mana supérieure";
          case 501:
            return "Poudre de fée";
          case 502:
            return "Éclat de cristal";
          case 503:
            return "Chapeau de clown";
          case 504:
            return "Veste de clown";
          case 505:
            return "Pantalon de clown";
          case 506:
            return "Lance-flammes";
          case 507:
            return "Cloche";
          case 508:
            return "Harpe";
          case 509:
            return "Clé à molette";
          case 510:
            return "Pince coupante";
          case 511:
            return "Bloc de pierre actif";
          case 512:
            return "Bloc de pierre inactif";
          case 513:
            return "Levier";
          case 514:
            return "Fusil laser";
          case 515:
            return "Balle de cristal";
          case 516:
            return "Flèche bénite";
          case 517:
            return "Dague magique";
          case 518:
            return "Tempête de cristal";
          case 519:
            return "Flammes maudites";
          case 520:
            return "Âme de lumière";
          case 521:
            return "Âme de la nuit";
          case 522:
            return "Flamme maudite";
          case 523:
            return "Torche maudite";
          case 524:
            return "Forge en adamantine";
          case 525:
            return "Enclume en mythril";
          case 526:
            return "Corne de licorne";
          case 527:
            return "Éclat sombre";
          case 528:
            return "Éclat de lumière";
          case 529:
            return "Plaque de pression rouge";
          case 530:
            return "Câble";
          case 531:
            return "Livre de sorts";
          case 532:
            return "Cape stellaire";
          case 533:
            return "Mégashark";
          case 534:
            return "Fusil à pompe";
          case 535:
            return "Pierre du philosophe";
          case 536:
            return "Gant du titan";
          case 537:
            return "Naginata en cobalt";
          case 538:
            return "Interrupteur";
          case 539:
            return "Piège à fléchette";
          case 540:
            return "Rocher";
          case 541:
            return "Plaque de pression verte";
          case 542:
            return "Plaque de pression grise";
          case 543:
            return "Plaque de pression marron";
          case 544:
            return "Œil mécanique";
          case 545:
            return "Flèche maudite";
          case 546:
            return "Balle maudite";
          case 547:
            return "Âme d'effroi";
          case 548:
            return "Âme de pouvoir";
          case 549:
            return "Âme de vision";
          case 550:
            return "Gungnir";
          case 551:
            return "Armure de plaques sacrée";
          case 552:
            return "Jambières sacrées";
          case 553:
            return "Casque sacré";
          case 554:
            return "Pendentif en croix";
          case 555:
            return "Fleur de mana";
          case 556:
            return "Ver mécanique";
          case 557:
            return "Crâne mécanique";
          case 558:
            return "Coiffe sacrée";
          case 559:
            return "Masque sacré";
          case 560:
            return "Couronne de slime";
          case 561:
            return "Disque de lumière";
          case 562:
            return "Boîte à musique (Jour du monde supérieur)";
          case 563:
            return "Boîte à musique (Surnaturel)";
          case 564:
            return "Boîte à musique (Nuit)";
          case 565:
            return "Boîte à musique (Titre)";
          case 566:
            return "Boîte à musique (Souterrain)";
          case 567:
            return "Boîte à musique (Boss 1)";
          case 568:
            return "Boîte à musique (Jungle)";
          case 569:
            return "Boîte à musique(Corruption)";
          case 570:
            return "Boîte à musique (Corruption du souterrain)";
          case 571:
            return "Boîte à musique (La purification)";
          case 572:
            return "Boîte à musique (Boss 2)";
          case 573:
            return "Boîte à musique (Purification du souterrain)";
          case 574:
            return "Boîte à musique (Boss 3)";
          case 575:
            return "Âme du vol";
          case 576:
            return "Boîte à musique";
          case 577:
            return "Brique de démonite";
          case 578:
            return "Arbalète bénie";
          case 579:
            return "Hâche-marteau";
          case 580:
            return "Explosifs";
          case 581:
            return "Poste de pompage";
          case 582:
            return "Sortie de pompage";
          case 583:
            return "Minuteur d'une seconde";
          case 584:
            return "Minuteur de 3 secondes";
          case 585:
            return "Minuteur de 5 secondes";
          case 586:
            return "Bloc Candy Cane";
          case 587:
            return "Candy Cane mur";
          case 588:
            return "Santa Hat";
          case 589:
            return "Père shirt";
          case 590:
            return "Pantalon de Santa";
          case 591:
            return "Bloc vert Candy Cane";
          case 592:
            return "Vert Candy Cane mur";
          case 593:
            return "neige bloc";
          case 594:
            return "brique de neige";
          case 595:
            return "Mur de briques de neige";
          case 596:
            return "Blue Light";
          case 597:
            return "Red Light";
          case 598:
            return "Green Light";
          case 599:
            return "présent Bleu";
          case 600:
            return "présent vert";
          case 601:
            return "présent jaune";
          case 602:
            return "Globe de neige";
          case 603:
            return "Carotte";
        }
      }
      else if (Lang.lang == 5)
      {
        switch (l)
        {
          case -24:
            return "Sable de luz amarillo";
          case -23:
            return "Sable de luz blanco";
          case -22:
            return "Sable de luz morado";
          case -21:
            return "Sable de luz verde";
          case -20:
            return "Sable de luz rojo";
          case -19:
            return "Sable de luz azul";
          case -18:
            return "Arco de cobre";
          case -17:
            return "Martillo de cobre";
          case -16:
            return "Hacha de cobre";
          case -15:
            return "Espada corta de cobre";
          case -14:
            return "Espada larga de cobre";
          case -13:
            return "Pico de cobre";
          case -12:
            return "Arco de plata";
          case -11:
            return "Martillo de plata";
          case -10:
            return "Hacha de plata";
          case -9:
            return "Espada corta de plata";
          case -8:
            return "Espada larga de plata";
          case -7:
            return "Pico de plata";
          case -6:
            return "Arco de oro";
          case -5:
            return "Martillo de oro";
          case -4:
            return "Hacha de oro";
          case -3:
            return "Espada corta de oro";
          case -2:
            return "Espada larga de oro";
          case -1:
            return "Pico de oro";
          case 1:
            return "Pico de hierro";
          case 2:
            return "Bloque de tierra";
          case 3:
            return "Bloque de piedra";
          case 4:
            return "Espada larga de hierro";
          case 5:
            return "Champiñón";
          case 6:
            return "Espada corta de hierro";
          case 7:
            return "Martillo de hierro";
          case 8:
            return "Antorcha";
          case 9:
            return "Madera";
          case 10:
            return "Hacha de hierro";
          case 11:
            return "Mineral de hierro";
          case 12:
            return "Mineral de cobre";
          case 13:
            return "Mineral de oro";
          case 14:
            return "Mineral de plata";
          case 15:
            return "Reloj de cobre";
          case 16:
            return "Reloj de plata";
          case 17:
            return "Reloj de oro";
          case 18:
            return "Medidor de profundidad";
          case 19:
            return "Lingote de oro";
          case 20:
            return "Lingote de cobre";
          case 21:
            return "Lingote de plata";
          case 22:
            return "Lingote de hierro";
          case 23:
            return "Baba";
          case 24:
            return "Espada de madera";
          case 25:
            return "Puerta de madera";
          case 26:
            return "Pared de piedra";
          case 27:
            return "Bellota";
          case 28:
            return "Poción curativa menor";
          case 29:
            return "Cristal de vida";
          case 30:
            return "Pared de tierra";
          case 31:
            return "Botella";
          case 32:
            return "Mesa de madera";
          case 33:
            return "Horno";
          case 34:
            return "Silla de madera";
          case 35:
            return "Yunque de hierro";
          case 36:
            return "Banco de trabajo";
          case 37:
            return "Gafas de protección";
          case 38:
            return "Lentes";
          case 39:
            return "Arco de madera";
          case 40:
            return "Flecha de madera";
          case 41:
            return "Flecha ardiente";
          case 42:
            return "Cuchillas ninja";
          case 43:
            return "Ojo de mirada desconfiada";
          case 44:
            return "Arco demoníaco";
          case 45:
            return "Hacha de la noche";
          case 46:
            return "Espada de la luz";
          case 47:
            return "Flecha infame";
          case 48:
            return "Cofre";
          case 49:
            return "Banda de regeneración";
          case 50:
            return "Espejo mágico";
          case 51:
            return "Flecha de bufón";
          case 52:
            return "Estatua de ángel";
          case 53:
            return "Nube embotellada";
          case 54:
            return "Botas de Hermes";
          case 55:
            return "Bumerán encantado";
          case 56:
            return "Mineral endemoniado";
          case 57:
            return "Lingote endemoniado";
          case 58:
            return "Corazón";
          case 59:
            return "Semillas corrompidas";
          case 60:
            return "Champiñón vil";
          case 61:
            return "Bloque de piedra de ébano";
          case 62:
            return "Semillas de césped";
          case 63:
            return "Girasol";
          case 64:
            return "Lanzador de espina vil";
          case 65:
            return "Furia de estrellas";
          case 66:
            return "Polvo de purificación";
          case 67:
            return "Polvo vil";
          case 68:
            return "Trozo podrido";
          case 69:
            return "Diente de gusano";
          case 70:
            return "Cebo de gusanos";
          case 71:
            return "Moneda de cobre";
          case 72:
            return "Moneda de plata";
          case 73:
            return "Moneda de oro";
          case 74:
            return "Moneda de platino";
          case 75:
            return "Estrella caída";
          case 76:
            return "Grebas de cobre";
          case 77:
            return "Grebas de hierro";
          case 78:
            return "Grebas de plata";
          case 79:
            return "Grebas de oro";
          case 80:
            return "Cota de malla de cobre";
          case 81:
            return "Cota de malla de hierro";
          case 82:
            return "Cota de malla de plata";
          case 83:
            return "Cota de malla de oro";
          case 84:
            return "Garfio extensible";
          case 85:
            return "Cadena de hierro";
          case 86:
            return "Escama de las sombras";
          case 87:
            return "Hucha";
          case 88:
            return "Casco de minero";
          case 89:
            return "Casco de cobre";
          case 90:
            return "Casco de hierro";
          case 91:
            return "Casco de plata";
          case 92:
            return "Casco de oro";
          case 93:
            return "Pared de madera";
          case 94:
            return "Plataforma de madera";
          case 95:
            return "Pistola de pedernal";
          case 96:
            return "Mosquetón";
          case 97:
            return "Bala de mosquetón";
          case 98:
            return "Minitiburón";
          case 99:
            return "Arco de hierro";
          case 100:
            return "Grebas de las sombras";
          case 101:
            return "Cota de escamas de las sombras";
          case 102:
            return "Casco de las sombras";
          case 103:
            return "Pico de pesadilla";
          case 104:
            return "La despedazadora";
          case 105:
            return "Vela";
          case 106:
            return "Lámpara araña de cobre";
          case 107:
            return "Lámpara araña de plata";
          case 108:
            return "Lámpara araña de oro";
          case 109:
            return "Cristal de maná";
          case 110:
            return "Poción de maná menor";
          case 111:
            return "Banda de polvo de estrellas";
          case 112:
            return "Flor de fuego";
          case 113:
            return "Misil mágico";
          case 114:
            return "Varita de tierra";
          case 115:
            return "Orbe de Luz";
          case 116:
            return "Meteorito";
          case 117:
            return "Lingote de meteorito";
          case 118:
            return "Garfio";
          case 119:
            return "Bumerán de llamas";
          case 120:
            return "Furia fundida";
          case 121:
            return "Gran espada ardiente";
          case 122:
            return "Pico fundido";
          case 123:
            return "Casco de meteorito";
          case 124:
            return "Cota de meteorito";
          case 125:
            return "Polainas de meteoritos";
          case 126:
            return "Agua embotellada";
          case (int) sbyte.MaxValue:
            return "Espacio de arma de fuego";
          case 128:
            return "Botas cohete";
          case 129:
            return "Ladrillo gris";
          case 130:
            return "Pared de ladrillo gris";
          case 131:
            return "Ladrillo rojo";
          case 132:
            return "Pared de ladrillo rojo";
          case 133:
            return "Bloque de arcilla";
          case 134:
            return "Ladrillo azul";
          case 135:
            return "Pared de ladrillo azul";
          case 136:
            return "Farolillo";
          case 137:
            return "Ladrillo verde";
          case 138:
            return "Pared de ladrillo verde";
          case 139:
            return "Ladrillo rosa";
          case 140:
            return "Pared de ladrillo rosa";
          case 141:
            return "Ladrillo dorado";
          case 142:
            return "Pared de ladrillo dorado";
          case 143:
            return "Ladrillo plateado";
          case 144:
            return "Pared de ladrillo plateado";
          case 145:
            return "Ladrillo cobrizo";
          case 146:
            return "Pared de ladrillo cobrizo";
          case 147:
            return "Púa";
          case 148:
            return "Vela de agua";
          case 149:
            return "Libro";
          case 150:
            return "Telaraña";
          case 151:
            return "Casco de los muertos";
          case 152:
            return "Peto de los muertos";
          case 153:
            return "Grebas de los muertos";
          case 154:
            return "Hueso";
          case 155:
            return "Catana Muramasa";
          case 156:
            return "Escudo de cobalto";
          case 157:
            return "Cetro de agua";
          case 158:
            return "Herradura de la suerte";
          case 159:
            return "Globo rojo brillante";
          case 160:
            return "Arpón";
          case 161:
            return "Bola con pinchos";
          case 162:
            return "Flagelo con bola";
          case 163:
            return "Luna azul";
          case 164:
            return "Pistola";
          case 165:
            return "Rayo de agua";
          case 166:
            return "Bomba";
          case 167:
            return "Dinamita";
          case 168:
            return "Granada";
          case 169:
            return "Bloque de arena";
          case 170:
            return "Cristal";
          case 171:
            return "Cartel";
          case 172:
            return "Bloque de ceniza";
          case 173:
            return "Obsidiana";
          case 174:
            return "Piedra infernal";
          case 175:
            return "Lingote de piedra infernal";
          case 176:
            return "Bloque de lodo";
          case 177:
            return "Zafiro";
          case 178:
            return "Rubí";
          case 179:
            return "Esmeralda";
          case 180:
            return "Topacio";
          case 181:
            return "Amatista";
          case 182:
            return "Diamante";
          case 183:
            return "Champiñón brillante";
          case 184:
            return "Estrella";
          case 185:
            return "Látigo de hiedra";
          case 186:
            return "Caña para respirar";
          case 187:
            return "Aletas";
          case 188:
            return "Poción curativa";
          case 189:
            return "Poción de maná";
          case 190:
            return "Espada de hierba";
          case 191:
            return "Chakram de espinas";
          case 192:
            return "Ladrillo de obsidiana";
          case 193:
            return "Cráneo de obsidiana";
          case 194:
            return "Semillas de césped para champiñón";
          case 195:
            return "Semillas de césped para selva";
          case 196:
            return "Martillo de madera";
          case 197:
            return "Cañón de estrellas";
          case 198:
            return "Espada de luz azul";
          case 199:
            return "Espada de luz roja";
          case 200:
            return "Espada de luz verde";
          case 201:
            return "Espada de luz morada";
          case 202:
            return "Espada de luz blanca";
          case 203:
            return "Espada de luz amarilla";
          case 204:
            return "Hacha-martillo de meteorito";
          case 205:
            return "Cubo vacío";
          case 206:
            return "Cubo de agua";
          case 207:
            return "Cubo de lava";
          case 208:
            return "Rosa de la selva";
          case 209:
            return "Aguijón";
          case 210:
            return "Enredadera";
          case 211:
            return "Garras de bestia";
          case 212:
            return "Tobillera de viento";
          case 213:
            return "Báculo de regeneración";
          case 214:
            return "Ladrillo de piedra infernal";
          case 215:
            return "Cojín flatulento";
          case 216:
            return "Argolla";
          case 217:
            return "Hacha-martillo fundido";
          case 218:
            return "Látigo de llamas";
          case 219:
            return "Desintegrador Fénix";
          case 220:
            return "Furia solar";
          case 221:
            return "Forjas infernal";
          case 222:
            return "Marmita de arcilla";
          case 223:
            return "Don de la naturaleza";
          case 224:
            return "Cama";
          case 225:
            return "Seda";
          case 226:
            return "Poción de recuperación menor";
          case 227:
            return "Poción de recuperación";
          case 228:
            return "Casco para la selva";
          case 229:
            return "Camisa para la selva";
          case 230:
            return "Pantalones para la selva";
          case 231:
            return "Casco fundido";
          case 232:
            return "Peto fundido";
          case 233:
            return "Grebas fundidas";
          case 234:
            return "proyectil de meteorito";
          case 235:
            return "Bomba lapa";
          case 236:
            return "Lentes negras";
          case 237:
            return "Gafas de sol";
          case 238:
            return "Sombrero de mago";
          case 239:
            return "Sombrero de copa";
          case 240:
            return "Camisa de esmoquin";
          case 241:
            return "Pantalones de esmoquin";
          case 242:
            return "Sombrero veraniego";
          case 243:
            return "Máscara de conejito";
          case 244:
            return "Gorra de fontanero";
          case 245:
            return "Camisa de fontanero";
          case 246:
            return "Pantalones de fontanero";
          case 247:
            return "Gorro de héroe";
          case 248:
            return "Camisa de héroe";
          case 249:
            return "Pantalones de héroe";
          case 250:
            return "Pecera";
          case 251:
            return "Sombrero de arqueólogo";
          case 252:
            return "Chaqueta de arqueólogo";
          case 253:
            return "Pantalones de arqueólogo";
          case 254:
            return "Tinte negro";
          case (int) byte.MaxValue:
            return "Tinte verde";
          case 256:
            return "Gorro de ninja";
          case 257:
            return "Camisa de ninja";
          case 258:
            return "Pantalones de ninja";
          case 259:
            return "Cuero";
          case 260:
            return "Sombrero rojo";
          case 261:
            return "Pececillo";
          case 262:
            return "Vestido";
          case 263:
            return "Sombrero de robot";
          case 264:
            return "Corona de oro";
          case 265:
            return "Flecha de fuego infernal";
          case 266:
            return "Pistola de arena";
          case 267:
            return "Muñeco vudú del Guía";
          case 268:
            return "Casco de buceo";
          case 269:
            return "Camisa informal";
          case 270:
            return "Pantalones informales";
          case 271:
            return "Peluca informal";
          case 272:
            return "Guadaña demoníaca";
          case 273:
            return "Espada de la noche";
          case 274:
            return "Lanza de la oscuridad";
          case 275:
            return "Coral";
          case 276:
            return "Cactus";
          case 277:
            return "Tridente";
          case 278:
            return "Bala de plata";
          case 279:
            return "Cuchillo arrojadizo";
          case 280:
            return "Lanza";
          case 281:
            return "Cerbatana";
          case 282:
            return "Barrita luminosa";
          case 283:
            return "Semilla";
          case 284:
            return "Bumerán de madera";
          case 285:
            return "Herrete";
          case 286:
            return "Barrita luminosa lapa";
          case 287:
            return "Cuchillo envenenado";
          case 288:
            return "Poción de piel obsidiana";
          case 289:
            return "Poción de regeneración";
          case 290:
            return "Poción de rapidez";
          case 291:
            return "Poción de agallas";
          case 292:
            return "Poción de piel de hierro";
          case 293:
            return "Poción de regeneración de maná";
          case 294:
            return "Poción de poder mágico";
          case 295:
            return "Poción de caída de pluma";
          case 296:
            return "Poción de espeleólogo";
          case 297:
            return "Poción de invisibilidad";
          case 298:
            return "Poción de brillo";
          case 299:
            return "Poción de noctámbulo";
          case 300:
            return "Poción de batalla";
          case 301:
            return "Poción de espinas";
          case 302:
            return "Poción caminando sobre el agua";
          case 303:
            return "Poción de tiro con arco";
          case 304:
            return "Poción de cazador";
          case 305:
            return "Poción de gravedad";
          case 306:
            return "Cofre de oro";
          case 307:
            return "Semillas de resplandor del día";
          case 308:
            return "Semillas de luz de luna";
          case 309:
            return "Semillas de raíz de resplandor";
          case 310:
            return "Semillas de malahierba";
          case 311:
            return "Semillas de hoja de agua";
          case 312:
            return "Semillas de resplandor de fuego";
          case 313:
            return "Resplandor del día";
          case 314:
            return "Luz de luna";
          case 315:
            return "Raíz de resplandor";
          case 316:
            return "Malahierba";
          case 317:
            return "Hoja de agua";
          case 318:
            return "Resplandor de fuego";
          case 319:
            return "Aleta de tiburón";
          case 320:
            return "Pluma";
          case 321:
            return "Lápida";
          case 322:
            return "Máscara de mimo";
          case 323:
            return "Mandíbula de hormiga león";
          case 324:
            return "Accesorios de arma ilegales";
          case 325:
            return "Camisa del doctor";
          case 326:
            return "Pantalones del doctor";
          case 327:
            return "Llave dorada";
          case 328:
            return "Cofre de las sombras";
          case 329:
            return "Llave de las sombras";
          case 330:
            return "Pared de ladrillo de obsidiana";
          case 331:
            return "Esporas de la selva";
          case 332:
            return "Telar";
          case 333:
            return "Piano";
          case 334:
            return "Aparador";
          case 335:
            return "Banco";
          case 336:
            return "Bañera";
          case 337:
            return "Estandarte rojo";
          case 338:
            return "Estandarte verde";
          case 339:
            return "Estandarte azul";
          case 340:
            return "Estandarte amarillo";
          case 341:
            return "Farola";
          case 342:
            return "Antorcha Tiki";
          case 343:
            return "Barril";
          case 344:
            return "Farolillo de papel";
          case 345:
            return "Perol";
          case 346:
            return "Caja fuerte";
          case 347:
            return "Cráneo con vela";
          case 348:
            return "Cubo de basura";
          case 349:
            return "Candelabro";
          case 350:
            return "Probeta rosa";
          case 351:
            return "Taza";
          case 352:
            return "Barrica";
          case 353:
            return "Cerveza";
          case 354:
            return "Librería";
          case 355:
            return "Trono";
          case 356:
            return "Cuenco";
          case 357:
            return "Cuenco de sopa";
          case 358:
            return "Retrete";
          case 359:
            return "Reloj de pie";
          case 360:
            return "Estatua de armadura";
          case 361:
            return "Batalla de duendes convencional";
          case 362:
            return "Harapos";
          case 363:
            return "Serrería";
          case 364:
            return "Mineral de cobalto";
          case 365:
            return "Mineral de mithril";
          case 366:
            return "Mineral de adamantita";
          case 367:
            return "Gran martillo";
          case 368:
            return "Excalibur";
          case 369:
            return "Semillas bendecidas";
          case 370:
            return "Bloque de arena de ébano";
          case 371:
            return "Gorro de cobalto";
          case 372:
            return "Casco de cobalto";
          case 373:
            return "Máscara de cobalto";
          case 374:
            return "Peto de cobalto";
          case 375:
            return "Polainas de cobalto";
          case 376:
            return "Caperuza de mithril";
          case 377:
            return "Casco de mithril";
          case 378:
            return "Gorro de mithril";
          case 379:
            return "Cota de malla de mithril";
          case 380:
            return "Grebas de mithril";
          case 381:
            return "Lingote de cobalto";
          case 382:
            return "Lingote de mithril";
          case 383:
            return "Motosierra de cobalto";
          case 384:
            return "Motosierra de mithril";
          case 385:
            return "Taladro de cobalto";
          case 386:
            return "Taladro de mithril";
          case 387:
            return "Motosierra de adamantita";
          case 388:
            return "Taladro de adamantita";
          case 389:
            return "Flagelo Taoísta";
          case 390:
            return "Alabarda de mithril";
          case 391:
            return "Lingote de adamantita";
          case 392:
            return "Cristal de pared";
          case 393:
            return "Brújula";
          case 394:
            return "Equipo de buceo";
          case 395:
            return "GPS";
          case 396:
            return "Herradura de obsidiana";
          case 397:
            return "Escudo de obsidiana";
          case 398:
            return "Taller del reparador";
          case 399:
            return "Globo de nube";
          case 400:
            return "Tocado de adamantita";
          case 401:
            return "Casco de adamantita";
          case 402:
            return "Máscara de adamantita";
          case 403:
            return "Peto de adamantita";
          case 404:
            return "Polainas de adamantita";
          case 405:
            return "Botas de espectro";
          case 406:
            return "Lanza de adamantita";
          case 407:
            return "Cinturón de herramientas";
          case 408:
            return "Bloque de arena de perla";
          case 409:
            return "Bloque de piedra perlada";
          case 410:
            return "Camisa de minero";
          case 411:
            return "Pantalones de minero";
          case 412:
            return "Ladrillo de piedra perlada";
          case 413:
            return "Ladrillo tornasol";
          case 414:
            return "Bloque de lutita";
          case 415:
            return "Ladrillo de cobalto";
          case 416:
            return "Ladrillo de mithril";
          case 417:
            return "Pared de ladrillo de piedra perlada";
          case 418:
            return "Pared de ladrillo tornasol";
          case 419:
            return "Pared de ladrillo de lutita";
          case 420:
            return "Pared de ladrillo de cobalto";
          case 421:
            return "Pared de ladrillo de mithril";
          case 422:
            return "Agua sagrada";
          case 423:
            return "Agua impura";
          case 424:
            return "Bloque de limo";
          case 425:
            return "Campana de hada";
          case 426:
            return "Espada despedazadora";
          case 427:
            return "Antorcha azul";
          case 428:
            return "Antorcha rojo";
          case 429:
            return "Antorcha verde";
          case 430:
            return "Antorcha morada";
          case 431:
            return "Antorcha blanca";
          case 432:
            return "Antorcha amarilla";
          case 433:
            return "Antorcha demoníaca";
          case 434:
            return "Fusil de asalto de precisión";
          case 435:
            return "Repetidor de cobalto";
          case 436:
            return "Repetidor de mithril";
          case 437:
            return "Gancho doble";
          case 438:
            return "Estatua de estrella";
          case 439:
            return "Estatua de espada";
          case 440:
            return "Estatua de babosa";
          case 441:
            return "Estatua de duende";
          case 442:
            return "Estatua de escudo";
          case 443:
            return "Estatua de murciélago";
          case 444:
            return "Estatua de pez";
          case 445:
            return "Estatua de conejito";
          case 446:
            return "Estatua de esqueleto";
          case 447:
            return "Estatua de la Muerte";
          case 448:
            return "Estatua de mujer";
          case 449:
            return "Estatua de diablillo";
          case 450:
            return "Estatua de gárgola";
          case 451:
            return "Estatua de Melancolía";
          case 452:
            return "Estatua de avispón";
          case 453:
            return "Estatua de bomba";
          case 454:
            return "Estatua de cangrejo";
          case 455:
            return "Estatua de martilla";
          case 456:
            return "Estatua de poción";
          case 457:
            return "Estatua de lanza";
          case 458:
            return "Estatua de cruz";
          case 459:
            return "Estatua de medusa";
          case 460:
            return "Estatua de arco";
          case 461:
            return "Estatua de bumerán";
          case 462:
            return "Estatua de bota";
          case 463:
            return "Estatua de cofre";
          case 464:
            return "Estatua de pájaro";
          case 465:
            return "Estatua de hacha";
          case 466:
            return "Estatua de corrupción";
          case 467:
            return "Estatua de árbol";
          case 468:
            return "Estatua de yunque";
          case 469:
            return "Estatua de pico";
          case 470:
            return "Estatua de champiñón";
          case 471:
            return "Estatua de ojo";
          case 472:
            return "Estatua de columna";
          case 473:
            return "Estatua de corazón";
          case 474:
            return "Estatua de marmita";
          case 475:
            return "Estatua de girasol";
          case 476:
            return "Estatua de rey";
          case 477:
            return "Estatua de reina";
          case 478:
            return "Estatua de piraña";
          case 479:
            return "Pared de tablones";
          case 480:
            return "Viga de madera";
          case 481:
            return "Repetidor de adamantita";
          case 482:
            return "Espada de adamantita";
          case 483:
            return "Espada de cobalto";
          case 484:
            return "Espada de mithril";
          case 485:
            return "Hechizo de luna";
          case 486:
            return "Regla";
          case 487:
            return "Bola de cristal";
          case 488:
            return "Bola de discoteca";
          case 489:
            return "Emblema de hechicero";
          case 490:
            return "Emblema de guerrero";
          case 491:
            return "Emblema de guardián";
          case 492:
            return "Alas demoníacas";
          case 493:
            return "Alas de ángel";
          case 494:
            return "Arpa mágica";
          case 495:
            return "Varita multicolor";
          case 496:
            return "Varita helada";
          case 497:
            return "Concha de Neptuno";
          case 498:
            return "Maniquí";
          case 499:
            return "Poción curativa mayor";
          case 500:
            return "Poción de maná mayor";
          case 501:
            return "Polvo de hada";
          case 502:
            return "Fragmento de cristal";
          case 503:
            return "Sombrero de payaso";
          case 504:
            return "Camisa de payaso";
          case 505:
            return "Pantalones de payaso";
          case 506:
            return "Lanzallamas";
          case 507:
            return "Campana";
          case 508:
            return "Arpa";
          case 509:
            return "Llave inglesa";
          case 510:
            return "Alicates";
          case 511:
            return "Bloque de piedra activo";
          case 512:
            return "Bloque de piedra inactivo";
          case 513:
            return "Palanca";
          case 514:
            return "Fusil láser";
          case 515:
            return "Bala de cristal";
          case 516:
            return "Flecha sagrada";
          case 517:
            return "Daga mágica";
          case 518:
            return "Tormenta de cristal";
          case 519:
            return "Llamas malditas";
          case 520:
            return "Alma de luz";
          case 521:
            return "Alma de noche";
          case 522:
            return "Llama maldita";
          case 523:
            return "Antorcha maldita";
          case 524:
            return "Forja de adamantita";
          case 525:
            return "Yunque de mithril";
          case 526:
            return "Cuerno de unicornio";
          case 527:
            return "Fragmento de oscuridad";
          case 528:
            return "Fragmento de luz";
          case 529:
            return "Chapa de presión roja";
          case 530:
            return "Alambre";
          case 531:
            return "Tomo encantado";
          case 532:
            return "Manto de estrellas";
          case 533:
            return "Megatiburón";
          case 534:
            return "Escopeta";
          case 535:
            return "Piedra filosofal";
          case 536:
            return "Guante de Titán";
          case 537:
            return "Naginata de cobalto";
          case 538:
            return "Interruptor";
          case 539:
            return "Trampa de dardos";
          case 540:
            return "Roca";
          case 541:
            return "Chapa de presión verde";
          case 542:
            return "Chapa de presión gris";
          case 543:
            return "Chapa de presión marrón";
          case 544:
            return "Ojo mecánico";
          case 545:
            return "Flecha maldita";
          case 546:
            return "Bala maldita";
          case 547:
            return "Alma de terror";
          case 548:
            return "Alma de poder";
          case 549:
            return "Alma de visión";
          case 550:
            return "Gungnir";
          case 551:
            return "Cota de chapas bendecida";
          case 552:
            return "Grebas bendecidas";
          case 553:
            return "Casco bendecido";
          case 554:
            return "Collar con cruz";
          case 555:
            return "Flor de maná";
          case 556:
            return "Gusano mecánico";
          case 557:
            return "Cráneo mecánico";
          case 558:
            return "Tocado bendecido";
          case 559:
            return "Máscara bendecida";
          case 560:
            return "Corona de babosa";
          case 561:
            return "Disco de luz";
          case 562:
            return "Caja de música (Superficie de día)";
          case 563:
            return "Caja de música (Sobrecogedor)";
          case 564:
            return "Caja de música (Noche)";
          case 565:
            return "Caja de música (Título)";
          case 566:
            return "Caja de música (Subsuelo)";
          case 567:
            return "Caja de música (Jefe 1)";
          case 568:
            return "Caja de música (Selva)";
          case 569:
            return "Caja de música (Corrupción)";
          case 570:
            return "Caja de música (Corrupción en el Subsuelo)";
          case 571:
            return "Caja de música (La Bendición)";
          case 572:
            return "Caja de música (Jefe 2)";
          case 573:
            return "Caja de música (Bendición en el Subsuelo)";
          case 574:
            return "Caja de música (Jefe 3)";
          case 575:
            return "Alma de vuelo";
          case 576:
            return "Caja de música";
          case 577:
            return "Ladrillo endemoniado";
          case 578:
            return "Repetidor bendecido";
          case 579:
            return "Martitaladrahacha";
          case 580:
            return "Explosivos";
          case 581:
            return "Colector de entrada";
          case 582:
            return "Colector de salida";
          case 583:
            return "Temporizador de 1 segundo";
          case 584:
            return "Temporizador de 3 segundos";
          case 585:
            return "Temporizador de 5 segundos";
          case 586:
            return "Bloquear dulces de caña";
          case 587:
            return "Candy Cane pared";
          case 588:
            return "Gorro de Papá Noel";
          case 589:
            return "Santa Camisa";
          case 590:
            return "Pantalones de Santa";
          case 591:
            return "Caramelo verde de caña de bloques";
          case 592:
            return "Verde del bastón de caramelo pared";
          case 593:
            return "Bloque de nieve";
          case 594:
            return "nieve ladrillo";
          case 595:
            return "Snow Brick Wall";
          case 596:
            return "Nieve pared de ladrillo";
          case 597:
            return "azul claro";
          case 598:
            return "luz roja";
          case 599:
            return "Presente azul";
          case 600:
            return "Presente verde";
          case 601:
            return "Presente amarillo";
          case 602:
            return "Bola de Nieve";
          case 603:
            return "Zanahoria";
        }
      }
      return "";
    }

    public static string evilGood()
    {
      if (Lang.lang <= 1)
      {
        string str;
        if (WorldGen.tGood == (byte) 0)
          str = Main.worldName + " is " + (object) WorldGen.tEvil + "% corrupt.";
        else if (WorldGen.tEvil == (byte) 0)
          str = Main.worldName + " is " + (object) WorldGen.tGood + "% hallow.";
        else
          str = Main.worldName + " is " + (object) WorldGen.tGood + "% hallow, and " + (object) WorldGen.tEvil + "% corrupt.";
        return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || WorldGen.tEvil <= (byte) 20 ? str + " You should try harder." : str + " Things are grim indeed.") : str + " Keep up the good work!";
      }
      if (Lang.lang == 2)
      {
        string str;
        if (WorldGen.tGood == (byte) 0)
          str = Main.worldName + " ist zu " + (object) WorldGen.tEvil + "% verderbt.";
        else if (WorldGen.tEvil == (byte) 0)
          str = Main.worldName + " ist zu " + (object) WorldGen.tGood + "% gesegnet.";
        else
          str = Main.worldName + " ist zu " + (object) WorldGen.tGood + "% gesegnet und zu " + (object) WorldGen.tEvil + "% verderbt.";
        return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || WorldGen.tEvil <= (byte) 20 ? str + " Streng dich mehr an!" : str + " Es steht nicht gut.") : str + " Gute Arbeit, weiter so!";
      }
      if (Lang.lang == 3)
      {
        string str;
        if (WorldGen.tGood == (byte) 0)
          str = Main.worldName + " è distrutto al " + (object) WorldGen.tEvil + "%.";
        else if (WorldGen.tEvil == (byte) 0)
          str = Main.worldName + " è santo al " + (object) WorldGen.tGood + "%.";
        else
          str = Main.worldName + " è santo al " + (object) WorldGen.tGood + "% e distrutto al " + (object) WorldGen.tEvil + "%.";
        return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || WorldGen.tEvil <= (byte) 20 ? str + " Dovresti impegnarti di più." : str + " Le cose vanno male.") : str + " Continua così!";
      }
      if (Lang.lang == 4)
      {
        string str;
        if (WorldGen.tGood == (byte) 0)
          str = Main.worldName + " est corrompu à " + (object) WorldGen.tEvil + "%.";
        else if (WorldGen.tEvil == (byte) 0)
          str = Main.worldName + " est purifié à " + (object) WorldGen.tGood + "%.";
        else
          str = Main.worldName + " est purifié à " + (object) WorldGen.tGood + "% et corrompu à " + (object) WorldGen.tEvil + "%.";
        return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || WorldGen.tEvil <= (byte) 20 ? str + " Essayez encore." : str + " En effet, c'est pas la joie.") : str + " Continuez comme ça.";
      }
      if (Lang.lang != 5)
        return "";
      string str1;
      if (WorldGen.tGood == (byte) 0)
        str1 = Main.worldName + " ha sido corrompido por " + (object) WorldGen.tEvil + "%.";
      else if (WorldGen.tEvil == (byte) 0)
        str1 = Main.worldName + " ha sido bendecido por " + (object) WorldGen.tGood + "%.";
      else
        str1 = Main.worldName + " ha sido bendecido por " + (object) WorldGen.tGood + "% y corrompido por " + (object) WorldGen.tEvil + "%.";
      return (int) WorldGen.tGood <= (int) WorldGen.tEvil ? ((int) WorldGen.tEvil <= (int) WorldGen.tGood || WorldGen.tEvil <= (byte) 20 ? str1 + " Deberías esforzarte más." : str1 + " Es bastante desalentador.") : str1 + " ¡Sigue haciéndolo bien!";
    }

    public static string title()
    {
      int num = Main.rand.Next(15);
      if (Lang.lang <= 1)
      {
        switch (num)
        {
          case 0:
            return "Terraria: Dig Peon, Dig!";
          case 1:
            return "Terraria: Epic Dirt";
          case 2:
            return "Terraria: Hey Guys!";
          case 3:
            return "Terraria: Sand is Overpowered";
          case 4:
            return "Terraria Part 3: The Return of the Guide";
          case 5:
            return "Terraria: A Bunnies Tale";
          case 6:
            return "Terraria: Dr. Bones and The Temple of Blood Moon";
          case 7:
            return "Terraria: Slimeassic Park";
          case 8:
            return "Terraria: The Grass is Greener on This Side";
          case 9:
            return "Terraria: Small Blocks, Not for Children Under the Age of 5";
          case 10:
            return "Terraria: Digger T' Blocks";
          case 11:
            return "Terraria: There is No Cow Layer";
          case 12:
            return "Terraria: Suspicous Looking Eyeballs";
          case 13:
            return "Terraria: Purple Grass!";
          case 14:
            return "Terraria: Noone Dug Behind!";
          default:
            return "Terraria: Shut Up and Dig Gaiden!";
        }
      }
      else if (Lang.lang == 2)
      {
        switch (num)
        {
          case 0:
            return "Terraria: Nun grab schon, Bauer, grab!";
          case 1:
            return "Terraria: Epischer Dreck";
          case 2:
            return "Terraria: Huhu, Leute!";
          case 3:
            return "Terraria: Sand is overpowered!";
          case 4:
            return "Terraria Teil 3: Die Rueckkehr des Fremdenfuehrers";
          case 5:
            return "Terraria: Geschichte eines verderbten Haeschens";
          case 6:
            return "Terraria: Dr. Bones und der Tempel des Blutmondes";
          case 7:
            return "Terraria: Schleimassic Park";
          case 8:
            return "Terraria: Das Gras ist auf dieser Seite gruener";
          case 9:
            return "Terraria: Kleine Bloecke, nicht fuer Kinder unter 5";
          case 10:
            return "Terraria: Der Block des Ausgraebers";
          case 11:
            return "Terraria: Hier gibt's auch kein Kuh-Level!";
          case 12:
            return "Terraria: Verdaechtig ausschauende Augaepfel";
          case 13:
            return "Terraria: Violettes Gras!";
          case 14:
            return "Terraria: Houston, wir haben ein Problem gehabt!";
          default:
            return "Terraria: Grab mit deiner Hand, nicht mit dem Mund!";
        }
      }
      else if (Lang.lang == 3)
      {
        switch (num)
        {
          case 0:
            return "Terraria: Scava contadino, scava!";
          case 1:
            return "Terraria: Terra epica";
          case 2:
            return "Terraria: Ehi, ragazzi!";
          case 3:
            return "Terraria: La sabbia è strapotente";
          case 4:
            return "Terraria: Il ritorno della guida";
          case 5:
            return "Terraria: Coda di coniglio";
          case 6:
            return "Terraria: Dottor Ossa e il tempio della luna di sangue";
          case 7:
            return "Terraria: Slimeassic Park";
          case 8:
            return "Terraria: L'erba è più verde da questo lato";
          case 9:
            return "Terraria: Piccoli blocchi, non per bambini al di sotto di 5 anni";
          case 10:
            return "Terraria:  Il blocco dello scavatore";
          case 11:
            return "Terraria: No mucche, no party";
          case 12:
            return "Terraria: Bulbi oculari diffidenti";
          case 13:
            return "Terraria: Erba viola!";
          case 14:
            return "Terraria: Houston, abbiamo un problema!";
          default:
            return "Terraria: Zitto e scava, 'azzo!";
        }
      }
      else if (Lang.lang == 4)
      {
        switch (num)
        {
          case 0:
            return "Terraria : Creuse et fais pas cette mine !";
          case 1:
            return "Terraria : Bain de boue";
          case 2:
            return "Terraria : Salut la compagnie !";
          case 3:
            return "Terraria : Le canon à sable, c'est vraiment grosbill";
          case 4:
            return "Terraria, 3e partie : Le retour du guide";
          case 5:
            return "Terraria : Des lapins pas si crétins";
          case 6:
            return "Terraria : Dr Bones et le temple de la lune de sang";
          case 7:
            return "Terraria: Slimeassic Park";
          case 8:
            return "Terraria : L'herbe est plus verte dans le pré du voisin";
          case 9:
            return "Terraria : Petits blocs interdits aux enfants de moins de 5 ans";
          case 10:
            return "Terraria : Des mineurs gonflés à bloc ! ";
          case 11:
            return "Terraria : Strates aux sphères";
          case 12:
            return "Terraria : L'œil observateur suspicieux";
          case 13:
            return "Terraria  : Silence, ça pousse !";
          case 14:
            return "Terraria : Houston, nous avons un problème !";
          default:
            return "Terraria : J'fais des trous, des p'tis trous...";
        }
      }
      else
      {
        if (Lang.lang != 5)
          return "";
        switch (num)
        {
          case 0:
            return "Terraria: ¡Cava, peón, cava!";
          case 1:
            return "Terraria: Terreno épico";
          case 2:
            return "Terraria: ¡Hola, tíos!";
          case 3:
            return "Terraria: El poder de la arena";
          case 4:
            return "Terraria parte 3: El regreso del Guía";
          case 5:
            return "Terraria: Un cuento de conejitos";
          case 6:
            return "Terraria: El Dr. Látigo y el Templo de la Luna Sangrienta";
          case 7:
            return "Terraria: Babosic Park";
          case 8:
            return "Terraria: Mi césped es más verde que el del vecino";
          case 9:
            return "Terraria: Bloques de construcción (no apto para menores de 5 años)";
          case 10:
            return "Terraria: Buscador de bloques";
          case 11:
            return "Terraria: Nada de niveles ocultos";
          case 12:
            return "Terraria: Ojos de aspecto sospechoso";
          case 13:
            return "Terraria: ¡Césped morado!";
          case 14:
            return "Terraria: ¡No abandonamos ningún agujero!";
          default:
            return "Terraria: ¡Cállate y cava un universo paralelo!";
        }
      }
    }

    public static void setLang()
    {
      Main.chTitle = true;
      if (Lang.lang <= 1)
      {
        Lang.misc[0] = "A goblin army has been defeated!";
        Lang.misc[1] = "A goblin army is approaching from the west!";
        Lang.misc[2] = "A goblin army is approaching from the east!";
        Lang.misc[3] = "A goblin army has arrived!";
        Lang.misc[4] = "The Frost Legion has been defeated!";
        Lang.misc[5] = "The Frost Legion is approaching from the west!";
        Lang.misc[6] = "The Frost Legion is approaching from the east!";
        Lang.misc[7] = "The Frost Legion has arrived!";
        Lang.misc[8] = "The Blood Moon is rising...";
        Lang.misc[9] = "You feel an evil presence watching you...";
        Lang.misc[10] = "A horrible chill goes down your spine...";
        Lang.misc[11] = "Screams echo around you...";
        Lang.misc[12] = "Your world has been blessed with Cobalt!";
        Lang.misc[13] = "Your world has been blessed with Mythril!";
        Lang.misc[14] = "Your world has been blessed with Adamantite!";
        Lang.misc[15] = "The ancient spirits of light and dark have been released.";
        Lang.misc[16] = "has awoken!";
        Lang.misc[17] = "has been defeated!";
        Lang.misc[18] = "has arrived!";
        Lang.misc[19] = " was slain...";
        Lang.menu[0] = "Start a new instance of Terraria to join!";
        Lang.menu[1] = "Running on port ";
        Lang.menu[2] = "Disconnect";
        Lang.menu[3] = "Server Requires Password:";
        Lang.menu[4] = "Accept";
        Lang.menu[5] = "Back";
        Lang.menu[6] = "Cancel";
        Lang.menu[7] = "Enter Server Password:";
        Lang.menu[8] = "Starting server...";
        Lang.menu[9] = "Load failed!";
        Lang.menu[10] = "Load Backup";
        Lang.menu[11] = "No backup found";
        Lang.menu[12] = "Single Player";
        Lang.menu[13] = "Multiplayer";
        Lang.menu[14] = "Settings";
        Lang.menu[15] = "Exit";
        Lang.menu[16] = "Create Character";
        Lang.menu[17] = "Delete";
        Lang.menu[18] = "Hair";
        Lang.menu[19] = "Eyes";
        Lang.menu[20] = "Skin";
        Lang.menu[21] = "Clothes";
        Lang.menu[22] = "Male";
        Lang.menu[23] = "Female";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Mediumcore";
        Lang.menu[26] = "Softcore";
        Lang.menu[27] = "Random";
        Lang.menu[28] = "Create";
        Lang.menu[29] = "Hardcore characters die for good";
        Lang.menu[30] = "Mediumcore characters drop items on death";
        Lang.menu[31] = "Softcore characters drop money on death";
        Lang.menu[32] = "Select difficulty";
        Lang.menu[33] = "Shirt";
        Lang.menu[34] = "Undershirt";
        Lang.menu[35] = "Pants";
        Lang.menu[36] = "Shoes";
        Lang.menu[37] = "Hair";
        Lang.menu[38] = "Hair Color";
        Lang.menu[39] = "Eye Color";
        Lang.menu[40] = "Skin Color";
        Lang.menu[41] = "Shirt Color";
        Lang.menu[42] = "Undershirt Color";
        Lang.menu[43] = "Pants Color";
        Lang.menu[44] = "Shoe Color";
        Lang.menu[45] = "Enter Character Name:";
        Lang.menu[46] = "Delete";
        Lang.menu[47] = "Create World";
        Lang.menu[48] = "Enter World Name:";
        Lang.menu[49] = "Go Windowed";
        Lang.menu[50] = "Go Fullscreen";
        Lang.menu[51] = "Resolution";
        Lang.menu[52] = "Parallax";
        Lang.menu[53] = "Frame Skip Off (Not Recommended)";
        Lang.menu[54] = "Frame Skip On (Recommended)";
        Lang.menu[55] = "Lighting: Color";
        Lang.menu[56] = "Lighting: White";
        Lang.menu[57] = "Lighting: Retro";
        Lang.menu[58] = "Lighting: Trippy";
        Lang.menu[59] = "Quality: Auto";
        Lang.menu[60] = "Quality: High";
        Lang.menu[61] = "Quality: Medium";
        Lang.menu[62] = "Quality: Low";
        Lang.menu[63] = "Video";
        Lang.menu[64] = "Cursor Color";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "Controls";
        Lang.menu[67] = "Autosave On";
        Lang.menu[68] = "Autosave Off";
        Lang.menu[69] = "Autopause On";
        Lang.menu[70] = "Autopause Off";
        Lang.menu[71] = "Pickup Text On";
        Lang.menu[72] = "Pickup Text Off";
        Lang.menu[73] = "Fullscreen Resolution";
        Lang.menu[74] = "Up             ";
        Lang.menu[75] = "Down          ";
        Lang.menu[76] = "Left            ";
        Lang.menu[77] = "Right          ";
        Lang.menu[78] = "Jump          ";
        Lang.menu[79] = "Throw         ";
        Lang.menu[80] = "Inventory      ";
        Lang.menu[81] = "Quick Heal    ";
        Lang.menu[82] = "Quick Mana   ";
        Lang.menu[83] = "Quick Buff    ";
        Lang.menu[84] = "Grapple        ";
        Lang.menu[85] = "Auto Select    ";
        Lang.menu[86] = "Reset to Default";
        Lang.menu[87] = "Join";
        Lang.menu[88] = "Host & Play";
        Lang.menu[89] = "Enter Server IP Address:";
        Lang.menu[90] = "Enter Server Port:";
        Lang.menu[91] = "Choose world size:";
        Lang.menu[92] = "Small";
        Lang.menu[93] = "Medium";
        Lang.menu[94] = "Large";
        Lang.menu[95] = "Red:";
        Lang.menu[96] = "Green:";
        Lang.menu[97] = "Blue:";
        Lang.menu[98] = "Sound:";
        Lang.menu[99] = "Music:";
        Lang.menu[100] = "Background On";
        Lang.menu[101] = "Background Off";
        Lang.menu[102] = "Select language";
        Lang.menu[103] = "Language";
        Lang.menu[104] = "Yes";
        Lang.menu[105] = "No";
        Lang.gen[0] = "Generating world terrain:";
        Lang.gen[1] = "Adding sand...";
        Lang.gen[2] = "Generating hills...";
        Lang.gen[3] = "Puttin dirt behind dirt:";
        Lang.gen[4] = "Placing rocks in the dirt...";
        Lang.gen[5] = "Placing dirt in the rocks...";
        Lang.gen[6] = "Adding clay...";
        Lang.gen[7] = "Making random holes:";
        Lang.gen[8] = "Generating small caves:";
        Lang.gen[9] = "Generating large caves:";
        Lang.gen[10] = "Generating surface caves...";
        Lang.gen[11] = "Generating jungle:";
        Lang.gen[12] = "Generating floating islands...";
        Lang.gen[13] = "Adding mushroom patches...";
        Lang.gen[14] = "Placing mud in the dirt...";
        Lang.gen[15] = "Adding silt...";
        Lang.gen[16] = "Adding shinies...";
        Lang.gen[17] = "Adding webs...";
        Lang.gen[18] = "Creating underworld:";
        Lang.gen[19] = "Adding water bodies:";
        Lang.gen[20] = "Making the world evil:";
        Lang.gen[21] = "Generating mountain caves...";
        Lang.gen[22] = "Creating beaches...";
        Lang.gen[23] = "Adding gems...";
        Lang.gen[24] = "Gravitating sand:";
        Lang.gen[25] = "Cleaning up dirt backgrounds:";
        Lang.gen[26] = "Placing altars:";
        Lang.gen[27] = "Settling liquids:";
        Lang.gen[28] = "Placing life crystals:";
        Lang.gen[29] = "Placing statues:";
        Lang.gen[30] = "Hiding treasure:";
        Lang.gen[31] = "Hiding more treasure:";
        Lang.gen[32] = "Hiding jungle treasure:";
        Lang.gen[33] = "Hiding water treasure:";
        Lang.gen[34] = "Placing traps:";
        Lang.gen[35] = "Placing breakables:";
        Lang.gen[36] = "Placing hellforges:";
        Lang.gen[37] = "Spreading grass...";
        Lang.gen[38] = "Growing cacti...";
        Lang.gen[39] = "Planting sunflowers...";
        Lang.gen[40] = "Planting trees...";
        Lang.gen[41] = "Planting herbs...";
        Lang.gen[42] = "Planting weeds...";
        Lang.gen[43] = "Growing vines...";
        Lang.gen[44] = "Planting flowers...";
        Lang.gen[45] = "Planting mushrooms...";
        Lang.gen[46] = "Freeing unused resources:";
        Lang.gen[47] = "Resetting game objects:";
        Lang.gen[48] = "Setting hard mode...";
        Lang.gen[49] = "Saving world data:";
        Lang.gen[50] = "Backing up world file...";
        Lang.gen[51] = "Loading world data:";
        Lang.gen[52] = "Checking tile alignment:";
        Lang.gen[53] = "Load failed!";
        Lang.gen[54] = "No backup found.";
        Lang.gen[55] = "Finding tile frames:";
        Lang.gen[56] = "Adding snow...";
        Lang.gen[57] = "World";
        Lang.gen[58] = "Creating dungeon:";
        Lang.gen[59] = "A meteorite has landed!";
        Lang.inter[0] = "Life:";
        Lang.inter[1] = "Breath";
        Lang.inter[2] = "Mana";
        Lang.inter[3] = "Trash Can";
        Lang.inter[4] = "Inventory";
        Lang.inter[5] = "Hotbar unlocked";
        Lang.inter[6] = "Hotbar locked";
        Lang.inter[7] = "Housing";
        Lang.inter[8] = "Housing Query";
        Lang.inter[9] = "Accessories";
        Lang.inter[10] = "Defense";
        Lang.inter[11] = "Social";
        Lang.inter[12] = "Helmet";
        Lang.inter[13] = "Shirt";
        Lang.inter[14] = "Pants";
        Lang.inter[15] = "platinum";
        Lang.inter[16] = "gold";
        Lang.inter[17] = "silver";
        Lang.inter[18] = "copper";
        Lang.inter[19] = "Reforge";
        Lang.inter[20] = "Place an item here to reforge";
        Lang.inter[21] = "Showing recipes that use";
        Lang.inter[22] = "Required objects:";
        Lang.inter[23] = "None";
        Lang.inter[24] = "Place a material here to show recipes";
        Lang.inter[25] = "Crafting";
        Lang.inter[26] = "Coins";
        Lang.inter[27] = "Ammo";
        Lang.inter[28] = "Shop";
        Lang.inter[29] = "Loot All";
        Lang.inter[30] = "Deposit All";
        Lang.inter[31] = "Quick Stack";
        Lang.inter[32] = "Piggy Bank";
        Lang.inter[33] = "Safe";
        Lang.inter[34] = "Time:";
        Lang.inter[35] = "Save & Exit";
        Lang.inter[36] = "Disconnect";
        Lang.inter[37] = "Items";
        Lang.inter[38] = "You were slain...";
        Lang.inter[39] = "This housing is suitable.";
        Lang.inter[40] = "This is not valid housing.";
        Lang.inter[41] = "This housing is already occupied.";
        Lang.inter[42] = "This housing is corrupted.";
        Lang.inter[43] = "Connection timed out";
        Lang.inter[44] = "Receiving tile data";
        Lang.inter[45] = "Equip";
        Lang.inter[46] = "Cost";
        Lang.inter[47] = "Save";
        Lang.inter[48] = "Edit";
        Lang.inter[49] = "Status";
        Lang.inter[50] = "Curse";
        Lang.inter[51] = "Help";
        Lang.inter[52] = "Close";
        Lang.inter[53] = "Water";
        Lang.inter[54] = "Heal";
        Lang.tip[0] = "Equipped in social slot";
        Lang.tip[1] = "No stats will be gained";
        Lang.tip[2] = " melee damage";
        Lang.tip[3] = " ranged damage";
        Lang.tip[4] = " magic damage";
        Lang.tip[5] = "% critical strike chance";
        Lang.tip[6] = "Insanely fast speed";
        Lang.tip[7] = "Very fast speed";
        Lang.tip[8] = "Fast speed";
        Lang.tip[9] = "Average speed";
        Lang.tip[10] = "Slow speed";
        Lang.tip[11] = "Very slow speed";
        Lang.tip[12] = "Extremely slow speed";
        Lang.tip[13] = "Snail speed";
        Lang.tip[14] = "No knockback";
        Lang.tip[15] = "Extremely weak knockback";
        Lang.tip[16] = "Very weak knockback";
        Lang.tip[17] = "Weak knockback";
        Lang.tip[18] = "Average knockback";
        Lang.tip[19] = "Strong knockback";
        Lang.tip[20] = "Very strong knockback";
        Lang.tip[21] = "Extremely strong knockback";
        Lang.tip[22] = "Insane knockback";
        Lang.tip[23] = "Equipable";
        Lang.tip[24] = "Vanity Item";
        Lang.tip[25] = " defense";
        Lang.tip[26] = "% pickaxe power";
        Lang.tip[27] = "% axe power";
        Lang.tip[28] = "% hammer power";
        Lang.tip[29] = "Restores";
        Lang.tip[30] = "life";
        Lang.tip[31] = "mana";
        Lang.tip[32] = "Uses";
        Lang.tip[33] = "Can be placed";
        Lang.tip[34] = "Ammo";
        Lang.tip[35] = "Consumable";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " minute duration";
        Lang.tip[38] = " second duration";
        Lang.tip[39] = "% damage";
        Lang.tip[40] = "% speed";
        Lang.tip[41] = "% critical strike chance";
        Lang.tip[42] = "% mana cost";
        Lang.tip[43] = "% size";
        Lang.tip[44] = "% velocity";
        Lang.tip[45] = "% knockback";
        Lang.tip[46] = "% movement speed";
        Lang.tip[47] = "% melee speed";
        Lang.tip[48] = "Set bonus:";
        Lang.tip[49] = "Sell price:";
        Lang.tip[50] = "Buy price:";
        Lang.tip[51] = "No value";
        Lang.mp[0] = "Recieve:";
        Lang.mp[1] = "Incorrect password.";
        Lang.mp[2] = "Invalid operation at this state.";
        Lang.mp[3] = "You are banned from this server.";
        Lang.mp[4] = "You are not using the same version as this server.";
        Lang.mp[5] = "is already on this server.";
        Lang.mp[6] = "/playing";
        Lang.mp[7] = "Current players:";
        Lang.mp[8] = "/roll";
        Lang.mp[9] = "rolls a";
        Lang.mp[10] = "You are not in a party!";
        Lang.mp[11] = "has enabled PvP!";
        Lang.mp[12] = "has disabled PvP!";
        Lang.mp[13] = "is no longer on a party.";
        Lang.mp[14] = "has joined the red party.";
        Lang.mp[15] = "has joined the green party.";
        Lang.mp[16] = "has joined the blue party.";
        Lang.mp[17] = "has joined the yellow party.";
        Lang.mp[18] = "Welcome to";
        Lang.mp[19] = "has joined.";
        Lang.mp[20] = "has left.";
        Lang.the = "the ";
        Lang.dt[0] = "couldn't find the antidote";
        Lang.dt[1] = "couldn't put the fire out";
        Main.buffName[1] = "Obsidian Skin";
        Main.buffTip[1] = "Immune to lava";
        Main.buffName[2] = "Regeneration";
        Main.buffTip[2] = "Provides life regeneration";
        Main.buffName[3] = "Swiftness";
        Main.buffTip[3] = "25% increased movement speed";
        Main.buffName[4] = "Gills";
        Main.buffTip[4] = "Breathe water instead of air";
        Main.buffName[5] = "Ironskin";
        Main.buffTip[5] = "Increase defense by 8";
        Main.buffName[6] = "Mana Regeneration";
        Main.buffTip[6] = "Increased mana regeneration";
        Main.buffName[7] = "Magic Power";
        Main.buffTip[7] = "20% increased magic damage";
        Main.buffName[8] = "Featherfall";
        Main.buffTip[8] = "Press UP or DOWN to control speed of descent";
        Main.buffName[9] = "Spelunker";
        Main.buffTip[9] = "Shows the location of treasure and ore";
        Main.buffName[10] = "Invisibility";
        Main.buffTip[10] = "Grants invisibility";
        Main.buffName[11] = "Shine";
        Main.buffTip[11] = "Emitting light";
        Main.buffName[12] = "Night Owl";
        Main.buffTip[12] = "Increased night vision";
        Main.buffName[13] = "Battle";
        Main.buffTip[13] = "Increased enemy spawn rate";
        Main.buffName[14] = "Thorns";
        Main.buffTip[14] = "Attackers also take damage";
        Main.buffName[15] = "Water Walking";
        Main.buffTip[15] = "Press DOWN to enter water";
        Main.buffName[16] = "Archery";
        Main.buffTip[16] = "20% increased arrow damage and speed";
        Main.buffName[17] = "Hunter";
        Main.buffTip[17] = "Shows the location of enemies";
        Main.buffName[18] = "Gravitation";
        Main.buffTip[18] = "Press UP or DOWN to reverse gravity";
        Main.buffName[19] = "Orb of Light";
        Main.buffTip[19] = "A magical orb that provides light";
        Main.buffName[20] = "Poisoned";
        Main.buffTip[20] = "Slowly losing life";
        Main.buffName[21] = "Potion Sickness";
        Main.buffTip[21] = "Cannot consume anymore healing items";
        Main.buffName[22] = "Darkness";
        Main.buffTip[22] = "Decreased light vision";
        Main.buffName[23] = "Cursed";
        Main.buffTip[23] = "Cannot use any items";
        Main.buffName[24] = "On Fire!";
        Main.buffTip[24] = "Slowly losing life";
        Main.buffName[25] = "Tipsy";
        Main.buffTip[25] = "Increased melee abilities, lowered defense";
        Main.buffName[26] = "Well Fed";
        Main.buffTip[26] = "Minor improvements to all stats";
        Main.buffName[27] = "Fairy";
        Main.buffTip[27] = "A fairy is following you";
        Main.buffName[28] = "Werewolf";
        Main.buffTip[28] = "Physical abilities are increased";
        Main.buffName[29] = "Clairvoyance";
        Main.buffTip[29] = "Magic powers are increased";
        Main.buffName[30] = "Bleeding";
        Main.buffTip[30] = "Cannot regenerate life";
        Main.buffName[31] = "Confused";
        Main.buffTip[31] = "Movement is reversed";
        Main.buffName[32] = "Slow";
        Main.buffTip[32] = "Movement speed is reduced";
        Main.buffName[33] = "Weak";
        Main.buffTip[33] = "Physical abilities are decreased";
        Main.buffName[34] = "Merfolk";
        Main.buffTip[34] = "Can breathe and move easily underwater";
        Main.buffName[35] = "Silenced";
        Main.buffTip[35] = "Cannot use items that require mana";
        Main.buffName[36] = "Broken Armor";
        Main.buffTip[36] = "Defense is cut in half";
        Main.buffName[37] = "Horrified";
        Main.buffTip[37] = "You have seen something nasty, there is no escape.";
        Main.buffName[38] = "The Tongue";
        Main.buffTip[38] = "You are being sucked into the mouth";
        Main.buffName[39] = "Cursed Inferno";
        Main.buffTip[39] = "Losing life";
        Main.buffName[40] = "Pet Bunny";
        Main.buffTip[40] = "I think it wants your carrot";
        Main.tileName[13] = "Bottle";
        Main.tileName[14] = "Table";
        Main.tileName[15] = "Chair";
        Main.tileName[16] = "Anvil";
        Main.tileName[17] = "Furnace";
        Main.tileName[18] = "Work Bench";
        Main.tileName[26] = "Demon Altar";
        Main.tileName[77] = "Hellforge";
        Main.tileName[86] = "Loom";
        Main.tileName[94] = "Keg";
        Main.tileName[96] = "Cooking Pot";
        Main.tileName[101] = "Bookcase";
        Main.tileName[106] = "Sawmill";
        Main.tileName[114] = "Tinkerer's Workshop";
        Main.tileName[133] = "Adamantite Forge";
        Main.tileName[134] = "Mythril Anvil";
      }
      else if (Lang.lang == 2)
      {
        Lang.misc[0] = "Die Goblin-Armee wurde besiegt!";
        Lang.misc[1] = "Eine Goblin-Armee naehert sich von Westen!";
        Lang.misc[2] = "Eine Goblin-Armee naehert sich von Osten!";
        Lang.misc[3] = "Ein Goblin-Armee ist da!";
        Lang.misc[4] = "Der Frost Legion wurde besiegt!";
        Lang.misc[5] = "Der Frost ist Legion aus dem Westen näher!";
        Lang.misc[6] = "Der Frost ist Legion aus dem Osten näher!";
        Lang.misc[7] = "Der Frost Legion ist da!";
        Lang.misc[8] = "Der Blutmond steigt auf ...";
        Lang.misc[9] = "Du fuehlst dich von einer boesen Kraft beobachtet ...";
        Lang.misc[10] = "Eine Eiseskaelte steigt in dir hoch ...";
        Lang.misc[11] = "Du hoerst das Echo von Schreien um dich herum ...";
        Lang.misc[12] = "Deine Welt wurde mit Kobalt gesegnet!";
        Lang.misc[13] = "Deine Welt wurde mit Mithril gesegnet!";
        Lang.misc[14] = "Deine Welt wurde mit Adamantit gesegnet!";
        Lang.misc[15] = "Die uralten Geister des Lichts und der Finsternis wurden frei gelassen.";
        Lang.misc[16] = "ist aufgewacht!";
        Lang.misc[17] = "wurde besiegt!";
        Lang.misc[18] = "ist eingetroffen!";
        Lang.misc[19] = " wurde durch...";
        Lang.menu[0] = "Beginne eine neue Sitzung auf Terraria!";
        Lang.menu[1] = "Laeuft auf Port ";
        Lang.menu[2] = "Trennen";
        Lang.menu[3] = "Server benoetigt Passwort:";
        Lang.menu[4] = "Akzeptieren";
        Lang.menu[5] = "Zurueck";
        Lang.menu[6] = "Abbrechen";
        Lang.menu[7] = "Server-Passwort eingeben:";
        Lang.menu[8] = "Server startet...";
        Lang.menu[9] = "Laden fehlgeschlagen!";
        Lang.menu[10] = "Backup laden";
        Lang.menu[11] = "Kein Backup gefunden";
        Lang.menu[12] = "Einzelspieler";
        Lang.menu[13] = "Mehrspieler";
        Lang.menu[14] = "Einstellungen";
        Lang.menu[15] = "Beenden";
        Lang.menu[16] = "Charakter erstellen";
        Lang.menu[17] = "Loeschen";
        Lang.menu[18] = "Haar";
        Lang.menu[19] = "Augen";
        Lang.menu[20] = "Haut";
        Lang.menu[21] = "Kleidung";
        Lang.menu[22] = "Maennlich";
        Lang.menu[23] = "Weiblich";
        Lang.menu[24] = "Hardcore";
        Lang.menu[25] = "Mediumcore";
        Lang.menu[26] = "Softcore";
        Lang.menu[27] = "Zufaellig";
        Lang.menu[28] = "Erstellen";
        Lang.menu[29] = "Hardcore-Charaktere sterben fuers Gute";
        Lang.menu[30] = "Mediumcore-Charaktere lassen im Tod Items fallen";
        Lang.menu[31] = "Softcore-Charaktere lassen im Tod Geld fallen";
        Lang.menu[32] = "Schwierigkeitsgrad waehlen";
        Lang.menu[33] = "Hemd";
        Lang.menu[34] = "Unterhemd";
        Lang.menu[35] = "Hose";
        Lang.menu[36] = "Schuhe";
        Lang.menu[37] = "Haar";
        Lang.menu[38] = "Haarfarbe";
        Lang.menu[39] = "Augenfarbe";
        Lang.menu[40] = "Hautfarbe";
        Lang.menu[41] = "Hemdfarbe";
        Lang.menu[42] = "Unterhemdfarbe";
        Lang.menu[43] = "Hosenfarbe";
        Lang.menu[44] = "Schuhfarbe";
        Lang.menu[45] = "Charaktername eingeben:";
        Lang.menu[46] = "Loeschen";
        Lang.menu[47] = "Welt erschaffen";
        Lang.menu[48] = "Weltnamen eingeben:";
        Lang.menu[49] = "Zum Fenstermodus";
        Lang.menu[50] = "Zum Vollbildschirm";
        Lang.menu[51] = "Aufloesung";
        Lang.menu[52] = "Parallaxe";
        Lang.menu[53] = "Frameskip aus (nicht empfohlen)";
        Lang.menu[54] = "Frameskip an (empfohlen)";
        Lang.menu[55] = "Beleuchtung: Farbe";
        Lang.menu[56] = "Beleuchtung: Weiss";
        Lang.menu[57] = "Beleuchtung: Retro";
        Lang.menu[58] = "Beleuchtung: Flippig";
        Lang.menu[59] = "Qualitaet: Auto";
        Lang.menu[60] = "Qualitaet: Hoch";
        Lang.menu[61] = "Qualitaet: Mittel";
        Lang.menu[62] = "Qualitaet: Niedrig";
        Lang.menu[63] = "Video";
        Lang.menu[64] = "Zeigerfarbe";
        Lang.menu[65] = "Lautstaerke";
        Lang.menu[66] = "Steuerung";
        Lang.menu[67] = "Automat. sichern an";
        Lang.menu[68] = "Automat. sichern aus";
        Lang.menu[69] = "Automat. Pause an";
        Lang.menu[70] = "Automat. Pause aus";
        Lang.menu[71] = "Pickup-Text an";
        Lang.menu[72] = "Pickup-Text aus";
        Lang.menu[73] = "Vollbildschirm-Aufloesung";
        Lang.menu[74] = "Hoch                 ";
        Lang.menu[75] = "Hinunter             ";
        Lang.menu[76] = "Links                 ";
        Lang.menu[77] = "Rechts                ";
        Lang.menu[78] = "Springen             ";
        Lang.menu[79] = "Werfen               ";
        Lang.menu[80] = "Inventar              ";
        Lang.menu[81] = "Schnellheilung       ";
        Lang.menu[82] = "Schnelles Mana     ";
        Lang.menu[83] = "Schneller Buff       ";
        Lang.menu[84] = "Entern                ";
        Lang.menu[85] = "Automat. Auswahl    ";
        Lang.menu[86] = "Auf Standard zuruecksetzen";
        Lang.menu[87] = "Mitmachen";
        Lang.menu[88] = "Hosten & Spielen";
        Lang.menu[89] = "Server-IP-Adresse eingeben:";
        Lang.menu[90] = "Server-Port eingeben:";
        Lang.menu[91] = "Weltgroesse waehlen:";
        Lang.menu[92] = "Klein";
        Lang.menu[93] = "Mittel";
        Lang.menu[94] = "Gross";
        Lang.menu[95] = "Rot:";
        Lang.menu[96] = "Gruen:";
        Lang.menu[97] = "Blau:";
        Lang.menu[98] = "Sound:";
        Lang.menu[99] = "Musik:";
        Lang.menu[100] = "Hintergrund On";
        Lang.menu[101] = "Hintergrund Off";
        Lang.menu[102] = "Wählen Sie die Sprache";
        Lang.menu[103] = "Sprache";
        Lang.menu[104] = "Ja";
        Lang.menu[105] = "Nicht";
        Lang.gen[0] = "Generieren des Weltgelaendes:";
        Lang.gen[1] = "Sand wird hinzugefuegt  ...";
        Lang.gen[2] = "Huegel werden generiert ...";
        Lang.gen[3] = "Dreck wird hinter Dreck geschoben:";
        Lang.gen[4] = "Felsen werden in den Dreck gesetzt ...";
        Lang.gen[5] = "Dreck wird in Felsen platziert ...";
        Lang.gen[6] = "Lehm wird hinzugefuegt ...";
        Lang.gen[7] = "Loecher werden zufaellig geschaffen:";
        Lang.gen[8] = "Generieren kleiner Hoehlen:";
        Lang.gen[9] = "Generieren grosser Hoehlen:";
        Lang.gen[10] = "Hoehlenoberflaechen werden generiert...";
        Lang.gen[11] = "Generieren des Dschungels:";
        Lang.gen[12] = "Schwimmende Inseln werden generiert ...";
        Lang.gen[13] = "Pilzflecken werden generiert ...";
        Lang.gen[14] = "Schlamm wird in Dreck gefuegt ...";
        Lang.gen[15] = "Schlick wird hinzugefuegt ...";
        Lang.gen[16] = "Glitzer wird hinzugefuegt ...";
        Lang.gen[17] = "Spinnweben werden hinzugefuegt ...";
        Lang.gen[18] = "Erstellen der Unterwelt:";
        Lang.gen[19] = "Gewaesser wird hinzugefuegt:";
        Lang.gen[20] = "Macht die Welt boese:";
        Lang.gen[21] = "Berghoehlen werden generiert ...";
        Lang.gen[22] = "Straende werden erstellt ...";
        Lang.gen[23] = "Edelsteine werden hinzugefuegt ...";
        Lang.gen[24] = "Gravitieren von Sand:";
        Lang.gen[25] = "Reinigung von Dreckhintergrund:";
        Lang.gen[26] = "Platzieren von Altaren:";
        Lang.gen[27] = "Gewaesser verteilen:";
        Lang.gen[28] = "Lebenskristalle platzieren:";
        Lang.gen[29] = "Platzieren von Statuen:";
        Lang.gen[30] = "Verstecken von Schaetzen:";
        Lang.gen[31] = "Verstecken von mehr Schaetzen:";
        Lang.gen[32] = "Verstecken von Dschungelschaetzen:";
        Lang.gen[33] = "Verstecken von Wasserschaetzen:";
        Lang.gen[34] = "Platzieren von Fallen:";
        Lang.gen[35] = "Platzieren von Zerbrechlichem:";
        Lang.gen[36] = "Platzieren von Hoellenschmieden:";
        Lang.gen[37] = "Gras wird verteilt ...";
        Lang.gen[38] = "Kakteen wachsen ...";
        Lang.gen[39] = "Sonnenblumen werden gepflanzt ...";
        Lang.gen[40] = "Baeume werden gepflanzt ...";
        Lang.gen[41] = "Kraeuter werden gepflanzt ...";
        Lang.gen[42] = "Unkraut wird gepflanzt ...";
        Lang.gen[43] = "Wein wird angebaut ...";
        Lang.gen[44] = "Blumen werden gepflanzt ...";
        Lang.gen[45] = "Pilze werden gesaet ...";
        Lang.gen[46] = "Ungenutzte Ressourcen werden freigesetzt:";
        Lang.gen[47] = "Spielobjekte werden zurueckgesetzt:";
        Lang.gen[48] = "Schwerer Modus wird eingestellt ...";
        Lang.gen[49] = "Weltdaten werden gesichert:";
        Lang.gen[50] = "Backup von Weltdatei wird erstellt ...";
        Lang.gen[51] = "Weltdaten werden geladen:";
        Lang.gen[52] = "Ueberpruefen der Feld-Ausrichtung:";
        Lang.gen[53] = "Laden fehlgeschlagen!";
        Lang.gen[54] = "Kein Backup gefunden.";
        Lang.gen[55] = "Suchen von Feld-Frames:";
        Lang.gen[56] = "Hinzufügen Schnee ...";
        Lang.gen[57] = "Welt";
        Lang.gen[58] = "Erstellen Verlies:";
        Lang.gen[59] = "Ein Meteorit ist gelandet!";
        Lang.inter[0] = "Leben:";
        Lang.inter[1] = "Atem";
        Lang.inter[2] = "Mana";
        Lang.inter[3] = "Muelleimer";
        Lang.inter[4] = "Inventar";
        Lang.inter[5] = "Hotbar entriegelt";
        Lang.inter[6] = "Hotbar gesperrt";
        Lang.inter[7] = "Behausung";
        Lang.inter[8] = "Behausungsanfrage";
        Lang.inter[9] = "Zusaetze";
        Lang.inter[10] = "Abwehr";
        Lang.inter[11] = "Sozial";
        Lang.inter[12] = "Helm";
        Lang.inter[13] = "Hemd";
        Lang.inter[14] = "Hose";
        Lang.inter[15] = "platin";
        Lang.inter[16] = "gold";
        Lang.inter[17] = "silber";
        Lang.inter[18] = "kupfer";
        Lang.inter[19] = "Nachschmieden";
        Lang.inter[20] = "Zum Nachschmieden Item hier platzieren";
        Lang.inter[21] = "Anzeige von Rezepten mit Verwendung von";
        Lang.inter[22] = "Erforderliche Objekte:";
        Lang.inter[23] = "Keins";
        Lang.inter[24] = "Bitte Material hier platzieren, um Rezepte zu zeigen";
        Lang.inter[25] = "Herstellen";
        Lang.inter[26] = "Muenzen";
        Lang.inter[27] = "Munition";
        Lang.inter[28] = "Geschaeft";
        Lang.inter[29] = "Alle ausraeumen";
        Lang.inter[30] = "Alle ablegen";
        Lang.inter[31] = "Schnellstapeln";
        Lang.inter[32] = "Sparschwein";
        Lang.inter[33] = "Tresor";
        Lang.inter[34] = "Zeit:";
        Lang.inter[35] = "Speichern & Beenden";
        Lang.inter[36] = "Trennen";
        Lang.inter[37] = "Artikel";
        Lang.inter[38] = "Du wurdest getoetet ...";
        Lang.inter[39] = "Diese Behausung ist geeignet.";
        Lang.inter[40] = "Das ist keine zulaessiges Behausung";
        Lang.inter[41] = "Diese Behausung ist bereits belegt.";
        Lang.inter[42] = "Diese Behausung ist beschaedigt.";
        Lang.inter[43] = "Zeitueberschreitung bei Verbindung";
        Lang.inter[44] = "Felddaten werden empfangen";
        Lang.inter[45] = "Ausrüsten";
        Lang.inter[46] = "Kosten";
        Lang.inter[47] = "Sparen";
        Lang.inter[48] = "Bearbeiten";
        Lang.inter[49] = "Status";
        Lang.inter[50] = "Fluch";
        Lang.inter[51] = "Hilfe";
        Lang.inter[52] = "in der Nähe";
        Lang.inter[53] = "Wasser";
        Lang.inter[54] = "Heilen";
        Lang.tip[1] = "Keine Werte werden gewonnen";
        Lang.tip[2] = " Nahkampfschaden";
        Lang.tip[3] = " Fernkampfschaden";
        Lang.tip[4] = " Magischer Schaden";
        Lang.tip[5] = "% kritische Trefferchance";
        Lang.tip[6] = "Wahnsinnig schnell";
        Lang.tip[7] = "Sehr schnell";
        Lang.tip[8] = "Schnell";
        Lang.tip[9] = "Durchschnittlich ";
        Lang.tip[10] = "Langsam";
        Lang.tip[11] = "Sehr langsam";
        Lang.tip[12] = "Extrem langsam";
        Lang.tip[13] = "Schneckentempo";
        Lang.tip[14] = "Kein Rueckstoss";
        Lang.tip[15] = "Extrem schwacher Rueckstoss";
        Lang.tip[16] = "Sehr schwacher Rueckstoss";
        Lang.tip[17] = "Schwacher Rueckstoss";
        Lang.tip[18] = "Mittlerer Rueckstoss";
        Lang.tip[19] = "Starker Rueckstoss";
        Lang.tip[20] = "Sehr starker Rueckstoss";
        Lang.tip[21] = "Extrem starker Rueckstoss";
        Lang.tip[22] = "Wahnsinniger Rueckstoss";
        Lang.tip[23] = "Ausruestbar";
        Lang.tip[24] = "Mode-Items";
        Lang.tip[25] = " Abwehr";
        Lang.tip[26] = "% Spitzhackenkraft";
        Lang.tip[27] = "% Axtmachtkraft";
        Lang.tip[28] = "% Hammerkraft";
        Lang.tip[29] = "Stellt";
        Lang.tip[30] = "Leben wieder her";
        Lang.tip[31] = "Mana wieder her";
        Lang.tip[32] = "Verwendet";
        Lang.tip[33] = "Kann platziert werden";
        Lang.tip[34] = "Munition";
        Lang.tip[35] = "Verbrauchbar";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " Minuten Dauer";
        Lang.tip[38] = " Sekunden Dauer";
        Lang.tip[39] = "% Schaden";
        Lang.tip[40] = "% Tempo";
        Lang.tip[41] = "% kritische Trefferchance";
        Lang.tip[42] = "% Manakosten";
        Lang.tip[43] = "% Groesse";
        Lang.tip[44] = "% Projektiltempo";
        Lang.tip[45] = "% Rueckstoss";
        Lang.tip[46] = "% Bewegungstempo";
        Lang.tip[47] = "% Nahkampftempo";
        Lang.tip[48] = "Bonus-Set:";
        Lang.tip[49] = "Verkaufspreis:";
        Lang.tip[50] = "Kaufpreis:";
        Lang.tip[51] = "Kein Wert";
        Lang.mp[1] = "Falsches Passwort.";
        Lang.mp[2] = "Ungueltige Operation in diesem Zustand.";
        Lang.mp[3] = "Auf diesem Server bist du gesperrt.";
        Lang.mp[4] = "Du verwendest nicht die gleiche Version wie der Server.";
        Lang.mp[5] = "ist bereits auf diesem Server.";
        Lang.mp[5] = "is already on this server.";
        Lang.mp[6] = "/spielen";
        Lang.mp[7] = "Aktuelle Spieler:";
        Lang.mp[8] = "/wuerfeln";
        Lang.mp[9] = "wuerfelt eine";
        Lang.mp[10] = "Du bist in keiner Gruppe!";
        Lang.mp[11] = "hat PvP aktiviert!";
        Lang.mp[12] = "hat PvP deaktiviert!";
        Lang.mp[13] = "ist in keiner Gruppe mehr.";
        Lang.mp[14] = "ist der roten Gruppe beigetreten.";
        Lang.mp[15] = "ist der gruenen Gruppe beigetreten.";
        Lang.mp[16] = "ist der blauen Gruppe beigetreten.";
        Lang.mp[17] = "ist der gelben Gruppe beigetreten.";
        Lang.mp[18] = "Willkommen in";
        Lang.mp[19] = "beigetreten.";
        Lang.mp[20] = "beenden.";
        Lang.the = "der ";
        Lang.dt[0] = "konnte das Antidot nicht finden";
        Lang.dt[1] = "konnte das Feuer nicht loeschen";
        Main.buffName[1] = "Obsidianhaut";
        Main.buffTip[1] = "Immun gegen Lava";
        Main.buffName[2] = "Wiederbelebung";
        Main.buffTip[2] = "Belebt wieder";
        Main.buffName[3] = "Wendigkeit";
        Main.buffTip[3] = "Erhoeht Bewegungstempo um 25%";
        Main.buffName[4] = "Kiemen";
        Main.buffTip[4] = "Wasser statt Luft atmen";
        Main.buffName[5] = "Eisenhaut";
        Main.buffTip[5] = "Erhoeht die Abwehr um 8";
        Main.buffName[6] = "Mana-Wiederherstellung";
        Main.buffTip[6] = "Erhoehte Mana-Wiederherstellung";
        Main.buffName[7] = "Magiekraft";
        Main.buffTip[7] = "Erhoeht magischen Schaden um 20%";
        Main.buffName[8] = "Federsturz";
        Main.buffTip[8] = "Zur Kontrolle der Sinkgeschwindigkeit UP oder DOWN druecken ";
        Main.buffName[9] = "Hoehlenforscher";
        Main.buffTip[9] = "Zeigt den Fundort von Schatz und Erz";
        Main.buffName[10] = "Unsichtbarkeit";
        Main.buffTip[10] = "Macht unsichtbar";
        Main.buffName[11] = "Glanz";
        Main.buffTip[11] = "Strahlt Licht aus";
        Main.buffName[12] = "Nachteule";
        Main.buffTip[12] = "Erhoehte Nachtsicht";
        Main.buffName[13] = "Kampf";
        Main.buffTip[13] = "Erhoehte Feind-Spawnrate";
        Main.buffName[14] = "Dornen";
        Main.buffTip[14] = "Auch die Angreifer erleiden Schaden";
        Main.buffName[15] = "Wasserlaufen";
        Main.buffTip[15] = "DOWN druecken, um aufs Wasser zu gehen";
        Main.buffName[16] = "Bogenschiessen";
        Main.buffTip[16] = "Um 20% erhoehter Pfeilschaden und -tempo";
        Main.buffName[17] = "Jaeger";
        Main.buffTip[17] = "Zeigt die Position von Feinden";
        Main.buffName[18] = "Gravitation";
        Main.buffTip[18] = "Zum Umkehren der Schwerkraft UP oder DOWN druecken";
        Main.buffName[19] = "Lichtkugel";
        Main.buffTip[19] = "Eine magische Kugel, die Licht verstroemt";
        Main.buffName[20] = "Vergiftet";
        Main.buffTip[20] = "Langsam entweicht das Leben";
        Main.buffName[21] = "Krankheitstrank";
        Main.buffTip[21] = "Kann keine Heil-Items mehr verbrauchen";
        Main.buffName[22] = "Dunkelheit";
        Main.buffTip[22] = "Schlechtere Sicht durch weniger Licht";
        Main.buffName[23] = "Verflucht";
        Main.buffTip[23] = "Kann keine Items verwenden";
        Main.buffName[24] = "Flammenmeer!";
        Main.buffTip[24] = "Langsam entweicht das Leben";
        Main.buffName[25] = "Beschwipst";
        Main.buffTip[25] = "Erhoehte Nahkampffaehigkeiten, verminderte Abwehr";
        Main.buffName[26] = "Kleine Staerkung";
        Main.buffTip[26] = "Geringe Anhebung aller Werte";
        Main.buffName[27] = "Fee";
        Main.buffTip[27] = "Eine Fee folgt dir";
        Main.buffName[28] = "Werwolf";
        Main.buffTip[28] = "Koerperliche Faehigkeiten sind gestiegen";
        Main.buffName[29] = "Hellsehen";
        Main.buffTip[29] = "Magiekraefte werden erhoeht";
        Main.buffName[30] = "Blutung";
        Main.buffTip[30] = "Kann nicht wiederbeleben";
        Main.buffName[31] = "Verwirrt";
        Main.buffTip[31] = "Bewegung wird umgekehrt";
        Main.buffName[32] = "Langsam";
        Main.buffTip[32] = "Bewegungen werden verlangsamt";
        Main.buffName[33] = "Schwach";
        Main.buffTip[33] = "Koerperliche Faehigkeiten sind gesunken";
        Main.buffName[34] = "Meermenschen";
        Main.buffTip[34] = "Kann atmen und  sich leicht unter Wasser bewegen";
        Main.buffName[35] = "Schweigen";
        Main.buffTip[35] = "Nicht verwenden können Gegenstände, die Mana benötigen";
        Main.buffName[36] = "Kaputte Ruestung";
        Main.buffTip[36] = "Die Abwehr ist halbiert worden";
        Main.buffName[37] = "Entsetzt";
        Main.buffTip[37] = "Du hast etwas Ekliges gesehen, es gibt kein Entrinnen.";
        Main.buffName[38] = "Die Zunge";
        Main.buffTip[38] = "Du wirst ins Maul eingesaugt";
        Main.buffName[39] = "Verfluchtes Inferno";
        Main.buffTip[39] = "Das Leben entweicht";
        Main.buffName[40] = "Haustierhäschen";
        Main.buffTip[40] = "Ich denke, sie will deine Karotte";
        Main.tileName[13] = "Flasche";
        Main.tileName[14] = "Tabelle";
        Main.tileName[15] = "Stuhl";
        Main.tileName[16] = "Amboss";
        Main.tileName[17] = "Ofen";
        Main.tileName[18] = "Werkbank";
        Main.tileName[26] = "Dämon Altar";
        Main.tileName[77] = "Hoellenschmiede";
        Main.tileName[86] = "Webstuhl";
        Main.tileName[94] = "Gaerbottich";
        Main.tileName[96] = "Kochtopf";
        Main.tileName[101] = "Buecherregal";
        Main.tileName[106] = "Saegewerk";
        Main.tileName[114] = "Tueftler-Werkstatt";
        Main.tileName[133] = "Adamantitschmiede";
        Main.tileName[134] = "Mithrilamboss";
      }
      else if (Lang.lang == 3)
      {
        Lang.misc[0] = "L'esercito di goblin è stato sconfitto! ";
        Lang.misc[1] = "Un esercito di goblin si sta avvicinando da ovest!";
        Lang.misc[2] = "Un esercito di goblin si sta avvicinando da est!";
        Lang.misc[3] = "Un esercito di goblin è arrivato!";
        Lang.misc[4] = "La Legione di Frost è stato sconfitto!";
        Lang.misc[5] = "La Legione gelo si sta avvicinando da ovest!";
        Lang.misc[6] = "La Legione gelo si sta avvicinando da est!";
        Lang.misc[7] = "La Legione gelo è arrivato!";
        Lang.misc[8] = "La luna di sangue sta sorgendo...";
        Lang.misc[9] = "Senti una presenza malvagia che ti sta guardando...";
        Lang.misc[10] = "Un freddo terribile ti attraversa la spina dorsale...";
        Lang.misc[11] = "Intorno a te echeggiano urla... ";
        Lang.misc[12] = "Il tuo mondo è stato benedetto con cobalto! ";
        Lang.misc[13] = "Il tuo mondo è stato benedetto con mitrilio! ";
        Lang.misc[14] = "Il tuo mondo è stato benedetto con adamantio!";
        Lang.misc[15] = "I vecchi spiriti di luce e tenebre sono stati liberati.  ";
        Lang.misc[16] = "si è svegliato!";
        Lang.misc[17] = "è stato sconfitto!";
        Lang.misc[18] = "è arrivato!";
        Lang.misc[19] = " è stato ucciso...";
        Lang.menu[0] = "Inizia una nuova istanza di Terraria!";
        Lang.menu[1] = "In esecuzione sulla porta";
        Lang.menu[2] = "Disconnetti";
        Lang.menu[3] = "Il server richiede una password:";
        Lang.menu[4] = "Accetta";
        Lang.menu[5] = "Indietro";
        Lang.menu[6] = "Annulla";
        Lang.menu[7] = "Inserisci la password del server:";
        Lang.menu[8] = "Avvio del server...";
        Lang.menu[9] = "Caricamento non riuscito!";
        Lang.menu[10] = "Carica backup";
        Lang.menu[11] = "Backup non trovato";
        Lang.menu[12] = "Giocatore singolo";
        Lang.menu[13] = "Multigiocatore";
        Lang.menu[14] = "Impostazioni";
        Lang.menu[15] = "Esci";
        Lang.menu[16] = "Crea personaggio";
        Lang.menu[17] = "Elimina";
        Lang.menu[18] = "Capelli";
        Lang.menu[19] = "Occhi";
        Lang.menu[20] = "Pelle";
        Lang.menu[21] = "Abiti";
        Lang.menu[22] = "Maschio";
        Lang.menu[23] = "Femmina";
        Lang.menu[24] = "Harcore";
        Lang.menu[25] = "Mediumcore ";
        Lang.menu[26] = "Softcore ";
        Lang.menu[27] = "Casuale";
        Lang.menu[28] = "Crea";
        Lang.menu[29] = "I personaggi hardcore muoiono definitivamente";
        Lang.menu[30] = "I personaggi mediumcore perdono oggetti morendo";
        Lang.menu[31] = "I personaggi softcore perdono denaro morendo";
        Lang.menu[32] = "Livello di difficoltà";
        Lang.menu[33] = "Camicia";
        Lang.menu[34] = "Maglietta";
        Lang.menu[35] = "Pantaloni";
        Lang.menu[36] = "Scarpe";
        Lang.menu[37] = "Capelli";
        Lang.menu[38] = "Colore capelli";
        Lang.menu[39] = "Colore occhi";
        Lang.menu[40] = "Colore pelle";
        Lang.menu[41] = "Colore camicia";
        Lang.menu[42] = "Colore maglietta";
        Lang.menu[43] = "Colore pantaloni";
        Lang.menu[44] = "Colore scarpe";
        Lang.menu[45] = "Inserisci nome personaggio:";
        Lang.menu[46] = "Elimina";
        Lang.menu[47] = "Crea mondo";
        Lang.menu[48] = "Inserisci nome mondo:";
        Lang.menu[49] = "Finestra";
        Lang.menu[50] = "Schermo intero";
        Lang.menu[51] = "Risoluzione";
        Lang.menu[52] = "Parallasse";
        Lang.menu[53] = "Salta fotogrammi Off (sconsigliato)";
        Lang.menu[54] = "Salta fotogrammi On (consigliato)";
        Lang.menu[55] = "Illuminazione: a colori ";
        Lang.menu[56] = "Illuminazione: bianca";
        Lang.menu[57] = "Illuminazione: retro";
        Lang.menu[58] = "Illuminazione: speciale";
        Lang.menu[59] = "Qualità: automatica";
        Lang.menu[60] = "Qualità: alta";
        Lang.menu[61] = "Qualità: media";
        Lang.menu[62] = "Qualità: bassa";
        Lang.menu[63] = "Video";
        Lang.menu[64] = "Colore cursore";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "Comandi";
        Lang.menu[67] = "Salvataggio automatico On";
        Lang.menu[68] = "Salvataggio automatico Off";
        Lang.menu[69] = "Pausa automatica On";
        Lang.menu[70] = "Pausa automatica Off";
        Lang.menu[71] = "Testo di collegamento On";
        Lang.menu[72] = "Testo di collegamento Off";
        Lang.menu[73] = "Risoluzione a schermo intero";
        Lang.menu[74] = "Su                      ";
        Lang.menu[75] = "Giù                     ";
        Lang.menu[76] = "Sinistra                 ";
        Lang.menu[77] = "Destra                  ";
        Lang.menu[78] = "Salta                    ";
        Lang.menu[79] = "Lancia                   ";
        Lang.menu[80] = "Inventario               ";
        Lang.menu[81] = "Cura veloce             ";
        Lang.menu[82] = "Mana veloce            ";
        Lang.menu[83] = "Buff veloce             ";
        Lang.menu[84] = "Rampino                 ";
        Lang.menu[85] = "Selezione automatica   ";
        Lang.menu[86] = "Ripristina predefiniti";
        Lang.menu[87] = "Entra";
        Lang.menu[88] = "Ospita e gioca";
        Lang.menu[89] = "Inserisci indirizzo IP del server:";
        Lang.menu[90] = "Inserisci porta server:";
        Lang.menu[91] = "Scegli grandezza del mondo:";
        Lang.menu[92] = "Piccolo";
        Lang.menu[93] = "Medio";
        Lang.menu[94] = "Grande";
        Lang.menu[95] = "Rosso:";
        Lang.menu[96] = "Verde:";
        Lang.menu[97] = "Blu:";
        Lang.menu[98] = "Audio:";
        Lang.menu[99] = "Musica:";
        Lang.menu[100] = "Sfondo su";
        Lang.menu[101] = "Fondo off";
        Lang.menu[102] = "Selezionare la lingua";
        Lang.menu[103] = "Lingua";
        Lang.menu[104] = "Sì";
        Lang.menu[105] = "No";
        Lang.gen[0] = "Crea terreno del mondo:";
        Lang.gen[1] = "Aggiunta sabbia...";
        Lang.gen[2] = "Creazione colline...";
        Lang.gen[3] = "Aggiungi terra dietro la terra:";
        Lang.gen[4] = "Aggiunta rocce nella terra...";
        Lang.gen[5] = "Aggiunta terra nelle rocce...";
        Lang.gen[6] = "Aggiunta argilla...";
        Lang.gen[7] = "Crea fori casuali:";
        Lang.gen[8] = "Crea piccole grotte: ";
        Lang.gen[9] = "Crea grandi grotte:";
        Lang.gen[10] = "Creazione di grotte superficiali...";
        Lang.gen[11] = "Crea giungla:";
        Lang.gen[12] = "Creazione di isole galleggianti...";
        Lang.gen[13] = "Aggiunta campi di funghi...";
        Lang.gen[14] = "Aggiunta fango nella terra...";
        Lang.gen[15] = "Aggiunta fango...";
        Lang.gen[16] = "Aggiunta elementi luminosi...";
        Lang.gen[17] = "Aggiunta ragnatele...";
        Lang.gen[18] = "Crea sottomondo:";
        Lang.gen[19] = "Aggiungi creature acquatiche:";
        Lang.gen[20] = "Rendi il mondo malvagio:";
        Lang.gen[21] = "Creazione grotte montuose...";
        Lang.gen[22] = "Creazione spiagge...";
        Lang.gen[23] = "Aggiunta gemme...";
        Lang.gen[24] = "Ruota sabbia:";
        Lang.gen[25] = "Pulisci sfondi terra:";
        Lang.gen[26] = "Aggiungi altari:";
        Lang.gen[27] = "Versa liquidi:";
        Lang.gen[28] = "Aggiungi cristalli di vita:";
        Lang.gen[29] = "Aggiungi statue:";
        Lang.gen[30] = "Nascondi tesori:";
        Lang.gen[31] = "Nascondi più tesori:";
        Lang.gen[32] = "Nascondi tesori nella giungla:";
        Lang.gen[33] = "Nascondi tesori in acqua:";
        Lang.gen[34] = "Disponi trappole:";
        Lang.gen[35] = "Disponi gli oggetti fragili:";
        Lang.gen[36] = "Disponi creazioni degli inferi:";
        Lang.gen[37] = "Estensione erba...";
        Lang.gen[38] = "Crescita cactus...";
        Lang.gen[39] = "Pianta girasoli...";
        Lang.gen[40] = "Pianta alberi...";
        Lang.gen[41] = "Pianta erbe...";
        Lang.gen[42] = "Pianta erbacce...";
        Lang.gen[43] = "Crescita viti...";
        Lang.gen[44] = "Pianta fiori...";
        Lang.gen[45] = "Pianta funghi...";
        Lang.gen[46] = "Libera risorse inutilizzate:";
        Lang.gen[47] = "Resetta oggetti di gioco:";
        Lang.gen[48] = "Imposta modalità difficile...";
        Lang.gen[49] = "Salva dati del mondo:";
        Lang.gen[50] = "Backup file mondo...";
        Lang.gen[51] = "Carica dati del mondo:";
        Lang.gen[52] = "Controlla l'allineamento delle mattonelle:";
        Lang.gen[53] = "Caricamento non riuscito!";
        Lang.gen[54] = "Backup non trovato";
        Lang.gen[55] = "Trova cornici delle mattonelle:";
        Lang.gen[56] = "L'aggiunta di neve ...";
        Lang.gen[57] = "Mondo";
        Lang.gen[58] = "La creazione di dungeon:";
        Lang.gen[59] = "Un meteorite è atterrato!";
        Lang.inter[0] = "Vita:";
        Lang.inter[1] = "Respiro";
        Lang.inter[2] = "Mana ";
        Lang.inter[3] = "Bidone";
        Lang.inter[4] = "Inventario";
        Lang.inter[5] = "Hotbar sbloccato";
        Lang.inter[6] = "Hotbar bloccato";
        Lang.inter[7] = "Alloggio";
        Lang.inter[8] = "Richiesta alloggio";
        Lang.inter[9] = "Accessori";
        Lang.inter[10] = "Difesa";
        Lang.inter[11] = "Sociale";
        Lang.inter[12] = "Casco";
        Lang.inter[13] = "Camicia";
        Lang.inter[14] = "Pantaloni";
        Lang.inter[15] = "platino";
        Lang.inter[16] = "oro";
        Lang.inter[17] = "argento";
        Lang.inter[18] = "rame";
        Lang.inter[19] = "Riforgiare";
        Lang.inter[20] = "Posizionare un oggetto qui per riforgiare";
        Lang.inter[21] = "Mostra ricetta da usare";
        Lang.inter[22] = "Oggetti richiesti:";
        Lang.inter[23] = "Nessuno";
        Lang.inter[24] = "Posizionare un materiale qui per mostrare ricette";
        Lang.inter[25] = "Artigianato";
        Lang.inter[26] = "Monete";
        Lang.inter[27] = "Munizioni";
        Lang.inter[28] = "Negozio";
        Lang.inter[29] = "Saccheggia tutto";
        Lang.inter[30] = "Deposita tutto";
        Lang.inter[31] = "Accumulo veloce";
        Lang.inter[32] = "Salvadanaio";
        Lang.inter[33] = "Caveau";
        Lang.inter[34] = "Tempo:";
        Lang.inter[35] = "Salva ed esci";
        Lang.inter[36] = "Disconnetti";
        Lang.inter[37] = "Oggetti";
        Lang.inter[38] = "Sei morto...";
        Lang.inter[39] = "Questo alloggio è adatto.";
        Lang.inter[40] = "Questo alloggio non è valido.";
        Lang.inter[41] = "Questo alloggio è già occupato.";
        Lang.inter[42] = "Questo alloggio è distrutto.";
        Lang.inter[43] = "Connessione scaduta";
        Lang.inter[44] = "Ricezione dati mattonella";
        Lang.inter[45] = "Equipaggiare";
        Lang.inter[46] = "Costo";
        Lang.inter[47] = "Salvare";
        Lang.inter[48] = "Edit";
        Lang.inter[49] = "Stato";
        Lang.inter[50] = "Maledizione";
        Lang.inter[51] = "Aiutare";
        Lang.inter[52] = "Chiudere";
        Lang.inter[53] = "Acqua";
        Lang.inter[54] = "Guarire";
        Lang.tip[0] = "Equipaggiato in slot sociale";
        Lang.tip[1] = "Nessun parametro incrementato";
        Lang.tip[2] = " Danno nel corpo a corpo";
        Lang.tip[3] = " Danno a distanza";
        Lang.tip[4] = " Danno magico";
        Lang.tip[5] = "% Possibilità colpo critico";
        Lang.tip[6] = "Velocità matta";
        Lang.tip[7] = "Extra velocità";
        Lang.tip[8] = "Alta velocità";
        Lang.tip[9] = "Media velocità";
        Lang.tip[10] = "Bassa velocità";
        Lang.tip[11] = "Velocità molto bassa";
        Lang.tip[12] = "Velocità extra bassa";
        Lang.tip[13] = "Velocità lumaca";
        Lang.tip[14] = "Nessuno spintone";
        Lang.tip[15] = "Spintone extra debole";
        Lang.tip[16] = "Spintone molto debole";
        Lang.tip[17] = "Spintone debole";
        Lang.tip[18] = "Spintone medio";
        Lang.tip[19] = "Spintone forte";
        Lang.tip[20] = "Spintone molto forte";
        Lang.tip[21] = "Spintone extra forte";
        Lang.tip[22] = "Spintone matto";
        Lang.tip[23] = "Equipaggiabili";
        Lang.tip[24] = "Oggetti estetici";
        Lang.tip[25] = " Difesa";
        Lang.tip[26] = "% Potenza piccone";
        Lang.tip[27] = "% Potenza ascia";
        Lang.tip[28] = "% Potenza martello";
        Lang.tip[29] = "Risana";
        Lang.tip[30] = "vita";
        Lang.tip[31] = "mana";
        Lang.tip[32] = "Utilizza";
        Lang.tip[33] = "Può essere posizionato";
        Lang.tip[34] = "Munizioni";
        Lang.tip[35] = "Consumabile";
        Lang.tip[36] = "Materiale";
        Lang.tip[37] = " Durata minuto";
        Lang.tip[38] = " Durata secondo";
        Lang.tip[39] = "% Danno";
        Lang.tip[40] = "% Velocità";
        Lang.tip[41] = "% Possibilità colpo critico";
        Lang.tip[42] = "% Costo mana";
        Lang.tip[43] = "% Dimensione";
        Lang.tip[44] = "% Velocità del proiettile";
        Lang.tip[45] = "% Spintone";
        Lang.tip[46] = "% Velocità movimento";
        Lang.tip[47] = "% Velocità corpo a corpo";
        Lang.tip[48] = "Imposta bonus:";
        Lang.tip[49] = "Prezzo di vendita:";
        Lang.tip[50] = "Prezzo di acquisto:";
        Lang.tip[51] = "Nessun valore";
        Lang.mp[0] = "Ricevere:";
        Lang.mp[1] = "Password errata.";
        Lang.mp[2] = "Operazione non valida in questo stato.";
        Lang.mp[3] = "Sei stato bandito da questo server.";
        Lang.mp[4] = "Non stai utilizzando la stessa versione del server.";
        Lang.mp[5] = "è già su questo server.";
        Lang.mp[6] = "/in gioco";
        Lang.mp[7] = "Giocatori correnti:";
        Lang.mp[8] = "/lancia";
        Lang.mp[9] = "lancia";
        Lang.mp[10] = "Non fai parte di un gruppo!";
        Lang.mp[11] = "ha attivato il PvP!";
        Lang.mp[12] = "ha disattivato il PvP!";
        Lang.mp[13] = "non è più in un gruppo.";
        Lang.mp[14] = "si è unito al gruppo rosso.";
        Lang.mp[15] = "si è unito al gruppo verde.";
        Lang.mp[16] = "si è unito al gruppo blu.";
        Lang.mp[17] = "si è unito al gruppo giallo.";
        Lang.mp[18] = "Benevenuto a";
        Lang.mp[19] = "ha aderito.";
        Lang.mp[20] = "ha smesso di.";
        Lang.the = "la ";
        Lang.dt[0] = "non ha trovato l'antidoto";
        Lang.dt[1] = "non ha spento il fuoco";
        Main.buffName[1] = "Pelle ossidiana";
        Main.buffTip[1] = "Immune alla lava";
        Main.buffName[2] = "Rigenerazione";
        Main.buffTip[2] = "Rigenera la vita";
        Main.buffName[3] = "Velocità";
        Main.buffTip[3] = "Velocità di movimento aumentata del 25%";
        Main.buffName[4] = "Branchie";
        Main.buffTip[4] = "Respira acqua invece di aria";
        Main.buffName[5] = "Pelle di ferro";
        Main.buffTip[5] = "Aumenta la difesa di 8";
        Main.buffName[6] = "Rigenerazione mana";
        Main.buffTip[6] = "Aumenta la rigenerazione del mana";
        Main.buffName[7] = "Potere magico";
        Main.buffTip[7] = "Danno magico aumentato del 20%";
        Main.buffName[8] = "Cascata di piume";
        Main.buffTip[8] = "Premi UP o DOWN per controllare la velocità di discesa";
        Main.buffName[9] = "Speleologo";
        Main.buffTip[9] = "Mostra l'ubicazione di tesori e minerale";
        Main.buffName[10] = "Invisibilità";
        Main.buffTip[10] = "Rende invisibili";
        Main.buffName[11] = "Brillantezza";
        Main.buffTip[11] = "Emette luce";
        Main.buffName[12] = "Civetta notturna";
        Main.buffTip[12] = "Visione notturna aumentata";
        Main.buffName[13] = "Battaglia";
        Main.buffTip[13] = "Ritmo generazione nemici aumentato";
        Main.buffName[14] = "Spine";
        Main.buffTip[14] = "Anche gli aggressori subiscono danni";
        Main.buffName[15] = "Camminata nell'acqua";
        Main.buffTip[15] = "Premi DOWN per entrare nell'acqua";
        Main.buffName[16] = "Arco";
        Main.buffTip[16] = "Danno e velocià freccia aumentati del 20%";
        Main.buffName[17] = "Cacciatore";
        Main.buffTip[17] = "Mostra la posizione dei nemici";
        Main.buffName[18] = "Gravità";
        Main.buffTip[18] = "Premi UP o DOWN per invertire la gravità";
        Main.buffName[19] = "Orbita di luce";
        Main.buffTip[19] = "Sfera magica che fornisce luce";
        Main.buffName[20] = "Avvelenato";
        Main.buffTip[20] = "Perdi lentamente la vita";
        Main.buffName[21] = "Malattia pozione";
        Main.buffTip[21] = "Non si possono più consumare oggetti curativi";
        Main.buffName[22] = "Oscurità";
        Main.buffTip[22] = "Diminuita visione della luce";
        Main.buffName[23] = "Maledetto";
        Main.buffTip[23] = "Non si possono più utilizzare oggetti";
        Main.buffName[24] = "A fuoco!";
        Main.buffTip[24] = "Perdi lentamente la vita";
        Main.buffName[25] = "Brillo";
        Main.buffTip[25] = "Abilità corpo a corpo aumentata, difesa abbassata";
        Main.buffName[26] = "Ben nutrito";
        Main.buffTip[26] = "Migliorie minori a tutti i parametri";
        Main.buffName[27] = "Fata";
        Main.buffTip[27] = "Una fata ti sta seguendo";
        Main.buffName[28] = "Lupo mannaro";
        Main.buffTip[28] = "Abilità fisiche aumentate";
        Main.buffName[29] = "Chiaroveggenza";
        Main.buffTip[29] = "Poteri magici aumentati";
        Main.buffName[30] = "Emorragia";
        Main.buffTip[30] = "Impossibile rigenerare vita";
        Main.buffName[31] = "Confuso";
        Main.buffTip[31] = "Movimento invertito";
        Main.buffName[32] = "Lento";
        Main.buffTip[32] = "Ridotta velocità movimento";
        Main.buffName[33] = "Debole";
        Main.buffTip[33] = "Abilità fisiche diminuite";
        Main.buffName[34] = "Tritone";
        Main.buffTip[34] = "Può respirare e muoversi facilmente sott'acqua";
        Main.buffName[35] = "Tacere";
        Main.buffTip[35] = "Non possono utilizzare gli elementi che richiedono mana";
        Main.buffName[36] = "Armatura rotta";
        Main.buffTip[36] = "La difesa è dimezzata";
        Main.buffName[37] = "Inorridito";
        Main.buffTip[37] = "Hai visto qualcosa di orribile, non c'è via di scampo.";
        Main.buffName[38] = "La Lingua";
        Main.buffTip[38] = "Sei stato succhiato nella bocca";
        Main.buffName[39] = "Inferno maledetto";
        Main.buffTip[39] = "Perdi la vita";
        Main.buffName[40] = "Animale coniglio";
        Main.buffTip[40] = "Penso che vuole la tua carota";
        Main.tileName[13] = "Bottiglia";
        Main.tileName[14] = "Tavolo";
        Main.tileName[15] = "Sedia";
        Main.tileName[16] = "Incudine";
        Main.tileName[17] = "Forno";
        Main.tileName[18] = "Banco di lavoro";
        Main.tileName[26] = "Demone altare";
        Main.tileName[77] = "Creazione degli inferi";
        Main.tileName[86] = "Telaio";
        Main.tileName[94] = "Barilotto";
        Main.tileName[96] = "Pentola";
        Main.tileName[101] = "Scaffale";
        Main.tileName[106] = "Segheria";
        Main.tileName[114] = "Laboratorio dell'inventore";
        Main.tileName[133] = "Fornace di adamantio";
        Main.tileName[134] = "Incudine di mitrilio";
      }
      else if (Lang.lang == 4)
      {
        Lang.misc[0] = "L'armée des gobelins a été vaincue.";
        Lang.misc[1] = "Une armée de gobelins approche par l'ouest.";
        Lang.misc[2] = "Une armée de gobelins approche par l'est.";
        Lang.misc[3] = "Une armée gobelin est arrivé!";
        Lang.misc[4] = "La Légion Frost a été vaincu!";
        Lang.misc[5] = "La Légion Frost est venant de l'ouest!";
        Lang.misc[6] = "La Légion Frost est l'approche de l'Est!";
        Lang.misc[7] = "La Légion gel est arrivé!";
        Lang.misc[8] = "La lune de sang se lève...";
        Lang.misc[9] = "Vous sentez une présence maléfique vous observer.";
        Lang.misc[10] = "Un frisson vous parcourt le dos...";
        Lang.misc[11] = "Des cris retentissent autour de vous...";
        Lang.misc[12] = "Votre monde a la chance de profiter de ressources de cobalt.";
        Lang.misc[13] = "Votre monde a la chance de profiter de ressources de mythril.";
        Lang.misc[14] = "Votre monde a la chance de profiter de ressources d'adamantine.";
        Lang.misc[15] = "Les anciens esprits de l'ombre et de la lumière ont été relâchés.";
        Lang.misc[16] = "est réveillé.";
        Lang.misc[17] = "a été vaincue.";
        Lang.misc[18] = "est arrivée.";
        Lang.misc[19] = " s'est fait éviscérer...";
        Lang.menu[0] = "Démarrez une nouvelle instance de Terraria pour rejoindre une partie.";
        Lang.menu[1] = "Fonctionne sur le port ";
        Lang.menu[2] = "Déconnexion";
        Lang.menu[3] = "Le serveur requiert un mot de passe :";
        Lang.menu[4] = "Accepter";
        Lang.menu[5] = "Retour";
        Lang.menu[6] = "Annuler";
        Lang.menu[7] = "Entrer le mot de passe :";
        Lang.menu[8] = "Lancement du serveur...";
        Lang.menu[9] = "Le chargement a échoué.";
        Lang.menu[10] = "Charger une sauvegarde";
        Lang.menu[11] = "Aucune sauvegarde trouvée";
        Lang.menu[12] = "Un joueur";
        Lang.menu[13] = "Multijoueur";
        Lang.menu[14] = "Réglages";
        Lang.menu[15] = "Quitter";
        Lang.menu[16] = "Créer un personnage";
        Lang.menu[17] = "Supprimer";
        Lang.menu[18] = "Cheveux";
        Lang.menu[19] = "Yeux";
        Lang.menu[20] = "Peau";
        Lang.menu[21] = "Vêtements";
        Lang.menu[22] = "Homme";
        Lang.menu[23] = "Femme";
        Lang.menu[24] = "Difficile";
        Lang.menu[25] = "Normal";
        Lang.menu[26] = "Facile";
        Lang.menu[27] = "Aléatoire";
        Lang.menu[28] = "Créer";
        Lang.menu[29] = "En cas de mort dans le mode Difficile, le personnage est tout simplement supprimé";
        Lang.menu[30] = "En cas de mort dans le mode Normal, les personnages laissent échapper des objets en mourant";
        Lang.menu[31] = "Les personnages en mode facile laissent échapper de l'argent en mourant.";
        Lang.menu[32] = "Choisir la difficulté";
        Lang.menu[33] = "Chemise";
        Lang.menu[34] = "Maillot de corps";
        Lang.menu[35] = "Pantalon";
        Lang.menu[36] = "Chaussures";
        Lang.menu[37] = "Cheveux";
        Lang.menu[38] = "Couleur des cheveux";
        Lang.menu[39] = "Couleur des yeux";
        Lang.menu[40] = "Couleur de peau";
        Lang.menu[41] = "Couleur de chemise";
        Lang.menu[42] = "Couleur de maillot de corps";
        Lang.menu[43] = "Couleur de pantalon";
        Lang.menu[44] = "Couelur des chaussures";
        Lang.menu[45] = "Saisir le nom du personnage :";
        Lang.menu[46] = "Supprimer";
        Lang.menu[47] = "Créer un monde";
        Lang.menu[48] = "Saisir un nom de monde :";
        Lang.menu[49] = "Mode fenêtré";
        Lang.menu[50] = "Mode Plein écran";
        Lang.menu[51] = "Résolution";
        Lang.menu[52] = "Parallax";
        Lang.menu[53] = "Frame Skip activé (non recommandé)";
        Lang.menu[54] = "Frame Skip désactivé (recommandé)";
        Lang.menu[55] = "Lumière : couleur";
        Lang.menu[56] = "Lumière : blanche";
        Lang.menu[57] = "Lumière : rétro";
        Lang.menu[58] = "Lumière : psyché";
        Lang.menu[59] = "Qualité : auto";
        Lang.menu[60] = "Qualité : haute";
        Lang.menu[61] = "Qualité : moyenne";
        Lang.menu[62] = "Qualité : basse";
        Lang.menu[63] = "Vidéo";
        Lang.menu[64] = "Curseur chromatique";
        Lang.menu[65] = "Volume";
        Lang.menu[66] = "Contrôles";
        Lang.menu[67] = "Sauvegarde auto activée";
        Lang.menu[68] = "Sauvegarde auto désactivée";
        Lang.menu[69] = "Pause auto activée";
        Lang.menu[70] = "Pause auto désactivée";
        Lang.menu[71] = "Affichage du texte activé";
        Lang.menu[72] = "Affichage du texte désactivé";
        Lang.menu[73] = "Résolution Plein écran";
        Lang.menu[74] = "Haut              ";
        Lang.menu[75] = "Bas               ";
        Lang.menu[76] = "Gauche           ";
        Lang.menu[77] = "Droite             ";
        Lang.menu[78] = "Sauter            ";
        Lang.menu[79] = "Lancer            ";
        Lang.menu[80] = "Inventaire        ";
        Lang.menu[81] = "Soin rapide      ";
        Lang.menu[82] = "Mana rapide     ";
        Lang.menu[83] = "Buff rapide      ";
        Lang.menu[84] = "Agripper          ";
        Lang.menu[85] = "Sélection auto    ";
        Lang.menu[86] = "Réglages par défaut";
        Lang.menu[87] = "Rejoindre";
        Lang.menu[88] = "Héberger et jouer";
        Lang.menu[89] = "Entrer l'adresse IP du serveur :";
        Lang.menu[90] = "Entrer le port du serveur :";
        Lang.menu[91] = "Choisir la taille du monde :";
        Lang.menu[92] = "Petit";
        Lang.menu[93] = "Moyen";
        Lang.menu[94] = "Grand";
        Lang.menu[95] = "Rouge :";
        Lang.menu[96] = "Vert :";
        Lang.menu[97] = "Bleu :";
        Lang.menu[98] = "Son :";
        Lang.menu[99] = "Musique :";
        Lang.menu[100] = "De fond sur";
        Lang.menu[101] = "De fond au large";
        Lang.menu[102] = "Sélectionnez la langue";
        Lang.menu[103] = "Langue";
        Lang.menu[104] = "Oui";
        Lang.menu[105] = "Pas";
        Lang.gen[0] = "Création du terrain :";
        Lang.gen[1] = "Ajout de sable...";
        Lang.gen[2] = "Création des collines...";
        Lang.gen[3] = "Placement de la boue derrière la boue :";
        Lang.gen[4] = "Placement des rochers dans la boue...";
        Lang.gen[5] = "Placement de boue dans les rochers...";
        Lang.gen[6] = "Ajout d'argile...";
        Lang.gen[7] = "Création de trous aléatoires :";
        Lang.gen[8] = "Création de petites cavernes :";
        Lang.gen[9] = "Création de grandes cavernes :";
        Lang.gen[10] = "Création des cavernes en surface...";
        Lang.gen[11] = "Création de jungle :";
        Lang.gen[12] = "Création d'îles flottantes...";
        Lang.gen[13] = "Ajout des patchs de champignon...";
        Lang.gen[14] = "Placement de la terre dans la boue...";
        Lang.gen[15] = "Ajout de limon...";
        Lang.gen[16] = "Ajout des brillances...";
        Lang.gen[17] = "Ajout de toiles d'araignées...";
        Lang.gen[18] = "Création du monde inférieur :";
        Lang.gen[19] = "Ajout d'étendues d'eau :";
        Lang.gen[20] = "Corruption du monde :";
        Lang.gen[21] = "Création de cavernes montagneuses...";
        Lang.gen[22] = "Création de plages...";
        Lang.gen[23] = "Ajout de gemmes...";
        Lang.gen[24] = "Gravitation du sable :";
        Lang.gen[25] = "Nettoyage d'arrière-plans de boue :";
        Lang.gen[26] = "Placement d'autels :";
        Lang.gen[27] = "Clarification de l'eau :";
        Lang.gen[28] = "Placement de cristaux de vie :";
        Lang.gen[29] = "Placement de statues :";
        Lang.gen[30] = "Dissimulation de trésor :";
        Lang.gen[31] = "Dissimulation de trésor supplémentaire :";
        Lang.gen[32] = "Dissimulation de trésor de jungle :";
        Lang.gen[33] = "Dissimulation de trésor dans l'eau :";
        Lang.gen[34] = "Placement de pièges :";
        Lang.gen[35] = "Placement d'objets cassables :";
        Lang.gen[36] = "Placement de forges infernales :";
        Lang.gen[37] = "Placement de l'herbe :";
        Lang.gen[38] = "Faire pousser des cactus...";
        Lang.gen[39] = "Plantation de tournesols...";
        Lang.gen[40] = "Plantation d'arbres...";
        Lang.gen[41] = "Plantation d'herbe...";
        Lang.gen[42] = "Plantation de mauvaises herbes...";
        Lang.gen[43] = "Faire pousser des vignes...";
        Lang.gen[44] = "Plantation de fleurs...";
        Lang.gen[45] = "Plantation de champignons...";
        Lang.gen[46] = "Libération des ressources inutilisées :";
        Lang.gen[47] = "Réinitialisation des objets du jeu :";
        Lang.gen[48] = "Réglage du mode difficile...";
        Lang.gen[49] = "Sauvegarde des données du monde :";
        Lang.gen[50] = "Sauvegarde du fichier du monde...";
        Lang.gen[51] = "Chargement des données du monde :";
        Lang.gen[52] = "Vérification de l'alignement de blocs :";
        Lang.gen[53] = "Le chargement a échoué.";
        Lang.gen[54] = "Aucune sauvegarde trouvée.";
        Lang.gen[55] = "Trouver les images de blocs :";
        Lang.gen[56] = "Ajout de la neige ...";
        Lang.gen[57] = "Mondiale";
        Lang.gen[58] = "Créer donjon:";
        Lang.gen[59] = "Une météorite a atterri!";
        Lang.inter[0] = "Vie :";
        Lang.inter[1] = "Souffle ";
        Lang.inter[2] = "Mana :";
        Lang.inter[3] = "Poubelle";
        Lang.inter[4] = "Inventaire";
        Lang.inter[5] = "Barre d'inventaire déverrouillée";
        Lang.inter[6] = "Barre d'inventaire verrouillée";
        Lang.inter[7] = "Logement";
        Lang.inter[8] = "Demande de logement";
        Lang.inter[9] = "Accessoires";
        Lang.inter[10] = "Défense";
        Lang.inter[11] = "Social";
        Lang.inter[12] = "Casque";
        Lang.inter[13] = "Chemise";
        Lang.inter[14] = "Pantalon";
        Lang.inter[15] = "Platine";
        Lang.inter[16] = "Or";
        Lang.inter[17] = "Argent";
        Lang.inter[18] = "Cuivre";
        Lang.inter[19] = "Reforger";
        Lang.inter[20] = "Placer un objet ici pour le reforger";
        Lang.inter[21] = "Affichage des techniques utilisant";
        Lang.inter[22] = "Objets requis :";
        Lang.inter[23] = "Aucun";
        Lang.inter[24] = "Placer un matériau ici pour afficher les techniques";
        Lang.inter[25] = "Artisanat";
        Lang.inter[26] = "Pièces";
        Lang.inter[27] = "Munitions";
        Lang.inter[28] = "Magasin";
        Lang.inter[29] = "Tout récupérer";
        Lang.inter[30] = "Tout déposer";
        Lang.inter[31] = "Pile rapide";
        Lang.inter[32] = "Tirelire";
        Lang.inter[33] = "Coffre-fort";
        Lang.inter[34] = "Temps :";
        Lang.inter[35] = "Sauvegarder et quitter";
        Lang.inter[36] = "Déconnexion";
        Lang.inter[37] = "Objets";
        Lang.inter[38] = "Vous vous êtes fait exterminer...";
        Lang.inter[39] = "Ce logement convient.";
        Lang.inter[40] = "Ce logement ne convient pas.";
        Lang.inter[41] = "Ce logement est déjà occupé.";
        Lang.inter[42] = "Ce logement est corrompu.";
        Lang.inter[43] = "La connexion a été interrompue";
        Lang.inter[44] = "Réception de données de blocs";
        Lang.inter[45] = "équiper";
        Lang.inter[46] = "Coût";
        Lang.inter[47] = "Enregistrer";
        Lang.inter[48] = "Modifier";
        Lang.inter[49] = "État";
        Lang.inter[50] = "Malédiction";
        Lang.inter[51] = "Aide";
        Lang.inter[52] = "Proches";
        Lang.inter[53] = "De l'eau";
        Lang.inter[54] = "Guérir";
        Lang.tip[0] = "Équipé dans l'emplacement social";
        Lang.tip[1] = "Ne procure pas de stats";
        Lang.tip[2] = " de dégâts de mêlée";
        Lang.tip[3] = " de dégâts à distance";
        Lang.tip[4] = " de dégâts de magie";
        Lang.tip[5] = "% de chance de coup critique";
        Lang.tip[6] = "Vitesse insensée";
        Lang.tip[7] = "Vitesse très rapide";
        Lang.tip[8] = "Vitesse rapide";
        Lang.tip[9] = "Vitesse moyenne";
        Lang.tip[10] = "Vitesse lente";
        Lang.tip[11] = "Vitesse très lente";
        Lang.tip[12] = "Vitesse extrêmement lente";
        Lang.tip[13] = "Vitesse d'escargot";
        Lang.tip[14] = "Pas de recul";
        Lang.tip[15] = "Recul extrêmement faible";
        Lang.tip[16] = "Recul très faible";
        Lang.tip[17] = "Recul faible";
        Lang.tip[18] = "Recul moyen";
        Lang.tip[19] = "Fort recul";
        Lang.tip[20] = "Très fort recul";
        Lang.tip[21] = "Recul extrêmement fort";
        Lang.tip[22] = "Recul ahurissant";
        Lang.tip[23] = "Équipable";
        Lang.tip[24] = "Objets sociaux";
        Lang.tip[25] = " de défense";
        Lang.tip[26] = "% de puissance de pioche";
        Lang.tip[27] = "% de puissance de hache";
        Lang.tip[28] = "% de puissance de marteau";
        Lang.tip[29] = "Redonne";
        Lang.tip[30] = "de vie";
        Lang.tip[31] = "de mana";
        Lang.tip[32] = "Consomme";
        Lang.tip[33] = "Peut être placé";
        Lang.tip[34] = "Munitions";
        Lang.tip[35] = "Consommable";
        Lang.tip[36] = "Matériau";
        Lang.tip[37] = " Durée minute";
        Lang.tip[38] = " Durée seconde";
        Lang.tip[39] = "% de dégâts";
        Lang.tip[40] = "% de vélocité";
        Lang.tip[41] = "% de chance de coup critique";
        Lang.tip[42] = "% de coût de mana";
        Lang.tip[43] = "% de la taille";
        Lang.tip[44] = "% de vitesse de projectile";
        Lang.tip[45] = "% de recul";
        Lang.tip[46] = "% de vitesse de déplacement";
        Lang.tip[47] = "% de vitesse de mêlée";
        Lang.tip[48] = "Bonus de collection :";
        Lang.tip[49] = "Prix de vente :";
        Lang.tip[50] = "Prix d'achat :";
        Lang.tip[51] = "Aucune valeur";
        Lang.mp[0] = "Recevoir :";
        Lang.mp[1] = "Mot de passe incorrect.";
        Lang.mp[2] = "Opération non valable en l'état.";
        Lang.mp[3] = "Vous vous êtes fait bannir de ce serveur.";
        Lang.mp[4] = "Vous n'utilisez pas la même version que ce serveur.";
        Lang.mp[5] = "est déjà sur ce serveur.";
        Lang.mp[6] = "/en train de jouer";
        Lang.mp[7] = "Joueurs actuels :";
        Lang.mp[8] = "/jet";
        Lang.mp[9] = "lance un";
        Lang.mp[10] = "Vous n'êtes pas dans une équipe.";
        Lang.mp[11] = "a activé le PvP.";
        Lang.mp[12] = "a désactivé le PvP.";
        Lang.mp[13] = "n'est plus dans une équipe.";
        Lang.mp[14] = "a rejoint l'équipe rouge.";
        Lang.mp[15] = "a rejoint l'équipe verte.";
        Lang.mp[16] = "a rejoint l'équipe bleue.";
        Lang.mp[17] = "a rejoint l'équipe jaune.";
        Lang.mp[18] = "Bienvenue dans";
        Lang.mp[19] = "a rejoint.";
        Lang.mp[20] = "a quitté.";
        Lang.the = "le ";
        Lang.dt[0] = "n'a pas trouvé l'antidote";
        Lang.dt[1] = "n'a pas réussi à éteindre l'incendie";
        Main.buffName[1] = "Peau d'obsidienne";
        Main.buffTip[1] = "Immunise contre la lave";
        Main.buffName[2] = "Régénération";
        Main.buffTip[2] = "Régénère la vie";
        Main.buffName[3] = "Rapidité";
        Main.buffTip[3] = "Augmente la vitesse de déplacement de 25 %";
        Main.buffName[4] = "Branchies";
        Main.buffTip[4] = "Permet de respirer sous l'eau comme dans l'air";
        Main.buffName[5] = "Peau de fer";
        Main.buffTip[5] = "Augmente la défense de 8";
        Main.buffName[6] = "Régénération de mana";
        Main.buffTip[6] = "Augmente la régénération de mana";
        Main.buffName[7] = "Pouvoir magique";
        Main.buffTip[7] = "Augmente les dégâts de magie de 20 %";
        Main.buffName[8] = "Poids plume";
        Main.buffTip[8] = "Appuyer sur Bas ou Haut pour contrôler la vitesse de descente";
        Main.buffName[9] = "Spéléologue";
        Main.buffTip[9] = "Indique l'emplacement des trésors et du minerai";
        Main.buffName[10] = "Invisibilité";
        Main.buffTip[10] = "Procure l'invisibilité";
        Main.buffName[11] = "Brillance";
        Main.buffTip[11] = "Emet une aura de lumière";
        Main.buffName[12] = "Vision nocturne";
        Main.buffTip[12] = "Améliore la vision de nuit";
        Main.buffName[13] = "Bataille";
        Main.buffTip[13] = "Augmente la vitesse d'apparition des ennemis";
        Main.buffName[14] = "Épines";
        Main.buffTip[14] = "Les attaquants subissent aussi des dégâts";
        Main.buffName[15] = "Marche sur l'eau";
        Main.buffTip[15] = "Appuyer sur Bas pour entrer dans l'eau";
        Main.buffName[16] = "Tir à l'arc";
        Main.buffTip[16] = "La vitesse et les dégâts des flèches augmentent de 20 %";
        Main.buffName[17] = "Chasseur";
        Main.buffTip[17] = "Indique l'emplacement des ennemis";
        Main.buffName[18] = "Gravitation";
        Main.buffTip[18] = "Appuyer sur Haut ou Bas pour inverser la gravité";
        Main.buffName[19] = "Orbe de lumière";
        Main.buffTip[19] = "Un orbe magique qui émet de la lumière";
        Main.buffName[20] = "Empoisonnement";
        Main.buffTip[20] = "Perte lente de vie";
        Main.buffName[21] = "Nausée des potions";
        Main.buffTip[21] = "Ne peut plus consommer de potions de soin";
        Main.buffName[22] = "Obscurité";
        Main.buffTip[22] = "Diminue la vision de nuit";
        Main.buffName[23] = "Malédiction";
        Main.buffTip[23] = "Ne peut utiliser aucun objet";
        Main.buffName[24] = "En feu !";
        Main.buffTip[24] = "Perte lente de vie";
        Main.buffName[25] = "Ivresse";
        Main.buffTip[25] = "Augmente les aptitudes de mêlée, diminue la défense";
        Main.buffName[26] = "Bien nourri";
        Main.buffTip[26] = "Amélioration mineure de toutes les stats.";
        Main.buffName[27] = "Fée";
        Main.buffTip[27] = "Une fée vous suit";
        Main.buffName[28] = "Loup-garou";
        Main.buffTip[28] = "Les aptitudes physiques sont augmentées";
        Main.buffName[29] = "Clairvoyance";
        Main.buffTip[29] = "Les pouvoirs magiques sont augmentés";
        Main.buffName[30] = "Saignement";
        Main.buffTip[30] = "Ne peut régénérer la vie";
        Main.buffName[31] = "Confusion";
        Main.buffTip[31] = "Les mouvements sont inversés";
        Main.buffName[32] = "Ralentissement";
        Main.buffTip[32] = "La vitesse de déplacement est réduite";
        Main.buffName[33] = "Faiblesse";
        Main.buffTip[33] = "Les aptitudes physiques sont diminuées";
        Main.buffName[34] = "Peuple des mers";
        Main.buffTip[34] = "Peut respirer et se déplacer sous l'eau facilement";
        Main.buffName[35] = "Silencieux";
        Main.buffTip[35] = "Ne peut pas utiliser des éléments qui nécessitent de mana";
        Main.buffName[36] = "Armure brisée";
        Main.buffTip[36] = "La défense est réduite de moitié";
        Main.buffName[37] = "Peur panique";
        Main.buffTip[37] = "Vous avez vu quelque chose de terrible et vous ne pouvez vous échapper.";
        Main.buffName[38] = "La langue";
        Main.buffTip[38] = "Vous vous êtes fait aspirer dans la bouche";
        Main.buffName[39] = "Brasier maudit";
        Main.buffTip[39] = "Perte de vie";
        Main.buffName[40] = "Animal lapin";
        Main.buffTip[40] = "Je pense qu'il veut votre carotte";
        Main.tileName[13] = "Bouteille";
        Main.tileName[14] = "Table";
        Main.tileName[15] = "Président";
        Main.tileName[16] = "Enclume";
        Main.tileName[17] = "Four";
        Main.tileName[18] = "Établi";
        Main.tileName[26] = "Autel démon";
        Main.tileName[77] = "Forge infernale";
        Main.tileName[86] = "Métier à tisser";
        Main.tileName[94] = "Tonnelet";
        Main.tileName[96] = "Marmite";
        Main.tileName[101] = "Bibliothèque";
        Main.tileName[106] = "Scierie";
        Main.tileName[114] = "Atelier du bricoleur";
        Main.tileName[133] = "Forge en adamantine";
        Main.tileName[134] = "Enclume en mythril";
      }
      else if (Lang.lang == 5)
      {
        Lang.misc[0] = "¡El ejército de duendes ha sido derrotado!";
        Lang.misc[1] = "¡Un ejército de duendes se aproxima por el oeste!";
        Lang.misc[2] = "¡Un ejército de duendes se aproxima por el este!";
        Lang.misc[3] = "Un ejército goblin ha llegado!";
        Lang.misc[4] = "La Legión Frost ha sido derrotado!";
        Lang.misc[5] = "La Legión de Frost se aproxima desde el oeste!";
        Lang.misc[6] = "La Legión de Frost se acercaba desde el este!";
        Lang.misc[7] = "La Legión Frost ha llegado!";
        Lang.misc[8] = "La luna sangrienta está saliendo...";
        Lang.misc[9] = "Sientes que una presencia maligna te observa...";
        Lang.misc[10] = "Sientes un horrible escalofrío por la espalda...";
        Lang.misc[11] = "El eco de los alaridos suena por todas partes...";
        Lang.misc[12] = "¡Tu mundo ha sido bendecido con Cobalto!";
        Lang.misc[13] = "¡Tu mundo ha sido bendecido con Mithril!";
        Lang.misc[14] = "¡Tu mundo ha sido bendecido con Adamantita!";
        Lang.misc[15] = "Los ancestrales espíritus de la luz y la oscuridad han sido liberados.";
        Lang.misc[16] = "ha despertado!";
        Lang.misc[17] = "ha sido derrotado!";
        Lang.misc[18] = "de duendes!";
        Lang.misc[19] = " fue asesinado...";
        Lang.menu[0] = "¡Comienza y únete a un nuevo periodo de Terraria!";
        Lang.menu[1] = "Ejecutándose en el puerto ";
        Lang.menu[2] = "Desconectar";
        Lang.menu[3] = "Contraseña del servidor obligatoria:";
        Lang.menu[4] = "Aceptar";
        Lang.menu[5] = "Atrás";
        Lang.menu[6] = "Cancelar";
        Lang.menu[7] = "Escribir contraseña del servidor:";
        Lang.menu[8] = "Iniciando servidor...";
        Lang.menu[9] = "¡Error al cargar!";
        Lang.menu[10] = "Cargar copia de seguridad";
        Lang.menu[11] = "No hay copia de seguridad";
        Lang.menu[12] = "Un jugador";
        Lang.menu[13] = "Multijugador";
        Lang.menu[14] = "Ajustes";
        Lang.menu[15] = "Salir";
        Lang.menu[16] = "Crear personaje";
        Lang.menu[17] = "Eliminar";
        Lang.menu[18] = "Pelo";
        Lang.menu[19] = "Ojos";
        Lang.menu[20] = "Piel";
        Lang.menu[21] = "Ropa";
        Lang.menu[22] = "Hombre";
        Lang.menu[23] = "Mujer";
        Lang.menu[24] = "Fanático";
        Lang.menu[25] = "Normal";
        Lang.menu[26] = "Novato";
        Lang.menu[27] = "Aleatorio";
        Lang.menu[28] = "Crear";
        Lang.menu[29] = "Los personajes fanáticos mueren para siempre.";
        Lang.menu[30] = "Los personajes normales sueltan objetos al morir";
        Lang.menu[31] = "Los personajes novatos sueltan dinero al morir";
        Lang.menu[32] = "Seleccionar dificultad";
        Lang.menu[33] = "Camisa";
        Lang.menu[34] = "Camiseta";
        Lang.menu[35] = "Pantalones";
        Lang.menu[36] = "Zapatos";
        Lang.menu[37] = "Pelo";
        Lang.menu[38] = "Color de pelo";
        Lang.menu[39] = "Color de ojos";
        Lang.menu[40] = "Color de piel";
        Lang.menu[41] = "Color de la camisa";
        Lang.menu[42] = "Color de la camiseta";
        Lang.menu[43] = "Color de los pantalones";
        Lang.menu[44] = "Color de los zapatos";
        Lang.menu[45] = "Escribir nombre del personaje:";
        Lang.menu[46] = "Eliminar";
        Lang.menu[47] = "Crear mundo";
        Lang.menu[48] = "Escribir nombre del mundo:";
        Lang.menu[49] = "Ir a Pantalla con ventanas";
        Lang.menu[50] = "Ir a Pantalla completa";
        Lang.menu[51] = "Resolución";
        Lang.menu[52] = "Paralaje";
        Lang.menu[53] = "Saltar fotograma desactivado (no recomendado)";
        Lang.menu[54] = "Saltar fotograma activado (recomendado)";
        Lang.menu[55] = "Iluminación: Color";
        Lang.menu[56] = "Iluminación: Blanco";
        Lang.menu[57] = "Iluminación: Retro";
        Lang.menu[58] = "Iluminación: Psicodélica";
        Lang.menu[59] = "Calidad: Automático";
        Lang.menu[60] = "Calidad: Alta";
        Lang.menu[61] = "Calidad: Normal";
        Lang.menu[62] = "Calidad: Baja";
        Lang.menu[63] = "Vídeo";
        Lang.menu[64] = "Color del cursor";
        Lang.menu[65] = "Volumen";
        Lang.menu[66] = "Controles";
        Lang.menu[67] = "Autoguardado activado";
        Lang.menu[68] = "Autoguardado desactivado";
        Lang.menu[69] = "Pausa automática activada";
        Lang.menu[70] = "Pausa automática desactivada";
        Lang.menu[71] = "Sugerencias activadas";
        Lang.menu[72] = "Sugerencias desactivadas";
        Lang.menu[73] = "Resolución de pantalla completa";
        Lang.menu[74] = "Arriba                 ";
        Lang.menu[75] = "Abajo                  ";
        Lang.menu[76] = "Izquierda              ";
        Lang.menu[77] = "Derecha                ";
        Lang.menu[78] = "Saltar                  ";
        Lang.menu[79] = "Lanzar                 ";
        Lang.menu[80] = "Inventario              ";
        Lang.menu[81] = "Curación rápida       ";
        Lang.menu[82] = "Maná rápido           ";
        Lang.menu[83] = "Extra rápido           ";
        Lang.menu[84] = "Apresar                 ";
        Lang.menu[85] = "Selección automática  ";
        Lang.menu[86] = "Volver a predeterminados";
        Lang.menu[87] = "Unirse";
        Lang.menu[88] = "Crear y Jugar";
        Lang.menu[89] = "Escribir dirección IP del servidor:";
        Lang.menu[90] = "Escribir puerto del servidor:";
        Lang.menu[91] = "Elegir tamaño del mundo:";
        Lang.menu[92] = "Pequeño";
        Lang.menu[93] = "Mediano";
        Lang.menu[94] = "Grande";
        Lang.menu[95] = "Rojo:";
        Lang.menu[96] = "Verde:";
        Lang.menu[97] = "Azul:";
        Lang.menu[98] = "Sonido:";
        Lang.menu[99] = "Música:";
        Lang.menu[100] = "Fondo activado";
        Lang.menu[101] = "Fondo desactivado";
        Lang.menu[102] = "Seleccione el idioma";
        Lang.menu[103] = "Idioma";
        Lang.menu[104] = "Sí";
        Lang.menu[105] = "No";
        Lang.gen[0] = "Generando terreno del mundo:";
        Lang.gen[1] = "Añadiendo arena...";
        Lang.gen[2] = "Generando colinas...";
        Lang.gen[3] = "Amontonando tierra:";
        Lang.gen[4] = "Añadiendo rocas a la tierra...";
        Lang.gen[5] = "Añadiendo tierra a las rocas...";
        Lang.gen[6] = "Añadiendo arcilla...";
        Lang.gen[7] = "Generando agujeros aleatorios:";
        Lang.gen[8] = "Generando cuevas pequeñas:";
        Lang.gen[9] = "Generando cuevas grandes:";
        Lang.gen[10] = "Generando superficie de cuevas...";
        Lang.gen[11] = "Generando selva:";
        Lang.gen[12] = "Generando islas flotantes...";
        Lang.gen[13] = "Añadiendo parcelas de champiñones...";
        Lang.gen[14] = "Añadiendo lodo a la tierra...";
        Lang.gen[15] = "Añadiendo cieno...";
        Lang.gen[16] = "Añadiendo brillos...";
        Lang.gen[17] = "Añadiendo telas de araña...";
        Lang.gen[18] = "Creando Inframundo:";
        Lang.gen[19] = "Añadiendo cursos de agua:";
        Lang.gen[20] = "Corrompiendo el mundo:";
        Lang.gen[21] = "Generando cuevas en montañas...";
        Lang.gen[22] = "Creando playas...";
        Lang.gen[23] = "Añadiendo gemas...";
        Lang.gen[24] = "Gravitando arena:";
        Lang.gen[25] = "Limpiando de tierra los entornos:";
        Lang.gen[26] = "Colocando altares:";
        Lang.gen[27] = "Distribuyendo líquidos:";
        Lang.gen[28] = "Colocando cristales de vida:";
        Lang.gen[29] = "Colocando estatuas:";
        Lang.gen[30] = "Ocultando tesoro:";
        Lang.gen[31] = "Ocultando otro tesoro:";
        Lang.gen[32] = "Ocultando tesoro en la selva:";
        Lang.gen[33] = "Ocultando tesoro en el agua:";
        Lang.gen[34] = "Colocando trampas:";
        Lang.gen[35] = "Colocando objetos quebradizos:";
        Lang.gen[36] = "Colocando forjas infernales:";
        Lang.gen[37] = "Plantando césped...";
        Lang.gen[38] = "Plantando cactus...";
        Lang.gen[39] = "Plantando girasoles...";
        Lang.gen[40] = "Plantando árboles...";
        Lang.gen[41] = "Plantando hierbas...";
        Lang.gen[42] = "Plantando hierbajos...";
        Lang.gen[43] = "Plantando enredaderas...";
        Lang.gen[44] = "Plantando flores...";
        Lang.gen[45] = "Cultivando champiñones...";
        Lang.gen[46] = "Liberando recursos sin usar:";
        Lang.gen[47] = "Reiniciando objetos del juego:";
        Lang.gen[48] = "Estableciendo modo difícil...";
        Lang.gen[49] = "Guardando datos del mundo:";
        Lang.gen[50] = "Copia de seguridad del archivo del mundo...";
        Lang.gen[51] = "Cargando datos del mundo:";
        Lang.gen[52] = "Comprobando alineación en cascada:";
        Lang.gen[53] = "¡Error al cargar!";
        Lang.gen[54] = "No hay copia de seguridad.";
        Lang.gen[55] = "Encontrando estructura en cascada:";
        Lang.gen[56] = "Adición de nieve ...";
        Lang.gen[57] = "Mundo";
        Lang.gen[58] = "La creación de mazmorra:";
        Lang.gen[59] = "Un meteorito ha caído!";
        Lang.inter[0] = "Vida:";
        Lang.inter[1] = "Aire";
        Lang.inter[2] = "Maná";
        Lang.inter[3] = "Cubo de basura";
        Lang.inter[4] = "Inventario";
        Lang.inter[5] = "Barra de acceso rápido desbloqueada";
        Lang.inter[6] = "Barra de acceso rápido bloqueada";
        Lang.inter[7] = "Vivienda";
        Lang.inter[8] = "Búsqueda de vivienda";
        Lang.inter[9] = "Accesorios";
        Lang.inter[10] = "Defensa";
        Lang.inter[11] = "Social";
        Lang.inter[12] = "Casco";
        Lang.inter[13] = "Camisa";
        Lang.inter[14] = "Pantalones";
        Lang.inter[15] = "platino";
        Lang.inter[16] = "oro";
        Lang.inter[17] = "plata";
        Lang.inter[18] = "cobre";
        Lang.inter[19] = "Remodelar";
        Lang.inter[20] = "Colocar un objeto aquí para remodelarlo";
        Lang.inter[21] = "Mostrando recetas en uso";
        Lang.inter[22] = "Objetos necesarios:";
        Lang.inter[23] = "Ninguno";
        Lang.inter[24] = "Colocar un material aquí para ver las recetas";
        Lang.inter[25] = "Producción";
        Lang.inter[26] = "Monedas";
        Lang.inter[27] = "Munición";
        Lang.inter[28] = "Tienda";
        Lang.inter[29] = "Saquear todo";
        Lang.inter[30] = "Ahorrar todo";
        Lang.inter[31] = "Apilar rápido";
        Lang.inter[32] = "Hucha";
        Lang.inter[33] = "Caja fuerte";
        Lang.inter[34] = "Hora:";
        Lang.inter[35] = "Guarda y Salir";
        Lang.inter[36] = "Desconectar";
        Lang.inter[37] = "Objetos";
        Lang.inter[38] = "Te han asesinado...";
        Lang.inter[39] = "Esta vivienda es habitable.";
        Lang.inter[40] = "Esta vivienda no es habitable.";
        Lang.inter[41] = "Esta vivienda ya está ocupada.";
        Lang.inter[42] = "Esta vivienda está corrompida.";
        Lang.inter[43] = "Ha finalizado el tiempo de conexión";
        Lang.inter[44] = "Recibiendo datos en cascada";
        Lang.inter[45] = "Equipar";
        Lang.inter[46] = "Costo";
        Lang.inter[47] = "Ahorrar";
        Lang.inter[48] = "Editar";
        Lang.inter[49] = "Estado";
        Lang.inter[50] = "Maldición";
        Lang.inter[51] = "Ayuda";
        Lang.inter[52] = "Cerca";
        Lang.inter[53] = "De agua";
        Lang.inter[54] = "Sanar";
        Lang.tip[0] = "Equipado en espacio social";
        Lang.tip[1] = "No se registrará ninguna estadística";
        Lang.tip[2] = " daño en el cuerpo a cuerpo";
        Lang.tip[3] = " daño a distancia";
        Lang.tip[4] = " daño por magia";
        Lang.tip[5] = "% probabilidad de ataque crítico";
        Lang.tip[6] = "Velocidad de vértigo";
        Lang.tip[7] = "A gran velocidad";
        Lang.tip[8] = "Deprisa";
        Lang.tip[9] = "Velocidad normal";
        Lang.tip[10] = "Despacio";
        Lang.tip[11] = "Muy despacio";
        Lang.tip[12] = "Exageradamente despacio";
        Lang.tip[13] = "Velocidad de tortuga";
        Lang.tip[14] = "Sin retroceso";
        Lang.tip[15] = "Retroceso sumamente débil";
        Lang.tip[16] = "Retroceso muy débil";
        Lang.tip[17] = "Retroceso débil";
        Lang.tip[18] = "Retroceso normal";
        Lang.tip[19] = "Retroceso fuerte";
        Lang.tip[20] = "Retroceso muy fuerte";
        Lang.tip[21] = "Retroceso tremendamente fuerte";
        Lang.tip[22] = "Retroceso descomunal";
        Lang.tip[23] = "Utilizable";
        Lang.tip[24] = "Objeto de apariencia";
        Lang.tip[25] = " defensa";
        Lang.tip[26] = "% potencia de pico";
        Lang.tip[27] = "% potencia de hacha";
        Lang.tip[28] = "% potencia de martillo";
        Lang.tip[29] = "Recupera";
        Lang.tip[30] = "vida";
        Lang.tip[31] = "maná";
        Lang.tip[32] = "Consume";
        Lang.tip[33] = "Se puede colocar";
        Lang.tip[34] = "Munición";
        Lang.tip[35] = "Consumible";
        Lang.tip[36] = "Material";
        Lang.tip[37] = " minuto/s de duración";
        Lang.tip[38] = " segundo/s de duración";
        Lang.tip[39] = "% daño";
        Lang.tip[40] = "% velocidad";
        Lang.tip[41] = "% probabilidad de ataque crítico";
        Lang.tip[42] = "% coste de maná";
        Lang.tip[43] = "% tamaño";
        Lang.tip[44] = "% velocidad de proyectil";
        Lang.tip[45] = "% retroceso";
        Lang.tip[46] = "% velocidad de movimiento";
        Lang.tip[47] = "% velocidad en el cuerpo a cuerpo";
        Lang.tip[48] = "Set completo:";
        Lang.tip[49] = "Precio de venta:";
        Lang.tip[50] = "Precio de compra:";
        Lang.tip[51] = "Sin valor";
        Lang.mp[0] = "Recibe:";
        Lang.mp[1] = "Contraseña incorrecta.";
        Lang.mp[2] = "Operación no válida en este estado.";
        Lang.mp[3] = "Se te ha prohibido la entrada a este servidor.";
        Lang.mp[4] = "No tienes la misma versión que este servidor.";
        Lang.mp[5] = "ya está en este servidor.";
        Lang.mp[6] = "/jugando";
        Lang.mp[7] = "Jugadores ahora:";
        Lang.mp[8] = "/tira";
        Lang.mp[9] = "tira de";
        Lang.mp[10] = "¡No estás en ningún bando!";
        Lang.mp[11] = "ha activado 1c1!";
        Lang.mp[12] = "ha desactivado 1c1!";
        Lang.mp[13] = "ya no pertenece a ningún bando.";
        Lang.mp[14] = "se ha unido al bando rojo.";
        Lang.mp[15] = "se ha unido al bando verde.";
        Lang.mp[16] = "se ha unido al bando azul.";
        Lang.mp[17] = "se ha unido al bando amarillo.";
        Lang.mp[18] = "¡Bienvenido a";
        Lang.mp[19] = "se ha unido.";
        Lang.mp[20] = "ha dejado de.";
        Lang.the = "el ";
        Lang.dt[0] = "no logró encontrar el antídoto";
        Lang.dt[1] = "no pudo extinguir el fuego";
        Main.buffName[1] = "Piel obsidiana";
        Main.buffTip[1] = "Inmune a la lava";
        Main.buffName[2] = "Regeneración";
        Main.buffTip[2] = "Regenera la vida";
        Main.buffName[3] = "Rapidez";
        Main.buffTip[3] = "Aumenta en un 25% la velocidad de movimiento";
        Main.buffName[4] = "Agallas";
        Main.buffTip[4] = "Permite respirar agua en lugar de aire";
        Main.buffName[5] = "Piel de hierro";
        Main.buffTip[5] = "Aumenta la defensa en 8";
        Main.buffName[6] = "Regeneración de maná";
        Main.buffTip[6] = "Aumenta la regeneración de maná";
        Main.buffName[7] = "Poder mágico";
        Main.buffTip[7] = "Aumenta el daño mágico en un 20%";
        Main.buffName[8] = "Caída de pluma";
        Main.buffTip[8] = "Pulsa ARRIBA o ABAJO para controlar la velocidad de descenso";
        Main.buffName[9] = "Espeleólogo";
        Main.buffTip[9] = "Muestra la ubicación de tesoros y minerales";
        Main.buffName[10] = "Invisibilidad";
        Main.buffTip[10] = "Proporciona invisibilidad";
        Main.buffName[11] = "Brillo";
        Main.buffTip[11] = "Emite luz";
        Main.buffName[12] = "Noctámbulo";
        Main.buffTip[12] = "Aumenta la visión nocturna";
        Main.buffName[13] = "Batalla";
        Main.buffTip[13] = "Aumenta el porcentaje de regeneración del enemigo";
        Main.buffName[14] = "Espinas";
        Main.buffTip[14] = "Los atacantes también sufren daños";
        Main.buffName[15] = "Caminando sobre el agua";
        Main.buffTip[15] = "Pulsa ABAJO para sumergirte";
        Main.buffName[16] = "Tiro con arco";
        Main.buffTip[16] = "Aumenta en un 20% la velocidad y el daño de las flechas";
        Main.buffName[17] = "Cazador";
        Main.buffTip[17] = "Muestra la ubicación de los enemigos";
        Main.buffName[18] = "Gravedad";
        Main.buffTip[18] = "Pulsa ARRIBA o ABAJO para invertir la gravedad";
        Main.buffName[19] = "Orbe de Luz";
        Main.buffTip[19] = "Orbe mágico que proporciona luz";
        Main.buffName[20] = "Veneno";
        Main.buffTip[20] = "Pérdida de vida lentamente";
        Main.buffName[21] = "Poción de náuseas";
        Main.buffTip[21] = "Deja de consumir remedios curativos";
        Main.buffName[22] = "Oscuridad";
        Main.buffTip[22] = "Disminuye la claridad";
        Main.buffName[23] = "Maldición";
        Main.buffTip[23] = "No se puede usar ningún objeto";
        Main.buffName[24] = "Llamas";
        Main.buffTip[24] = "Pérdida de vida lentamente";
        Main.buffName[25] = "Beodo";
        Main.buffTip[25] = "Mejora el cuerpo a cuerpo pero ralentiza la defensa";
        Main.buffName[26] = "Bien alimentado";
        Main.buffTip[26] = "Pequeñas mejoras de todas las estadísticas";
        Main.buffName[27] = "Hada";
        Main.buffTip[27] = "Un hada te acompaña";
        Main.buffName[28] = "Hombre lobo";
        Main.buffTip[28] = "Aumenta la capacidad física";
        Main.buffName[29] = "Clarividencia";
        Main.buffTip[29] = "Aumenta los poderes mágicos";
        Main.buffName[30] = "Ensangrentado";
        Main.buffTip[30] = "No se puede recuperar vida";
        Main.buffName[31] = "Confundido";
        Main.buffTip[31] = "Se invierte el movimiento";
        Main.buffName[32] = "Lento";
        Main.buffTip[32] = "Disminuye la velocidad de movimiento";
        Main.buffName[33] = "Débil";
        Main.buffTip[33] = "Disminuye la capacidad física";
        Main.buffName[34] = "Tritón";
        Main.buffTip[34] = "Respira y se mueve bajo el agua con facilidad";
        Main.buffName[35] = "Silenciado";
        Main.buffTip[35] = "No puede utilizar los artículos que requieren maná";
        Main.buffName[36] = "Armadura rota";
        Main.buffTip[36] = "La defensa disminuye hasta la mitad";
        Main.buffName[37] = "Aterrado";
        Main.buffTip[37] = "Has visto algo horrible, no hay escapatoria";
        Main.buffName[38] = "La Lengua";
        Main.buffTip[38] = "Te succiona";
        Main.buffName[39] = "El Averno";
        Main.buffTip[39] = "Pérdida de la vida";
        Main.buffName[40] = "Mascota conejo";
        Main.buffTip[40] = "Creo que quiere su zanahoria";
        Main.tileName[13] = "Botella";
        Main.tileName[14] = "Mesa";
        Main.tileName[15] = "Silla";
        Main.tileName[16] = "Yunque";
        Main.tileName[17] = "Horno";
        Main.tileName[18] = "Banco de trabajo";
        Main.tileName[26] = "Demonio altar";
        Main.tileName[77] = "Forjas infernal";
        Main.tileName[86] = "Telar";
        Main.tileName[94] = "Barrica";
        Main.tileName[96] = "Perol";
        Main.tileName[101] = "Librería";
        Main.tileName[106] = "Serrería";
        Main.tileName[114] = "Taller del reparador";
        Main.tileName[133] = "Forja de adamantita";
        Main.tileName[134] = "Yunque de mithril";
      }
      for (int index1 = 0; index1 < Main.recipe.Length; ++index1)
      {
        if (Main.recipe[index1].createItem.name != null && Main.recipe[index1].createItem.name != "" && Main.recipe[index1].createItem.netID != 0)
        {
          Main.recipe[index1].createItem.name = Lang.itemName(Main.recipe[index1].createItem.netID);
          Main.recipe[index1].createItem.CheckTip();
          for (int index2 = 0; index2 < Main.recipe[index2].requiredItem.Length; ++index2)
          {
            Main.recipe[index1].requiredItem[index2].name = Lang.itemName(Main.recipe[index1].requiredItem[index2].netID);
            Main.recipe[index1].requiredItem[index2].CheckTip();
          }
        }
      }
    }

    public static string deathMsg(int plr = -1, int npc = -1, int proj = -1, int other = -1)
    {
      if (Lang.lang <= 1)
      {
        string str1 = "";
        int num = Main.rand.Next(26);
        string str2 = "";
        switch (num)
        {
          case 0:
            str2 = " was slain";
            break;
          case 1:
            str2 = " was eviscerated";
            break;
          case 2:
            str2 = " was murdered";
            break;
          case 3:
            str2 = "'s face was torn off";
            break;
          case 4:
            str2 = "'s entrails were ripped out";
            break;
          case 5:
            str2 = " was destroyed";
            break;
          case 6:
            str2 = "'s skull was crushed";
            break;
          case 7:
            str2 = " got massacred";
            break;
          case 8:
            str2 = " got impaled";
            break;
          case 9:
            str2 = " was torn in half";
            break;
          case 10:
            str2 = " was decapitated";
            break;
          case 11:
            str2 = " let their arms get torn off";
            break;
          case 12:
            str2 = " watched their innards become outards";
            break;
          case 13:
            str2 = " was brutally dissected";
            break;
          case 14:
            str2 = "'s extremities were detached";
            break;
          case 15:
            str2 = "'s body was mangled";
            break;
          case 16:
            str2 = "'s vital organs were ruptured";
            break;
          case 17:
            str2 = " was turned into a pile of flesh";
            break;
          case 18:
            str2 = " was removed from " + Main.worldName;
            break;
          case 19:
            str2 = " got snapped in half";
            break;
          case 20:
            str2 = " was cut down the middle";
            break;
          case 21:
            str2 = " was chopped up";
            break;
          case 22:
            str2 = "'s plead for death was answered";
            break;
          case 23:
            str2 = "'s meat was ripped off the bone";
            break;
          case 24:
            str2 = "'s flailing about was finally stopped";
            break;
          case 25:
            str2 = " had their head removed";
            break;
        }
        if (plr >= 0 && plr < (int) byte.MaxValue)
        {
          if (proj >= 0 && Main.projectile[proj].name != "")
            str1 = str2 + " by " + Main.player[plr].name + "'s " + Main.projectile[proj].name + ".";
          else
            str1 = str2 + " by " + Main.player[plr].name + "'s " + Main.player[plr].inventory[Main.player[plr].selectedItem].name + ".";
        }
        else if (npc >= 0 && Main.npc[npc].displayName != "")
          str1 = str2 + " by " + Main.npc[npc].displayName + ".";
        else if (proj >= 0 && Main.projectile[proj].name != "")
        {
          str1 = str2 + " by " + Main.projectile[proj].name + ".";
        }
        else
        {
          switch (other)
          {
            case 0:
              str1 = Main.rand.Next(2) != 0 ? " didn't bounce." : " fell to their death.";
              break;
            case 1:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str1 = " forgot to breathe.";
                  break;
                case 1:
                  str1 = " is sleeping with the fish.";
                  break;
                case 2:
                  str1 = " drowned.";
                  break;
                case 3:
                  str1 = " is shark food.";
                  break;
              }
              break;
            case 2:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str1 = " got melted.";
                  break;
                case 1:
                  str1 = " was incinerated.";
                  break;
                case 2:
                  str1 = " tried to swim in lava.";
                  break;
                case 3:
                  str1 = " likes to play in magma.";
                  break;
              }
              break;
            case 3:
              str1 = str2 + ".";
              break;
          }
        }
        return str1;
      }
      if (Lang.lang == 2)
      {
        string str3 = "";
        string str4;
        switch (Main.rand.Next(15))
        {
          case 0:
            str4 = " wurde durch";
            break;
          case 1:
            str4 = " wurde vernichtet";
            break;
          case 2:
            str4 = " wurde ermordet";
            break;
          case 3:
            str4 = " wurde zerstoert";
            break;
          case 4:
            str4 = " wurde massakriert";
            break;
          case 5:
            str4 = " wurde aufgespiesst";
            break;
          case 6:
            str4 = " wurde in zwei Haelften gerissen";
            break;
          case 7:
            str4 = " wurde gekoepft";
            break;
          case 8:
            str4 = " liess sich die Arme wegreissen";
            break;
          case 9:
            str4 = " sah die eigenen Innereien herausquellen";
            break;
          case 10:
            str4 = " wurde brutal seziert";
            break;
          case 11:
            str4 = " wurde in Hackfleisch verwandelt";
            break;
          case 12:
            str4 = " wurde laengs gefaltet";
            break;
          case 13:
            str4 = " wurde um die Haelfte gekuerzt";
            break;
          default:
            str4 = " liess sich den Kopf wegreissen";
            break;
        }
        if (plr >= 0 && plr < (int) byte.MaxValue || npc >= 0 && Main.npc[npc].displayName != "" || proj >= 0 && Main.projectile[proj].name != "")
        {
          str3 = str4 + ".";
        }
        else
        {
          switch (other)
          {
            case 0:
              str3 = Main.rand.Next(2) != 0 ? " ist nicht gesprungen." : " stuerzte in den Tod.";
              break;
            case 1:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str3 = " hat vergessen zu atmen.";
                  break;
                case 1:
                  str3 = " hat jetzt ein feuchtes Grab bei den Fischen.";
                  break;
                case 2:
                  str3 = " ist ertrunken.";
                  break;
                case 3:
                  str3 = " ist jetzt Fischfutter.";
                  break;
              }
              break;
            case 2:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str3 = " ist geschmolzen.";
                  break;
                case 1:
                  str3 = " wurde eingeaeschert.";
                  break;
                case 2:
                  str3 = " versuchte, in Lava zu baden.";
                  break;
                case 3:
                  str3 = " spielt gern mit Magma.";
                  break;
              }
              break;
            case 3:
              str3 = str4 + ".";
              break;
          }
        }
        return str3;
      }
      if (Lang.lang == 3)
      {
        string str5 = "";
        string str6;
        switch (Main.rand.Next(13))
        {
          case 0:
            str6 = " è stato ucciso";
            break;
          case 1:
            str6 = " è stato sventrato";
            break;
          case 2:
            str6 = " è stato assassinato";
            break;
          case 3:
            str6 = " è stato distrutto";
            break;
          case 4:
            str6 = " è stato massacrato";
            break;
          case 5:
            str6 = " è stato trafitto";
            break;
          case 6:
            str6 = " è stato diviso in due";
            break;
          case 7:
            str6 = " è stato decapitato";
            break;
          case 8:
            str6 = " ha visto uscire le sue interiora ";
            break;
          case 9:
            str6 = " è stato brutalmente sezionato";
            break;
          case 10:
            str6 = " è diventato un mucchio di carne";
            break;
          case 11:
            str6 = " è stato spezzato a metà";
            break;
          default:
            str6 = " è stato tagliato a metà";
            break;
        }
        if (plr >= 0 && plr < (int) byte.MaxValue || npc >= 0 && Main.npc[npc].displayName != "" || proj >= 0 && Main.projectile[proj].name != "")
        {
          str5 = str6 + ".";
        }
        else
        {
          switch (other)
          {
            case 0:
              str5 = Main.rand.Next(2) != 0 ? " non poteva rimbalzare." : " sente la sua morte.";
              break;
            case 1:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str5 = " ha dimenticato di respirare.";
                  break;
                case 1:
                  str5 = " sta dormendo con i pesci.";
                  break;
                case 2:
                  str5 = " è affogato.";
                  break;
                case 3:
                  str5 = " è un pasto dello squalo.";
                  break;
              }
              break;
            case 2:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str5 = " si è sciolto.";
                  break;
                case 1:
                  str5 = " si è incenerito.";
                  break;
                case 2:
                  str5 = " ha provato a nuotare nella lava.";
                  break;
                case 3:
                  str5 = " piace giocare nel magma.";
                  break;
              }
              break;
            case 3:
              str5 = str6 + ".";
              break;
          }
        }
        return str5;
      }
      if (Lang.lang == 4)
      {
        string str7 = "";
        string str8;
        switch (Main.rand.Next(14))
        {
          case 0:
            str8 = " s'est fait éviscérer";
            break;
          case 1:
            str8 = " s'est fait assassiner";
            break;
          case 2:
            str8 = " s'est fait détruire";
            break;
          case 3:
            str8 = " s'est fait massacrer";
            break;
          case 4:
            str8 = " s'est fait empaler";
            break;
          case 5:
            str8 = " s'est fait couper en deux";
            break;
          case 6:
            str8 = " s'est fait arracher la tête";
            break;
          case 7:
            str8 = " s'est fait déchiqueter les bras";
            break;
          case 8:
            str8 = " a vu ses entrailles tomber à ses pieds";
            break;
          case 9:
            str8 = " s'est fait brutalement découper";
            break;
          case 10:
            str8 = " a fini en chair à pâtée";
            break;
          case 11:
            str8 = " s'est fait couper en deux";
            break;
          case 12:
            str8 = " s'est fait couper en tranches";
            break;
          default:
            str8 = " a perdu la tête";
            break;
        }
        if (plr >= 0 && plr < (int) byte.MaxValue || npc >= 0 && Main.npc[npc].displayName != "" || proj >= 0 && Main.projectile[proj].name != "")
        {
          str7 = str8 + ".";
        }
        else
        {
          switch (other)
          {
            case 0:
              str7 = Main.rand.Next(2) != 0 ? " ne bouge plus." : " a cassé sa pipe.";
              break;
            case 1:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str7 = " a cessé de respirer.";
                  break;
                case 1:
                  str7 = " mange les pissenlits par la racine.";
                  break;
                case 2:
                  str7 = " a coulé à pic.";
                  break;
                case 3:
                  str7 = " nourrit les requins.";
                  break;
              }
              break;
            case 2:
              switch (Main.rand.Next(4))
              {
                case 0:
                  str7 = " a fondu.";
                  break;
                case 1:
                  str7 = " s'est fait incinérer.";
                  break;
                case 2:
                  str7 = " a tenté de nager dans la lave.";
                  break;
                case 3:
                  str7 = " aime barboter dans le magma.";
                  break;
              }
              break;
            case 3:
              str7 = str8 + ".";
              break;
          }
        }
        return str7;
      }
      if (Lang.lang != 5)
        return "";
      string str9 = "";
      string str10 = " fue asesinado";
      if (plr >= 0 && plr < (int) byte.MaxValue || npc >= 0 && Main.npc[npc].displayName != "" || proj >= 0 && Main.projectile[proj].name != "")
      {
        str9 = str10 + ".";
      }
      else
      {
        switch (other)
        {
          case 0:
            str9 = Main.rand.Next(2) != 0 ? " no saltó a tiempo." : " le ha llegado la hora.";
            break;
          case 1:
            switch (Main.rand.Next(4))
            {
              case 0:
                str9 = " se olvidó de respirar.";
                break;
              case 1:
                str9 = " duerme con los peces.";
                break;
              case 2:
                str9 = " se ha ahogado.";
                break;
              case 3:
                str9 = " es pasto de los tiburones.";
                break;
            }
            break;
          case 2:
            switch (Main.rand.Next(4))
            {
              case 0:
                str9 = " se ha calcinado.";
                break;
              case 1:
                str9 = " se ha chamuscado.";
                break;
              case 2:
                str9 = " ha intentado nadar en lava.";
                break;
              case 3:
                str9 = " le gusta jugar con el magma.";
                break;
            }
            break;
          case 3:
            str9 = str10 + ".";
            break;
        }
      }
      return str9;
    }
  }
}
