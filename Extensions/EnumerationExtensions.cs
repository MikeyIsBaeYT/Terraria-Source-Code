// Decompiled with JetBrains decompiler
// Type: Extensions.EnumerationExtensions
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Extensions
{
  public static class EnumerationExtensions
  {
    public static T Include<T>(this Enum value, T append)
    {
      Type type = value.GetType();
      object obj1 = (object) value;
      EnumerationExtensions._Value obj2 = new EnumerationExtensions._Value((object) append, type);
      if ((ValueType) obj2.Signed is long)
        obj1 = (object) (Convert.ToInt64((object) value) | obj2.Signed.Value);
      else if ((ValueType) obj2.Unsigned is ulong)
        obj1 = (object) (ulong) ((long) Convert.ToUInt64((object) value) | (long) obj2.Unsigned.Value);
      return (T) Enum.Parse(type, obj1.ToString());
    }

    public static T Remove<T>(this Enum value, T remove)
    {
      Type type = value.GetType();
      object obj1 = (object) value;
      EnumerationExtensions._Value obj2 = new EnumerationExtensions._Value((object) remove, type);
      if ((ValueType) obj2.Signed is long)
        obj1 = (object) (Convert.ToInt64((object) value) & ~obj2.Signed.Value);
      else if ((ValueType) obj2.Unsigned is ulong)
        obj1 = (object) (ulong) ((long) Convert.ToUInt64((object) value) & ~(long) obj2.Unsigned.Value);
      return (T) Enum.Parse(type, obj1.ToString());
    }

    public static bool Has<T>(this Enum value, T check)
    {
      Type type = value.GetType();
      EnumerationExtensions._Value obj = new EnumerationExtensions._Value((object) check, type);
      if ((ValueType) obj.Signed is long)
        return (Convert.ToInt64((object) value) & obj.Signed.Value) == obj.Signed.Value;
      return (ValueType) obj.Unsigned is ulong && ((long) Convert.ToUInt64((object) value) & (long) obj.Unsigned.Value) == (long) obj.Unsigned.Value;
    }

    public static bool Missing<T>(this Enum obj, T value) => !obj.Has<T>(value);

    private class _Value
    {
      private static Type _UInt64 = typeof (ulong);
      private static Type _UInt32 = typeof (long);
      public long? Signed;
      public ulong? Unsigned;

      public _Value(object value, Type type)
      {
        Type type1 = type.IsEnum ? Enum.GetUnderlyingType(type) : throw new ArgumentException("Value provided is not an enumerated type!");
        if (type1.Equals(EnumerationExtensions._Value._UInt32) || type1.Equals(EnumerationExtensions._Value._UInt64))
          this.Unsigned = new ulong?(Convert.ToUInt64(value));
        else
          this.Signed = new long?(Convert.ToInt64(value));
      }
    }
  }
}
