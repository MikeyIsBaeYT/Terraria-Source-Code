// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.WeGameHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Terraria.Social.WeGame
{
  public class WeGameHelper
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern void OutputDebugString(string message);

    public static void WriteDebugString(string format, params object[] args)
    {
      string str = "[WeGame] - " + format;
    }

    public static string Serialize<T>(T data)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        new DataContractJsonSerializer(typeof (T)).WriteObject((Stream) memoryStream, (object) data);
        memoryStream.Position = 0L;
        using (StreamReader streamReader = new StreamReader((Stream) memoryStream, Encoding.UTF8))
          return streamReader.ReadToEnd();
      }
    }

    public static void UnSerialize<T>(string str, out T data)
    {
      using (MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(str)))
      {
        DataContractJsonSerializer contractJsonSerializer = new DataContractJsonSerializer(typeof (T));
        data = (T) contractJsonSerializer.ReadObject((Stream) memoryStream);
      }
    }
  }
}
