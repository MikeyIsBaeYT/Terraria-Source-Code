// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerDrawHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Graphics.Shaders;

namespace Terraria.DataStructures
{
  public class PlayerDrawHelper
  {
    public static int PackShader(
      int localShaderIndex,
      PlayerDrawHelper.ShaderConfiguration shaderType)
    {
      return localShaderIndex + (int) shaderType * 1000;
    }

    public static void UnpackShader(
      int packedShaderIndex,
      out int localShaderIndex,
      out PlayerDrawHelper.ShaderConfiguration shaderType)
    {
      shaderType = (PlayerDrawHelper.ShaderConfiguration) (packedShaderIndex / 1000);
      localShaderIndex = packedShaderIndex % 1000;
    }

    public static void SetShaderForData(Player player, int cHead, ref DrawData cdd)
    {
      int localShaderIndex;
      PlayerDrawHelper.ShaderConfiguration shaderType;
      PlayerDrawHelper.UnpackShader(cdd.shader, out localShaderIndex, out shaderType);
      switch (shaderType)
      {
        case PlayerDrawHelper.ShaderConfiguration.ArmorShader:
          GameShaders.Hair.Apply((short) 0, player, new DrawData?(cdd));
          GameShaders.Armor.Apply(localShaderIndex, (Entity) player, new DrawData?(cdd));
          break;
        case PlayerDrawHelper.ShaderConfiguration.HairShader:
          if (player.head == 0)
          {
            GameShaders.Hair.Apply((short) 0, player, new DrawData?(cdd));
            GameShaders.Armor.Apply(cHead, (Entity) player, new DrawData?(cdd));
            break;
          }
          GameShaders.Armor.Apply(0, (Entity) player, new DrawData?(cdd));
          GameShaders.Hair.Apply((short) localShaderIndex, player, new DrawData?(cdd));
          break;
        case PlayerDrawHelper.ShaderConfiguration.TileShader:
          Main.tileShader.CurrentTechnique.Passes[localShaderIndex].Apply();
          break;
        case PlayerDrawHelper.ShaderConfiguration.TilePaintID:
          if (localShaderIndex == 31)
          {
            GameShaders.Armor.Apply(0, (Entity) player, new DrawData?(cdd));
            break;
          }
          Main.tileShader.CurrentTechnique.Passes[Main.ConvertPaintIdToTileShaderIndex(localShaderIndex, false, false)].Apply();
          break;
      }
    }

    public enum ShaderConfiguration
    {
      ArmorShader,
      HairShader,
      TileShader,
      TilePaintID,
    }
  }
}
