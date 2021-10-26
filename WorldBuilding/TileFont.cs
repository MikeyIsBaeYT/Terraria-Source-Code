// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.TileFont
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Terraria.WorldBuilding
{
  public class TileFont
  {
    private static readonly Dictionary<char, byte[]> MicroFont = new Dictionary<char, byte[]>()
    {
      {
        'A',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 68,
          (byte) 124,
          (byte) 68
        }
      },
      {
        'B',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 120,
          (byte) 68,
          (byte) 124
        }
      },
      {
        'C',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 64,
          (byte) 64,
          (byte) 124
        }
      },
      {
        'D',
        new byte[5]
        {
          (byte) 120,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 120
        }
      },
      {
        'E',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 120,
          (byte) 64,
          (byte) 124
        }
      },
      {
        'F',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 112,
          (byte) 64,
          (byte) 64
        }
      },
      {
        'G',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 76,
          (byte) 68,
          (byte) 124
        }
      },
      {
        'H',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 124,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'I',
        new byte[5]
        {
          (byte) 124,
          (byte) 16,
          (byte) 16,
          (byte) 16,
          (byte) 124
        }
      },
      {
        'J',
        new byte[5]
        {
          (byte) 12,
          (byte) 4,
          (byte) 4,
          (byte) 68,
          (byte) 124
        }
      },
      {
        'K',
        new byte[5]
        {
          (byte) 68,
          (byte) 72,
          (byte) 112,
          (byte) 72,
          (byte) 68
        }
      },
      {
        'L',
        new byte[5]
        {
          (byte) 64,
          (byte) 64,
          (byte) 64,
          (byte) 64,
          (byte) 124
        }
      },
      {
        'M',
        new byte[5]
        {
          (byte) 68,
          (byte) 108,
          (byte) 84,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'N',
        new byte[5]
        {
          (byte) 68,
          (byte) 100,
          (byte) 84,
          (byte) 76,
          (byte) 68
        }
      },
      {
        'O',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 124
        }
      },
      {
        'P',
        new byte[5]
        {
          (byte) 120,
          (byte) 68,
          (byte) 120,
          (byte) 64,
          (byte) 64
        }
      },
      {
        'Q',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 68,
          (byte) 124,
          (byte) 16
        }
      },
      {
        'R',
        new byte[5]
        {
          (byte) 120,
          (byte) 68,
          (byte) 120,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'S',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 124,
          (byte) 4,
          (byte) 124
        }
      },
      {
        'T',
        new byte[5]
        {
          (byte) 124,
          (byte) 16,
          (byte) 16,
          (byte) 16,
          (byte) 16
        }
      },
      {
        'U',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 124
        }
      },
      {
        'V',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 40,
          (byte) 40,
          (byte) 16
        }
      },
      {
        'W',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 84,
          (byte) 84,
          (byte) 40
        }
      },
      {
        'X',
        new byte[5]
        {
          (byte) 68,
          (byte) 40,
          (byte) 16,
          (byte) 40,
          (byte) 68
        }
      },
      {
        'Y',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 40,
          (byte) 16,
          (byte) 16
        }
      },
      {
        'Z',
        new byte[5]
        {
          (byte) 124,
          (byte) 8,
          (byte) 16,
          (byte) 32,
          (byte) 124
        }
      },
      {
        'a',
        new byte[5]
        {
          (byte) 56,
          (byte) 4,
          (byte) 60,
          (byte) 68,
          (byte) 60
        }
      },
      {
        'b',
        new byte[5]
        {
          (byte) 64,
          (byte) 120,
          (byte) 68,
          (byte) 68,
          (byte) 120
        }
      },
      {
        'c',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 64,
          (byte) 68,
          (byte) 56
        }
      },
      {
        'd',
        new byte[5]
        {
          (byte) 4,
          (byte) 60,
          (byte) 68,
          (byte) 68,
          (byte) 60
        }
      },
      {
        'e',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 124,
          (byte) 64,
          (byte) 60
        }
      },
      {
        'f',
        new byte[5]
        {
          (byte) 28,
          (byte) 32,
          (byte) 120,
          (byte) 32,
          (byte) 32
        }
      },
      {
        'g',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 60,
          (byte) 4,
          (byte) 120
        }
      },
      {
        'h',
        new byte[5]
        {
          (byte) 64,
          (byte) 64,
          (byte) 120,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'i',
        new byte[5]
        {
          (byte) 16,
          (byte) 0,
          (byte) 16,
          (byte) 16,
          (byte) 16
        }
      },
      {
        'j',
        new byte[5]
        {
          (byte) 4,
          (byte) 4,
          (byte) 4,
          (byte) 4,
          (byte) 120
        }
      },
      {
        'k',
        new byte[5]
        {
          (byte) 64,
          (byte) 72,
          (byte) 112,
          (byte) 72,
          (byte) 68
        }
      },
      {
        'l',
        new byte[5]
        {
          (byte) 64,
          (byte) 64,
          (byte) 64,
          (byte) 64,
          (byte) 60
        }
      },
      {
        'm',
        new byte[5]
        {
          (byte) 40,
          (byte) 84,
          (byte) 84,
          (byte) 84,
          (byte) 84
        }
      },
      {
        'n',
        new byte[5]
        {
          (byte) 120,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'o',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 56
        }
      },
      {
        'p',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 68,
          (byte) 120,
          (byte) 64
        }
      },
      {
        'q',
        new byte[5]
        {
          (byte) 56,
          (byte) 68,
          (byte) 68,
          (byte) 60,
          (byte) 4
        }
      },
      {
        'r',
        new byte[5]
        {
          (byte) 88,
          (byte) 100,
          (byte) 64,
          (byte) 64,
          (byte) 64
        }
      },
      {
        's',
        new byte[5]
        {
          (byte) 60,
          (byte) 64,
          (byte) 56,
          (byte) 4,
          (byte) 120
        }
      },
      {
        't',
        new byte[5]
        {
          (byte) 64,
          (byte) 112,
          (byte) 64,
          (byte) 68,
          (byte) 56
        }
      },
      {
        'u',
        new byte[5]
        {
          (byte) 0,
          (byte) 68,
          (byte) 68,
          (byte) 68,
          (byte) 56
        }
      },
      {
        'v',
        new byte[5]
        {
          (byte) 0,
          (byte) 68,
          (byte) 68,
          (byte) 40,
          (byte) 16
        }
      },
      {
        'w',
        new byte[5]
        {
          (byte) 84,
          (byte) 84,
          (byte) 84,
          (byte) 84,
          (byte) 40
        }
      },
      {
        'x',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 56,
          (byte) 68,
          (byte) 68
        }
      },
      {
        'y',
        new byte[5]
        {
          (byte) 68,
          (byte) 68,
          (byte) 60,
          (byte) 4,
          (byte) 120
        }
      },
      {
        'z',
        new byte[5]
        {
          (byte) 124,
          (byte) 4,
          (byte) 56,
          (byte) 64,
          (byte) 124
        }
      },
      {
        '0',
        new byte[5]
        {
          (byte) 124,
          (byte) 76,
          (byte) 84,
          (byte) 100,
          (byte) 124
        }
      },
      {
        '1',
        new byte[5]
        {
          (byte) 16,
          (byte) 48,
          (byte) 16,
          (byte) 16,
          (byte) 56
        }
      },
      {
        '2',
        new byte[5]
        {
          (byte) 120,
          (byte) 4,
          (byte) 56,
          (byte) 64,
          (byte) 124
        }
      },
      {
        '3',
        new byte[5]
        {
          (byte) 124,
          (byte) 4,
          (byte) 56,
          (byte) 4,
          (byte) 124
        }
      },
      {
        '4',
        new byte[5]
        {
          (byte) 64,
          (byte) 64,
          (byte) 80,
          (byte) 124,
          (byte) 16
        }
      },
      {
        '5',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 120,
          (byte) 4,
          (byte) 120
        }
      },
      {
        '6',
        new byte[5]
        {
          (byte) 124,
          (byte) 64,
          (byte) 124,
          (byte) 68,
          (byte) 124
        }
      },
      {
        '7',
        new byte[5]
        {
          (byte) 124,
          (byte) 4,
          (byte) 8,
          (byte) 16,
          (byte) 16
        }
      },
      {
        '8',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 124,
          (byte) 68,
          (byte) 124
        }
      },
      {
        '9',
        new byte[5]
        {
          (byte) 124,
          (byte) 68,
          (byte) 124,
          (byte) 4,
          (byte) 124
        }
      },
      {
        '-',
        new byte[5]
        {
          (byte) 0,
          (byte) 0,
          (byte) 124,
          (byte) 0,
          (byte) 0
        }
      },
      {
        ' ',
        new byte[5]
      }
    };

    public static void DrawString(Point start, string text, TileFont.DrawMode mode)
    {
      Point position = start;
      foreach (char key in text)
      {
        if (key == '\n')
        {
          position.X = start.X;
          position.Y += 6;
        }
        byte[] charData;
        if (TileFont.MicroFont.TryGetValue(key, out charData))
        {
          TileFont.DrawChar(position, charData, mode);
          position.X += 6;
        }
      }
    }

    private static void DrawChar(Point position, byte[] charData, TileFont.DrawMode mode)
    {
      if (mode.HasBackground)
      {
        for (int index1 = -1; index1 < charData.Length + 1; ++index1)
        {
          for (int index2 = -1; index2 < 6; ++index2)
          {
            Main.tile[position.X + index2, position.Y + index1].ResetToType(mode.BackgroundTile);
            WorldGen.TileFrame(position.X + index2, position.Y + index1);
          }
        }
      }
      for (int index3 = 0; index3 < charData.Length; ++index3)
      {
        int num = (int) charData[index3] << 1;
        for (int index4 = 0; index4 < 5; ++index4)
        {
          if ((num & 128) == 128)
          {
            Main.tile[position.X + index4, position.Y + index3].ResetToType(mode.ForegroundTile);
            WorldGen.TileFrame(position.X + index4, position.Y + index3);
          }
          num <<= 1;
        }
      }
    }

    public static Point MeasureString(string text)
    {
      Point zero = Point.Zero;
      Point point1 = zero;
      Point point2 = new Point(0, 5);
      foreach (char key in text)
      {
        if (key == '\n')
        {
          point1.X = zero.X;
          point1.Y += 6;
          point2.Y = point1.Y + 5;
        }
        if (TileFont.MicroFont.TryGetValue(key, out byte[] _))
        {
          point1.X += 6;
          point2.X = Math.Max(point2.X, point1.X - 1);
        }
      }
      return point2;
    }

    public static void HLineLabel(
      Point start,
      int width,
      string text,
      TileFont.DrawMode mode,
      bool rightSideText = false)
    {
      Point point = TileFont.MeasureString(text);
      for (int x = start.X; x < start.X + width; ++x)
      {
        Main.tile[x, start.Y].ResetToType(mode.ForegroundTile);
        WorldGen.TileFrame(x, start.Y);
      }
      TileFont.DrawString(new Point(rightSideText ? start.X + width + 1 : start.X - point.X - 1, start.Y - point.Y / 2), text, mode);
    }

    public static void VLineLabel(
      Point start,
      int height,
      string text,
      TileFont.DrawMode mode,
      bool bottomText = false)
    {
      Point point = TileFont.MeasureString(text);
      for (int y = start.Y; y < start.Y + height; ++y)
      {
        Main.tile[start.X, y].ResetToType(mode.ForegroundTile);
        WorldGen.TileFrame(start.X, y);
      }
      TileFont.DrawString(new Point(start.X - point.X / 2, bottomText ? start.Y + height + 1 : start.Y - point.Y - 1), text, mode);
    }

    public struct DrawMode
    {
      public readonly ushort ForegroundTile;
      public readonly ushort BackgroundTile;
      public readonly bool HasBackground;

      public DrawMode(ushort foregroundTile)
      {
        this.ForegroundTile = foregroundTile;
        this.HasBackground = false;
        this.BackgroundTile = (ushort) 0;
      }

      public DrawMode(ushort foregroundTile, ushort backgroundTile)
      {
        this.ForegroundTile = foregroundTile;
        this.BackgroundTile = backgroundTile;
        this.HasBackground = true;
      }
    }
  }
}
