using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp1;

public static class GameRenderer
{
    public static void Draw(Graphics g, GameState state)
    {
        g.SmoothingMode = SmoothingMode.None;
        g.Clear(Color.FromArgb(18, 18, 24));
        var origin = new Point(GameConfig.MarginSize, GameConfig.MarginSize);
        var fieldRect = LayoutHelper.GetFieldRect(origin);
        using var fieldBrush = new SolidBrush(Color.FromArgb(30, 30, 40));
        g.FillRectangle(fieldBrush, fieldRect);
        PlacedRenderer.Draw(g, state, origin);
        ActivePieceRenderer.DrawGhost(g, state, origin);
        ActivePieceRenderer.DrawCurrent(g, state, origin);
        GridRenderer.Draw(g, origin);
        SidePanelRenderer.Draw(g, state, fieldRect.Right + GameConfig.MarginSize, origin.Y);
        OverlayRenderer.Draw(g, state, fieldRect);
    }
}
