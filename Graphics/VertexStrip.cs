// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.VertexStrip
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria.Graphics
{
  public class VertexStrip
  {
    private VertexStrip.CustomVertexInfo[] _vertices = new VertexStrip.CustomVertexInfo[1];
    private int _vertexAmountCurrentlyMaintained;
    private short[] _indices = new short[1];
    private int _indicesAmountCurrentlyMaintained;
    private List<Vector2> _temporaryPositionsCache = new List<Vector2>();
    private List<float> _temporaryRotationsCache = new List<float>();

    public void PrepareStrip(
      Vector2[] positions,
      float[] rotations,
      VertexStrip.StripColorFunction colorFunction,
      VertexStrip.StripHalfWidthFunction widthFunction,
      Vector2 offsetForAllPositions = default (Vector2),
      int? expectedVertexPairsAmount = null,
      bool includeBacksides = false)
    {
      int vertexPaidsAdded = positions.Length;
      int newSize = vertexPaidsAdded * 2;
      this._vertexAmountCurrentlyMaintained = newSize;
      if (this._vertices.Length < newSize)
        Array.Resize<VertexStrip.CustomVertexInfo>(ref this._vertices, newSize);
      int num = vertexPaidsAdded;
      if (expectedVertexPairsAmount.HasValue)
        num = expectedVertexPairsAmount.Value;
      for (int index = 0; index < vertexPaidsAdded; ++index)
      {
        if (positions[index] == Vector2.Zero)
        {
          vertexPaidsAdded = index - 1;
          this._vertexAmountCurrentlyMaintained = vertexPaidsAdded * 2;
          break;
        }
        Vector2 pos = positions[index] + offsetForAllPositions;
        float rot = MathHelper.WrapAngle(rotations[index]);
        int indexOnVertexArray = index * 2;
        float progressOnStrip = (float) index / (float) (num - 1);
        this.AddVertex(colorFunction, widthFunction, pos, rot, indexOnVertexArray, progressOnStrip);
      }
      this.PrepareIndices(vertexPaidsAdded, includeBacksides);
    }

    public void PrepareStripWithProceduralPadding(
      Vector2[] positions,
      float[] rotations,
      VertexStrip.StripColorFunction colorFunction,
      VertexStrip.StripHalfWidthFunction widthFunction,
      Vector2 offsetForAllPositions = default (Vector2),
      bool includeBacksides = false)
    {
      int length = positions.Length;
      this._temporaryPositionsCache.Clear();
      this._temporaryRotationsCache.Clear();
      for (int index = 0; index < length && !(positions[index] == Vector2.Zero); ++index)
      {
        Vector2 position1 = positions[index];
        float f1 = MathHelper.WrapAngle(rotations[index]);
        this._temporaryPositionsCache.Add(position1);
        this._temporaryRotationsCache.Add(f1);
        if (index + 1 < length && positions[index + 1] != Vector2.Zero)
        {
          Vector2 position2 = positions[index + 1];
          float f2 = MathHelper.WrapAngle(rotations[index + 1]);
          int num1 = (int) ((double) Math.Abs(MathHelper.WrapAngle(f2 - f1)) / 0.261799395084381);
          if (num1 != 0)
          {
            float num2 = position1.Distance(position2);
            Vector2 vector2_1 = position1 + f1.ToRotationVector2() * num2;
            Vector2 vector2_2 = position2 + f2.ToRotationVector2() * -num2;
            float num3 = 1f / (float) (num1 + 2);
            Vector2 Target = position1;
            for (float amount = num3; (double) amount < 1.0; amount += num3)
            {
              Vector2 Origin = Vector2.CatmullRom(vector2_1, position1, position2, vector2_2, amount);
              float num4 = MathHelper.WrapAngle(Origin.DirectionTo(Target).ToRotation());
              this._temporaryPositionsCache.Add(Origin);
              this._temporaryRotationsCache.Add(num4);
              Target = Origin;
            }
          }
        }
      }
      int count = this._temporaryPositionsCache.Count;
      for (int index = 0; index < count; ++index)
      {
        Vector2 pos = this._temporaryPositionsCache[index] + offsetForAllPositions;
        float rot = this._temporaryRotationsCache[index];
        int indexOnVertexArray = index * 2;
        float progressOnStrip = (float) index / (float) (count - 1);
        this.AddVertex(colorFunction, widthFunction, pos, rot, indexOnVertexArray, progressOnStrip);
      }
      this._vertexAmountCurrentlyMaintained = count * 2;
      this.PrepareIndices(count, includeBacksides);
    }

    private void PrepareIndices(int vertexPaidsAdded, bool includeBacksides)
    {
      int num1 = vertexPaidsAdded - 1;
      int num2 = 6 + includeBacksides.ToInt() * 6;
      int newSize = num1 * num2;
      this._indicesAmountCurrentlyMaintained = newSize;
      if (this._indices.Length < newSize)
        Array.Resize<short>(ref this._indices, newSize);
      for (short index = 0; (int) index < num1; ++index)
      {
        short num3 = (short) ((int) index * num2);
        int num4 = (int) index * 2;
        this._indices[(int) num3] = (short) num4;
        this._indices[(int) num3 + 1] = (short) (num4 + 1);
        this._indices[(int) num3 + 2] = (short) (num4 + 2);
        this._indices[(int) num3 + 3] = (short) (num4 + 2);
        this._indices[(int) num3 + 4] = (short) (num4 + 1);
        this._indices[(int) num3 + 5] = (short) (num4 + 3);
        if (includeBacksides)
        {
          this._indices[(int) num3 + 6] = (short) (num4 + 2);
          this._indices[(int) num3 + 7] = (short) (num4 + 1);
          this._indices[(int) num3 + 8] = (short) num4;
          this._indices[(int) num3 + 9] = (short) (num4 + 2);
          this._indices[(int) num3 + 10] = (short) (num4 + 3);
          this._indices[(int) num3 + 11] = (short) (num4 + 1);
        }
      }
    }

    private void AddVertex(
      VertexStrip.StripColorFunction colorFunction,
      VertexStrip.StripHalfWidthFunction widthFunction,
      Vector2 pos,
      float rot,
      int indexOnVertexArray,
      float progressOnStrip)
    {
      while (indexOnVertexArray + 1 >= this._vertices.Length)
        Array.Resize<VertexStrip.CustomVertexInfo>(ref this._vertices, this._vertices.Length * 2);
      Color color = colorFunction(progressOnStrip);
      float num = widthFunction(progressOnStrip);
      Vector2 vector2 = MathHelper.WrapAngle(rot - 1.570796f).ToRotationVector2() * num;
      this._vertices[indexOnVertexArray].Position = pos + vector2;
      this._vertices[indexOnVertexArray + 1].Position = pos - vector2;
      this._vertices[indexOnVertexArray].TexCoord = new Vector3(progressOnStrip, num, num);
      this._vertices[indexOnVertexArray + 1].TexCoord = new Vector3(progressOnStrip, 0.0f, num);
      this._vertices[indexOnVertexArray].Color = color;
      this._vertices[indexOnVertexArray + 1].Color = color;
    }

    public void DrawTrail()
    {
      if (this._vertexAmountCurrentlyMaintained < 3)
        return;
      Main.instance.GraphicsDevice.DrawUserIndexedPrimitives<VertexStrip.CustomVertexInfo>(PrimitiveType.TriangleList, this._vertices, 0, this._vertexAmountCurrentlyMaintained, this._indices, 0, this._indicesAmountCurrentlyMaintained / 3);
    }

    public delegate Color StripColorFunction(float progressOnStrip);

    public delegate float StripHalfWidthFunction(float progressOnStrip);

    private struct CustomVertexInfo : IVertexType
    {
      public Vector2 Position;
      public Color Color;
      public Vector3 TexCoord;
      private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement[3]
      {
        new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
        new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
        new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
      });

      public CustomVertexInfo(Vector2 position, Color color, Vector3 texCoord)
      {
        this.Position = position;
        this.Color = color;
        this.TexCoord = texCoord;
      }

      public VertexDeclaration VertexDeclaration => VertexStrip.CustomVertexInfo._vertexDeclaration;
    }
  }
}
