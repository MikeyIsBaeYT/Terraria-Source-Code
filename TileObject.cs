// Decompiled with JetBrains decompiler
// Type: Terraria.TileObject
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
  public struct TileObject
  {
    public int xCoord;
    public int yCoord;
    public int type;
    public int style;
    public int alternate;
    public int random;
    public static TileObject Empty = new TileObject();
    public static TileObjectPreviewData objectPreview = new TileObjectPreviewData();

    public static bool Place(TileObject toBePlaced)
    {
      TileObjectData tileData = TileObjectData.GetTileData(toBePlaced.type, toBePlaced.style, toBePlaced.alternate);
      if (tileData == null)
        return false;
      if (tileData.HookPlaceOverride.hook != null)
      {
        int num1;
        int num2;
        if (tileData.HookPlaceOverride.processedCoordinates)
        {
          num1 = toBePlaced.xCoord;
          num2 = toBePlaced.yCoord;
        }
        else
        {
          num1 = toBePlaced.xCoord + (int) tileData.Origin.X;
          num2 = toBePlaced.yCoord + (int) tileData.Origin.Y;
        }
        if (tileData.HookPlaceOverride.hook(num1, num2, toBePlaced.type, toBePlaced.style, 1) == tileData.HookPlaceOverride.badReturn)
          return false;
      }
      else
      {
        ushort type = (ushort) toBePlaced.type;
        int placementStyle = tileData.CalculatePlacementStyle(toBePlaced.style, toBePlaced.alternate, toBePlaced.random);
        int num3 = 0;
        if (tileData.StyleWrapLimit > 0)
        {
          num3 = placementStyle / tileData.StyleWrapLimit * tileData.StyleLineSkip;
          placementStyle %= tileData.StyleWrapLimit;
        }
        int num4;
        int num5;
        if (tileData.StyleHorizontal)
        {
          num4 = tileData.CoordinateFullWidth * placementStyle;
          num5 = tileData.CoordinateFullHeight * num3;
        }
        else
        {
          num4 = tileData.CoordinateFullWidth * num3;
          num5 = tileData.CoordinateFullHeight * placementStyle;
        }
        int xCoord = toBePlaced.xCoord;
        int yCoord = toBePlaced.yCoord;
        for (int index1 = 0; index1 < tileData.Width; ++index1)
        {
          for (int index2 = 0; index2 < tileData.Height; ++index2)
          {
            Tile tileSafely = Framing.GetTileSafely(xCoord + index1, yCoord + index2);
            if (tileSafely.active() && Main.tileCut[(int) tileSafely.type])
              WorldGen.KillTile(xCoord + index1, yCoord + index2);
          }
        }
        for (int index3 = 0; index3 < tileData.Width; ++index3)
        {
          int num6 = num4 + index3 * (tileData.CoordinateWidth + tileData.CoordinatePadding);
          int num7 = num5;
          for (int index4 = 0; index4 < tileData.Height; ++index4)
          {
            Tile tileSafely = Framing.GetTileSafely(xCoord + index3, yCoord + index4);
            if (!tileSafely.active())
            {
              tileSafely.active(true);
              tileSafely.frameX = (short) num6;
              tileSafely.frameY = (short) num7;
              tileSafely.type = type;
            }
            num7 += tileData.CoordinateHeights[index4] + tileData.CoordinatePadding;
          }
        }
      }
      if (tileData.FlattenAnchors)
      {
        AnchorData anchorBottom = tileData.AnchorBottom;
        if (anchorBottom.tileCount != 0 && (anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile)
        {
          int num = toBePlaced.xCoord + anchorBottom.checkStart;
          int j = toBePlaced.yCoord + tileData.Height;
          for (int index = 0; index < anchorBottom.tileCount; ++index)
          {
            Tile tileSafely = Framing.GetTileSafely(num + index, j);
            if (Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && tileSafely.blockType() != 0)
              WorldGen.SlopeTile(num + index, j);
          }
        }
        AnchorData anchorTop = tileData.AnchorTop;
        if (anchorTop.tileCount != 0 && (anchorTop.type & AnchorType.SolidTile) == AnchorType.SolidTile)
        {
          int num = toBePlaced.xCoord + anchorTop.checkStart;
          int j = toBePlaced.yCoord - 1;
          for (int index = 0; index < anchorTop.tileCount; ++index)
          {
            Tile tileSafely = Framing.GetTileSafely(num + index, j);
            if (Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && tileSafely.blockType() != 0)
              WorldGen.SlopeTile(num + index, j);
          }
        }
        AnchorData anchorRight = tileData.AnchorRight;
        if (anchorRight.tileCount != 0 && (anchorRight.type & AnchorType.SolidTile) == AnchorType.SolidTile)
        {
          int i = toBePlaced.xCoord + tileData.Width;
          int num = toBePlaced.yCoord + anchorRight.checkStart;
          for (int index = 0; index < anchorRight.tileCount; ++index)
          {
            Tile tileSafely = Framing.GetTileSafely(i, num + index);
            if (Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && tileSafely.blockType() != 0)
              WorldGen.SlopeTile(i, num + index);
          }
        }
        AnchorData anchorLeft = tileData.AnchorLeft;
        if (anchorLeft.tileCount != 0 && (anchorLeft.type & AnchorType.SolidTile) == AnchorType.SolidTile)
        {
          int i = toBePlaced.xCoord - 1;
          int num = toBePlaced.yCoord + anchorLeft.checkStart;
          for (int index = 0; index < anchorLeft.tileCount; ++index)
          {
            Tile tileSafely = Framing.GetTileSafely(i, num + index);
            if (Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && tileSafely.blockType() != 0)
              WorldGen.SlopeTile(i, num + index);
          }
        }
      }
      return true;
    }

    public static bool CanPlace(
      int x,
      int y,
      int type,
      int style,
      int dir,
      out TileObject objectData,
      bool onlyCheck = false)
    {
      TileObjectData tileData1 = TileObjectData.GetTileData(type, style);
      objectData = TileObject.Empty;
      if (tileData1 == null)
        return false;
      int num1 = x - (int) tileData1.Origin.X;
      int num2 = y - (int) tileData1.Origin.Y;
      if (num1 < 0 || num1 + tileData1.Width >= Main.maxTilesX || num2 < 0 || num2 + tileData1.Height >= Main.maxTilesY)
        return false;
      bool flag1 = tileData1.RandomStyleRange > 0;
      if (TileObjectPreviewData.placementCache == null)
        TileObjectPreviewData.placementCache = new TileObjectPreviewData();
      TileObjectPreviewData.placementCache.Reset();
      int num3 = 0;
      if (tileData1.AlternatesCount != 0)
        num3 = tileData1.AlternatesCount;
      float num4 = -1f;
      float num5 = -1f;
      int num6 = 0;
      TileObjectData tileObjectData = (TileObjectData) null;
      int alternate = 0 - 1;
      while (alternate < num3)
      {
        ++alternate;
        TileObjectData tileData2 = TileObjectData.GetTileData(type, style, alternate);
        if (tileData2.Direction == TileObjectDirection.None || (tileData2.Direction != TileObjectDirection.PlaceLeft || dir != 1) && (tileData2.Direction != TileObjectDirection.PlaceRight || dir != -1))
        {
          int num7 = x - (int) tileData2.Origin.X;
          int num8 = y - (int) tileData2.Origin.Y;
          if (num7 < 5 || num7 + tileData2.Width > Main.maxTilesX - 5 || num8 < 5 || num8 + tileData2.Height > Main.maxTilesY - 5)
            return false;
          Rectangle rectangle = new Rectangle(0, 0, tileData2.Width, tileData2.Height);
          int X = 0;
          int Y = 0;
          if (tileData2.AnchorTop.tileCount != 0)
          {
            if (rectangle.Y == 0)
            {
              rectangle.Y = -1;
              ++rectangle.Height;
              ++Y;
            }
            int checkStart = tileData2.AnchorTop.checkStart;
            if (checkStart < rectangle.X)
            {
              rectangle.Width += rectangle.X - checkStart;
              X += rectangle.X - checkStart;
              rectangle.X = checkStart;
            }
            int num9 = checkStart + tileData2.AnchorTop.tileCount - 1;
            int num10 = rectangle.X + rectangle.Width - 1;
            if (num9 > num10)
              rectangle.Width += num9 - num10;
          }
          if (tileData2.AnchorBottom.tileCount != 0)
          {
            if (rectangle.Y + rectangle.Height == tileData2.Height)
              ++rectangle.Height;
            int checkStart = tileData2.AnchorBottom.checkStart;
            if (checkStart < rectangle.X)
            {
              rectangle.Width += rectangle.X - checkStart;
              X += rectangle.X - checkStart;
              rectangle.X = checkStart;
            }
            int num11 = checkStart + tileData2.AnchorBottom.tileCount - 1;
            int num12 = rectangle.X + rectangle.Width - 1;
            if (num11 > num12)
              rectangle.Width += num11 - num12;
          }
          if (tileData2.AnchorLeft.tileCount != 0)
          {
            if (rectangle.X == 0)
            {
              rectangle.X = -1;
              ++rectangle.Width;
              ++X;
            }
            int checkStart = tileData2.AnchorLeft.checkStart;
            if ((tileData2.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
              --checkStart;
            if (checkStart < rectangle.Y)
            {
              rectangle.Width += rectangle.Y - checkStart;
              Y += rectangle.Y - checkStart;
              rectangle.Y = checkStart;
            }
            int num13 = checkStart + tileData2.AnchorLeft.tileCount - 1;
            if ((tileData2.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
              num13 += 2;
            int num14 = rectangle.Y + rectangle.Height - 1;
            if (num13 > num14)
              rectangle.Height += num13 - num14;
          }
          if (tileData2.AnchorRight.tileCount != 0)
          {
            if (rectangle.X + rectangle.Width == tileData2.Width)
              ++rectangle.Width;
            int checkStart = tileData2.AnchorLeft.checkStart;
            if ((tileData2.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
              --checkStart;
            if (checkStart < rectangle.Y)
            {
              rectangle.Width += rectangle.Y - checkStart;
              Y += rectangle.Y - checkStart;
              rectangle.Y = checkStart;
            }
            int num15 = checkStart + tileData2.AnchorRight.tileCount - 1;
            if ((tileData2.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
              num15 += 2;
            int num16 = rectangle.Y + rectangle.Height - 1;
            if (num15 > num16)
              rectangle.Height += num15 - num16;
          }
          if (onlyCheck)
          {
            TileObject.objectPreview.Reset();
            TileObject.objectPreview.Active = true;
            TileObject.objectPreview.Type = (ushort) type;
            TileObject.objectPreview.Style = (short) style;
            TileObject.objectPreview.Alternate = alternate;
            TileObject.objectPreview.Size = new Point16(rectangle.Width, rectangle.Height);
            TileObject.objectPreview.ObjectStart = new Point16(X, Y);
            TileObject.objectPreview.Coordinates = new Point16(num7 - X, num8 - Y);
          }
          float num17 = 0.0f;
          float num18 = (float) (tileData2.Width * tileData2.Height);
          float num19 = 0.0f;
          float num20 = 0.0f;
          for (int index1 = 0; index1 < tileData2.Width; ++index1)
          {
            for (int index2 = 0; index2 < tileData2.Height; ++index2)
            {
              Tile tileSafely = Framing.GetTileSafely(num7 + index1, num8 + index2);
              bool flag2 = !tileData2.LiquidPlace(tileSafely);
              bool flag3 = false;
              if (tileData2.AnchorWall)
              {
                ++num20;
                if (!tileData2.isValidWallAnchor((int) tileSafely.wall))
                  flag3 = true;
                else
                  ++num19;
              }
              bool flag4 = false;
              if (tileSafely.active() && !Main.tileCut[(int) tileSafely.type])
                flag4 = true;
              if (flag4 | flag2 | flag3)
              {
                if (onlyCheck)
                  TileObject.objectPreview[index1 + X, index2 + Y] = 2;
              }
              else
              {
                if (onlyCheck)
                  TileObject.objectPreview[index1 + X, index2 + Y] = 1;
                ++num17;
              }
            }
          }
          AnchorData anchorBottom = tileData2.AnchorBottom;
          if (anchorBottom.tileCount != 0)
          {
            num20 += (float) anchorBottom.tileCount;
            int height = tileData2.Height;
            for (int index = 0; index < anchorBottom.tileCount; ++index)
            {
              int num21 = anchorBottom.checkStart + index;
              Tile tileSafely = Framing.GetTileSafely(num7 + num21, num8 + height);
              bool flag5 = false;
              if (tileSafely.nactive())
              {
                if ((anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile && Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && !Main.tileNoAttach[(int) tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
                  flag5 = tileData2.isValidTileAnchor((int) tileSafely.type);
                if (!flag5 && ((anchorBottom.type & AnchorType.SolidWithTop) == AnchorType.SolidWithTop || (anchorBottom.type & AnchorType.Table) == AnchorType.Table))
                {
                  if (TileID.Sets.Platforms[(int) tileSafely.type])
                  {
                    int num22 = (int) tileSafely.frameX / TileObjectData.PlatformFrameWidth();
                    if (!tileSafely.halfBrick() && num22 >= 0 && num22 <= 7 || num22 >= 12 && num22 <= 16 || num22 >= 25 && num22 <= 26)
                      flag5 = true;
                  }
                  else if (Main.tileSolid[(int) tileSafely.type] && Main.tileSolidTop[(int) tileSafely.type])
                    flag5 = true;
                }
                if (!flag5 && (anchorBottom.type & AnchorType.Table) == AnchorType.Table && !TileID.Sets.Platforms[(int) tileSafely.type] && Main.tileTable[(int) tileSafely.type] && tileSafely.blockType() == 0)
                  flag5 = true;
                if (!flag5 && (anchorBottom.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type])
                {
                  switch (tileSafely.blockType())
                  {
                    case 4:
                    case 5:
                      flag5 = tileData2.isValidTileAnchor((int) tileSafely.type);
                      break;
                  }
                }
                if (!flag5 && (anchorBottom.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int) tileSafely.type))
                  flag5 = true;
              }
              else if (!flag5 && (anchorBottom.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
                flag5 = true;
              if (!flag5)
              {
                if (onlyCheck)
                  TileObject.objectPreview[num21 + X, height + Y] = 2;
              }
              else
              {
                if (onlyCheck)
                  TileObject.objectPreview[num21 + X, height + Y] = 1;
                ++num19;
              }
            }
          }
          AnchorData anchorTop = tileData2.AnchorTop;
          if (anchorTop.tileCount != 0)
          {
            num20 += (float) anchorTop.tileCount;
            int num23 = -1;
            for (int index = 0; index < anchorTop.tileCount; ++index)
            {
              int num24 = anchorTop.checkStart + index;
              Tile tileSafely = Framing.GetTileSafely(num7 + num24, num8 + num23);
              bool flag6 = false;
              if (tileSafely.nactive())
              {
                if (Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type] && !Main.tileNoAttach[(int) tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
                  flag6 = tileData2.isValidTileAnchor((int) tileSafely.type);
                if (!flag6 && (anchorTop.type & AnchorType.SolidBottom) == AnchorType.SolidBottom && (Main.tileSolid[(int) tileSafely.type] && (!Main.tileSolidTop[(int) tileSafely.type] || TileID.Sets.Platforms[(int) tileSafely.type] && (tileSafely.halfBrick() || tileSafely.topSlope())) || tileSafely.halfBrick() || tileSafely.topSlope()) && !TileID.Sets.NotReallySolid[(int) tileSafely.type] && !tileSafely.bottomSlope())
                  flag6 = tileData2.isValidTileAnchor((int) tileSafely.type);
                if (!flag6 && (anchorTop.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int) tileSafely.type] && !Main.tileSolidTop[(int) tileSafely.type])
                {
                  switch (tileSafely.blockType())
                  {
                    case 2:
                    case 3:
                      flag6 = tileData2.isValidTileAnchor((int) tileSafely.type);
                      break;
                  }
                }
                if (!flag6 && (anchorTop.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int) tileSafely.type))
                  flag6 = true;
              }
              else if (!flag6 && (anchorTop.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
                flag6 = true;
              if (!flag6)
              {
                if (onlyCheck)
                  TileObject.objectPreview[num24 + X, num23 + Y] = 2;
              }
              else
              {
                if (onlyCheck)
                  TileObject.objectPreview[num24 + X, num23 + Y] = 1;
                ++num19;
              }
            }
          }
          AnchorData anchorRight = tileData2.AnchorRight;
          if (anchorRight.tileCount != 0)
          {
            num20 += (float) anchorRight.tileCount;
            int width = tileData2.Width;
            for (int index = 0; index < anchorRight.tileCount; ++index)
            {
              int num25 = anchorRight.checkStart + index;
              Tile tileSafely1 = Framing.GetTileSafely(num7 + width, num8 + num25);
              bool flag7 = false;
              if (tileSafely1.nactive())
              {
                if (Main.tileSolid[(int) tileSafely1.type] && !Main.tileSolidTop[(int) tileSafely1.type] && !Main.tileNoAttach[(int) tileSafely1.type] && (tileData2.FlattenAnchors || tileSafely1.blockType() == 0))
                  flag7 = tileData2.isValidTileAnchor((int) tileSafely1.type);
                if (!flag7 && (anchorRight.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int) tileSafely1.type] && !Main.tileSolidTop[(int) tileSafely1.type])
                {
                  switch (tileSafely1.blockType())
                  {
                    case 2:
                    case 4:
                      flag7 = tileData2.isValidTileAnchor((int) tileSafely1.type);
                      break;
                  }
                }
                if (!flag7 && (anchorRight.type & AnchorType.Tree) == AnchorType.Tree && tileSafely1.type == (ushort) 5)
                {
                  flag7 = true;
                  if (index == 0)
                  {
                    ++num20;
                    Tile tileSafely2 = Framing.GetTileSafely(num7 + width, num8 + num25 - 1);
                    if (tileSafely2.nactive() && tileSafely2.type == (ushort) 5)
                    {
                      ++num19;
                      if (onlyCheck)
                        TileObject.objectPreview[width + X, num25 + Y - 1] = 1;
                    }
                    else if (onlyCheck)
                      TileObject.objectPreview[width + X, num25 + Y - 1] = 2;
                  }
                  if (index == anchorRight.tileCount - 1)
                  {
                    ++num20;
                    Tile tileSafely3 = Framing.GetTileSafely(num7 + width, num8 + num25 + 1);
                    if (tileSafely3.nactive() && tileSafely3.type == (ushort) 5)
                    {
                      ++num19;
                      if (onlyCheck)
                        TileObject.objectPreview[width + X, num25 + Y + 1] = 1;
                    }
                    else if (onlyCheck)
                      TileObject.objectPreview[width + X, num25 + Y + 1] = 2;
                  }
                }
                if (!flag7 && (anchorRight.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int) tileSafely1.type))
                  flag7 = true;
              }
              else if (!flag7 && (anchorRight.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
                flag7 = true;
              if (!flag7)
              {
                if (onlyCheck)
                  TileObject.objectPreview[width + X, num25 + Y] = 2;
              }
              else
              {
                if (onlyCheck)
                  TileObject.objectPreview[width + X, num25 + Y] = 1;
                ++num19;
              }
            }
          }
          AnchorData anchorLeft = tileData2.AnchorLeft;
          if (anchorLeft.tileCount != 0)
          {
            num20 += (float) anchorLeft.tileCount;
            int num26 = -1;
            for (int index = 0; index < anchorLeft.tileCount; ++index)
            {
              int num27 = anchorLeft.checkStart + index;
              Tile tileSafely4 = Framing.GetTileSafely(num7 + num26, num8 + num27);
              bool flag8 = false;
              if (tileSafely4.nactive())
              {
                if (Main.tileSolid[(int) tileSafely4.type] && !Main.tileSolidTop[(int) tileSafely4.type] && !Main.tileNoAttach[(int) tileSafely4.type] && (tileData2.FlattenAnchors || tileSafely4.blockType() == 0))
                  flag8 = tileData2.isValidTileAnchor((int) tileSafely4.type);
                if (!flag8 && (anchorLeft.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int) tileSafely4.type] && !Main.tileSolidTop[(int) tileSafely4.type])
                {
                  switch (tileSafely4.blockType())
                  {
                    case 3:
                    case 5:
                      flag8 = tileData2.isValidTileAnchor((int) tileSafely4.type);
                      break;
                  }
                }
                if (!flag8 && (anchorLeft.type & AnchorType.Tree) == AnchorType.Tree && tileSafely4.type == (ushort) 5)
                {
                  flag8 = true;
                  if (index == 0)
                  {
                    ++num20;
                    Tile tileSafely5 = Framing.GetTileSafely(num7 + num26, num8 + num27 - 1);
                    if (tileSafely5.nactive() && tileSafely5.type == (ushort) 5)
                    {
                      ++num19;
                      if (onlyCheck)
                        TileObject.objectPreview[num26 + X, num27 + Y - 1] = 1;
                    }
                    else if (onlyCheck)
                      TileObject.objectPreview[num26 + X, num27 + Y - 1] = 2;
                  }
                  if (index == anchorLeft.tileCount - 1)
                  {
                    ++num20;
                    Tile tileSafely6 = Framing.GetTileSafely(num7 + num26, num8 + num27 + 1);
                    if (tileSafely6.nactive() && tileSafely6.type == (ushort) 5)
                    {
                      ++num19;
                      if (onlyCheck)
                        TileObject.objectPreview[num26 + X, num27 + Y + 1] = 1;
                    }
                    else if (onlyCheck)
                      TileObject.objectPreview[num26 + X, num27 + Y + 1] = 2;
                  }
                }
                if (!flag8 && (anchorLeft.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int) tileSafely4.type))
                  flag8 = true;
              }
              else if (!flag8 && (anchorLeft.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
                flag8 = true;
              if (!flag8)
              {
                if (onlyCheck)
                  TileObject.objectPreview[num26 + X, num27 + Y] = 2;
              }
              else
              {
                if (onlyCheck)
                  TileObject.objectPreview[num26 + X, num27 + Y] = 1;
                ++num19;
              }
            }
          }
          if (tileData2.HookCheck.hook != null)
          {
            if (tileData2.HookCheck.processedCoordinates)
            {
              Point16 origin1 = tileData2.Origin;
              Point16 origin2 = tileData2.Origin;
            }
            if (tileData2.HookCheck.hook(x, y, type, style, dir) == tileData2.HookCheck.badReturn && tileData2.HookCheck.badResponse == 0)
            {
              num19 = 0.0f;
              num17 = 0.0f;
              TileObject.objectPreview.AllInvalid();
            }
          }
          float num28 = num19 / num20;
          float num29 = num17 / num18;
          if ((double) num29 == 1.0 && (double) num20 == 0.0)
          {
            num28 = 1f;
            num29 = 1f;
          }
          if ((double) num28 == 1.0 && (double) num29 == 1.0)
          {
            num4 = 1f;
            num5 = 1f;
            num6 = alternate;
            tileObjectData = tileData2;
            break;
          }
          if ((double) num28 > (double) num4 || (double) num28 == (double) num4 && (double) num29 > (double) num5)
          {
            TileObjectPreviewData.placementCache.CopyFrom(TileObject.objectPreview);
            num4 = num28;
            num5 = num29;
            tileObjectData = tileData2;
            num6 = alternate;
          }
        }
      }
      int num30 = -1;
      if (flag1)
      {
        if (TileObjectPreviewData.randomCache == null)
          TileObjectPreviewData.randomCache = new TileObjectPreviewData();
        bool flag9 = false;
        if ((int) TileObjectPreviewData.randomCache.Type == type)
        {
          Point16 coordinates = TileObjectPreviewData.randomCache.Coordinates;
          Point16 objectStart = TileObjectPreviewData.randomCache.ObjectStart;
          int num31 = (int) coordinates.X + (int) objectStart.X;
          int num32 = (int) coordinates.Y + (int) objectStart.Y;
          int num33 = x - (int) tileData1.Origin.X;
          int num34 = y - (int) tileData1.Origin.Y;
          if (num31 != num33 || num32 != num34)
            flag9 = true;
        }
        else
          flag9 = true;
        num30 = !flag9 ? TileObjectPreviewData.randomCache.Random : Main.rand.Next(tileData1.RandomStyleRange);
      }
      if (onlyCheck)
      {
        if ((double) num4 != 1.0 || (double) num5 != 1.0)
        {
          TileObject.objectPreview.CopyFrom(TileObjectPreviewData.placementCache);
          alternate = num6;
        }
        TileObject.objectPreview.Random = num30;
        if (tileData1.RandomStyleRange > 0)
          TileObjectPreviewData.randomCache.CopyFrom(TileObject.objectPreview);
      }
      if (!onlyCheck)
      {
        objectData.xCoord = x - (int) tileObjectData.Origin.X;
        objectData.yCoord = y - (int) tileObjectData.Origin.Y;
        objectData.type = type;
        objectData.style = style;
        objectData.alternate = alternate;
        objectData.random = num30;
      }
      return (double) num4 == 1.0 && (double) num5 == 1.0;
    }

    public static void DrawPreview(SpriteBatch sb, TileObjectPreviewData op, Vector2 position)
    {
      Point16 coordinates = op.Coordinates;
      Texture2D texture = Main.tileTexture[(int) op.Type];
      TileObjectData tileData = TileObjectData.GetTileData((int) op.Type, (int) op.Style, op.Alternate);
      int placementStyle = tileData.CalculatePlacementStyle((int) op.Style, op.Alternate, op.Random);
      int num1 = 0;
      int drawYoffset = tileData.DrawYOffset;
      if (tileData.StyleWrapLimit > 0)
      {
        num1 = placementStyle / tileData.StyleWrapLimit * tileData.StyleLineSkip;
        placementStyle %= tileData.StyleWrapLimit;
      }
      int num2;
      int num3;
      if (tileData.StyleHorizontal)
      {
        num2 = tileData.CoordinateFullWidth * placementStyle;
        num3 = tileData.CoordinateFullHeight * num1;
      }
      else
      {
        num2 = tileData.CoordinateFullWidth * num1;
        num3 = tileData.CoordinateFullHeight * placementStyle;
      }
      for (int x1 = 0; x1 < (int) op.Size.X; ++x1)
      {
        int x2 = num2 + (x1 - (int) op.ObjectStart.X) * (tileData.CoordinateWidth + tileData.CoordinatePadding);
        int y1 = num3;
        for (int y2 = 0; y2 < (int) op.Size.Y; ++y2)
        {
          int i = (int) coordinates.X + x1;
          int num4 = (int) coordinates.Y + y2;
          if (y2 == 0 && tileData.DrawStepDown != 0 && WorldGen.SolidTile(Framing.GetTileSafely(i, num4 - 1)))
            drawYoffset += tileData.DrawStepDown;
          Color color1;
          switch (op[x1, y2])
          {
            case 1:
              color1 = Color.White;
              break;
            case 2:
              color1 = Color.Red * 0.7f;
              break;
            default:
              continue;
          }
          Color color2 = color1 * 0.5f;
          if (x1 >= (int) op.ObjectStart.X && x1 < (int) op.ObjectStart.X + tileData.Width && y2 >= (int) op.ObjectStart.Y && y2 < (int) op.ObjectStart.Y + tileData.Height)
          {
            SpriteEffects effects = SpriteEffects.None;
            if (tileData.DrawFlipHorizontal && x1 % 2 == 1)
              effects |= SpriteEffects.FlipHorizontally;
            if (tileData.DrawFlipVertical && y2 % 2 == 1)
              effects |= SpriteEffects.FlipVertically;
            Rectangle rectangle = new Rectangle(x2, y1, tileData.CoordinateWidth, tileData.CoordinateHeights[y2 - (int) op.ObjectStart.Y]);
            sb.Draw(texture, new Vector2((float) (i * 16 - (int) ((double) position.X + (double) (tileData.CoordinateWidth - 16) / 2.0)), (float) (num4 * 16 - (int) position.Y + drawYoffset)), new Rectangle?(rectangle), color2, 0.0f, Vector2.Zero, 1f, effects, 0.0f);
            y1 += tileData.CoordinateHeights[y2 - (int) op.ObjectStart.Y] + tileData.CoordinatePadding;
          }
        }
      }
    }
  }
}
