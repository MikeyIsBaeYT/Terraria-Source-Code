// Decompiled with JetBrains decompiler
// Type: Terraria.Program
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.IO;
using ReLogic.OS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
  public static class Program
  {
    public const bool IsServer = false;
    public const bool IsXna = true;
    public const bool IsFna = false;
    public const bool IsDebug = false;
    public static Dictionary<string, string> LaunchParameters = new Dictionary<string, string>();
    private static int ThingsToLoad;
    private static int ThingsLoaded;
    public static bool LoadedEverything;
    public static IntPtr JitForcedMethodCache;

    public static float LoadedPercentage => Program.ThingsToLoad == 0 ? 1f : (float) Program.ThingsLoaded / (float) Program.ThingsToLoad;

    public static void StartForceLoad()
    {
      if (!Main.SkipAssemblyLoad)
        new Thread(new ParameterizedThreadStart(Program.ForceLoadThread))
        {
          IsBackground = true
        }.Start();
      else
        Program.LoadedEverything = true;
    }

    public static void ForceLoadThread(object threadContext)
    {
      Program.ForceLoadAssembly(Assembly.GetExecutingAssembly(), true);
      Program.LoadedEverything = true;
    }

    private static void ForceJITOnAssembly(Assembly assembly)
    {
      foreach (System.Type type in assembly.GetTypes())
      {
        foreach (MethodInfo method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (!method.IsAbstract && !method.ContainsGenericParameters && method.GetMethodBody() != null)
            RuntimeHelpers.PrepareMethod(method.MethodHandle);
        }
        ++Program.ThingsLoaded;
      }
    }

    private static void ForceStaticInitializers(Assembly assembly)
    {
      foreach (System.Type type in assembly.GetTypes())
      {
        if (!type.IsGenericType)
          RuntimeHelpers.RunClassConstructor(type.TypeHandle);
      }
    }

    private static void ForceLoadAssembly(Assembly assembly, bool initializeStaticMembers)
    {
      Program.ThingsToLoad = assembly.GetTypes().Length;
      Program.ForceJITOnAssembly(assembly);
      if (!initializeStaticMembers)
        return;
      Program.ForceStaticInitializers(assembly);
    }

    private static void ForceLoadAssembly(string name, bool initializeStaticMembers)
    {
      Assembly assembly = (Assembly) null;
      Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
      for (int index = 0; index < assemblies.Length; ++index)
      {
        if (assemblies[index].GetName().Name.Equals(name))
        {
          assembly = assemblies[index];
          break;
        }
      }
      if (assembly == (Assembly) null)
        assembly = Assembly.Load(name);
      Program.ForceLoadAssembly(assembly, initializeStaticMembers);
    }

    private static void SetupLogging()
    {
      if (Program.LaunchParameters.ContainsKey("-logfile"))
      {
        string launchParameter = Program.LaunchParameters["-logfile"];
        ConsoleOutputMirror.ToFile(launchParameter == null || launchParameter.Trim() == "" ? Path.Combine(Main.SavePath, "Logs", string.Format("Log_{0:yyyyMMddHHmmssfff}.log", (object) DateTime.Now)) : Path.Combine(launchParameter, string.Format("Log_{0:yyyyMMddHHmmssfff}.log", (object) DateTime.Now)));
      }
      CrashWatcher.Inititialize();
      CrashWatcher.DumpOnException = Program.LaunchParameters.ContainsKey("-minidump");
      CrashWatcher.LogAllExceptions = Program.LaunchParameters.ContainsKey("-logerrors");
      if (!Program.LaunchParameters.ContainsKey("-fulldump"))
        return;
      Console.WriteLine("Full Dump logs enabled.");
      CrashWatcher.EnableCrashDumps(CrashDump.Options.WithFullMemory);
    }

    private static void InitializeConsoleOutput()
    {
      if (Debugger.IsAttached)
        return;
      try
      {
        Console.OutputEncoding = Encoding.UTF8;
        if (Platform.IsWindows)
          Console.InputEncoding = Encoding.Unicode;
        else
          Console.InputEncoding = Encoding.UTF8;
      }
      catch
      {
      }
    }

    public static void LaunchGame(string[] args, bool monoArgs = false)
    {
      Thread.CurrentThread.Name = "Main Thread";
      if (monoArgs)
        args = Utils.ConvertMonoArgsToDotNet(args);
      if (Platform.IsOSX)
        Main.OnEngineLoad += (Action) (() => Main.instance.IsMouseVisible = false);
      Program.LaunchParameters = Utils.ParseArguements(args);
      ThreadPool.SetMinThreads(8, 8);
      LanguageManager.Instance.SetLanguage(GameCulture.DefaultCulture);
      Program.InitializeConsoleOutput();
      Program.SetupLogging();
      Platform.Get<IWindowService>().SetQuickEditEnabled(false);
      using (Main game = new Main())
      {
        try
        {
          Lang.InitializeLegacyLocalization();
          SocialAPI.Initialize();
          LaunchInitializer.LoadParameters(game);
          Main.OnEnginePreload += new Action(Program.StartForceLoad);
          game.Run();
        }
        catch (Exception ex)
        {
          Program.DisplayException(ex);
        }
      }
    }

    private static void DisplayException(Exception e)
    {
      try
      {
        string text = e.ToString();
        if (WorldGen.gen)
        {
          try
          {
            text = string.Format("Creating world - Seed: {0} Width: {1}, Height: {2}, Evil: {3}, IsExpert: {4}\n{5}", (object) Main.ActiveWorldFileData.Seed, (object) Main.maxTilesX, (object) Main.maxTilesY, (object) WorldGen.WorldGenParam_Evil, (object) Main.expertMode, (object) text);
          }
          catch
          {
          }
        }
        using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
        {
          streamWriter.WriteLine((object) DateTime.Now);
          streamWriter.WriteLine(text);
          streamWriter.WriteLine("");
        }
        int num = (int) MessageBox.Show(text, "Terraria: Error");
      }
      catch
      {
      }
    }
  }
}
