using System.Drawing;

namespace WinFormsApp1;

public static class PieceMovement
{
    public static bool TryMove(GameState state, int dx, int dy)
    {
        var nx = state.CurrentX + dx;
        var ny = state.CurrentY + dy;
        if (Collision.Hits(state, state.CurrentType, state.CurrentRotation, nx, ny))
        {
            return false;
        }

        state.CurrentX = nx;
        state.CurrentY = ny;
        return true;
    }

    public static void TryRotate(GameState state, int direction)
    {
        var newRotation = (state.CurrentRotation + direction + 4) % 4;
        var kicks = new[] { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(2, 0), new Point(-2, 0), new Point(0, -1) };
        foreach (var kick in kicks)
        {
            if (!Collision.Hits(state, state.CurrentType, newRotation, state.CurrentX + kick.X, state.CurrentY + kick.Y))
            {
                state.CurrentX += kick.X;
                state.CurrentY += kick.Y;
                state.CurrentRotation = newRotation;
                return;
            }
        }
    }
}
