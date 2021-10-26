// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemTooltip
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.UI
{
  public class ItemTooltip
  {
    public static readonly ItemTooltip None = new ItemTooltip();
    private static readonly List<TooltipProcessor> _globalProcessors = new List<TooltipProcessor>();
    private static ulong _globalValidatorKey = 1;
    private string[] _tooltipLines;
    private ulong _validatorKey;
    private readonly LocalizedText _text;
    private string _processedText;

    public int Lines
    {
      get
      {
        this.ValidateTooltip();
        return this._tooltipLines == null ? 0 : this._tooltipLines.Length;
      }
    }

    private ItemTooltip()
    {
    }

    private ItemTooltip(string key) => this._text = Language.GetText(key);

    public static ItemTooltip FromLanguageKey(string key) => !Language.Exists(key) ? ItemTooltip.None : new ItemTooltip(key);

    public string GetLine(int line)
    {
      this.ValidateTooltip();
      return this._tooltipLines[line];
    }

    private void ValidateTooltip()
    {
      if ((long) this._validatorKey == (long) ItemTooltip._globalValidatorKey)
        return;
      this._validatorKey = ItemTooltip._globalValidatorKey;
      if (this._text == null)
      {
        this._tooltipLines = (string[]) null;
        this._processedText = string.Empty;
      }
      else
      {
        string tooltip = this._text.Value;
        foreach (TooltipProcessor globalProcessor in ItemTooltip._globalProcessors)
          tooltip = globalProcessor(tooltip);
        this._tooltipLines = tooltip.Split('\n');
        this._processedText = tooltip;
      }
    }

    public static void AddGlobalProcessor(TooltipProcessor processor) => ItemTooltip._globalProcessors.Add(processor);

    public static void RemoveGlobalProcessor(TooltipProcessor processor) => ItemTooltip._globalProcessors.Remove(processor);

    public static void ClearGlobalProcessors() => ItemTooltip._globalProcessors.Clear();

    public static void InvalidateTooltips()
    {
      ++ItemTooltip._globalValidatorKey;
      if (ItemTooltip._globalValidatorKey != ulong.MaxValue)
        return;
      ItemTooltip._globalValidatorKey = 0UL;
    }
  }
}
