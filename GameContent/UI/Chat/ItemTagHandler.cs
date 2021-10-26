// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.ItemTagHandler
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class ItemTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(
      string text,
      Color baseColor,
      string options)
    {
      Item obj = new Item();
      int result1;
      if (int.TryParse(text, out result1))
        obj.netDefaults(result1);
      if (obj.type <= 0)
        return new TextSnippet(text);
      obj.stack = 1;
      if (options != null)
      {
        string[] strArray = options.Split(',');
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (strArray[index].Length != 0)
          {
            switch (strArray[index][0])
            {
              case 'p':
                int result2;
                if (int.TryParse(strArray[index].Substring(1), out result2))
                {
                  obj.Prefix((int) (byte) Utils.Clamp<int>(result2, 0, 85));
                  continue;
                }
                continue;
              case 's':
              case 'x':
                int result3;
                if (int.TryParse(strArray[index].Substring(1), out result3))
                {
                  obj.stack = Utils.Clamp<int>(result3, 1, obj.maxStack);
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
        }
      }
      string str = "";
      if (obj.stack > 1)
        str = " (" + (object) obj.stack + ")";
      ItemTagHandler.ItemSnippet itemSnippet = new ItemTagHandler.ItemSnippet(obj);
      itemSnippet.Text = "[" + obj.AffixName() + str + "]";
      itemSnippet.CheckForHover = true;
      itemSnippet.DeleteWhole = true;
      return (TextSnippet) itemSnippet;
    }

    public static string GenerateTag(Item I)
    {
      string str = "[i";
      if (I.prefix != (byte) 0)
        str = str + "/p" + (object) I.prefix;
      if (I.stack != 1)
        str = str + "/s" + (object) I.stack;
      return str + ":" + (object) I.netID + "]";
    }

    private class ItemSnippet : TextSnippet
    {
      private Item _item;

      public ItemSnippet(Item item)
        : base()
      {
        this._item = item;
        this.Color = ItemRarity.GetColor(item.rare);
      }

      public override void OnHover()
      {
        Main.HoverItem = this._item.Clone();
        Main.instance.MouseText(this._item.Name, this._item.rare);
      }

      public override bool UniqueDraw(
        bool justCheckingString,
        out Vector2 size,
        SpriteBatch spriteBatch,
        Vector2 position = default (Vector2),
        Color color = default (Color),
        float scale = 1f)
      {
        float num1 = 1f;
        float num2 = 1f;
        if (Main.netMode != 2 && !Main.dedServ)
        {
          Main.instance.LoadItem(this._item.type);
          Texture2D texture2D = TextureAssets.Item[this._item.type].Value;
          Rectangle rectangle = Main.itemAnimations[this._item.type] == null ? texture2D.Frame() : Main.itemAnimations[this._item.type].GetFrame(texture2D);
          if (rectangle.Height > 32)
            num2 = 32f / (float) rectangle.Height;
        }
        float num3 = num2 * scale;
        float num4 = num1 * num3;
        if ((double) num4 > 0.75)
          num4 = 0.75f;
        if (!justCheckingString && color != Color.Black)
        {
          double inventoryScale = (double) Main.inventoryScale;
          Main.inventoryScale = scale * num4;
          ItemSlot.Draw(spriteBatch, ref this._item, 14, position - new Vector2(10f) * scale * num4, Color.White);
          Main.inventoryScale = (float) inventoryScale;
        }
        size = new Vector2(32f) * scale * num4;
        return true;
      }

      public override float GetStringLength(DynamicSpriteFont font) => (float) (32.0 * (double) this.Scale * 0.649999976158142);
    }
  }
}
