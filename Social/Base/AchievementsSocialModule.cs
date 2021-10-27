// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.AchievementsSocialModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Social.Base
{
  public abstract class AchievementsSocialModule : ISocialModule
  {
    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract byte[] GetEncryptionKey();

    public abstract string GetSavePath();

    public abstract void UpdateIntStat(string name, int value);

    public abstract void UpdateFloatStat(string name, float value);

    public abstract void CompleteAchievement(string name);

    public abstract bool IsAchievementCompleted(string name);

    public abstract void StoreStats();
  }
}
