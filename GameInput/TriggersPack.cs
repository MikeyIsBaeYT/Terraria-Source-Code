// Decompiled with JetBrains decompiler
// Type: Terraria.GameInput.TriggersPack
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Linq;

namespace Terraria.GameInput
{
  public class TriggersPack
  {
    public TriggersSet Current = new TriggersSet();
    public TriggersSet Old = new TriggersSet();
    public TriggersSet JustPressed = new TriggersSet();
    public TriggersSet JustReleased = new TriggersSet();

    public void Initialize()
    {
      this.Current.SetupKeys();
      this.Old.SetupKeys();
      this.JustPressed.SetupKeys();
      this.JustReleased.SetupKeys();
    }

    public void Reset()
    {
      this.Old = this.Current.Clone();
      this.Current.Reset();
    }

    public void Update()
    {
      this.CompareDiffs(this.JustPressed, this.Old, this.Current);
      this.CompareDiffs(this.JustReleased, this.Current, this.Old);
    }

    public void CompareDiffs(TriggersSet Bearer, TriggersSet oldset, TriggersSet newset)
    {
      Bearer.Reset();
      foreach (string key in Bearer.KeyStatus.Keys.ToList<string>())
        Bearer.KeyStatus[key] = newset.KeyStatus[key] && !oldset.KeyStatus[key];
    }
  }
}
