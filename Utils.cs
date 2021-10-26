// Decompiled with JetBrains decompiler
// Type: Terraria.Utils
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.Utilities;
using Terraria.Utilities.Terraria.Utilities;

namespace Terraria
{
  public static class Utils
  {
    public const long MaxCoins = 999999999;
    public static Dictionary<DynamicSpriteFont, float[]> charLengths = new Dictionary<DynamicSpriteFont, float[]>();
    private static Regex _substitutionRegex = new Regex("{(\\?(?:!)?)?([a-zA-Z][\\w\\.]*)}", RegexOptions.Compiled);
    private const ulong RANDOM_MULTIPLIER = 25214903917;
    private const ulong RANDOM_ADD = 11;
    private const ulong RANDOM_MASK = 281474976710655;

    public static Color ColorLerp_BlackToWhite(float percent) => Color.Lerp(Color.Black, Color.White, percent);

    public static Vector2 Round(Vector2 input) => new Vector2((float) Math.Round((double) input.X), (float) Math.Round((double) input.Y));

    public static bool IsPowerOfTwo(int x) => x != 0 && (x & x - 1) == 0;

    public static float SmoothStep(float min, float max, float x) => MathHelper.Clamp((float) (((double) x - (double) min) / ((double) max - (double) min)), 0.0f, 1f);

    public static float UnclampedSmoothStep(float min, float max, float x) => (float) (((double) x - (double) min) / ((double) max - (double) min));

    public static Dictionary<string, string> ParseArguements(string[] args)
    {
      string str1 = (string) null;
      string str2 = "";
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      string str3;
      for (int index = 0; index < args.Length; ++index)
      {
        if (args[index].Length != 0)
        {
          if (args[index][0] == '-' || args[index][0] == '+')
          {
            if (str1 != null)
            {
              dictionary.Add(str1.ToLower(), str2);
              str3 = "";
            }
            str1 = args[index];
            str2 = "";
          }
          else
          {
            if (str2 != "")
              str2 += " ";
            str2 += args[index];
          }
        }
      }
      if (str1 != null)
      {
        dictionary.Add(str1.ToLower(), str2);
        str3 = "";
      }
      return dictionary;
    }

    public static void Swap<T>(ref T t1, ref T t2)
    {
      T obj = t1;
      t1 = t2;
      t2 = obj;
    }

    public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
    {
      if (value.CompareTo(max) > 0)
        return max;
      return value.CompareTo(min) < 0 ? min : value;
    }

    public static float Turn01ToCyclic010(float value) => (float) (1.0 - (Math.Cos((double) value * 6.28318548202515) * 0.5 + 0.5));

    public static float PingPongFrom01To010(float value)
    {
      value %= 1f;
      if ((double) value < 0.0)
        ++value;
      return (double) value >= 0.5 ? (float) (2.0 - (double) value * 2.0) : value * 2f;
    }

    public static float MultiLerp(float percent, params float[] floats)
    {
      float num1 = (float) (1.0 / ((double) floats.Length - 1.0));
      float num2 = num1;
      int index;
      for (index = 0; (double) percent / (double) num2 > 1.0 && index < floats.Length - 2; ++index)
        num2 += num1;
      return MathHelper.Lerp(floats[index], floats[index + 1], (percent - num1 * (float) index) / num1);
    }

    public static float WrappedLerp(float value1, float value2, float percent)
    {
      float amount = percent * 2f;
      if ((double) amount > 1.0)
        amount = 2f - amount;
      return MathHelper.Lerp(value1, value2, amount);
    }

    public static float GetLerpValue(float from, float to, float t, bool clamped = false)
    {
      if (clamped)
      {
        if ((double) from < (double) to)
        {
          if ((double) t < (double) from)
            return 0.0f;
          if ((double) t > (double) to)
            return 1f;
        }
        else
        {
          if ((double) t < (double) to)
            return 1f;
          if ((double) t > (double) from)
            return 0.0f;
        }
      }
      return (float) (((double) t - (double) from) / ((double) to - (double) from));
    }

    public static float Remap(
      float fromValue,
      float fromMin,
      float fromMax,
      float toMin,
      float toMax,
      bool clamped = true)
    {
      return MathHelper.Lerp(toMin, toMax, Utils.GetLerpValue(fromMin, fromMax, fromValue, clamped));
    }

    public static void ClampWithinWorld(
      ref int minX,
      ref int minY,
      ref int maxX,
      ref int maxY,
      bool lastValuesInclusiveToIteration = false,
      int fluffX = 0,
      int fluffY = 0)
    {
      int num = lastValuesInclusiveToIteration ? 1 : 0;
      minX = Utils.Clamp<int>(minX, fluffX, Main.maxTilesX - num - fluffX);
      maxX = Utils.Clamp<int>(maxX, fluffX, Main.maxTilesX - num - fluffX);
      minY = Utils.Clamp<int>(minY, fluffY, Main.maxTilesY - num - fluffY);
      maxY = Utils.Clamp<int>(maxY, fluffY, Main.maxTilesY - num - fluffY);
    }

    public static double GetLerpValue(double from, double to, double t, bool clamped = false)
    {
      if (clamped)
      {
        if (from < to)
        {
          if (t < from)
            return 0.0;
          if (t > to)
            return 1.0;
        }
        else
        {
          if (t < to)
            return 1.0;
          if (t > from)
            return 0.0;
        }
      }
      return (t - from) / (to - from);
    }

    public static string[] ConvertMonoArgsToDotNet(string[] brokenArgs)
    {
      ArrayList arrayList = new ArrayList();
      string str = "";
      for (int index = 0; index < brokenArgs.Length; ++index)
      {
        if (brokenArgs[index].StartsWith("-"))
        {
          if (str != "")
          {
            arrayList.Add((object) str);
            str = "";
          }
          else
            arrayList.Add((object) "");
          arrayList.Add((object) brokenArgs[index]);
        }
        else
        {
          if (str != "")
            str += " ";
          str += brokenArgs[index];
        }
      }
      arrayList.Add((object) str);
      string[] strArray = new string[arrayList.Count];
      arrayList.CopyTo((Array) strArray);
      return strArray;
    }

    public static T Max<T>(params T[] args) where T : IComparable
    {
      T obj = args[0];
      for (int index = 1; index < args.Length; ++index)
      {
        if (obj.CompareTo((object) args[index]) < 0)
          obj = args[index];
      }
      return obj;
    }

    public static List<List<TextSnippet>> WordwrapStringSmart(
      string text,
      Color c,
      DynamicSpriteFont font,
      int maxWidth,
      int maxLines)
    {
      TextSnippet[] array = ChatManager.ParseMessage(text, c).ToArray();
      List<List<TextSnippet>> textSnippetListList = new List<List<TextSnippet>>();
      List<TextSnippet> textSnippetList1 = new List<TextSnippet>();
      for (int index1 = 0; index1 < array.Length; ++index1)
      {
        TextSnippet textSnippet = array[index1];
        string[] strArray = textSnippet.Text.Split('\n');
        for (int index2 = 0; index2 < strArray.Length - 1; ++index2)
        {
          textSnippetList1.Add(textSnippet.CopyMorph(strArray[index2]));
          textSnippetListList.Add(textSnippetList1);
          textSnippetList1 = new List<TextSnippet>();
        }
        textSnippetList1.Add(textSnippet.CopyMorph(strArray[strArray.Length - 1]));
      }
      textSnippetListList.Add(textSnippetList1);
      if (maxWidth != -1)
      {
        for (int index3 = 0; index3 < textSnippetListList.Count; ++index3)
        {
          List<TextSnippet> textSnippetList2 = textSnippetListList[index3];
          float num1 = 0.0f;
          for (int index4 = 0; index4 < textSnippetList2.Count; ++index4)
          {
            float stringLength = textSnippetList2[index4].GetStringLength(font);
            if ((double) stringLength + (double) num1 > (double) maxWidth)
            {
              int num2 = maxWidth - (int) num1;
              if ((double) num1 > 0.0)
                num2 -= 16;
              int num3 = Math.Min(textSnippetList2[index4].Text.Length, num2 / 8);
              if (num3 < 0)
                num3 = 0;
              string[] strArray = textSnippetList2[index4].Text.Split(' ');
              int num4 = num3;
              if (strArray.Length > 1)
              {
                num4 = 0;
                for (int index5 = 0; index5 < strArray.Length && num4 + strArray[index5].Length <= num3; ++index5)
                  num4 += strArray[index5].Length + 1;
                if (num4 > num3)
                  num4 = num3;
              }
              string newText1 = textSnippetList2[index4].Text.Substring(0, num4);
              string newText2 = textSnippetList2[index4].Text.Substring(num4);
              List<TextSnippet> textSnippetList3 = new List<TextSnippet>()
              {
                textSnippetList2[index4].CopyMorph(newText2)
              };
              for (int index6 = index4 + 1; index6 < textSnippetList2.Count; ++index6)
                textSnippetList3.Add(textSnippetList2[index6]);
              textSnippetList2[index4] = textSnippetList2[index4].CopyMorph(newText1);
              textSnippetListList[index3] = textSnippetListList[index3].Take<TextSnippet>(index4 + 1).ToList<TextSnippet>();
              textSnippetListList.Insert(index3 + 1, textSnippetList3);
              break;
            }
            num1 += stringLength;
          }
        }
      }
      if (maxLines != -1)
      {
        while (textSnippetListList.Count > 10)
          textSnippetListList.RemoveAt(10);
      }
      return textSnippetListList;
    }

    public static string[] WordwrapString(
      string text,
      DynamicSpriteFont font,
      int maxWidth,
      int maxLines,
      out int lineAmount)
    {
      string[] strArray = new string[maxLines];
      int index1 = 0;
      List<string> stringList1 = new List<string>((IEnumerable<string>) text.Split('\n'));
      List<string> stringList2 = new List<string>((IEnumerable<string>) stringList1[0].Split(' '));
      for (int index2 = 1; index2 < stringList1.Count && index2 < maxLines; ++index2)
      {
        stringList2.Add("\n");
        stringList2.AddRange((IEnumerable<string>) stringList1[index2].Split(' '));
      }
      bool flag = true;
      while (stringList2.Count > 0)
      {
        string str1 = stringList2[0];
        string str2 = " ";
        if (stringList2.Count == 1)
          str2 = "";
        if (str1 == "\n")
        {
          // ISSUE: explicit reference operation
          ^ref strArray[index1++] += str1;
          flag = true;
          if (index1 < maxLines)
            stringList2.RemoveAt(0);
          else
            break;
        }
        else if (flag)
        {
          if ((double) font.MeasureString(str1).X > (double) maxWidth)
          {
            char ch = str1[0];
            string str3 = ch.ToString() ?? "";
            int num = 1;
            while (true)
            {
              DynamicSpriteFont dynamicSpriteFont = font;
              string str4 = str3;
              ch = str1[num];
              string str5 = ch.ToString();
              string str6 = str4 + str5 + "-";
              if ((double) dynamicSpriteFont.MeasureString(str6).X <= (double) maxWidth)
              {
                string str7 = str3;
                ch = str1[num++];
                string str8 = ch.ToString();
                str3 = str7 + str8;
              }
              else
                break;
            }
            string str9 = str3 + "-";
            strArray[index1++] = str9 + " ";
            if (index1 < maxLines)
            {
              stringList2.RemoveAt(0);
              stringList2.Insert(0, str1.Substring(num));
            }
            else
              break;
          }
          else
          {
            ref string local = ref strArray[index1];
            local = local + str1 + str2;
            flag = false;
            stringList2.RemoveAt(0);
          }
        }
        else if ((double) font.MeasureString(strArray[index1] + str1).X > (double) maxWidth)
        {
          ++index1;
          if (index1 < maxLines)
            flag = true;
          else
            break;
        }
        else
        {
          ref string local = ref strArray[index1];
          local = local + str1 + str2;
          flag = false;
          stringList2.RemoveAt(0);
        }
      }
      lineAmount = index1;
      if (lineAmount == maxLines)
        --lineAmount;
      return strArray;
    }

    public static Rectangle CenteredRectangle(Vector2 center, Vector2 size) => new Rectangle((int) ((double) center.X - (double) size.X / 2.0), (int) ((double) center.Y - (double) size.Y / 2.0), (int) size.X, (int) size.Y);

    public static Vector2 Vector2FromElipse(Vector2 angleVector, Vector2 elipseSizes)
    {
      if (elipseSizes == Vector2.Zero || angleVector == Vector2.Zero)
        return Vector2.Zero;
      angleVector.Normalize();
      Vector2 vector2 = Vector2.One / Vector2.Normalize(elipseSizes);
      angleVector *= vector2;
      angleVector.Normalize();
      return angleVector * elipseSizes / 2f;
    }

    public static bool FloatIntersect(
      float r1StartX,
      float r1StartY,
      float r1Width,
      float r1Height,
      float r2StartX,
      float r2StartY,
      float r2Width,
      float r2Height)
    {
      return (double) r1StartX <= (double) r2StartX + (double) r2Width && (double) r1StartY <= (double) r2StartY + (double) r2Height && (double) r1StartX + (double) r1Width >= (double) r2StartX && (double) r1StartY + (double) r1Height >= (double) r2StartY;
    }

    public static long CoinsCount(out bool overFlowing, Item[] inv, params int[] ignoreSlots)
    {
      List<int> intList = new List<int>((IEnumerable<int>) ignoreSlots);
      long num = 0;
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!intList.Contains(index))
        {
          switch (inv[index].type)
          {
            case 71:
              num += (long) inv[index].stack;
              break;
            case 72:
              num += (long) (inv[index].stack * 100);
              break;
            case 73:
              num += (long) (inv[index].stack * 10000);
              break;
            case 74:
              num += (long) (inv[index].stack * 1000000);
              break;
          }
          if (num >= 999999999L)
          {
            overFlowing = true;
            return 999999999;
          }
        }
      }
      overFlowing = false;
      return num;
    }

    public static int[] CoinsSplit(long count)
    {
      int[] numArray = new int[4];
      long num1 = 0;
      long num2 = 1000000;
      for (int index = 3; index >= 0; --index)
      {
        numArray[index] = (int) ((count - num1) / num2);
        num1 += (long) numArray[index] * num2;
        num2 /= 100L;
      }
      return numArray;
    }

    public static long CoinsCombineStacks(out bool overFlowing, params long[] coinCounts)
    {
      long num = 0;
      foreach (long coinCount in coinCounts)
      {
        num += coinCount;
        if (num >= 999999999L)
        {
          overFlowing = true;
          return 999999999;
        }
      }
      overFlowing = false;
      return num;
    }

    public static void PoofOfSmoke(Vector2 position)
    {
      int num = Main.rand.Next(3, 7);
      for (int index1 = 0; index1 < num; ++index1)
      {
        int index2 = Gore.NewGore(position, (Main.rand.NextFloat() * 6.283185f).ToRotationVector2() * new Vector2(2f, 0.7f) * 0.7f, Main.rand.Next(11, 14));
        Main.gore[index2].scale = 0.7f;
        Main.gore[index2].velocity *= 0.5f;
      }
      for (int index = 0; index < 10; ++index)
      {
        Dust dust = Main.dust[Dust.NewDust(position, 14, 14, 16, Alpha: 100, Scale: 1.5f)];
        dust.position += new Vector2(5f);
        dust.velocity = (Main.rand.NextFloat() * 6.283185f).ToRotationVector2() * new Vector2(2f, 0.7f) * 0.7f * (float) (0.5 + 0.5 * (double) Main.rand.NextFloat());
      }
    }

    public static Vector2 ToScreenPosition(this Vector2 worldPosition) => Vector2.Transform(worldPosition - Main.screenPosition, Main.GameViewMatrix.ZoomMatrix) / Main.UIScale;

    public static string PrettifyPercentDisplay(float percent, string originalFormat) => string.Format("{0:" + originalFormat + "}", (object) percent).TrimEnd('0', '%', ' ').TrimEnd('.', ' ').TrimStart('0', ' ') + "%";

    public static void TrimTextIfNeeded(
      ref string text,
      DynamicSpriteFont font,
      float scale,
      float maxWidth)
    {
      int num = 0;
      for (Vector2 vector2 = font.MeasureString(text) * scale; (double) vector2.X > (double) maxWidth; vector2 = font.MeasureString(text) * scale)
      {
        text = text.Substring(0, text.Length - 1);
        ++num;
      }
      if (num <= 0)
        return;
      text = text.Substring(0, text.Length - 1) + "…";
    }

    public static string FormatWith(string original, object obj)
    {
      string input = original;
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
      return Utils._substitutionRegex.Replace(input, (MatchEvaluator) (match =>
      {
        if (match.Groups[1].Length != 0)
          return "";
        PropertyDescriptor propertyDescriptor = properties.Find(match.Groups[2].ToString(), false);
        return propertyDescriptor == null ? "" : (propertyDescriptor.GetValue(obj) ?? (object) "").ToString();
      }));
    }

    public static bool TryCreatingDirectory(string folderPath)
    {
      if (Directory.Exists(folderPath))
        return true;
      try
      {
        Directory.CreateDirectory(folderPath);
        return true;
      }
      catch (Exception ex)
      {
        string folderPath1 = folderPath;
        FancyErrorPrinter.ShowDirectoryCreationFailError(ex, folderPath1);
        return false;
      }
    }

    public static void OpenFolder(string folderPath)
    {
      if (!Utils.TryCreatingDirectory(folderPath))
        return;
      Process.Start(folderPath);
    }

    public static byte[] ToByteArray(this string str)
    {
      byte[] numArray = new byte[str.Length * 2];
      Buffer.BlockCopy((Array) str.ToCharArray(), 0, (Array) numArray, 0, numArray.Length);
      return numArray;
    }

    public static float NextFloat(this UnifiedRandom r) => (float) r.NextDouble();

    public static float NextFloatDirection(this UnifiedRandom r) => (float) (r.NextDouble() * 2.0 - 1.0);

    public static float NextFloat(this UnifiedRandom random, FloatRange range) => random.NextFloat() * (range.Maximum - range.Minimum) + range.Minimum;

    public static T NextFromList<T>(this UnifiedRandom random, params T[] objs) => objs[random.Next(objs.Length)];

    public static int Next(this UnifiedRandom random, IntRange range) => random.Next(range.Minimum, range.Maximum + 1);

    public static Vector2 NextVector2Square(this UnifiedRandom r, float min, float max) => new Vector2((max - min) * (float) r.NextDouble() + min, (max - min) * (float) r.NextDouble() + min);

    public static Vector2 NextVector2FromRectangle(this UnifiedRandom r, Rectangle rect) => new Vector2((float) rect.X + r.NextFloat() * (float) rect.Width, (float) rect.Y + r.NextFloat() * (float) rect.Height);

    public static Vector2 NextVector2Unit(
      this UnifiedRandom r,
      float startRotation = 0.0f,
      float rotationRange = 6.283185f)
    {
      return (startRotation + rotationRange * r.NextFloat()).ToRotationVector2();
    }

    public static Vector2 NextVector2Circular(
      this UnifiedRandom r,
      float circleHalfWidth,
      float circleHalfHeight)
    {
      return r.NextVector2Unit() * new Vector2(circleHalfWidth, circleHalfHeight) * r.NextFloat();
    }

    public static Vector2 NextVector2CircularEdge(
      this UnifiedRandom r,
      float circleHalfWidth,
      float circleHalfHeight)
    {
      return r.NextVector2Unit() * new Vector2(circleHalfWidth, circleHalfHeight);
    }

    public static int Width(this Asset<Texture2D> asset) => !asset.IsLoaded ? 0 : asset.Value.Width;

    public static int Height(this Asset<Texture2D> asset) => !asset.IsLoaded ? 0 : asset.Value.Height;

    public static Rectangle Frame(
      this Asset<Texture2D> tex,
      int horizontalFrames = 1,
      int verticalFrames = 1,
      int frameX = 0,
      int frameY = 0,
      int sizeOffsetX = 0,
      int sizeOffsetY = 0)
    {
      return !tex.IsLoaded ? Rectangle.Empty : tex.Value.Frame(horizontalFrames, verticalFrames, frameX, frameY, sizeOffsetX, sizeOffsetY);
    }

    public static Rectangle OffsetSize(this Rectangle rect, int xSize, int ySize)
    {
      rect.Width += xSize;
      rect.Height += ySize;
      return rect;
    }

    public static Vector2 Size(this Asset<Texture2D> tex) => !tex.IsLoaded ? Vector2.Zero : tex.Value.Size();

    public static Rectangle Frame(
      this Texture2D tex,
      int horizontalFrames = 1,
      int verticalFrames = 1,
      int frameX = 0,
      int frameY = 0,
      int sizeOffsetX = 0,
      int sizeOffsetY = 0)
    {
      int num1 = tex.Width / horizontalFrames;
      int num2 = tex.Height / verticalFrames;
      return new Rectangle(num1 * frameX, num2 * frameY, num1 + sizeOffsetX, num2 + sizeOffsetY);
    }

    public static Vector2 OriginFlip(
      this Rectangle rect,
      Vector2 origin,
      SpriteEffects effects)
    {
      if (effects.HasFlag((Enum) SpriteEffects.FlipHorizontally))
        origin.X = (float) rect.Width - origin.X;
      if (effects.HasFlag((Enum) SpriteEffects.FlipVertically))
        origin.Y = (float) rect.Height - origin.Y;
      return origin;
    }

    public static Vector2 Size(this Texture2D tex) => new Vector2((float) tex.Width, (float) tex.Height);

    public static void WriteRGB(this BinaryWriter bb, Color c)
    {
      bb.Write(c.R);
      bb.Write(c.G);
      bb.Write(c.B);
    }

    public static void WriteVector2(this BinaryWriter bb, Vector2 v)
    {
      bb.Write(v.X);
      bb.Write(v.Y);
    }

    public static void WritePackedVector2(this BinaryWriter bb, Vector2 v)
    {
      HalfVector2 halfVector2 = new HalfVector2(v.X, v.Y);
      bb.Write(halfVector2.PackedValue);
    }

    public static Color ReadRGB(this BinaryReader bb) => new Color((int) bb.ReadByte(), (int) bb.ReadByte(), (int) bb.ReadByte());

    public static Vector2 ReadVector2(this BinaryReader bb) => new Vector2(bb.ReadSingle(), bb.ReadSingle());

    public static Vector2 ReadPackedVector2(this BinaryReader bb) => new HalfVector2()
    {
      PackedValue = bb.ReadUInt32()
    }.ToVector2();

    public static Vector2 Left(this Rectangle r) => new Vector2((float) r.X, (float) (r.Y + r.Height / 2));

    public static Vector2 Right(this Rectangle r) => new Vector2((float) (r.X + r.Width), (float) (r.Y + r.Height / 2));

    public static Vector2 Top(this Rectangle r) => new Vector2((float) (r.X + r.Width / 2), (float) r.Y);

    public static Vector2 Bottom(this Rectangle r) => new Vector2((float) (r.X + r.Width / 2), (float) (r.Y + r.Height));

    public static Vector2 TopLeft(this Rectangle r) => new Vector2((float) r.X, (float) r.Y);

    public static Vector2 TopRight(this Rectangle r) => new Vector2((float) (r.X + r.Width), (float) r.Y);

    public static Vector2 BottomLeft(this Rectangle r) => new Vector2((float) r.X, (float) (r.Y + r.Height));

    public static Vector2 BottomRight(this Rectangle r) => new Vector2((float) (r.X + r.Width), (float) (r.Y + r.Height));

    public static Vector2 Center(this Rectangle r) => new Vector2((float) (r.X + r.Width / 2), (float) (r.Y + r.Height / 2));

    public static Vector2 Size(this Rectangle r) => new Vector2((float) r.Width, (float) r.Height);

    public static float Distance(this Rectangle r, Vector2 point)
    {
      if (Utils.FloatIntersect((float) r.Left, (float) r.Top, (float) r.Width, (float) r.Height, point.X, point.Y, 0.0f, 0.0f))
        return 0.0f;
      return (double) point.X >= (double) r.Left && (double) point.X <= (double) r.Right ? ((double) point.Y < (double) r.Top ? (float) r.Top - point.Y : point.Y - (float) r.Bottom) : ((double) point.Y >= (double) r.Top && (double) point.Y <= (double) r.Bottom ? ((double) point.X < (double) r.Left ? (float) r.Left - point.X : point.X - (float) r.Right) : ((double) point.X < (double) r.Left ? ((double) point.Y < (double) r.Top ? Vector2.Distance(point, r.TopLeft()) : Vector2.Distance(point, r.BottomLeft())) : ((double) point.Y < (double) r.Top ? Vector2.Distance(point, r.TopRight()) : Vector2.Distance(point, r.BottomRight()))));
    }

    public static Vector2 ClosestPointInRect(this Rectangle r, Vector2 point)
    {
      Vector2 vector2 = point;
      if ((double) vector2.X < (double) r.Left)
        vector2.X = (float) r.Left;
      if ((double) vector2.X > (double) r.Right)
        vector2.X = (float) r.Right;
      if ((double) vector2.Y < (double) r.Top)
        vector2.Y = (float) r.Top;
      if ((double) vector2.Y > (double) r.Bottom)
        vector2.Y = (float) r.Bottom;
      return vector2;
    }

    public static Rectangle Modified(this Rectangle r, int x, int y, int w, int h) => new Rectangle(r.X + x, r.Y + y, r.Width + w, r.Height + h);

    public static float ToRotation(this Vector2 v) => (float) Math.Atan2((double) v.Y, (double) v.X);

    public static Vector2 ToRotationVector2(this float f) => new Vector2((float) Math.Cos((double) f), (float) Math.Sin((double) f));

    public static Vector2 RotatedBy(
      this Vector2 spinningpoint,
      double radians,
      Vector2 center = default (Vector2))
    {
      float num1 = (float) Math.Cos(radians);
      float num2 = (float) Math.Sin(radians);
      Vector2 vector2_1 = spinningpoint - center;
      Vector2 vector2_2 = center;
      vector2_2.X += (float) ((double) vector2_1.X * (double) num1 - (double) vector2_1.Y * (double) num2);
      vector2_2.Y += (float) ((double) vector2_1.X * (double) num2 + (double) vector2_1.Y * (double) num1);
      return vector2_2;
    }

    public static Vector2 RotatedByRandom(this Vector2 spinninpoint, double maxRadians) => spinninpoint.RotatedBy(Main.rand.NextDouble() * maxRadians - Main.rand.NextDouble() * maxRadians);

    public static Vector2 Floor(this Vector2 vec)
    {
      vec.X = (float) (int) vec.X;
      vec.Y = (float) (int) vec.Y;
      return vec;
    }

    public static bool HasNaNs(this Vector2 vec) => float.IsNaN(vec.X) || float.IsNaN(vec.Y);

    public static bool Between(this Vector2 vec, Vector2 minimum, Vector2 maximum) => (double) vec.X >= (double) minimum.X && (double) vec.X <= (double) maximum.X && (double) vec.Y >= (double) minimum.Y && (double) vec.Y <= (double) maximum.Y;

    public static Vector2 ToVector2(this Point p) => new Vector2((float) p.X, (float) p.Y);

    public static Vector2 ToVector2(this Point16 p) => new Vector2((float) p.X, (float) p.Y);

    public static Vector2 ToWorldCoordinates(this Point p, float autoAddX = 8f, float autoAddY = 8f) => p.ToVector2() * 16f + new Vector2(autoAddX, autoAddY);

    public static Vector2 ToWorldCoordinates(this Point16 p, float autoAddX = 8f, float autoAddY = 8f) => p.ToVector2() * 16f + new Vector2(autoAddX, autoAddY);

    public static Vector2 MoveTowards(
      this Vector2 currentPosition,
      Vector2 targetPosition,
      float maxAmountAllowedToMove)
    {
      Vector2 v = targetPosition - currentPosition;
      return (double) v.Length() < (double) maxAmountAllowedToMove ? targetPosition : currentPosition + v.SafeNormalize(Vector2.Zero) * maxAmountAllowedToMove;
    }

    public static Point16 ToTileCoordinates16(this Vector2 vec) => new Point16((int) vec.X >> 4, (int) vec.Y >> 4);

    public static Point ToTileCoordinates(this Vector2 vec) => new Point((int) vec.X >> 4, (int) vec.Y >> 4);

    public static Point ToPoint(this Vector2 v) => new Point((int) v.X, (int) v.Y);

    public static Vector2 SafeNormalize(this Vector2 v, Vector2 defaultValue) => v == Vector2.Zero || v.HasNaNs() ? defaultValue : Vector2.Normalize(v);

    public static Vector2 ClosestPointOnLine(this Vector2 P, Vector2 A, Vector2 B)
    {
      Vector2 vector2_1 = P - A;
      Vector2 vector2_2 = B - A;
      float num1 = vector2_2.LengthSquared();
      Vector2 vector2_3 = vector2_2;
      float num2 = Vector2.Dot(vector2_1, vector2_3) / num1;
      if ((double) num2 < 0.0)
        return A;
      return (double) num2 > 1.0 ? B : A + vector2_2 * num2;
    }

    public static bool RectangleLineCollision(
      Vector2 rectTopLeft,
      Vector2 rectBottomRight,
      Vector2 lineStart,
      Vector2 lineEnd)
    {
      if (lineStart.Between(rectTopLeft, rectBottomRight) || lineEnd.Between(rectTopLeft, rectBottomRight))
        return true;
      Vector2 P = new Vector2(rectBottomRight.X, rectTopLeft.Y);
      Vector2 vector2 = new Vector2(rectTopLeft.X, rectBottomRight.Y);
      Vector2[] vector2Array = new Vector2[4]
      {
        rectTopLeft.ClosestPointOnLine(lineStart, lineEnd),
        P.ClosestPointOnLine(lineStart, lineEnd),
        vector2.ClosestPointOnLine(lineStart, lineEnd),
        rectBottomRight.ClosestPointOnLine(lineStart, lineEnd)
      };
      for (int index = 0; index < vector2Array.Length; ++index)
      {
        if (vector2Array[0].Between(rectTopLeft, vector2))
          return true;
      }
      return false;
    }

    public static Vector2 RotateRandom(this Vector2 spinninpoint, double maxRadians) => spinninpoint.RotatedBy(Main.rand.NextDouble() * maxRadians - Main.rand.NextDouble() * maxRadians);

    public static float AngleTo(this Vector2 Origin, Vector2 Target) => (float) Math.Atan2((double) Target.Y - (double) Origin.Y, (double) Target.X - (double) Origin.X);

    public static float AngleFrom(this Vector2 Origin, Vector2 Target) => (float) Math.Atan2((double) Origin.Y - (double) Target.Y, (double) Origin.X - (double) Target.X);

    public static Vector2 rotateTowards(
      Vector2 currentPosition,
      Vector2 currentVelocity,
      Vector2 targetPosition,
      float maxChange)
    {
      float num = currentVelocity.Length();
      float targetAngle = currentPosition.AngleTo(targetPosition);
      return currentVelocity.ToRotation().AngleTowards(targetAngle, (float) Math.PI / 180f).ToRotationVector2() * num;
    }

    public static float Distance(this Vector2 Origin, Vector2 Target) => Vector2.Distance(Origin, Target);

    public static float DistanceSQ(this Vector2 Origin, Vector2 Target) => Vector2.DistanceSquared(Origin, Target);

    public static Vector2 DirectionTo(this Vector2 Origin, Vector2 Target) => Vector2.Normalize(Target - Origin);

    public static Vector2 DirectionFrom(this Vector2 Origin, Vector2 Target) => Vector2.Normalize(Origin - Target);

    public static bool WithinRange(this Vector2 Origin, Vector2 Target, float MaxRange) => (double) Vector2.DistanceSquared(Origin, Target) <= (double) MaxRange * (double) MaxRange;

    public static Vector2 XY(this Vector4 vec) => new Vector2(vec.X, vec.Y);

    public static Vector2 ZW(this Vector4 vec) => new Vector2(vec.Z, vec.W);

    public static Vector3 XZW(this Vector4 vec) => new Vector3(vec.X, vec.Z, vec.W);

    public static Vector3 YZW(this Vector4 vec) => new Vector3(vec.Y, vec.Z, vec.W);

    public static Color MultiplyRGB(this Color firstColor, Color secondColor) => new Color((int) (byte) ((double) ((int) firstColor.R * (int) secondColor.R) / (double) byte.MaxValue), (int) (byte) ((double) ((int) firstColor.G * (int) secondColor.G) / (double) byte.MaxValue), (int) (byte) ((double) ((int) firstColor.B * (int) secondColor.B) / (double) byte.MaxValue));

    public static Color MultiplyRGBA(this Color firstColor, Color secondColor) => new Color((int) (byte) ((double) ((int) firstColor.R * (int) secondColor.R) / (double) byte.MaxValue), (int) (byte) ((double) ((int) firstColor.G * (int) secondColor.G) / (double) byte.MaxValue), (int) (byte) ((double) ((int) firstColor.B * (int) secondColor.B) / (double) byte.MaxValue), (int) (byte) ((double) ((int) firstColor.A * (int) secondColor.A) / (double) byte.MaxValue));

    public static string Hex3(this Color color)
    {
      byte num = color.R;
      string str1 = num.ToString("X2");
      num = color.G;
      string str2 = num.ToString("X2");
      num = color.B;
      string str3 = num.ToString("X2");
      return (str1 + str2 + str3).ToLower();
    }

    public static string Hex4(this Color color)
    {
      byte num = color.R;
      string str1 = num.ToString("X2");
      num = color.G;
      string str2 = num.ToString("X2");
      num = color.B;
      string str3 = num.ToString("X2");
      num = color.A;
      string str4 = num.ToString("X2");
      return (str1 + str2 + str3 + str4).ToLower();
    }

    public static int ToDirectionInt(this bool value) => !value ? -1 : 1;

    public static int ToInt(this bool value) => !value ? 0 : 1;

    public static int ModulusPositive(this int myInteger, int modulusNumber) => (myInteger % modulusNumber + modulusNumber) % modulusNumber;

    public static float AngleLerp(this float curAngle, float targetAngle, float amount)
    {
      float angle;
      if ((double) targetAngle < (double) curAngle)
      {
        float num = targetAngle + 6.283185f;
        angle = (double) num - (double) curAngle > (double) curAngle - (double) targetAngle ? MathHelper.Lerp(curAngle, targetAngle, amount) : MathHelper.Lerp(curAngle, num, amount);
      }
      else
      {
        if ((double) targetAngle <= (double) curAngle)
          return curAngle;
        float num = targetAngle - 6.283185f;
        angle = (double) targetAngle - (double) curAngle > (double) curAngle - (double) num ? MathHelper.Lerp(curAngle, num, amount) : MathHelper.Lerp(curAngle, targetAngle, amount);
      }
      return MathHelper.WrapAngle(angle);
    }

    public static float AngleTowards(this float curAngle, float targetAngle, float maxChange)
    {
      curAngle = MathHelper.WrapAngle(curAngle);
      targetAngle = MathHelper.WrapAngle(targetAngle);
      if ((double) curAngle < (double) targetAngle)
      {
        if ((double) targetAngle - (double) curAngle > 3.14159274101257)
          curAngle += 6.283185f;
      }
      else if ((double) curAngle - (double) targetAngle > 3.14159274101257)
        curAngle -= 6.283185f;
      curAngle += MathHelper.Clamp(targetAngle - curAngle, -maxChange, maxChange);
      return MathHelper.WrapAngle(curAngle);
    }

    public static bool deepCompare(this int[] firstArray, int[] secondArray)
    {
      if (firstArray == null && secondArray == null)
        return true;
      if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
        return false;
      for (int index = 0; index < firstArray.Length; ++index)
      {
        if (firstArray[index] != secondArray[index])
          return false;
      }
      return true;
    }

    public static List<int> GetTrueIndexes(this bool[] array)
    {
      List<int> intList = new List<int>();
      for (int index = 0; index < array.Length; ++index)
      {
        if (array[index])
          intList.Add(index);
      }
      return intList;
    }

    public static List<int> GetTrueIndexes(params bool[][] arrays)
    {
      List<int> source = new List<int>();
      foreach (bool[] array in arrays)
        source.AddRange((IEnumerable<int>) array.GetTrueIndexes());
      return source.Distinct<int>().ToList<int>();
    }

    public static bool PressingShift(this KeyboardState kb) => kb.IsKeyDown(Keys.LeftShift) || kb.IsKeyDown(Keys.RightShift);

    public static bool PressingControl(this KeyboardState kb) => kb.IsKeyDown(Keys.LeftControl) || kb.IsKeyDown(Keys.RightControl);

    public static bool PlotLine(Point16 p0, Point16 p1, Utils.TileActionAttempt plot, bool jump = true) => Utils.PlotLine((int) p0.X, (int) p0.Y, (int) p1.X, (int) p1.Y, plot, jump);

    public static bool PlotLine(Point p0, Point p1, Utils.TileActionAttempt plot, bool jump = true) => Utils.PlotLine(p0.X, p0.Y, p1.X, p1.Y, plot, jump);

    private static bool PlotLine(
      int x0,
      int y0,
      int x1,
      int y1,
      Utils.TileActionAttempt plot,
      bool jump = true)
    {
      if (x0 == x1 && y0 == y1)
        return plot(x0, y0);
      bool flag = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
      if (flag)
      {
        Utils.Swap<int>(ref x0, ref y0);
        Utils.Swap<int>(ref x1, ref y1);
      }
      int num1 = Math.Abs(x1 - x0);
      int num2 = Math.Abs(y1 - y0);
      int num3 = num1 / 2;
      int num4 = y0;
      int num5 = x0 < x1 ? 1 : -1;
      int num6 = y0 < y1 ? 1 : -1;
      for (int index = x0; index != x1; index += num5)
      {
        if (flag)
        {
          if (!plot(num4, index))
            return false;
        }
        else if (!plot(index, num4))
          return false;
        num3 -= num2;
        if (num3 < 0)
        {
          num4 += num6;
          if (!jump)
          {
            if (flag)
            {
              if (!plot(num4, index))
                return false;
            }
            else if (!plot(index, num4))
              return false;
          }
          num3 += num1;
        }
      }
      return true;
    }

    public static int RandomNext(ref ulong seed, int bits)
    {
      seed = Utils.RandomNextSeed(seed);
      return (int) (seed >> 48 - bits);
    }

    public static ulong RandomNextSeed(ulong seed) => (ulong) ((long) seed * 25214903917L + 11L & 281474976710655L);

    public static float RandomFloat(ref ulong seed) => (float) Utils.RandomNext(ref seed, 24) / 1.677722E+07f;

    public static int RandomInt(ref ulong seed, int max)
    {
      if ((max & -max) == max)
        return (int) ((long) max * (long) Utils.RandomNext(ref seed, 31) >> 31);
      int num1;
      int num2;
      do
      {
        num1 = Utils.RandomNext(ref seed, 31);
        num2 = num1 % max;
      }
      while (num1 - num2 + (max - 1) < 0);
      return num2;
    }

    public static int RandomInt(ref ulong seed, int min, int max) => Utils.RandomInt(ref seed, max - min) + min;

    public static bool PlotTileLine(
      Vector2 start,
      Vector2 end,
      float width,
      Utils.TileActionAttempt plot)
    {
      float num = width / 2f;
      Vector2 vector2_1 = end - start;
      Vector2 vector2_2 = vector2_1 / vector2_1.Length();
      Vector2 vector2_3 = new Vector2(-vector2_2.Y, vector2_2.X) * num;
      Point tileCoordinates1 = (start - vector2_3).ToTileCoordinates();
      Point tileCoordinates2 = (start + vector2_3).ToTileCoordinates();
      Point tileCoordinates3 = start.ToTileCoordinates();
      Point tileCoordinates4 = end.ToTileCoordinates();
      Point lineMinOffset = new Point(tileCoordinates1.X - tileCoordinates3.X, tileCoordinates1.Y - tileCoordinates3.Y);
      Point lineMaxOffset = new Point(tileCoordinates2.X - tileCoordinates3.X, tileCoordinates2.Y - tileCoordinates3.Y);
      return Utils.PlotLine(tileCoordinates3.X, tileCoordinates3.Y, tileCoordinates4.X, tileCoordinates4.Y, (Utils.TileActionAttempt) ((x, y) => Utils.PlotLine(x + lineMinOffset.X, y + lineMinOffset.Y, x + lineMaxOffset.X, y + lineMaxOffset.Y, plot, false)));
    }

    public static bool PlotTileTale(
      Vector2 start,
      Vector2 end,
      float width,
      Utils.TileActionAttempt plot)
    {
      float halfWidth = width / 2f;
      Vector2 vector2_1 = end - start;
      Vector2 vector2_2 = vector2_1 / vector2_1.Length();
      Vector2 perpOffset = new Vector2(-vector2_2.Y, vector2_2.X);
      Point pointStart = start.ToTileCoordinates();
      Point tileCoordinates1 = end.ToTileCoordinates();
      int length = 0;
      Utils.PlotLine(pointStart.X, pointStart.Y, tileCoordinates1.X, tileCoordinates1.Y, (Utils.TileActionAttempt) ((_param1, _param2) =>
      {
        ++length;
        return true;
      }));
      length--;
      int curLength = 0;
      return Utils.PlotLine(pointStart.X, pointStart.Y, tileCoordinates1.X, tileCoordinates1.Y, (Utils.TileActionAttempt) ((x, y) =>
      {
        float num = (float) (1.0 - (double) curLength / (double) length);
        ++curLength;
        Point tileCoordinates2 = (start - perpOffset * halfWidth * num).ToTileCoordinates();
        Point tileCoordinates3 = (start + perpOffset * halfWidth * num).ToTileCoordinates();
        Point point1 = new Point(tileCoordinates2.X - pointStart.X, tileCoordinates2.Y - pointStart.Y);
        Point point2 = new Point(tileCoordinates3.X - pointStart.X, tileCoordinates3.Y - pointStart.Y);
        return Utils.PlotLine(x + point1.X, y + point1.Y, x + point2.X, y + point2.Y, plot, false);
      }));
    }

    public static bool PlotTileArea(int x, int y, Utils.TileActionAttempt plot)
    {
      if (!WorldGen.InWorld(x, y))
        return false;
      List<Point> pointList1 = new List<Point>();
      List<Point> pointList2 = new List<Point>();
      HashSet<Point> pointSet = new HashSet<Point>();
      pointList2.Add(new Point(x, y));
      while (pointList2.Count > 0)
      {
        pointList1.Clear();
        pointList1.AddRange((IEnumerable<Point>) pointList2);
        pointList2.Clear();
        while (pointList1.Count > 0)
        {
          Point point1 = pointList1[0];
          if (!WorldGen.InWorld(point1.X, point1.Y, 1))
          {
            pointList1.Remove(point1);
          }
          else
          {
            pointSet.Add(point1);
            pointList1.Remove(point1);
            if (plot(point1.X, point1.Y))
            {
              Point point2 = new Point(point1.X - 1, point1.Y);
              if (!pointSet.Contains(point2))
                pointList2.Add(point2);
              point2 = new Point(point1.X + 1, point1.Y);
              if (!pointSet.Contains(point2))
                pointList2.Add(point2);
              point2 = new Point(point1.X, point1.Y - 1);
              if (!pointSet.Contains(point2))
                pointList2.Add(point2);
              point2 = new Point(point1.X, point1.Y + 1);
              if (!pointSet.Contains(point2))
                pointList2.Add(point2);
            }
          }
        }
      }
      return true;
    }

    public static int RandomConsecutive(double random, int odds) => (int) Math.Log(1.0 - random, 1.0 / (double) odds);

    public static Vector2 RandomVector2(UnifiedRandom random, float min, float max) => new Vector2((max - min) * (float) random.NextDouble() + min, (max - min) * (float) random.NextDouble() + min);

    public static bool IndexInRange<T>(this T[] t, int index) => index >= 0 && index < t.Length;

    public static bool IndexInRange<T>(this List<T> t, int index) => index >= 0 && index < t.Count;

    public static T SelectRandom<T>(UnifiedRandom random, params T[] choices) => choices[random.Next(choices.Length)];

    public static void DrawBorderStringFourWay(
      SpriteBatch sb,
      DynamicSpriteFont font,
      string text,
      float x,
      float y,
      Color textColor,
      Color borderColor,
      Vector2 origin,
      float scale = 1f)
    {
      Color color = borderColor;
      Vector2 zero = Vector2.Zero;
      for (int index = 0; index < 5; ++index)
      {
        switch (index)
        {
          case 0:
            zero.X = x - 2f;
            zero.Y = y;
            break;
          case 1:
            zero.X = x + 2f;
            zero.Y = y;
            break;
          case 2:
            zero.X = x;
            zero.Y = y - 2f;
            break;
          case 3:
            zero.X = x;
            zero.Y = y + 2f;
            break;
          default:
            zero.X = x;
            zero.Y = y;
            color = textColor;
            break;
        }
        DynamicSpriteFontExtensionMethods.DrawString(sb, font, text, zero, color, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
      }
    }

    public static Vector2 DrawBorderString(
      SpriteBatch sb,
      string text,
      Vector2 pos,
      Color color,
      float scale = 1f,
      float anchorx = 0.0f,
      float anchory = 0.0f,
      int maxCharactersDisplayed = -1)
    {
      if (maxCharactersDisplayed != -1 && text.Length > maxCharactersDisplayed)
        text.Substring(0, maxCharactersDisplayed);
      DynamicSpriteFont font = FontAssets.MouseText.Value;
      Vector2 vector2 = font.MeasureString(text);
      ChatManager.DrawColorCodedStringWithShadow(sb, font, text, pos, color, 0.0f, new Vector2(anchorx, anchory) * vector2, new Vector2(scale), spread: 1.5f);
      return vector2 * scale;
    }

    public static Vector2 DrawBorderStringBig(
      SpriteBatch spriteBatch,
      string text,
      Vector2 pos,
      Color color,
      float scale = 1f,
      float anchorx = 0.0f,
      float anchory = 0.0f,
      int maxCharactersDisplayed = -1)
    {
      if (maxCharactersDisplayed != -1 && text.Length > maxCharactersDisplayed)
        text.Substring(0, maxCharactersDisplayed);
      DynamicSpriteFont dynamicSpriteFont = FontAssets.DeathText.Value;
      for (int index1 = -1; index1 < 2; ++index1)
      {
        for (int index2 = -1; index2 < 2; ++index2)
          DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, dynamicSpriteFont, text, pos + new Vector2((float) index1, (float) index2), Color.Black, 0.0f, new Vector2(anchorx, anchory) * dynamicSpriteFont.MeasureString(text), scale, SpriteEffects.None, 0.0f);
      }
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, dynamicSpriteFont, text, pos, color, 0.0f, new Vector2(anchorx, anchory) * dynamicSpriteFont.MeasureString(text), scale, SpriteEffects.None, 0.0f);
      return dynamicSpriteFont.MeasureString(text) * scale;
    }

    public static void DrawInvBG(SpriteBatch sb, Rectangle R, Color c = default (Color)) => Utils.DrawInvBG(sb, R.X, R.Y, R.Width, R.Height, c);

    public static void DrawInvBG(SpriteBatch sb, float x, float y, float w, float h, Color c = default (Color)) => Utils.DrawInvBG(sb, (int) x, (int) y, (int) w, (int) h, c);

    public static void DrawInvBG(SpriteBatch sb, int x, int y, int w, int h, Color c = default (Color))
    {
      if (c == new Color())
        c = new Color(63, 65, 151, (int) byte.MaxValue) * 0.785f;
      Texture2D texture = TextureAssets.InventoryBack13.Value;
      if (w < 20)
        w = 20;
      if (h < 20)
        h = 20;
      sb.Draw(texture, new Rectangle(x, y, 10, 10), new Rectangle?(new Rectangle(0, 0, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + 10, y, w - 20, 10), new Rectangle?(new Rectangle(10, 0, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + w - 10, y, 10, 10), new Rectangle?(new Rectangle(texture.Width - 10, 0, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x, y + 10, 10, h - 20), new Rectangle?(new Rectangle(0, 10, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + 10, y + 10, w - 20, h - 20), new Rectangle?(new Rectangle(10, 10, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + w - 10, y + 10, 10, h - 20), new Rectangle?(new Rectangle(texture.Width - 10, 10, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x, y + h - 10, 10, 10), new Rectangle?(new Rectangle(0, texture.Height - 10, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + 10, y + h - 10, w - 20, 10), new Rectangle?(new Rectangle(10, texture.Height - 10, 10, 10)), c);
      sb.Draw(texture, new Rectangle(x + w - 10, y + h - 10, 10, 10), new Rectangle?(new Rectangle(texture.Width - 10, texture.Height - 10, 10, 10)), c);
    }

    public static string ReadEmbeddedResource(string path)
    {
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
      {
        using (StreamReader streamReader = new StreamReader(manifestResourceStream))
          return streamReader.ReadToEnd();
      }
    }

    public static void DrawSplicedPanel(
      SpriteBatch sb,
      Texture2D texture,
      int x,
      int y,
      int w,
      int h,
      int leftEnd,
      int rightEnd,
      int topEnd,
      int bottomEnd,
      Color c)
    {
      if (w < leftEnd + rightEnd)
        w = leftEnd + rightEnd;
      if (h < topEnd + bottomEnd)
        h = topEnd + bottomEnd;
      sb.Draw(texture, new Rectangle(x, y, leftEnd, topEnd), new Rectangle?(new Rectangle(0, 0, leftEnd, topEnd)), c);
      sb.Draw(texture, new Rectangle(x + leftEnd, y, w - leftEnd - rightEnd, topEnd), new Rectangle?(new Rectangle(leftEnd, 0, texture.Width - leftEnd - rightEnd, topEnd)), c);
      sb.Draw(texture, new Rectangle(x + w - rightEnd, y, topEnd, rightEnd), new Rectangle?(new Rectangle(texture.Width - rightEnd, 0, rightEnd, topEnd)), c);
      sb.Draw(texture, new Rectangle(x, y + topEnd, leftEnd, h - topEnd - bottomEnd), new Rectangle?(new Rectangle(0, topEnd, leftEnd, texture.Height - topEnd - bottomEnd)), c);
      sb.Draw(texture, new Rectangle(x + leftEnd, y + topEnd, w - leftEnd - rightEnd, h - topEnd - bottomEnd), new Rectangle?(new Rectangle(leftEnd, topEnd, texture.Width - leftEnd - rightEnd, texture.Height - topEnd - bottomEnd)), c);
      sb.Draw(texture, new Rectangle(x + w - rightEnd, y + topEnd, rightEnd, h - topEnd - bottomEnd), new Rectangle?(new Rectangle(texture.Width - rightEnd, topEnd, rightEnd, texture.Height - topEnd - bottomEnd)), c);
      sb.Draw(texture, new Rectangle(x, y + h - bottomEnd, leftEnd, bottomEnd), new Rectangle?(new Rectangle(0, texture.Height - bottomEnd, leftEnd, bottomEnd)), c);
      sb.Draw(texture, new Rectangle(x + leftEnd, y + h - bottomEnd, w - leftEnd - rightEnd, bottomEnd), new Rectangle?(new Rectangle(leftEnd, texture.Height - bottomEnd, texture.Width - leftEnd - rightEnd, bottomEnd)), c);
      sb.Draw(texture, new Rectangle(x + w - rightEnd, y + h - bottomEnd, rightEnd, bottomEnd), new Rectangle?(new Rectangle(texture.Width - rightEnd, texture.Height - bottomEnd, rightEnd, bottomEnd)), c);
    }

    public static void DrawSettingsPanel(
      SpriteBatch spriteBatch,
      Vector2 position,
      float width,
      Color color)
    {
      Utils.DrawPanel(TextureAssets.SettingsPanel.Value, 2, 0, spriteBatch, position, width, color);
    }

    public static void DrawSettings2Panel(
      SpriteBatch spriteBatch,
      Vector2 position,
      float width,
      Color color)
    {
      Utils.DrawPanel(TextureAssets.SettingsPanel.Value, 2, 0, spriteBatch, position, width, color);
    }

    public static void DrawPanel(
      Texture2D texture,
      int edgeWidth,
      int edgeShove,
      SpriteBatch spriteBatch,
      Vector2 position,
      float width,
      Color color)
    {
      spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(0, 0, edgeWidth, texture.Height)), color);
      spriteBatch.Draw(texture, new Vector2(position.X + (float) edgeWidth, position.Y), new Rectangle?(new Rectangle(edgeWidth + edgeShove, 0, texture.Width - (edgeWidth + edgeShove) * 2, texture.Height)), color, 0.0f, Vector2.Zero, new Vector2((width - (float) (edgeWidth * 2)) / (float) (texture.Width - (edgeWidth + edgeShove) * 2), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture, new Vector2(position.X + width - (float) edgeWidth, position.Y), new Rectangle?(new Rectangle(texture.Width - edgeWidth, 0, edgeWidth, texture.Height)), color);
    }

    public static void DrawRectangle(
      SpriteBatch sb,
      Vector2 start,
      Vector2 end,
      Color colorStart,
      Color colorEnd,
      float width)
    {
      Utils.DrawLine(sb, start, new Vector2(start.X, end.Y), colorStart, colorEnd, width);
      Utils.DrawLine(sb, start, new Vector2(end.X, start.Y), colorStart, colorEnd, width);
      Utils.DrawLine(sb, end, new Vector2(start.X, end.Y), colorStart, colorEnd, width);
      Utils.DrawLine(sb, end, new Vector2(end.X, start.Y), colorStart, colorEnd, width);
    }

    public static void DrawLaser(
      SpriteBatch sb,
      Texture2D tex,
      Vector2 start,
      Vector2 end,
      Vector2 scale,
      Utils.LaserLineFraming framing)
    {
      Vector2 vector2_1 = start;
      Vector2 vector2_2 = Vector2.Normalize(end - start);
      float distanceLeft1 = (end - start).Length();
      float rotation = vector2_2.ToRotation() - 1.570796f;
      if (vector2_2.HasNaNs())
        return;
      float distanceCovered;
      Rectangle frame;
      Vector2 origin;
      Color color;
      framing(0, vector2_1, distanceLeft1, new Rectangle(), out distanceCovered, out frame, out origin, out color);
      sb.Draw(tex, vector2_1, new Rectangle?(frame), color, rotation, frame.Size() / 2f, scale, SpriteEffects.None, 0.0f);
      float distanceLeft2 = distanceLeft1 - distanceCovered * scale.Y;
      Vector2 vector2_3 = vector2_1 + vector2_2 * ((float) frame.Height - origin.Y) * scale.Y;
      if ((double) distanceLeft2 > 0.0)
      {
        float num = 0.0f;
        while ((double) num + 1.0 < (double) distanceLeft2)
        {
          framing(1, vector2_3, distanceLeft2 - num, frame, out distanceCovered, out frame, out origin, out color);
          if ((double) distanceLeft2 - (double) num < (double) frame.Height)
          {
            distanceCovered *= (distanceLeft2 - num) / (float) frame.Height;
            frame.Height = (int) ((double) distanceLeft2 - (double) num);
          }
          sb.Draw(tex, vector2_3, new Rectangle?(frame), color, rotation, origin, scale, SpriteEffects.None, 0.0f);
          num += distanceCovered * scale.Y;
          vector2_3 += vector2_2 * distanceCovered * scale.Y;
        }
      }
      framing(2, vector2_3, distanceLeft2, new Rectangle(), out distanceCovered, out frame, out origin, out color);
      sb.Draw(tex, vector2_3, new Rectangle?(frame), color, rotation, origin, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawLine(SpriteBatch spriteBatch, Point start, Point end, Color color) => Utils.DrawLine(spriteBatch, new Vector2((float) (start.X << 4), (float) (start.Y << 4)), new Vector2((float) (end.X << 4), (float) (end.Y << 4)), color);

    public static void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
    {
      float num1 = Vector2.Distance(start, end);
      Vector2 v = (end - start) / num1;
      Vector2 vector2 = start;
      Vector2 screenPosition = Main.screenPosition;
      float rotation = v.ToRotation();
      for (float num2 = 0.0f; (double) num2 <= (double) num1; num2 += 4f)
      {
        float num3 = num2 / num1;
        spriteBatch.Draw(TextureAssets.BlackTile.Value, vector2 - screenPosition, new Rectangle?(), new Color(new Vector4(num3, num3, num3, 1f) * color.ToVector4()), rotation, Vector2.Zero, 0.25f, SpriteEffects.None, 0.0f);
        vector2 = start + num2 * v;
      }
    }

    public static void DrawLine(
      SpriteBatch spriteBatch,
      Vector2 start,
      Vector2 end,
      Color colorStart,
      Color colorEnd,
      float width)
    {
      float num1 = Vector2.Distance(start, end);
      Vector2 v = (end - start) / num1;
      Vector2 vector2 = start;
      Vector2 screenPosition = Main.screenPosition;
      float rotation = v.ToRotation();
      float scale = width / 16f;
      for (float num2 = 0.0f; (double) num2 <= (double) num1; num2 += width)
      {
        float amount = num2 / num1;
        spriteBatch.Draw(TextureAssets.BlackTile.Value, vector2 - screenPosition, new Rectangle?(), Color.Lerp(colorStart, colorEnd, amount), rotation, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        vector2 = start + num2 * v;
      }
    }

    public static void DrawRectForTilesInWorld(
      SpriteBatch spriteBatch,
      Rectangle rect,
      Color color)
    {
      Utils.DrawRectForTilesInWorld(spriteBatch, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), color);
    }

    public static void DrawRectForTilesInWorld(
      SpriteBatch spriteBatch,
      Point start,
      Point end,
      Color color)
    {
      Utils.DrawRect(spriteBatch, new Vector2((float) (start.X << 4), (float) (start.Y << 4)), new Vector2((float) ((end.X << 4) - 4), (float) ((end.Y << 4) - 4)), color);
    }

    public static void DrawRect(SpriteBatch spriteBatch, Rectangle rect, Color color) => Utils.DrawRect(spriteBatch, new Vector2((float) rect.X, (float) rect.Y), new Vector2((float) (rect.X + rect.Width), (float) (rect.Y + rect.Height)), color);

    public static void DrawRect(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
    {
      Utils.DrawLine(spriteBatch, start, new Vector2(start.X, end.Y), color);
      Utils.DrawLine(spriteBatch, start, new Vector2(end.X, start.Y), color);
      Utils.DrawLine(spriteBatch, end, new Vector2(start.X, end.Y), color);
      Utils.DrawLine(spriteBatch, end, new Vector2(end.X, start.Y), color);
    }

    public static void DrawRect(
      SpriteBatch spriteBatch,
      Vector2 topLeft,
      Vector2 topRight,
      Vector2 bottomRight,
      Vector2 bottomLeft,
      Color color)
    {
      Utils.DrawLine(spriteBatch, topLeft, topRight, color);
      Utils.DrawLine(spriteBatch, topRight, bottomRight, color);
      Utils.DrawLine(spriteBatch, bottomRight, bottomLeft, color);
      Utils.DrawLine(spriteBatch, bottomLeft, topLeft, color);
    }

    public static void DrawCursorSingle(
      SpriteBatch sb,
      Color color,
      float rot = float.NaN,
      float scale = 1f,
      Vector2 manualPosition = default (Vector2),
      int cursorSlot = 0,
      int specialMode = 0)
    {
      bool flag1 = false;
      bool flag2 = true;
      bool flag3 = true;
      Vector2 origin = Vector2.Zero;
      Vector2 vector2_1 = new Vector2((float) Main.mouseX, (float) Main.mouseY);
      if (manualPosition != Vector2.Zero)
        vector2_1 = manualPosition;
      if (float.IsNaN(rot))
      {
        rot = 0.0f;
      }
      else
      {
        flag1 = true;
        rot -= 2.356194f;
      }
      if (cursorSlot == 4 || cursorSlot == 5)
      {
        flag2 = false;
        origin = new Vector2(8f);
        if (flag1 && specialMode == 0)
        {
          float num1 = rot;
          if ((double) num1 < 0.0)
            num1 += 6.283185f;
          for (float num2 = 0.0f; (double) num2 < 4.0; ++num2)
          {
            if ((double) Math.Abs(num1 - 1.570796f * num2) <= 0.785398185253143)
            {
              rot = 1.570796f * num2;
              break;
            }
          }
        }
      }
      Vector2 vector2_2 = Vector2.One;
      if (Main.ThickMouse && cursorSlot == 0 || cursorSlot == 1)
        vector2_2 = Main.DrawThickCursor(cursorSlot == 1);
      if (flag2)
        sb.Draw(TextureAssets.Cursors[cursorSlot].Value, vector2_1 + vector2_2 + Vector2.One, new Rectangle?(), color.MultiplyRGB(new Color(0.2f, 0.2f, 0.2f, 0.5f)), rot, origin, scale * 1.1f, SpriteEffects.None, 0.0f);
      if (!flag3)
        return;
      sb.Draw(TextureAssets.Cursors[cursorSlot].Value, vector2_1 + vector2_2, new Rectangle?(), color, rot, origin, scale, SpriteEffects.None, 0.0f);
    }

    public delegate bool TileActionAttempt(int x, int y);

    public delegate void LaserLineFraming(
      int stage,
      Vector2 currentPosition,
      float distanceLeft,
      Rectangle lastFrame,
      out float distanceCovered,
      out Rectangle frame,
      out Vector2 origin,
      out Color color);

    public delegate Color ColorLerpMethod(float percent);
  }
}
