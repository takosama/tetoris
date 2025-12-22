namespace WinFormsApp1;

public static class InputHandler
{
    public static void Handle(GameState state, Random rng, Keys key)
    {
        if (key == Keys.P) { state.Paused = !state.Paused; return; }
        if (key == Keys.R || (state.GameOver && (key == Keys.Enter || key == Keys.Space))) { GameReset.Reset(state, rng); return; }
        if (state.WaitingToStart)
        {
            if (key == Keys.Enter || key == Keys.Space) { state.WaitingToStart = false; state.DropAccumulatorMs = 0; }
            return;
        }
        if (state.Paused || state.GameOver) return;
        switch (key)
        {
            case Keys.Left: PieceMovement.TryMove(state, -1, 0); break;
            case Keys.Right: PieceMovement.TryMove(state, 1, 0); break;
            case Keys.Down:
                if (PieceMovement.TryMove(state, 0, 1)) state.Score += 1;
                state.DropAccumulatorMs = 0;
                break;
            case Keys.Up: PieceMovement.TryRotate(state, 1); break;
            case Keys.Z: PieceMovement.TryRotate(state, -1); break;
            case Keys.Space: PieceSpecials.HardDrop(state, rng); break;
            case Keys.C: PieceSpecials.Hold(state, rng); break;
        }
    }
}
