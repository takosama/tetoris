using System.Drawing;

namespace WinFormsApp1;

public static class ActivePieceRenderer
{
    public static void DrawCurrent(Graphics g, GameState state, Point origin)
    {
        if (state.GameOver)
        {
            return;
        }

        foreach (var p in TetrominoData.Cells(state.CurrentType, state.CurrentRotation))
        {
            CellRenderer.Draw(g, origin, state.CurrentX + p.X, state.CurrentY + p.Y, TetrominoData.Colors[state.CurrentType], true);
        }
    }

    public static void DrawGhost(Graphics g, GameState state, Point origin)
    {
        if (state.GameOver)
        {
            return;
        }

        var ghostY = state.CurrentY;
        while (!Collision.Hits(state, state.CurrentType, state.CurrentRotation, state.CurrentX, ghostY + 1))
        {
            ghostY++;
        }

        foreach (var p in TetrominoData.Cells(state.CurrentType, state.CurrentRotation))
        {
            CellRenderer.Draw(
                g,
                origin,
                state.CurrentX + p.X,
                ghostY + p.Y,
                Color.FromArgb(90, TetrominoData.Colors[state.CurrentType]),
                false);
        }
    }
}
