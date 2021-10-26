// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.CrashDump
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.OS;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Terraria.Utilities
{
  public static class CrashDump
  {
    public static bool WriteException(CrashDump.Options options, string outputDirectory = ".") => CrashDump.Write(options, CrashDump.ExceptionInfo.Present, outputDirectory);

    public static bool Write(CrashDump.Options options, string outputDirectory = ".") => CrashDump.Write(options, CrashDump.ExceptionInfo.None, outputDirectory);

    private static string CreateDumpName()
    {
      DateTime localTime = DateTime.Now.ToLocalTime();
      return string.Format("{0}_{1}_{2}_{3}.dmp", (object) "Terraria", (object) Main.versionNumber, (object) localTime.ToString("MM-dd-yy_HH-mm-ss-ffff", (IFormatProvider) CultureInfo.InvariantCulture), (object) Thread.CurrentThread.ManagedThreadId);
    }

    private static bool Write(
      CrashDump.Options options,
      CrashDump.ExceptionInfo exceptionInfo,
      string outputDirectory)
    {
      if (!Platform.IsWindows)
        return false;
      string path = Path.Combine(outputDirectory, CrashDump.CreateDumpName());
      if (!Utils.TryCreatingDirectory(outputDirectory))
        return false;
      using (FileStream fileStream = File.Create(path))
        return CrashDump.Write((SafeHandle) fileStream.SafeFileHandle, options, exceptionInfo);
    }

    private static bool Write(
      SafeHandle fileHandle,
      CrashDump.Options options,
      CrashDump.ExceptionInfo exceptionInfo)
    {
      if (!Platform.IsWindows)
        return false;
      Process currentProcess = Process.GetCurrentProcess();
      IntPtr handle = currentProcess.Handle;
      uint id = (uint) currentProcess.Id;
      CrashDump.MiniDumpExceptionInformation expParam;
      expParam.ThreadId = CrashDump.GetCurrentThreadId();
      expParam.ClientPointers = false;
      expParam.ExceptionPointers = IntPtr.Zero;
      if (exceptionInfo == CrashDump.ExceptionInfo.Present)
        expParam.ExceptionPointers = Marshal.GetExceptionPointers();
      return !(expParam.ExceptionPointers == IntPtr.Zero) ? CrashDump.MiniDumpWriteDump(handle, id, fileHandle, (uint) options, ref expParam, IntPtr.Zero, IntPtr.Zero) : CrashDump.MiniDumpWriteDump(handle, id, fileHandle, (uint) options, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
    }

    [DllImport("dbghelp.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern bool MiniDumpWriteDump(
      IntPtr hProcess,
      uint processId,
      SafeHandle hFile,
      uint dumpType,
      ref CrashDump.MiniDumpExceptionInformation expParam,
      IntPtr userStreamParam,
      IntPtr callbackParam);

    [DllImport("dbghelp.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern bool MiniDumpWriteDump(
      IntPtr hProcess,
      uint processId,
      SafeHandle hFile,
      uint dumpType,
      IntPtr expParam,
      IntPtr userStreamParam,
      IntPtr callbackParam);

    [DllImport("kernel32.dll")]
    private static extern uint GetCurrentThreadId();

    [System.Flags]
    public enum Options : uint
    {
      Normal = 0,
      WithDataSegs = 1,
      WithFullMemory = 2,
      WithHandleData = 4,
      FilterMemory = 8,
      ScanMemory = 16, // 0x00000010
      WithUnloadedModules = 32, // 0x00000020
      WithIndirectlyReferencedMemory = 64, // 0x00000040
      FilterModulePaths = 128, // 0x00000080
      WithProcessThreadData = 256, // 0x00000100
      WithPrivateReadWriteMemory = 512, // 0x00000200
      WithoutOptionalData = 1024, // 0x00000400
      WithFullMemoryInfo = 2048, // 0x00000800
      WithThreadInfo = 4096, // 0x00001000
      WithCodeSegs = 8192, // 0x00002000
      WithoutAuxiliaryState = 16384, // 0x00004000
      WithFullAuxiliaryState = 32768, // 0x00008000
      WithPrivateWriteCopyMemory = 65536, // 0x00010000
      IgnoreInaccessibleMemory = 131072, // 0x00020000
      ValidTypeFlags = IgnoreInaccessibleMemory | WithPrivateWriteCopyMemory | WithFullAuxiliaryState | WithoutAuxiliaryState | WithCodeSegs | WithThreadInfo | WithFullMemoryInfo | WithoutOptionalData | WithPrivateReadWriteMemory | WithProcessThreadData | FilterModulePaths | WithIndirectlyReferencedMemory | WithUnloadedModules | ScanMemory | FilterMemory | WithHandleData | WithFullMemory | WithDataSegs, // 0x0003FFFF
    }

    private enum ExceptionInfo
    {
      None,
      Present,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    private struct MiniDumpExceptionInformation
    {
      public uint ThreadId;
      public IntPtr ExceptionPointers;
      [MarshalAs(UnmanagedType.Bool)]
      public bool ClientPointers;
    }
  }
}
