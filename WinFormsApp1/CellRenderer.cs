using System.Drawing;

namespace WinFormsApp1;

public static class CellRenderer
{
    public static void Draw(Graphics g, Point origin, int x, int y, Color color, bool outline)
    {
        if (y < 0)
        {
            return;
        }

        var rect = new Rectangle(
            origin.X + x * GameConfig.CellSize,
            origin.Y + y * GameConfig.CellSize,
            GameConfig.CellSize,
            GameConfig.CellSize);
        using var brush = new SolidBrush(color);
        g.FillRectangle(brush, rect);
        if (outline)
        {
            g.DrawRectangle(Pens.Black, rect);
        }
    }
}
