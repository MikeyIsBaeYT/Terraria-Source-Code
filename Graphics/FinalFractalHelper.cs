// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.FinalFractalHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct FinalFractalHelper
  {
    public const int TotalIllusions = 4;
    public const int FramesPerImportantTrail = 15;
    private static VertexStrip _vertexStrip = new VertexStrip();
    private static Dictionary<int, FinalFractalHelper.FinalFractalProfile> _fractalProfiles = new Dictionary<int, FinalFractalHelper.FinalFractalProfile>()
    {
      {
        65,
        new FinalFractalHelper.FinalFractalProfile(48f, new Color(236, 62, 192))
      },
      {
        1123,
        new FinalFractalHelper.FinalFractalProfile(48f, Main.OurFavoriteColor)
      },
      {
        46,
        new FinalFractalHelper.FinalFractalProfile(48f, new Color(122, 66, 191))
      },
      {
        121,
        new FinalFractalHelper.FinalFractalProfile(76f, new Color(254, 158, 35))
      },
      {
        190,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(107, 203, 0))
      },
      {
        368,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(236, 200, 19))
      },
      {
        674,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(236, 200, 19))
      },
      {
        273,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(179, 54, 201))
      },
      {
        675,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(179, 54, 201))
      },
      {
        2880,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(84, 234, 245))
      },
      {
        989,
        new FinalFractalHelper.FinalFractalProfile(48f, new Color(91, 158, 232))
      },
      {
        1826,
        new FinalFractalHelper.FinalFractalProfile(76f, new Color(252, 95, 4))
      },
      {
        3063,
        new FinalFractalHelper.FinalFractalProfile(76f, new Color(254, 194, 250))
      },
      {
        3065,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(237, 63, 133))
      },
      {
        757,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(80, 222, 122))
      },
      {
        155,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(56, 78, 210))
      },
      {
        795,
        new FinalFractalHelper.FinalFractalProfile(70f, new Color(237, 28, 36))
      },
      {
        3018,
        new FinalFractalHelper.FinalFractalProfile(80f, new Color(143, 215, 29))
      },
      {
        4144,
        new FinalFractalHelper.FinalFractalProfile(45f, new Color(178, (int) byte.MaxValue, 180))
      },
      {
        3507,
        new FinalFractalHelper.FinalFractalProfile(45f, new Color(235, 166, 135))
      },
      {
        4956,
        new FinalFractalHelper.FinalFractalProfile(86f, new Color(178, (int) byte.MaxValue, 180))
      }
    };
    private static FinalFractalHelper.FinalFractalProfile _defaultProfile = new FinalFractalHelper.FinalFractalProfile(50f, Color.White);

    public static int GetRandomProfileIndex()
    {
      List<int> list = FinalFractalHelper._fractalProfiles.Keys.ToList<int>();
      int index = Main.rand.Next(list.Count);
      if (list[index] == 4956)
      {
        list.RemoveAt(index);
        index = Main.rand.Next(list.Count);
      }
      return list[index];
    }

    public void Draw(Projectile proj)
    {
      FinalFractalHelper.FinalFractalProfile finalFractalProfile = FinalFractalHelper.GetFinalFractalProfile((int) proj.ai[1]);
      MiscShaderData miscShaderData = GameShaders.Misc["FinalFractal"];
      miscShaderData.UseShaderSpecificData(new Vector4(4f, 0.0f, 0.0f, 4f));
      miscShaderData.UseImage0("Images/Extra_" + (object) (short) 201);
      miscShaderData.UseImage1("Images/Extra_" + (object) (short) 193);
      miscShaderData.Apply(new DrawData?());
      FinalFractalHelper._vertexStrip.PrepareStrip(proj.oldPos, proj.oldRot, finalFractalProfile.colorMethod, finalFractalProfile.widthMethod, -Main.screenPosition + proj.Size / 2f, new int?(proj.oldPos.Length), true);
      FinalFractalHelper._vertexStrip.DrawTrail();
      Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public static FinalFractalHelper.FinalFractalProfile GetFinalFractalProfile(
      int usedSwordId)
    {
      FinalFractalHelper.FinalFractalProfile defaultProfile;
      if (!FinalFractalHelper._fractalProfiles.TryGetValue(usedSwordId, out defaultProfile))
        defaultProfile = FinalFractalHelper._defaultProfile;
      return defaultProfile;
    }

    private Color StripColors(float progressOnStrip)
    {
      Color color = Color.Lerp(Color.White, Color.Violet, Utils.GetLerpValue(0.0f, 0.7f, progressOnStrip, true)) * (1f - Utils.GetLerpValue(0.0f, 0.98f, progressOnStrip, false));
      color.A /= (byte) 2;
      return color;
    }

    private float StripWidth(float progressOnStrip) => 50f;

    public delegate void SpawnDustMethod(Vector2 centerPosition, float rotation, Vector2 velocity);

    public struct FinalFractalProfile
    {
      public float trailWidth;
      public Color trailColor;
      public FinalFractalHelper.SpawnDustMethod dustMethod;
      public VertexStrip.StripColorFunction colorMethod;
      public VertexStrip.StripHalfWidthFunction widthMethod;

      public FinalFractalProfile(float fullBladeLength, Color color)
      {
        this.trailWidth = fullBladeLength / 2f;
        this.trailColor = color;
        this.widthMethod = (VertexStrip.StripHalfWidthFunction) null;
        this.colorMethod = (VertexStrip.StripColorFunction) null;
        this.dustMethod = (FinalFractalHelper.SpawnDustMethod) null;
        this.widthMethod = new VertexStrip.StripHalfWidthFunction(this.StripWidth);
        this.colorMethod = new VertexStrip.StripColorFunction(this.StripColors);
        this.dustMethod = new FinalFractalHelper.SpawnDustMethod(this.StripDust);
      }

      private void StripDust(Vector2 centerPosition, float rotation, Vector2 velocity)
      {
        if (Main.rand.Next(9) != 0)
          return;
        int num = Main.rand.Next(1, 4);
        for (int index = 0; index < num; ++index)
        {
          Dust dust = Dust.NewDustPerfect(centerPosition, 278, Alpha: 100, newColor: Color.Lerp(this.trailColor, Color.White, Main.rand.NextFloat() * 0.3f));
          dust.scale = 0.4f;
          dust.fadeIn = (float) (0.400000005960464 + (double) Main.rand.NextFloat() * 0.300000011920929);
          dust.noGravity = true;
          dust.velocity += rotation.ToRotationVector2() * (float) (3.0 + (double) Main.rand.NextFloat() * 4.0);
        }
      }

      private Color StripColors(float progressOnStrip)
      {
        Color color = this.trailColor * (1f - Utils.GetLerpValue(0.0f, 0.98f, progressOnStrip, false));
        color.A /= (byte) 2;
        return color;
      }

      private float StripWidth(float progressOnStrip) => this.trailWidth;
    }
  }
}
