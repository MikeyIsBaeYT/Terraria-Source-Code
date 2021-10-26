// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCStatsReportInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class NPCStatsReportInfoElement : IBestiaryInfoElement
  {
    public int NpcId;
    public int GameMode;
    public int Damage;
    public int LifeMax;
    public float MonetaryValue;
    public int Defense;
    public float KnockbackResist;

    public NPCStatsReportInfoElement(int npcNetId, int gameMode)
    {
      this.NpcId = npcNetId;
      this.GameMode = gameMode;
      if (!Main.RegisterdGameModes.TryGetValue(this.GameMode, out GameModeData _))
        return;
      NPC npc = new NPC();
      npc.SetDefaults(this.NpcId);
      this.Damage = npc.damage;
      this.LifeMax = npc.lifeMax;
      this.MonetaryValue = npc.value;
      this.Defense = npc.defense;
      this.KnockbackResist = npc.knockBackResist;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info)
    {
      if (info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0)
        return (UIElement) null;
      if (this.GameMode != Main.GameMode)
        return (UIElement) null;
      UIElement uiElement = new UIElement()
      {
        Width = new StyleDimension(0.0f, 1f),
        Height = new StyleDimension(109f, 0.0f)
      };
      int num1 = 99;
      int num2 = 35;
      int num3 = 3;
      int num4 = 0;
      UIImage uiImage1 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_HP", (AssetRequestMode) 1));
      uiImage1.Top = new StyleDimension((float) num4, 0.0f);
      uiImage1.Left = new StyleDimension((float) num3, 0.0f);
      UIImage uiImage2 = uiImage1;
      UIImage uiImage3 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Attack", (AssetRequestMode) 1));
      uiImage3.Top = new StyleDimension((float) (num4 + num2), 0.0f);
      uiImage3.Left = new StyleDimension((float) num3, 0.0f);
      UIImage uiImage4 = uiImage3;
      UIImage uiImage5 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Defense", (AssetRequestMode) 1));
      uiImage5.Top = new StyleDimension((float) (num4 + num2), 0.0f);
      uiImage5.Left = new StyleDimension((float) (num3 + num1), 0.0f);
      UIImage uiImage6 = uiImage5;
      UIImage uiImage7 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Knockback", (AssetRequestMode) 1));
      uiImage7.Top = new StyleDimension((float) num4, 0.0f);
      uiImage7.Left = new StyleDimension((float) (num3 + num1), 0.0f);
      UIImage uiImage8 = uiImage7;
      uiElement.Append((UIElement) uiImage2);
      uiElement.Append((UIElement) uiImage4);
      uiElement.Append((UIElement) uiImage6);
      uiElement.Append((UIElement) uiImage8);
      int num5 = -10;
      int num6 = 0;
      int monetaryValue = (int) this.MonetaryValue;
      string text1 = Utils.Clamp<int>(monetaryValue / 1000000, 0, 999).ToString();
      string text2 = Utils.Clamp<int>(monetaryValue % 1000000 / 10000, 0, 99).ToString();
      string text3 = Utils.Clamp<int>(monetaryValue % 10000 / 100, 0, 99).ToString();
      string text4 = Utils.Clamp<int>(monetaryValue % 100 / 1, 0, 99).ToString();
      if (monetaryValue / 1000000 < 1)
        text1 = "-";
      if (monetaryValue / 10000 < 1)
        text2 = "-";
      if (monetaryValue / 100 < 1)
        text3 = "-";
      if (monetaryValue < 1)
        text4 = "-";
      string text5 = this.LifeMax.ToString();
      string text6 = this.Damage.ToString();
      string text7 = this.Defense.ToString();
      string text8 = (double) this.KnockbackResist <= 0.800000011920929 ? ((double) this.KnockbackResist <= 0.400000005960464 ? ((double) this.KnockbackResist <= 0.0 ? Language.GetText("BestiaryInfo.KnockbackNone").Value : Language.GetText("BestiaryInfo.KnockbackLow").Value) : Language.GetText("BestiaryInfo.KnockbackMedium").Value) : Language.GetText("BestiaryInfo.KnockbackHigh").Value;
      if (info.UnlockState < BestiaryEntryUnlockState.CanShowStats_2)
      {
        string str1;
        text4 = str1 = "?";
        text3 = str1;
        text2 = str1;
        text1 = str1;
        string str2;
        text8 = str2 = "???";
        text7 = str2;
        text6 = str2;
        text5 = str2;
      }
      UIText uiText1 = new UIText(text5);
      uiText1.HAlign = 1f;
      uiText1.VAlign = 0.5f;
      uiText1.Left = new StyleDimension((float) num5, 0.0f);
      uiText1.Top = new StyleDimension((float) num6, 0.0f);
      uiText1.IgnoresMouseInteraction = true;
      UIText uiText2 = uiText1;
      UIText uiText3 = new UIText(text8);
      uiText3.HAlign = 1f;
      uiText3.VAlign = 0.5f;
      uiText3.Left = new StyleDimension((float) num5, 0.0f);
      uiText3.Top = new StyleDimension((float) num6, 0.0f);
      uiText3.IgnoresMouseInteraction = true;
      UIText uiText4 = uiText3;
      UIText uiText5 = new UIText(text6);
      uiText5.HAlign = 1f;
      uiText5.VAlign = 0.5f;
      uiText5.Left = new StyleDimension((float) num5, 0.0f);
      uiText5.Top = new StyleDimension((float) num6, 0.0f);
      uiText5.IgnoresMouseInteraction = true;
      UIText uiText6 = uiText5;
      UIText uiText7 = new UIText(text7);
      uiText7.HAlign = 1f;
      uiText7.VAlign = 0.5f;
      uiText7.Left = new StyleDimension((float) num5, 0.0f);
      uiText7.Top = new StyleDimension((float) num6, 0.0f);
      uiText7.IgnoresMouseInteraction = true;
      UIText uiText8 = uiText7;
      uiImage2.Append((UIElement) uiText2);
      uiImage4.Append((UIElement) uiText6);
      uiImage6.Append((UIElement) uiText8);
      uiImage8.Append((UIElement) uiText4);
      if (monetaryValue > 0)
      {
        UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
        horizontalSeparator1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
        horizontalSeparator1.Color = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
        horizontalSeparator1.Left = new StyleDimension(0.0f, 0.0f);
        horizontalSeparator1.Top = new StyleDimension((float) (num6 + num2 * 2), 0.0f);
        UIHorizontalSeparator horizontalSeparator2 = horizontalSeparator1;
        uiElement.Append((UIElement) horizontalSeparator2);
        int num7 = num3;
        int num8 = num6 + num2 * 2 + 8;
        int num9 = 49;
        UIImage uiImage9 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Platinum", (AssetRequestMode) 1));
        uiImage9.Top = new StyleDimension((float) num8, 0.0f);
        uiImage9.Left = new StyleDimension((float) num7, 0.0f);
        UIImage uiImage10 = uiImage9;
        UIImage uiImage11 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Gold", (AssetRequestMode) 1));
        uiImage11.Top = new StyleDimension((float) num8, 0.0f);
        uiImage11.Left = new StyleDimension((float) (num7 + num9), 0.0f);
        UIImage uiImage12 = uiImage11;
        UIImage uiImage13 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Silver", (AssetRequestMode) 1));
        uiImage13.Top = new StyleDimension((float) num8, 0.0f);
        uiImage13.Left = new StyleDimension((float) (num7 + num9 * 2 + 1), 0.0f);
        UIImage uiImage14 = uiImage13;
        UIImage uiImage15 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Copper", (AssetRequestMode) 1));
        uiImage15.Top = new StyleDimension((float) num8, 0.0f);
        uiImage15.Left = new StyleDimension((float) (num7 + num9 * 3 + 1), 0.0f);
        UIImage uiImage16 = uiImage15;
        if (text1 != "-")
          uiElement.Append((UIElement) uiImage10);
        if (text2 != "-")
          uiElement.Append((UIElement) uiImage12);
        if (text3 != "-")
          uiElement.Append((UIElement) uiImage14);
        if (text4 != "-")
          uiElement.Append((UIElement) uiImage16);
        int num10 = num5 + 3;
        float textScale = 0.85f;
        UIText uiText9 = new UIText(text1, textScale);
        uiText9.HAlign = 1f;
        uiText9.VAlign = 0.5f;
        uiText9.Left = new StyleDimension((float) num10, 0.0f);
        uiText9.Top = new StyleDimension((float) num6, 0.0f);
        UIText uiText10 = uiText9;
        UIText uiText11 = new UIText(text2, textScale);
        uiText11.HAlign = 1f;
        uiText11.VAlign = 0.5f;
        uiText11.Left = new StyleDimension((float) num10, 0.0f);
        uiText11.Top = new StyleDimension((float) num6, 0.0f);
        UIText uiText12 = uiText11;
        UIText uiText13 = new UIText(text3, textScale);
        uiText13.HAlign = 1f;
        uiText13.VAlign = 0.5f;
        uiText13.Left = new StyleDimension((float) num10, 0.0f);
        uiText13.Top = new StyleDimension((float) num6, 0.0f);
        UIText uiText14 = uiText13;
        UIText uiText15 = new UIText(text4, textScale);
        uiText15.HAlign = 1f;
        uiText15.VAlign = 0.5f;
        uiText15.Left = new StyleDimension((float) num10, 0.0f);
        uiText15.Top = new StyleDimension((float) num6, 0.0f);
        UIText uiText16 = uiText15;
        uiImage10.Append((UIElement) uiText10);
        uiImage12.Append((UIElement) uiText12);
        uiImage14.Append((UIElement) uiText14);
        uiImage16.Append((UIElement) uiText16);
      }
      else
        uiElement.Height.Pixels = (float) (num6 + num2 * 2 - 4);
      uiImage4.OnUpdate += new UIElement.ElementEvent(this.ShowStats_Attack);
      uiImage6.OnUpdate += new UIElement.ElementEvent(this.ShowStats_Defense);
      uiImage2.OnUpdate += new UIElement.ElementEvent(this.ShowStats_Life);
      uiImage8.OnUpdate += new UIElement.ElementEvent(this.ShowStats_Knockback);
      return uiElement;
    }

    private void ShowStats_Attack(UIElement element)
    {
      if (!element.IsMouseHovering)
        return;
      Main.instance.MouseText(Language.GetTextValue("BestiaryInfo.Attack"));
    }

    private void ShowStats_Defense(UIElement element)
    {
      if (!element.IsMouseHovering)
        return;
      Main.instance.MouseText(Language.GetTextValue("BestiaryInfo.Defense"));
    }

    private void ShowStats_Knockback(UIElement element)
    {
      if (!element.IsMouseHovering)
        return;
      Main.instance.MouseText(Language.GetTextValue("BestiaryInfo.Knockback"));
    }

    private void ShowStats_Life(UIElement element)
    {
      if (!element.IsMouseHovering)
        return;
      Main.instance.MouseText(Language.GetTextValue("BestiaryInfo.Life"));
    }
  }
}
