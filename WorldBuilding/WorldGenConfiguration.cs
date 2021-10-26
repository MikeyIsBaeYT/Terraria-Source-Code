// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.WorldGenConfiguration
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using Terraria.IO;

namespace Terraria.WorldBuilding
{
  public class WorldGenConfiguration : GameConfiguration
  {
    private readonly JObject _biomeRoot;
    private readonly JObject _passRoot;

    public WorldGenConfiguration(JObject configurationRoot)
      : base(configurationRoot)
    {
      this._biomeRoot = (JObject) configurationRoot["Biomes"] ?? new JObject();
      this._passRoot = (JObject) configurationRoot["Passes"] ?? new JObject();
    }

    public T CreateBiome<T>() where T : MicroBiome, new() => this.CreateBiome<T>(typeof (T).Name);

    public T CreateBiome<T>(string name) where T : MicroBiome, new()
    {
      JToken jtoken;
      return this._biomeRoot.TryGetValue(name, ref jtoken) ? jtoken.ToObject<T>() : new T();
    }

    public GameConfiguration GetPassConfiguration(string name)
    {
      JToken jtoken;
      return this._passRoot.TryGetValue(name, ref jtoken) ? new GameConfiguration((JObject) jtoken) : new GameConfiguration(new JObject());
    }

    public static WorldGenConfiguration FromEmbeddedPath(string path)
    {
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
      {
        using (StreamReader streamReader = new StreamReader(manifestResourceStream))
          return new WorldGenConfiguration(JsonConvert.DeserializeObject<JObject>(streamReader.ReadToEnd()));
      }
    }
  }
}
