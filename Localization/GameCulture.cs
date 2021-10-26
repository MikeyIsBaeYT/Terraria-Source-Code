// Decompiled with JetBrains decompiler
// Type: Terraria.Localization.GameCulture
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Terraria.Localization
{
  public class GameCulture
  {
    private static Dictionary<GameCulture.CultureName, GameCulture> _NamedCultures = new Dictionary<GameCulture.CultureName, GameCulture>()
    {
      {
        GameCulture.CultureName.English,
        new GameCulture("en-US", 1)
      },
      {
        GameCulture.CultureName.German,
        new GameCulture("de-DE", 2)
      },
      {
        GameCulture.CultureName.Italian,
        new GameCulture("it-IT", 3)
      },
      {
        GameCulture.CultureName.French,
        new GameCulture("fr-FR", 4)
      },
      {
        GameCulture.CultureName.Spanish,
        new GameCulture("es-ES", 5)
      },
      {
        GameCulture.CultureName.Russian,
        new GameCulture("ru-RU", 6)
      },
      {
        GameCulture.CultureName.Chinese,
        new GameCulture("zh-Hans", 7)
      },
      {
        GameCulture.CultureName.Portuguese,
        new GameCulture("pt-BR", 8)
      },
      {
        GameCulture.CultureName.Polish,
        new GameCulture("pl-PL", 9)
      }
    };
    private static Dictionary<int, GameCulture> _legacyCultures;
    public readonly CultureInfo CultureInfo;
    public readonly int LegacyId;

    public static GameCulture DefaultCulture { get; set; }

    public bool IsActive => Language.ActiveCulture == this;

    public string Name => this.CultureInfo.Name;

    public static GameCulture FromCultureName(GameCulture.CultureName name) => !GameCulture._NamedCultures.ContainsKey(name) ? GameCulture.DefaultCulture : GameCulture._NamedCultures[name];

    public static GameCulture FromLegacyId(int id)
    {
      if (id < 1)
        id = 1;
      return !GameCulture._legacyCultures.ContainsKey(id) ? GameCulture.DefaultCulture : GameCulture._legacyCultures[id];
    }

    public static GameCulture FromName(string name) => GameCulture._legacyCultures.Values.SingleOrDefault<GameCulture>((Func<GameCulture, bool>) (culture => culture.Name == name)) ?? GameCulture.DefaultCulture;

    static GameCulture() => GameCulture.DefaultCulture = GameCulture._NamedCultures[GameCulture.CultureName.English];

    public GameCulture(string name, int legacyId)
    {
      this.CultureInfo = new CultureInfo(name);
      this.LegacyId = legacyId;
      GameCulture.RegisterLegacyCulture(this, legacyId);
    }

    private static void RegisterLegacyCulture(GameCulture culture, int legacyId)
    {
      if (GameCulture._legacyCultures == null)
        GameCulture._legacyCultures = new Dictionary<int, GameCulture>();
      GameCulture._legacyCultures.Add(legacyId, culture);
    }

    public enum CultureName
    {
      English = 1,
      German = 2,
      Italian = 3,
      French = 4,
      Spanish = 5,
      Russian = 6,
      Chinese = 7,
      Portuguese = 8,
      Polish = 9,
      Unknown = 9999, // 0x0000270F
    }
  }
}
