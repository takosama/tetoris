using System.Drawing;

namespace WinFormsApp1;

public static class MiniPieceRenderer
{
    public static void Draw(Graphics g, int x, int y, int type)
    {
        foreach (var p in TetrominoData.Cells(type, 0))
        {
            var rect = new Rectangle(
                x + p.X * GameConfig.CellSize / 2,
                y + p.Y * GameConfig.CellSize / 2,
                GameConfig.CellSize / 2,
                GameConfig.CellSize / 2);
            using var brush = new SolidBrush(TetrominoData.Colors[type]);
            g.FillRectangle(brush, rect);
            g.DrawRectangle(Pens.Black, rect);
        }
    }
}
