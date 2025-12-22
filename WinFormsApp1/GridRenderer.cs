using System.Drawing;

namespace WinFormsApp1;

public static class GridRenderer
{
    public static void Draw(Graphics g, Point origin)
    {
        using var pen = new Pen(Color.FromArgb(40, 40, 52));
        for (var x = 0; x <= GameConfig.FieldWidth; x++)
        {
            var px = origin.X + x * GameConfig.CellSize;
            g.DrawLine(pen, px, origin.Y, px, origin.Y + GameConfig.FieldHeight * GameConfig.CellSize);
        }

        for (var y = 0; y <= GameConfig.FieldHeight; y++)
        {
            var py = origin.Y + y * GameConfig.CellSize;
            g.DrawLine(pen, origin.X, py, origin.X + GameConfig.FieldWidth * GameConfig.CellSize, py);
        }
    }
}
