// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.VanillaContentValidator
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Terraria.GameContent
{
  public class VanillaContentValidator : IContentValidator
  {
    public static VanillaContentValidator Instance;
    private Dictionary<string, VanillaContentValidator.TextureMetaData> _info = new Dictionary<string, VanillaContentValidator.TextureMetaData>();

    public VanillaContentValidator(string infoFilePath)
    {
      foreach (string str in Regex.Split(Utils.ReadEmbeddedResource(infoFilePath), "\r\n|\r|\n"))
      {
        if (!str.StartsWith("//"))
        {
          string[] strArray = str.Split('\t');
          int result1;
          int result2;
          if (strArray.Length >= 3 && int.TryParse(strArray[1], out result1) && int.TryParse(strArray[2], out result2))
            this._info[strArray[0].Replace('/', '\\')] = new VanillaContentValidator.TextureMetaData()
            {
              Width = result1,
              Height = result2
            };
        }
      }
    }

    public bool AssetIsValid<T>(T content, string contentPath, out IRejectionReason rejectReason) where T : class
    {
      Texture2D texture = (object) content as Texture2D;
      rejectReason = (IRejectionReason) null;
      VanillaContentValidator.TextureMetaData textureMetaData;
      return texture == null || !this._info.TryGetValue(contentPath, out textureMetaData) || textureMetaData.Matches(texture, out rejectReason);
    }

    private struct TextureMetaData
    {
      public int Width;
      public int Height;

      public bool Matches(Texture2D texture, out IRejectionReason rejectReason)
      {
        if (texture.Width != this.Width || texture.Height != this.Height)
        {
          rejectReason = (IRejectionReason) new ContentRejectionFromSize(this.Width, this.Height, texture.Width, texture.Height);
          return false;
        }
        rejectReason = (IRejectionReason) null;
        return true;
      }
    }
  }
}
