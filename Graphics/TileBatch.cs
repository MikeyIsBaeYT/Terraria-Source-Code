// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.TileBatch
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.Graphics
{
  public class TileBatch
  {
    private static readonly float[] CORNER_OFFSET_X = new float[4]
    {
      0.0f,
      1f,
      1f,
      0.0f
    };
    private static readonly float[] CORNER_OFFSET_Y = new float[4]
    {
      0.0f,
      0.0f,
      1f,
      1f
    };
    private GraphicsDevice _graphicsDevice;
    private TileBatch.SpriteData[] _spriteDataQueue = new TileBatch.SpriteData[2048];
    private Texture2D[] _spriteTextures;
    private int _queuedSpriteCount;
    private SpriteBatch _spriteBatch;
    private static Vector2 _vector2Zero;
    private static Rectangle? _nullRectangle;
    private DynamicVertexBuffer _vertexBuffer;
    private DynamicIndexBuffer _indexBuffer;
    private short[] _fallbackIndexData;
    private VertexPositionColorTexture[] _vertices = new VertexPositionColorTexture[8192];
    private int _vertexBufferPosition;

    public TileBatch(GraphicsDevice graphicsDevice)
    {
      this._graphicsDevice = graphicsDevice;
      this._spriteBatch = new SpriteBatch(graphicsDevice);
      this.Allocate();
    }

    private void Allocate()
    {
      if (this._vertexBuffer == null || this._vertexBuffer.IsDisposed)
      {
        this._vertexBuffer = new DynamicVertexBuffer(this._graphicsDevice, typeof (VertexPositionColorTexture), 8192, BufferUsage.WriteOnly);
        this._vertexBufferPosition = 0;
        this._vertexBuffer.ContentLost += (EventHandler<EventArgs>) ((sender, e) => this._vertexBufferPosition = 0);
      }
      if (this._indexBuffer != null && !this._indexBuffer.IsDisposed)
        return;
      if (this._fallbackIndexData == null)
      {
        this._fallbackIndexData = new short[12288];
        for (int index = 0; index < 2048; ++index)
        {
          this._fallbackIndexData[index * 6] = (short) (index * 4);
          this._fallbackIndexData[index * 6 + 1] = (short) (index * 4 + 1);
          this._fallbackIndexData[index * 6 + 2] = (short) (index * 4 + 2);
          this._fallbackIndexData[index * 6 + 3] = (short) (index * 4);
          this._fallbackIndexData[index * 6 + 4] = (short) (index * 4 + 2);
          this._fallbackIndexData[index * 6 + 5] = (short) (index * 4 + 3);
        }
      }
      this._indexBuffer = new DynamicIndexBuffer(this._graphicsDevice, typeof (short), 12288, BufferUsage.WriteOnly);
      this._indexBuffer.SetData<short>(this._fallbackIndexData);
      this._indexBuffer.ContentLost += (EventHandler<EventArgs>) ((sender, e) => this._indexBuffer.SetData<short>(this._fallbackIndexData));
    }

    private void FlushRenderState()
    {
      this.Allocate();
      this._graphicsDevice.SetVertexBuffer((VertexBuffer) this._vertexBuffer);
      this._graphicsDevice.Indices = (IndexBuffer) this._indexBuffer;
      this._graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
    }

    public void Dispose()
    {
      if (this._vertexBuffer != null)
        this._vertexBuffer.Dispose();
      if (this._indexBuffer == null)
        return;
      this._indexBuffer.Dispose();
    }

    public void Begin(Matrix transformation)
    {
      this._spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, transformation);
      this._spriteBatch.End();
    }

    public void Begin()
    {
      this._spriteBatch.Begin();
      this._spriteBatch.End();
    }

    public void Draw(Texture2D texture, Vector2 position, VertexColors colors) => this.InternalDraw(texture, ref new Vector4()
    {
      X = position.X,
      Y = position.Y,
      Z = 1f,
      W = 1f
    }, true, ref TileBatch._nullRectangle, ref colors, ref TileBatch._vector2Zero, SpriteEffects.None, 0.0f);

    public void Draw(
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRectangle,
      VertexColors colors,
      Vector2 origin,
      float scale,
      SpriteEffects effects)
    {
      this.InternalDraw(texture, ref new Vector4()
      {
        X = position.X,
        Y = position.Y,
        Z = scale,
        W = scale
      }, true, ref sourceRectangle, ref colors, ref origin, effects, 0.0f);
    }

    public void Draw(Texture2D texture, Vector4 destination, VertexColors colors) => this.InternalDraw(texture, ref destination, false, ref TileBatch._nullRectangle, ref colors, ref TileBatch._vector2Zero, SpriteEffects.None, 0.0f);

    public void Draw(Texture2D texture, Vector2 position, VertexColors colors, Vector2 scale) => this.InternalDraw(texture, ref new Vector4()
    {
      X = position.X,
      Y = position.Y,
      Z = scale.X,
      W = scale.Y
    }, true, ref TileBatch._nullRectangle, ref colors, ref TileBatch._vector2Zero, SpriteEffects.None, 0.0f);

    public void Draw(
      Texture2D texture,
      Vector4 destination,
      Rectangle? sourceRectangle,
      VertexColors colors)
    {
      this.InternalDraw(texture, ref destination, false, ref sourceRectangle, ref colors, ref TileBatch._vector2Zero, SpriteEffects.None, 0.0f);
    }

    public void Draw(
      Texture2D texture,
      Vector4 destination,
      Rectangle? sourceRectangle,
      VertexColors colors,
      Vector2 origin,
      SpriteEffects effects,
      float rotation)
    {
      this.InternalDraw(texture, ref destination, false, ref sourceRectangle, ref colors, ref origin, effects, rotation);
    }

    public void Draw(
      Texture2D texture,
      Rectangle destinationRectangle,
      Rectangle? sourceRectangle,
      VertexColors colors)
    {
      this.InternalDraw(texture, ref new Vector4()
      {
        X = (float) destinationRectangle.X,
        Y = (float) destinationRectangle.Y,
        Z = (float) destinationRectangle.Width,
        W = (float) destinationRectangle.Height
      }, false, ref sourceRectangle, ref colors, ref TileBatch._vector2Zero, SpriteEffects.None, 0.0f);
    }

    private static short[] CreateIndexData()
    {
      short[] numArray = new short[12288];
      for (int index = 0; index < 2048; ++index)
      {
        numArray[index * 6] = (short) (index * 4);
        numArray[index * 6 + 1] = (short) (index * 4 + 1);
        numArray[index * 6 + 2] = (short) (index * 4 + 2);
        numArray[index * 6 + 3] = (short) (index * 4);
        numArray[index * 6 + 4] = (short) (index * 4 + 2);
        numArray[index * 6 + 5] = (short) (index * 4 + 3);
      }
      return numArray;
    }

    private unsafe void InternalDraw(
      Texture2D texture,
      ref Vector4 destination,
      bool scaleDestination,
      ref Rectangle? sourceRectangle,
      ref VertexColors colors,
      ref Vector2 origin,
      SpriteEffects effects,
      float rotation)
    {
      if (this._queuedSpriteCount >= this._spriteDataQueue.Length)
        Array.Resize<TileBatch.SpriteData>(ref this._spriteDataQueue, this._spriteDataQueue.Length << 1);
      fixed (TileBatch.SpriteData* spriteDataPtr = &this._spriteDataQueue[this._queuedSpriteCount])
      {
        float z = destination.Z;
        float w = destination.W;
        if (sourceRectangle.HasValue)
        {
          Rectangle rectangle = sourceRectangle.Value;
          spriteDataPtr->Source.X = (float) rectangle.X;
          spriteDataPtr->Source.Y = (float) rectangle.Y;
          spriteDataPtr->Source.Z = (float) rectangle.Width;
          spriteDataPtr->Source.W = (float) rectangle.Height;
          if (scaleDestination)
          {
            z *= (float) rectangle.Width;
            w *= (float) rectangle.Height;
          }
        }
        else
        {
          float width = (float) texture.Width;
          float height = (float) texture.Height;
          spriteDataPtr->Source.X = 0.0f;
          spriteDataPtr->Source.Y = 0.0f;
          spriteDataPtr->Source.Z = width;
          spriteDataPtr->Source.W = height;
          if (scaleDestination)
          {
            z *= width;
            w *= height;
          }
        }
        spriteDataPtr->Destination.X = destination.X;
        spriteDataPtr->Destination.Y = destination.Y;
        spriteDataPtr->Destination.Z = z;
        spriteDataPtr->Destination.W = w;
        spriteDataPtr->Origin.X = origin.X;
        spriteDataPtr->Origin.Y = origin.Y;
        spriteDataPtr->Effects = effects;
        spriteDataPtr->Colors = colors;
        spriteDataPtr->Rotation = rotation;
      }
      if (this._spriteTextures == null || this._spriteTextures.Length != this._spriteDataQueue.Length)
        Array.Resize<Texture2D>(ref this._spriteTextures, this._spriteDataQueue.Length);
      this._spriteTextures[this._queuedSpriteCount++] = texture;
    }

    public void End()
    {
      if (this._queuedSpriteCount == 0)
        return;
      this.FlushRenderState();
      this.Flush();
    }

    private void Flush()
    {
      Texture2D texture = (Texture2D) null;
      int offset = 0;
      for (int index = 0; index < this._queuedSpriteCount; ++index)
      {
        if (this._spriteTextures[index] != texture)
        {
          if (index > offset)
            this.RenderBatch(texture, this._spriteDataQueue, offset, index - offset);
          offset = index;
          texture = this._spriteTextures[index];
        }
      }
      this.RenderBatch(texture, this._spriteDataQueue, offset, this._queuedSpriteCount - offset);
      Array.Clear((Array) this._spriteTextures, 0, this._queuedSpriteCount);
      this._queuedSpriteCount = 0;
    }

    private unsafe void RenderBatch(
      Texture2D texture,
      TileBatch.SpriteData[] sprites,
      int offset,
      int count)
    {
      this._graphicsDevice.Textures[0] = (Texture) texture;
      float num1 = 1f / (float) texture.Width;
      float num2 = 1f / (float) texture.Height;
      int num3;
      for (; count > 0; count -= num3)
      {
        SetDataOptions options = SetDataOptions.NoOverwrite;
        num3 = count;
        if (num3 > 2048 - this._vertexBufferPosition)
        {
          num3 = 2048 - this._vertexBufferPosition;
          if (num3 < 256)
          {
            this._vertexBufferPosition = 0;
            options = SetDataOptions.Discard;
            num3 = count;
            if (num3 > 2048)
              num3 = 2048;
          }
        }
        fixed (TileBatch.SpriteData* spriteDataPtr1 = &sprites[offset])
          fixed (VertexPositionColorTexture* positionColorTexturePtr1 = &this._vertices[0])
          {
            TileBatch.SpriteData* spriteDataPtr2 = spriteDataPtr1;
            VertexPositionColorTexture* positionColorTexturePtr2 = positionColorTexturePtr1;
            for (int index1 = 0; index1 < num3; ++index1)
            {
              float num4;
              float num5;
              if ((double) spriteDataPtr2->Rotation != 0.0)
              {
                num4 = (float) Math.Cos((double) spriteDataPtr2->Rotation);
                num5 = (float) Math.Sin((double) spriteDataPtr2->Rotation);
              }
              else
              {
                num4 = 1f;
                num5 = 0.0f;
              }
              float num6 = spriteDataPtr2->Origin.X / spriteDataPtr2->Source.Z;
              float num7 = spriteDataPtr2->Origin.Y / spriteDataPtr2->Source.W;
              positionColorTexturePtr2->Color = spriteDataPtr2->Colors.TopLeftColor;
              positionColorTexturePtr2[1].Color = spriteDataPtr2->Colors.TopRightColor;
              positionColorTexturePtr2[2].Color = spriteDataPtr2->Colors.BottomRightColor;
              positionColorTexturePtr2[3].Color = spriteDataPtr2->Colors.BottomLeftColor;
              for (int index2 = 0; index2 < 4; ++index2)
              {
                float num8 = TileBatch.CORNER_OFFSET_X[index2];
                float num9 = TileBatch.CORNER_OFFSET_Y[index2];
                float num10 = (num8 - num6) * spriteDataPtr2->Destination.Z;
                float num11 = (num9 - num7) * spriteDataPtr2->Destination.W;
                float num12 = (float) ((double) spriteDataPtr2->Destination.X + (double) num10 * (double) num4 - (double) num11 * (double) num5);
                float num13 = (float) ((double) spriteDataPtr2->Destination.Y + (double) num10 * (double) num5 + (double) num11 * (double) num4);
                if ((spriteDataPtr2->Effects & SpriteEffects.FlipVertically) != SpriteEffects.None)
                  num8 = 1f - num8;
                if ((spriteDataPtr2->Effects & SpriteEffects.FlipHorizontally) != SpriteEffects.None)
                  num9 = 1f - num9;
                positionColorTexturePtr2->Position.X = num12;
                positionColorTexturePtr2->Position.Y = num13;
                positionColorTexturePtr2->Position.Z = 0.0f;
                positionColorTexturePtr2->TextureCoordinate.X = (spriteDataPtr2->Source.X + num8 * spriteDataPtr2->Source.Z) * num1;
                positionColorTexturePtr2->TextureCoordinate.Y = (spriteDataPtr2->Source.Y + num9 * spriteDataPtr2->Source.W) * num2;
                ++positionColorTexturePtr2;
              }
              ++spriteDataPtr2;
            }
          }
        this._vertexBuffer.SetData<VertexPositionColorTexture>(this._vertexBufferPosition * sizeof (VertexPositionColorTexture) * 4, this._vertices, 0, num3 * 4, sizeof (VertexPositionColorTexture), options);
        this._graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, this._vertexBufferPosition * 4, num3 * 4, this._vertexBufferPosition * 6, num3 * 2);
        this._vertexBufferPosition += num3;
        offset += num3;
      }
    }

    private struct SpriteData
    {
      public Vector4 Source;
      public Vector4 Destination;
      public Vector2 Origin;
      public SpriteEffects Effects;
      public VertexColors Colors;
      public float Rotation;
    }
  }
}
