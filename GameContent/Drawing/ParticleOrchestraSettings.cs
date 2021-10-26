// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.ParticleOrchestraSettings
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;

namespace Terraria.GameContent.Drawing
{
  public struct ParticleOrchestraSettings
  {
    public Vector2 PositionInWorld;
    public Vector2 MovementVector;
    public int PackedShaderIndex;
    public byte IndexOfPlayerWhoInvokedThis;
    public const int SerializationSize = 21;

    public void Serialize(BinaryWriter writer)
    {
      writer.WriteVector2(this.PositionInWorld);
      writer.WriteVector2(this.MovementVector);
      writer.Write(this.PackedShaderIndex);
      writer.Write(this.IndexOfPlayerWhoInvokedThis);
    }

    public void DeserializeFrom(BinaryReader reader)
    {
      this.PositionInWorld = reader.ReadVector2();
      this.MovementVector = reader.ReadVector2();
      this.PackedShaderIndex = reader.ReadInt32();
      this.IndexOfPlayerWhoInvokedThis = reader.ReadByte();
    }
  }
}
