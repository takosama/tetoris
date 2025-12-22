namespace WinFormsApp1;

public static class PieceLock
{
    public static void Lock(GameState state, Random rng)
    {
        var toppedOut = false;
        foreach (var p in TetrominoData.Cells(state.CurrentType, state.CurrentRotation))
        {
            var fx = state.CurrentX + p.X;
            var fy = state.CurrentY + p.Y;
            if (fy < 0)
            {
                toppedOut = true;
                continue;
            }

            if (fx >= 0 && fx < GameConfig.FieldWidth && fy < GameConfig.FieldHeight)
            {
                state.Field[fx, fy] = state.CurrentType + 1;
            }
        }

        if (toppedOut)
        {
            state.GameOver = true;
            return;
        }

        var cleared = LineClearer.Clear(state);
        Scoring.Apply(state, cleared);
        state.HoldUsed = false;
        Spawner.Spawn(state, rng);
    }
}
