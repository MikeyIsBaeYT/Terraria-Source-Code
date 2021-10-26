// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.EmotesGroupListItem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class EmotesGroupListItem : UIElement
  {
    private const int TITLE_HEIGHT = 20;
    private const int SEPARATOR_HEIGHT = 10;
    private const int SIZE_PER_EMOTE = 36;
    private Asset<Texture2D> _tempTex;
    private int _groupIndex;
    private int _maxEmotesPerRow = 10;

    public EmotesGroupListItem(
      LocalizedText groupTitle,
      int groupIndex,
      int maxEmotesPerRow,
      params int[] emotes)
    {
      maxEmotesPerRow = 14;
      this.SetPadding(0.0f);
      this._groupIndex = groupIndex;
      this._maxEmotesPerRow = maxEmotesPerRow;
      this._tempTex = Main.Assets.Request<Texture2D>("Images/UI/ButtonFavoriteInactive", (AssetRequestMode) 1);
      int num1 = emotes.Length / this._maxEmotesPerRow;
      if (emotes.Length % this._maxEmotesPerRow != 0)
        ++num1;
      this.Height.Set((float) (30 + 36 * num1), 0.0f);
      this.Width.Set(0.0f, 1f);
      UIElement element = new UIElement()
      {
        Height = StyleDimension.FromPixels(30f),
        Width = StyleDimension.FromPixelsAndPercent(-20f, 1f),
        HAlign = 0.5f
      };
      element.SetPadding(0.0f);
      this.Append(element);
      UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
      horizontalSeparator1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      horizontalSeparator1.VAlign = 1f;
      horizontalSeparator1.HAlign = 0.5f;
      horizontalSeparator1.Color = Color.Lerp(Color.White, new Color(63, 65, 151, (int) byte.MaxValue), 0.85f) * 0.9f;
      UIHorizontalSeparator horizontalSeparator2 = horizontalSeparator1;
      element.Append((UIElement) horizontalSeparator2);
      UIText uiText1 = new UIText(groupTitle);
      uiText1.VAlign = 1f;
      uiText1.HAlign = 0.5f;
      uiText1.Top = StyleDimension.FromPixels(-6f);
      UIText uiText2 = uiText1;
      element.Append((UIElement) uiText2);
      float num2 = 6f;
      for (int id = 0; id < emotes.Length; ++id)
      {
        int emote = emotes[id];
        int num3 = id / this._maxEmotesPerRow;
        int num4 = id % this._maxEmotesPerRow;
        int num5 = emotes.Length % this._maxEmotesPerRow;
        if (emotes.Length / this._maxEmotesPerRow != num3)
          num5 = this._maxEmotesPerRow;
        if (num5 == 0)
          num5 = this._maxEmotesPerRow;
        float num6 = (float) (36.0 * ((double) num5 / 2.0)) - 16f;
        float num7 = -16f;
        EmoteButton emoteButton1 = new EmoteButton(emote);
        emoteButton1.HAlign = 0.0f;
        emoteButton1.VAlign = 0.0f;
        emoteButton1.Top = StyleDimension.FromPixels((float) (30 + num3 * 36) + num2);
        emoteButton1.Left = StyleDimension.FromPixels((float) (36 * num4) - num7);
        EmoteButton emoteButton2 = emoteButton1;
        this.Append((UIElement) emoteButton2);
        emoteButton2.SetSnapPoint("Group " + (object) groupIndex, id);
      }
    }

    public override int CompareTo(object obj) => obj is EmotesGroupListItem emotesGroupListItem ? this._groupIndex.CompareTo(emotesGroupListItem._groupIndex) : base.CompareTo(obj);
  }
}
