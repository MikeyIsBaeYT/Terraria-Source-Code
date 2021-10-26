// Decompiled with JetBrains decompiler
// Type: Terraria.UI.InGameNotificationsTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.GameInput;
using Terraria.Social;
using Terraria.Social.Base;

namespace Terraria.UI
{
  public class InGameNotificationsTracker
  {
    private static List<IInGameNotification> _notifications = new List<IInGameNotification>();

    public static void Initialize()
    {
      Main.Achievements.OnAchievementCompleted += new Achievement.AchievementCompleted(InGameNotificationsTracker.AddCompleted);
      SocialAPI.JoinRequests.OnRequestAdded += new ServerJoinRequestEvent(InGameNotificationsTracker.JoinRequests_OnRequestAdded);
      SocialAPI.JoinRequests.OnRequestRemoved += new ServerJoinRequestEvent(InGameNotificationsTracker.JoinRequests_OnRequestRemoved);
    }

    private static void JoinRequests_OnRequestAdded(UserJoinToServerRequest request) => InGameNotificationsTracker.AddJoinRequest(request);

    private static void JoinRequests_OnRequestRemoved(UserJoinToServerRequest request)
    {
      for (int index = InGameNotificationsTracker._notifications.Count - 1; index >= 0; --index)
      {
        if (InGameNotificationsTracker._notifications[index].CreationObject == request)
          InGameNotificationsTracker._notifications.RemoveAt(index);
      }
    }

    public static void DrawInGame(SpriteBatch sb)
    {
      float y = (float) (Main.screenHeight - 40);
      if (PlayerInput.UsingGamepad)
        y -= 25f;
      Vector2 positionAnchorBottom = new Vector2((float) (Main.screenWidth / 2), y);
      foreach (IInGameNotification notification in InGameNotificationsTracker._notifications)
      {
        notification.DrawInGame(sb, positionAnchorBottom);
        notification.PushAnchor(ref positionAnchorBottom);
        if ((double) positionAnchorBottom.Y < -100.0)
          break;
      }
    }

    public static void DrawInIngameOptions(
      SpriteBatch spriteBatch,
      Rectangle area,
      ref int gamepadPointIdLocalIndexToUse)
    {
      int num1 = 4;
      int height = area.Height / 5 - num1;
      Rectangle area1 = new Rectangle(area.X, area.Y, area.Width - 6, height);
      int num2 = 0;
      foreach (IInGameNotification notification in InGameNotificationsTracker._notifications)
      {
        notification.DrawInNotificationsArea(spriteBatch, area1, ref gamepadPointIdLocalIndexToUse);
        area1.Y += height + num1;
        ++num2;
        if (num2 >= 5)
          break;
      }
    }

    public static void AddCompleted(Achievement achievement)
    {
      if (Main.netMode == 2)
        return;
      InGameNotificationsTracker._notifications.Add((IInGameNotification) new InGamePopups.AchievementUnlockedPopup(achievement));
    }

    public static void AddJoinRequest(UserJoinToServerRequest request)
    {
      if (Main.netMode == 2)
        return;
      InGameNotificationsTracker._notifications.Add((IInGameNotification) new InGamePopups.PlayerWantsToJoinGamePopup(request));
    }

    public static void Clear() => InGameNotificationsTracker._notifications.Clear();

    public static void Update()
    {
      for (int index = 0; index < InGameNotificationsTracker._notifications.Count; ++index)
      {
        InGameNotificationsTracker._notifications[index].Update();
        if (InGameNotificationsTracker._notifications[index].ShouldBeRemoved)
        {
          InGameNotificationsTracker._notifications.Remove(InGameNotificationsTracker._notifications[index]);
          --index;
        }
      }
    }
  }
}
