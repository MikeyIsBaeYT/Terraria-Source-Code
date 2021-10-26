// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.CurrentThreadRunner
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Windows.Threading;

namespace Terraria.Social.WeGame
{
  public class CurrentThreadRunner
  {
    private Dispatcher _dsipatcher;

    public CurrentThreadRunner() => this._dsipatcher = Dispatcher.CurrentDispatcher;

    public void Run(Action f) => this._dsipatcher.BeginInvoke((Delegate) f);
  }
}
