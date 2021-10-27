// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemTooltip
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.UI
{
  public class ItemTooltip
  {
    public static readonly ItemTooltip None = new ItemTooltip();
    private static List<TooltipProcessor> _globalProcessors = new List<TooltipProcessor>();
    private string[] _tooltipLines;
    private GameCulture _lastCulture;
    private LocalizedText _text;
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
      if (this._lastCulture == Language.ActiveCulture)
        return;
      this._lastCulture = Language.ActiveCulture;
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
  }
}
