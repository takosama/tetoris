using System.Drawing;

namespace WinFormsApp1;

public static class PlacedRenderer
{
    public static void Draw(Graphics g, GameState state, Point origin)
    {
        for (var y = 0; y < GameConfig.FieldHeight; y++)
        {
            for (var x = 0; x < GameConfig.FieldWidth; x++)
            {
                var type = state.Field[x, y];
                if (type != 0)
                {
                    CellRenderer.Draw(g, origin, x, y, TetrominoData.Colors[type - 1], true);
                }
            }
        }
    }
}
