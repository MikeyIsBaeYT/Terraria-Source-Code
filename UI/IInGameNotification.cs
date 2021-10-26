// Decompiled with JetBrains decompiler
// Type: Terraria.UI.IInGameNotification
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.UI
{
  public interface IInGameNotification
  {
    object CreationObject { get; }

    bool ShouldBeRemoved { get; }

    void Update();

    void DrawInGame(SpriteBatch spriteBatch, Vector2 bottomAnchorPosition);

    void PushAnchor(ref Vector2 positionAnchorBottom);

    void DrawInNotificationsArea(
      SpriteBatch spriteBatch,
      Rectangle area,
      ref int gamepadPointLocalIndexTouse);
  }
}
