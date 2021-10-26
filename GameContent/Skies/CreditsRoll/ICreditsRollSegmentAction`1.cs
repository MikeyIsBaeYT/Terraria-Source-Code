// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.CreditsRoll.ICreditsRollSegmentAction`1
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.Skies.CreditsRoll
{
  public interface ICreditsRollSegmentAction<T>
  {
    void BindTo(T obj);

    int ExpectedLengthOfActionInFrames { get; }

    void ApplyTo(T obj, float localTimeForObj);

    void SetDelay(float delay);
  }
}
