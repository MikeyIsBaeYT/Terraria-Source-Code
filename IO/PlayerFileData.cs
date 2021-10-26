// Decompiled with JetBrains decompiler
// Type: Terraria.IO.PlayerFileData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.IO
{
  public class PlayerFileData : FileData
  {
    private Player _player;
    private TimeSpan _playTime = TimeSpan.Zero;
    private readonly Stopwatch _timer = new Stopwatch();
    private bool _isTimerActive;

    public Player Player
    {
      get => this._player;
      set
      {
        this._player = value;
        if (value == null)
          return;
        this.Name = this._player.name;
      }
    }

    public PlayerFileData()
      : base(nameof (Player))
    {
    }

    public PlayerFileData(string path, bool cloudSave)
      : base(nameof (Player), path, cloudSave)
    {
    }

    public static PlayerFileData CreateAndSave(Player player)
    {
      PlayerFileData playerFile = new PlayerFileData();
      playerFile.Metadata = FileMetadata.FromCurrentSettings(FileType.Player);
      playerFile.Player = player;
      playerFile._isCloudSave = SocialAPI.Cloud != null && SocialAPI.Cloud.EnabledByDefault;
      playerFile._path = Main.GetPlayerPathFromName(player.name, playerFile.IsCloudSave);
      (playerFile.IsCloudSave ? Main.CloudFavoritesData : Main.LocalFavoriteData).ClearEntry((FileData) playerFile);
      Player.SavePlayer(playerFile, true);
      return playerFile;
    }

    public override void SetAsActive()
    {
      Main.ActivePlayerFileData = this;
      Main.player[Main.myPlayer] = this.Player;
    }

    public override void MoveToCloud()
    {
      if (this.IsCloudSave || SocialAPI.Cloud == null)
        return;
      string playerPathFromName = Main.GetPlayerPathFromName(this.Name, true);
      if (!FileUtilities.MoveToCloud(this.Path, playerPathFromName))
        return;
      string fileName = this.GetFileName(false);
      string path = Main.PlayerPath + Path.DirectorySeparatorChar.ToString() + fileName + Path.DirectorySeparatorChar.ToString();
      if (Directory.Exists(path))
      {
        string[] files = Directory.GetFiles(path);
        for (int index = 0; index < files.Length; ++index)
        {
          string cloudPath = Main.CloudPlayerPath + "/" + fileName + "/" + FileUtilities.GetFileName(files[index]);
          FileUtilities.MoveToCloud(files[index], cloudPath);
        }
      }
      Main.LocalFavoriteData.ClearEntry((FileData) this);
      this._isCloudSave = true;
      this._path = playerPathFromName;
      Main.CloudFavoritesData.SaveFavorite((FileData) this);
    }

    public override void MoveToLocal()
    {
      if (!this.IsCloudSave || SocialAPI.Cloud == null)
        return;
      string playerPathFromName = Main.GetPlayerPathFromName(this.Name, false);
      if (!FileUtilities.MoveToLocal(this.Path, playerPathFromName))
        return;
      string fileName = this.GetFileName(false);
      string mapPath = Path.Combine(Main.CloudPlayerPath, fileName);
      foreach (string str in SocialAPI.Cloud.GetFiles().Where<string>((Func<string, bool>) (path => path.StartsWith(mapPath, StringComparison.CurrentCultureIgnoreCase) && path.EndsWith(".map", StringComparison.CurrentCultureIgnoreCase))))
      {
        string localPath = Path.Combine(Main.PlayerPath, fileName, FileUtilities.GetFileName(str));
        FileUtilities.MoveToLocal(str, localPath);
      }
      Main.CloudFavoritesData.ClearEntry((FileData) this);
      this._isCloudSave = false;
      this._path = playerPathFromName;
      Main.LocalFavoriteData.SaveFavorite((FileData) this);
    }

    public void UpdatePlayTimer()
    {
      bool flag1 = Main.gamePaused && !Main.hasFocus;
      bool flag2 = Main.instance.IsActive && !flag1;
      if (Main.gameMenu)
        flag2 = false;
      if (flag2)
        this.StartPlayTimer();
      else
        this.PausePlayTimer();
    }

    public void StartPlayTimer()
    {
      if (this._isTimerActive)
        return;
      this._isTimerActive = true;
      if (this._timer.IsRunning)
        return;
      this._timer.Start();
    }

    public void PausePlayTimer() => this.StopPlayTimer();

    public TimeSpan GetPlayTime() => this._timer.IsRunning ? this._playTime + this._timer.Elapsed : this._playTime;

    public void UpdatePlayTimerAndKeepState()
    {
      int num = this._timer.IsRunning ? 1 : 0;
      this._playTime += this._timer.Elapsed;
      this._timer.Reset();
      if (num == 0)
        return;
      this._timer.Start();
    }

    public void StopPlayTimer()
    {
      if (!this._isTimerActive)
        return;
      this._isTimerActive = false;
      if (!this._timer.IsRunning)
        return;
      this._playTime += this._timer.Elapsed;
      this._timer.Reset();
    }

    public void SetPlayTime(TimeSpan time) => this._playTime = time;
  }
}
