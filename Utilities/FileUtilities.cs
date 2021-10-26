// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.FileUtilities
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Terraria.Social;

namespace Terraria.Utilities
{
  public static class FileUtilities
  {
    private static Regex FileNameRegex = new Regex("^(?<path>.*[\\\\\\/])?(?:$|(?<fileName>.+?)(?:(?<extension>\\.[^.]*$)|$))", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static bool Exists(string path, bool cloud) => cloud && SocialAPI.Cloud != null ? SocialAPI.Cloud.HasFile(path) : File.Exists(path);

    public static void Delete(string path, bool cloud)
    {
      if (cloud && SocialAPI.Cloud != null)
        SocialAPI.Cloud.Delete(path);
      else
        FileOperationAPIWrapper.MoveToRecycleBin(path);
    }

    public static string GetFullPath(string path, bool cloud) => !cloud ? Path.GetFullPath(path) : path;

    public static void Copy(string source, string destination, bool cloud, bool overwrite = true)
    {
      if (!cloud)
      {
        File.Copy(source, destination, overwrite);
      }
      else
      {
        if (SocialAPI.Cloud == null || !overwrite && SocialAPI.Cloud.HasFile(destination))
          return;
        SocialAPI.Cloud.Write(destination, SocialAPI.Cloud.Read(source));
      }
    }

    public static void Move(string source, string destination, bool cloud, bool overwrite = true)
    {
      FileUtilities.Copy(source, destination, cloud, overwrite);
      FileUtilities.Delete(source, cloud);
    }

    public static int GetFileSize(string path, bool cloud) => cloud && SocialAPI.Cloud != null ? SocialAPI.Cloud.GetFileSize(path) : (int) new FileInfo(path).Length;

    public static void Read(string path, byte[] buffer, int length, bool cloud)
    {
      if (cloud && SocialAPI.Cloud != null)
      {
        SocialAPI.Cloud.Read(path, buffer, length);
      }
      else
      {
        using (FileStream fileStream = File.OpenRead(path))
          fileStream.Read(buffer, 0, length);
      }
    }

    public static byte[] ReadAllBytes(string path, bool cloud) => cloud && SocialAPI.Cloud != null ? SocialAPI.Cloud.Read(path) : File.ReadAllBytes(path);

    public static void WriteAllBytes(string path, byte[] data, bool cloud) => FileUtilities.Write(path, data, data.Length, cloud);

    public static void Write(string path, byte[] data, int length, bool cloud)
    {
      if (cloud && SocialAPI.Cloud != null)
      {
        SocialAPI.Cloud.Write(path, data, length);
      }
      else
      {
        string parentFolderPath = FileUtilities.GetParentFolderPath(path);
        if (parentFolderPath != "")
          Utils.TryCreatingDirectory(parentFolderPath);
        FileUtilities.RemoveReadOnlyAttribute(path);
        using (FileStream fileStream = File.Open(path, FileMode.Create))
        {
          while (fileStream.Position < (long) length)
            fileStream.Write(data, (int) fileStream.Position, Math.Min(length - (int) fileStream.Position, 2048));
        }
      }
    }

    public static void RemoveReadOnlyAttribute(string path)
    {
      if (!File.Exists(path))
        return;
      try
      {
        FileAttributes attributes = File.GetAttributes(path);
        if ((attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
          return;
        FileAttributes fileAttributes = attributes & ~FileAttributes.ReadOnly;
        File.SetAttributes(path, fileAttributes);
      }
      catch (Exception ex)
      {
      }
    }

    public static bool MoveToCloud(string localPath, string cloudPath)
    {
      if (SocialAPI.Cloud == null)
        return false;
      FileUtilities.WriteAllBytes(cloudPath, FileUtilities.ReadAllBytes(localPath, false), true);
      FileUtilities.Delete(localPath, false);
      return true;
    }

    public static bool MoveToLocal(string cloudPath, string localPath)
    {
      if (SocialAPI.Cloud == null)
        return false;
      FileUtilities.WriteAllBytes(localPath, FileUtilities.ReadAllBytes(cloudPath, true), false);
      FileUtilities.Delete(cloudPath, true);
      return true;
    }

    public static string GetFileName(string path, bool includeExtension = true)
    {
      Match match = FileUtilities.FileNameRegex.Match(path);
      if (match == null || match.Groups["fileName"] == null)
        return "";
      includeExtension &= match.Groups["extension"] != null;
      return match.Groups["fileName"].Value + (includeExtension ? match.Groups["extension"].Value : "");
    }

    public static string GetParentFolderPath(string path, bool includeExtension = true)
    {
      Match match = FileUtilities.FileNameRegex.Match(path);
      return match == null || match.Groups[nameof (path)] == null ? "" : match.Groups[nameof (path)].Value;
    }

    public static void CopyFolder(string sourcePath, string destinationPath)
    {
      Directory.CreateDirectory(destinationPath);
      foreach (string directory in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        Directory.CreateDirectory(directory.Replace(sourcePath, destinationPath));
      foreach (string file in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        File.Copy(file, file.Replace(sourcePath, destinationPath), true);
    }

    public static void ProtectedInvoke(Action action)
    {
      bool isBackground = Thread.CurrentThread.IsBackground;
      try
      {
        Thread.CurrentThread.IsBackground = false;
        action();
      }
      finally
      {
        Thread.CurrentThread.IsBackground = isBackground;
      }
    }
  }
}
