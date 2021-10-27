// Decompiled with JetBrains decompiler
// Type: Terraria.Animation
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria
{
  public class Animation
  {
    private static List<Animation> _animations;
    private static Dictionary<Point16, Animation> _temporaryAnimations;
    private static List<Point16> _awaitingRemoval;
    private static List<Animation> _awaitingAddition;
    private bool _temporary;
    private Point16 _coordinates;
    private ushort _tileType;
    private int _frame;
    private int _frameMax;
    private int _frameCounter;
    private int _frameCounterMax;
    private int[] _frameData;

    public static void Initialize()
    {
      Animation._animations = new List<Animation>();
      Animation._temporaryAnimations = new Dictionary<Point16, Animation>();
      Animation._awaitingRemoval = new List<Point16>();
      Animation._awaitingAddition = new List<Animation>();
    }

    private void SetDefaults(int type)
    {
      this._tileType = (ushort) 0;
      this._frame = 0;
      this._frameMax = 0;
      this._frameCounter = 0;
      this._frameCounterMax = 0;
      this._temporary = false;
      switch (type)
      {
        case 0:
          this._frameMax = 5;
          this._frameCounterMax = 12;
          this._frameData = new int[this._frameMax];
          for (int index = 0; index < this._frameMax; ++index)
            this._frameData[index] = index + 1;
          break;
        case 1:
          this._frameMax = 5;
          this._frameCounterMax = 12;
          this._frameData = new int[this._frameMax];
          for (int index = 0; index < this._frameMax; ++index)
            this._frameData[index] = 5 - index;
          break;
        case 2:
          this._frameCounterMax = 6;
          this._frameData = new int[5]{ 1, 2, 2, 2, 1 };
          this._frameMax = this._frameData.Length;
          break;
      }
    }

    public static void NewTemporaryAnimation(int type, ushort tileType, int x, int y)
    {
      Point16 point16 = new Point16(x, y);
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
        return;
      Animation animation = new Animation();
      animation.SetDefaults(type);
      animation._tileType = tileType;
      animation._coordinates = point16;
      animation._temporary = true;
      Animation._awaitingAddition.Add(animation);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTemporaryAnimation(-1, type, (int) tileType, x, y);
    }

    private static void RemoveTemporaryAnimation(short x, short y)
    {
      Point16 key = new Point16(x, y);
      if (!Animation._temporaryAnimations.ContainsKey(key))
        return;
      Animation._awaitingRemoval.Add(key);
    }

    public static void UpdateAll()
    {
      for (int index = 0; index < Animation._animations.Count; ++index)
        Animation._animations[index].Update();
      if (Animation._awaitingAddition.Count > 0)
      {
        for (int index = 0; index < Animation._awaitingAddition.Count; ++index)
        {
          Animation animation = Animation._awaitingAddition[index];
          Animation._temporaryAnimations[animation._coordinates] = animation;
        }
        Animation._awaitingAddition.Clear();
      }
      foreach (KeyValuePair<Point16, Animation> temporaryAnimation in Animation._temporaryAnimations)
        temporaryAnimation.Value.Update();
      if (Animation._awaitingRemoval.Count <= 0)
        return;
      for (int index = 0; index < Animation._awaitingRemoval.Count; ++index)
        Animation._temporaryAnimations.Remove(Animation._awaitingRemoval[index]);
      Animation._awaitingRemoval.Clear();
    }

    public void Update()
    {
      if (this._temporary)
      {
        Tile tile = Main.tile[(int) this._coordinates.X, (int) this._coordinates.Y];
        if (tile != null && (int) tile.type != (int) this._tileType)
        {
          Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
          return;
        }
      }
      ++this._frameCounter;
      if (this._frameCounter < this._frameCounterMax)
        return;
      this._frameCounter = 0;
      ++this._frame;
      if (this._frame < this._frameMax)
        return;
      this._frame = 0;
      if (!this._temporary)
        return;
      Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
    }

    public static bool GetTemporaryFrame(int x, int y, out int frameData)
    {
      Point16 key = new Point16(x, y);
      Animation animation;
      if (!Animation._temporaryAnimations.TryGetValue(key, out animation))
      {
        frameData = 0;
        return false;
      }
      frameData = animation._frameData[animation._frame];
      return true;
    }
  }
}
