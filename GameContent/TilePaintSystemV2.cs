// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TilePaintSystemV2
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class TilePaintSystemV2
  {
    private Dictionary<TilePaintSystemV2.TileVariationkey, TilePaintSystemV2.TileRenderTargetHolder> _tilesRenders = new Dictionary<TilePaintSystemV2.TileVariationkey, TilePaintSystemV2.TileRenderTargetHolder>();
    private Dictionary<TilePaintSystemV2.WallVariationKey, TilePaintSystemV2.WallRenderTargetHolder> _wallsRenders = new Dictionary<TilePaintSystemV2.WallVariationKey, TilePaintSystemV2.WallRenderTargetHolder>();
    private Dictionary<TilePaintSystemV2.TreeFoliageVariantKey, TilePaintSystemV2.TreeTopRenderTargetHolder> _treeTopRenders = new Dictionary<TilePaintSystemV2.TreeFoliageVariantKey, TilePaintSystemV2.TreeTopRenderTargetHolder>();
    private Dictionary<TilePaintSystemV2.TreeFoliageVariantKey, TilePaintSystemV2.TreeBranchTargetHolder> _treeBranchRenders = new Dictionary<TilePaintSystemV2.TreeFoliageVariantKey, TilePaintSystemV2.TreeBranchTargetHolder>();
    private List<TilePaintSystemV2.ARenderTargetHolder> _requests = new List<TilePaintSystemV2.ARenderTargetHolder>();

    public void Reset()
    {
      foreach (TilePaintSystemV2.ARenderTargetHolder arenderTargetHolder in this._tilesRenders.Values)
        arenderTargetHolder.Clear();
      this._tilesRenders.Clear();
      foreach (TilePaintSystemV2.ARenderTargetHolder arenderTargetHolder in this._wallsRenders.Values)
        arenderTargetHolder.Clear();
      this._wallsRenders.Clear();
      foreach (TilePaintSystemV2.ARenderTargetHolder arenderTargetHolder in this._treeTopRenders.Values)
        arenderTargetHolder.Clear();
      this._treeTopRenders.Clear();
      foreach (TilePaintSystemV2.ARenderTargetHolder arenderTargetHolder in this._treeBranchRenders.Values)
        arenderTargetHolder.Clear();
      this._treeBranchRenders.Clear();
      foreach (TilePaintSystemV2.ARenderTargetHolder request in this._requests)
        request.Clear();
      this._requests.Clear();
    }

    public void RequestTile(ref TilePaintSystemV2.TileVariationkey lookupKey)
    {
      TilePaintSystemV2.TileRenderTargetHolder renderTargetHolder;
      if (!this._tilesRenders.TryGetValue(lookupKey, out renderTargetHolder))
      {
        renderTargetHolder = new TilePaintSystemV2.TileRenderTargetHolder()
        {
          Key = lookupKey
        };
        this._tilesRenders.Add(lookupKey, renderTargetHolder);
      }
      if (renderTargetHolder.IsReady)
        return;
      this._requests.Add((TilePaintSystemV2.ARenderTargetHolder) renderTargetHolder);
    }

    private void RequestTile_CheckForRelatedTileRequests(
      ref TilePaintSystemV2.TileVariationkey lookupKey)
    {
      if (lookupKey.TileType != 83)
        return;
      TilePaintSystemV2.TileVariationkey lookupKey1 = new TilePaintSystemV2.TileVariationkey()
      {
        TileType = 84,
        TileStyle = lookupKey.TileStyle,
        PaintColor = lookupKey.PaintColor
      };
      this.RequestTile(ref lookupKey1);
    }

    public void RequestWall(ref TilePaintSystemV2.WallVariationKey lookupKey)
    {
      TilePaintSystemV2.WallRenderTargetHolder renderTargetHolder;
      if (!this._wallsRenders.TryGetValue(lookupKey, out renderTargetHolder))
      {
        renderTargetHolder = new TilePaintSystemV2.WallRenderTargetHolder()
        {
          Key = lookupKey
        };
        this._wallsRenders.Add(lookupKey, renderTargetHolder);
      }
      if (renderTargetHolder.IsReady)
        return;
      this._requests.Add((TilePaintSystemV2.ARenderTargetHolder) renderTargetHolder);
    }

    public void RequestTreeTop(
      ref TilePaintSystemV2.TreeFoliageVariantKey lookupKey)
    {
      TilePaintSystemV2.TreeTopRenderTargetHolder renderTargetHolder;
      if (!this._treeTopRenders.TryGetValue(lookupKey, out renderTargetHolder))
      {
        renderTargetHolder = new TilePaintSystemV2.TreeTopRenderTargetHolder()
        {
          Key = lookupKey
        };
        this._treeTopRenders.Add(lookupKey, renderTargetHolder);
      }
      if (renderTargetHolder.IsReady)
        return;
      this._requests.Add((TilePaintSystemV2.ARenderTargetHolder) renderTargetHolder);
    }

    public void RequestTreeBranch(
      ref TilePaintSystemV2.TreeFoliageVariantKey lookupKey)
    {
      TilePaintSystemV2.TreeBranchTargetHolder branchTargetHolder;
      if (!this._treeBranchRenders.TryGetValue(lookupKey, out branchTargetHolder))
      {
        branchTargetHolder = new TilePaintSystemV2.TreeBranchTargetHolder()
        {
          Key = lookupKey
        };
        this._treeBranchRenders.Add(lookupKey, branchTargetHolder);
      }
      if (branchTargetHolder.IsReady)
        return;
      this._requests.Add((TilePaintSystemV2.ARenderTargetHolder) branchTargetHolder);
    }

    public Texture2D TryGetTileAndRequestIfNotReady(
      int tileType,
      int tileStyle,
      int paintColor)
    {
      TilePaintSystemV2.TileVariationkey lookupKey = new TilePaintSystemV2.TileVariationkey()
      {
        TileType = tileType,
        TileStyle = tileStyle,
        PaintColor = paintColor
      };
      TilePaintSystemV2.TileRenderTargetHolder renderTargetHolder;
      if (this._tilesRenders.TryGetValue(lookupKey, out renderTargetHolder) && renderTargetHolder.IsReady)
        return (Texture2D) renderTargetHolder.Target;
      this.RequestTile(ref lookupKey);
      return (Texture2D) null;
    }

    public Texture2D TryGetWallAndRequestIfNotReady(int wallType, int paintColor)
    {
      TilePaintSystemV2.WallVariationKey lookupKey = new TilePaintSystemV2.WallVariationKey()
      {
        WallType = wallType,
        PaintColor = paintColor
      };
      TilePaintSystemV2.WallRenderTargetHolder renderTargetHolder;
      if (this._wallsRenders.TryGetValue(lookupKey, out renderTargetHolder) && renderTargetHolder.IsReady)
        return (Texture2D) renderTargetHolder.Target;
      this.RequestWall(ref lookupKey);
      return (Texture2D) null;
    }

    public Texture2D TryGetTreeTopAndRequestIfNotReady(
      int treeTopIndex,
      int treeTopStyle,
      int paintColor)
    {
      TilePaintSystemV2.TreeFoliageVariantKey lookupKey = new TilePaintSystemV2.TreeFoliageVariantKey()
      {
        TextureIndex = treeTopIndex,
        TextureStyle = treeTopStyle,
        PaintColor = paintColor
      };
      TilePaintSystemV2.TreeTopRenderTargetHolder renderTargetHolder;
      if (this._treeTopRenders.TryGetValue(lookupKey, out renderTargetHolder) && renderTargetHolder.IsReady)
        return (Texture2D) renderTargetHolder.Target;
      this.RequestTreeTop(ref lookupKey);
      return (Texture2D) null;
    }

    public Texture2D TryGetTreeBranchAndRequestIfNotReady(
      int treeTopIndex,
      int treeTopStyle,
      int paintColor)
    {
      TilePaintSystemV2.TreeFoliageVariantKey lookupKey = new TilePaintSystemV2.TreeFoliageVariantKey()
      {
        TextureIndex = treeTopIndex,
        TextureStyle = treeTopStyle,
        PaintColor = paintColor
      };
      TilePaintSystemV2.TreeBranchTargetHolder branchTargetHolder;
      if (this._treeBranchRenders.TryGetValue(lookupKey, out branchTargetHolder) && branchTargetHolder.IsReady)
        return (Texture2D) branchTargetHolder.Target;
      this.RequestTreeBranch(ref lookupKey);
      return (Texture2D) null;
    }

    public void PrepareAllRequests()
    {
      if (this._requests.Count == 0)
        return;
      for (int index = 0; index < this._requests.Count; ++index)
        this._requests[index].Prepare();
      this._requests.Clear();
    }

    public abstract class ARenderTargetHolder
    {
      public RenderTarget2D Target;
      protected bool _wasPrepared;

      public bool IsReady => this._wasPrepared;

      public abstract void Prepare();

      public abstract void PrepareShader();

      public void Clear()
      {
        if (this.Target == null || this.Target.IsDisposed)
          return;
        this.Target.Dispose();
      }

      protected void PrepareTextureIfNecessary(Texture2D originalTexture, Rectangle? sourceRect = null)
      {
        if (this.Target != null && !this.Target.IsContentLost)
          return;
        Main instance = Main.instance;
        if (!sourceRect.HasValue)
          sourceRect = new Rectangle?(originalTexture.Frame());
        this.Target = new RenderTarget2D(instance.GraphicsDevice, sourceRect.Value.Width, sourceRect.Value.Height, false, instance.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
        this.Target.ContentLost += new EventHandler<EventArgs>(this.Target_ContentLost);
        this.Target.Disposing += new EventHandler<EventArgs>(this.Target_Disposing);
        instance.GraphicsDevice.SetRenderTarget(this.Target);
        instance.GraphicsDevice.Clear(Color.Transparent);
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        this.PrepareShader();
        Rectangle destinationRectangle = sourceRect.Value;
        destinationRectangle.X = 0;
        destinationRectangle.Y = 0;
        Main.spriteBatch.Draw(originalTexture, destinationRectangle, Color.White);
        Main.spriteBatch.End();
        instance.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this._wasPrepared = true;
      }

      private void Target_Disposing(object sender, EventArgs e)
      {
        this._wasPrepared = false;
        this.Target = (RenderTarget2D) null;
      }

      private void Target_ContentLost(object sender, EventArgs e) => this._wasPrepared = false;

      protected void PrepareShader(int paintColor, TreePaintingSettings settings)
      {
        Effect tileShader = Main.tileShader;
        tileShader.Parameters["leafHueTestOffset"].SetValue(settings.HueTestOffset);
        tileShader.Parameters["leafMinHue"].SetValue(settings.SpecialGroupMinimalHueValue);
        tileShader.Parameters["leafMaxHue"].SetValue(settings.SpecialGroupMaximumHueValue);
        tileShader.Parameters["leafMinSat"].SetValue(settings.SpecialGroupMinimumSaturationValue);
        tileShader.Parameters["leafMaxSat"].SetValue(settings.SpecialGroupMaximumSaturationValue);
        tileShader.Parameters["invertSpecialGroupResult"].SetValue(settings.InvertSpecialGroupResult);
        tileShader.CurrentTechnique.Passes[Main.ConvertPaintIdToTileShaderIndex(paintColor, settings.UseSpecialGroups, settings.UseWallShaderHacks)].Apply();
      }
    }

    public class TreeTopRenderTargetHolder : TilePaintSystemV2.ARenderTargetHolder
    {
      public TilePaintSystemV2.TreeFoliageVariantKey Key;

      public override void Prepare() => this.PrepareTextureIfNecessary(Main.Assets.Request<Texture2D>(TextureAssets.TreeTop[this.Key.TextureIndex].Name, (AssetRequestMode) 1).Value);

      public override void PrepareShader() => this.PrepareShader(this.Key.PaintColor, TreePaintSystemData.GetTreeFoliageSettings(this.Key.TextureIndex, this.Key.TextureStyle));
    }

    public class TreeBranchTargetHolder : TilePaintSystemV2.ARenderTargetHolder
    {
      public TilePaintSystemV2.TreeFoliageVariantKey Key;

      public override void Prepare() => this.PrepareTextureIfNecessary(Main.Assets.Request<Texture2D>(TextureAssets.TreeBranch[this.Key.TextureIndex].Name, (AssetRequestMode) 1).Value);

      public override void PrepareShader() => this.PrepareShader(this.Key.PaintColor, TreePaintSystemData.GetTreeFoliageSettings(this.Key.TextureIndex, this.Key.TextureStyle));
    }

    public class TileRenderTargetHolder : TilePaintSystemV2.ARenderTargetHolder
    {
      public TilePaintSystemV2.TileVariationkey Key;

      public override void Prepare() => this.PrepareTextureIfNecessary(Main.Assets.Request<Texture2D>(TextureAssets.Tile[this.Key.TileType].Name, (AssetRequestMode) 1).Value);

      public override void PrepareShader() => this.PrepareShader(this.Key.PaintColor, TreePaintSystemData.GetTileSettings(this.Key.TileType, this.Key.TileStyle));
    }

    public class WallRenderTargetHolder : TilePaintSystemV2.ARenderTargetHolder
    {
      public TilePaintSystemV2.WallVariationKey Key;

      public override void Prepare() => this.PrepareTextureIfNecessary(Main.Assets.Request<Texture2D>(TextureAssets.Wall[this.Key.WallType].Name, (AssetRequestMode) 1).Value);

      public override void PrepareShader() => this.PrepareShader(this.Key.PaintColor, TreePaintSystemData.GetWallSettings(this.Key.WallType));
    }

    public struct TileVariationkey
    {
      public int TileType;
      public int TileStyle;
      public int PaintColor;

      public bool Equals(TilePaintSystemV2.TileVariationkey other) => this.TileType == other.TileType && this.TileStyle == other.TileStyle && this.PaintColor == other.PaintColor;

      public override bool Equals(object obj) => obj is TilePaintSystemV2.TileVariationkey other && this.Equals(other);

      public override int GetHashCode() => (this.TileType * 397 ^ this.TileStyle) * 397 ^ this.PaintColor;

      public static bool operator ==(
        TilePaintSystemV2.TileVariationkey left,
        TilePaintSystemV2.TileVariationkey right)
      {
        return left.Equals(right);
      }

      public static bool operator !=(
        TilePaintSystemV2.TileVariationkey left,
        TilePaintSystemV2.TileVariationkey right)
      {
        return !left.Equals(right);
      }
    }

    public struct WallVariationKey
    {
      public int WallType;
      public int PaintColor;

      public bool Equals(TilePaintSystemV2.WallVariationKey other) => this.WallType == other.WallType && this.PaintColor == other.PaintColor;

      public override bool Equals(object obj) => obj is TilePaintSystemV2.WallVariationKey other && this.Equals(other);

      public override int GetHashCode() => this.WallType * 397 ^ this.PaintColor;

      public static bool operator ==(
        TilePaintSystemV2.WallVariationKey left,
        TilePaintSystemV2.WallVariationKey right)
      {
        return left.Equals(right);
      }

      public static bool operator !=(
        TilePaintSystemV2.WallVariationKey left,
        TilePaintSystemV2.WallVariationKey right)
      {
        return !left.Equals(right);
      }
    }

    public struct TreeFoliageVariantKey
    {
      public int TextureIndex;
      public int TextureStyle;
      public int PaintColor;

      public bool Equals(TilePaintSystemV2.TreeFoliageVariantKey other) => this.TextureIndex == other.TextureIndex && this.TextureStyle == other.TextureStyle && this.PaintColor == other.PaintColor;

      public override bool Equals(object obj) => obj is TilePaintSystemV2.TreeFoliageVariantKey other && this.Equals(other);

      public override int GetHashCode() => (this.TextureIndex * 397 ^ this.TextureStyle) * 397 ^ this.PaintColor;

      public static bool operator ==(
        TilePaintSystemV2.TreeFoliageVariantKey left,
        TilePaintSystemV2.TreeFoliageVariantKey right)
      {
        return left.Equals(right);
      }

      public static bool operator !=(
        TilePaintSystemV2.TreeFoliageVariantKey left,
        TilePaintSystemV2.TreeFoliageVariantKey right)
      {
        return !left.Equals(right);
      }
    }
  }
}
