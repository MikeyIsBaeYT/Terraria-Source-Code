// Decompiled with JetBrains decompiler
// Type: Terraria.Testing.ChatCommands.ArgumentHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Testing.ChatCommands
{
  public static class ArgumentHelper
  {
    public static ArgumentListResult ParseList(string arguments) => new ArgumentListResult(((IEnumerable<string>) arguments.Split(' ')).Select<string, string>((Func<string, string>) (arg => arg.Trim())).Where<string>((Func<string, bool>) (arg => (uint) arg.Length > 0U)));
  }
}
