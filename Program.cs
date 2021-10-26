// Decompiled with JetBrains decompiler
// Type: Terraria.Program
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace Terraria
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      using (Terraria.Main main = new Terraria.Main())
      {
        try
        {
          for (int index = 0; index < args.Length; ++index)
          {
            if (args[index].ToLower() == "-port" || args[index].ToLower() == "-p")
            {
              ++index;
              try
              {
                Netplay.serverPort = Convert.ToInt32(args[index]);
              }
              catch
              {
              }
            }
            if (args[index].ToLower() == "-join" || args[index].ToLower() == "-j")
            {
              ++index;
              try
              {
                main.AutoJoin(args[index]);
              }
              catch
              {
              }
            }
            if (args[index].ToLower() == "-pass" || args[index].ToLower() == "-password")
            {
              ++index;
              Netplay.password = args[index];
              main.AutoPass();
            }
            if (args[index].ToLower() == "-host")
              main.AutoHost();
            if (args[index].ToLower() == "-loadlib")
            {
              ++index;
              string path = args[index];
              main.loadLib(path);
            }
          }
          Steam.Init();
          if (Steam.SteamInit)
          {
            main.Run();
          }
          else
          {
            int num = (int) MessageBox.Show("Please launch the game from your Steam client.", "Error");
          }
        }
        catch (Exception ex)
        {
          try
          {
            using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
            {
              streamWriter.WriteLine((object) DateTime.Now);
              streamWriter.WriteLine((object) ex);
              streamWriter.WriteLine("");
            }
            int num = (int) MessageBox.Show(ex.ToString(), "Terraria: Error");
          }
          catch
          {
          }
        }
      }
    }
  }
}
