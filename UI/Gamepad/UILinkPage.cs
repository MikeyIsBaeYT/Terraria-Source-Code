// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.UILinkPage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria.UI.Gamepad
{
  public class UILinkPage
  {
    public int ID;
    public int PageOnLeft = -1;
    public int PageOnRight = -1;
    public int DefaultPoint;
    public int CurrentPoint;
    public Dictionary<int, UILinkPoint> LinkMap = new Dictionary<int, UILinkPoint>();

    public event Action<int, int> ReachEndEvent;

    public event Action TravelEvent;

    public event Action LeaveEvent;

    public event Action EnterEvent;

    public event Action UpdateEvent;

    public event Func<bool> IsValidEvent;

    public event Func<bool> CanEnterEvent;

    public event Action<int> OnPageMoveAttempt;

    public UILinkPage()
    {
    }

    public UILinkPage(int id) => this.ID = id;

    public void Update()
    {
      if (this.UpdateEvent == null)
        return;
      this.UpdateEvent();
    }

    public void Leave()
    {
      if (this.LeaveEvent == null)
        return;
      this.LeaveEvent();
    }

    public void Enter()
    {
      if (this.EnterEvent == null)
        return;
      this.EnterEvent();
    }

    public bool IsValid() => this.IsValidEvent == null || this.IsValidEvent();

    public bool CanEnter() => this.CanEnterEvent == null || this.CanEnterEvent();

    public void TravelUp() => this.Travel(this.LinkMap[this.CurrentPoint].Up);

    public void TravelDown() => this.Travel(this.LinkMap[this.CurrentPoint].Down);

    public void TravelLeft() => this.Travel(this.LinkMap[this.CurrentPoint].Left);

    public void TravelRight() => this.Travel(this.LinkMap[this.CurrentPoint].Right);

    public void SwapPageLeft()
    {
      if (this.OnPageMoveAttempt != null)
        this.OnPageMoveAttempt(-1);
      UILinkPointNavigator.ChangePage(this.PageOnLeft);
    }

    public void SwapPageRight()
    {
      if (this.OnPageMoveAttempt != null)
        this.OnPageMoveAttempt(1);
      UILinkPointNavigator.ChangePage(this.PageOnRight);
    }

    private void Travel(int next)
    {
      if (next < 0)
      {
        if (this.ReachEndEvent == null)
          return;
        this.ReachEndEvent(this.CurrentPoint, next);
        if (this.TravelEvent == null)
          return;
        this.TravelEvent();
      }
      else
      {
        UILinkPointNavigator.ChangePoint(next);
        if (this.TravelEvent == null)
          return;
        this.TravelEvent();
      }
    }

    public event Func<string> OnSpecialInteracts;

    public string SpecialInteractions() => this.OnSpecialInteracts != null ? this.OnSpecialInteracts() : string.Empty;
  }
}
