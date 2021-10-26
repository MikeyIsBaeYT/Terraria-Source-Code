// Decompiled with JetBrains decompiler
// Type: Terraria.keyBoardInput
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Terraria
{
  public class keyBoardInput
  {
    public static event Action<char> newKeyEvent;

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool TranslateMessage(IntPtr message);

    static keyBoardInput() => Application.AddMessageFilter((IMessageFilter) new keyBoardInput.inKey());

    public class inKey : IMessageFilter
    {
      public bool PreFilterMessage(ref Message m)
      {
        if (m.Msg == 258)
        {
          char wparam = (char) (int) m.WParam;
          Console.WriteLine(wparam);
          if (keyBoardInput.newKeyEvent != null)
            keyBoardInput.newKeyEvent(wparam);
        }
        else if (m.Msg == 256)
        {
          IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf((object) m));
          Marshal.StructureToPtr((object) m, num, true);
          keyBoardInput.TranslateMessage(num);
        }
        return false;
      }
    }
  }
}
