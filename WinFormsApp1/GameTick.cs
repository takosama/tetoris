namespace WinFormsApp1;

public static class GameTick
{
    public static void Tick(GameState state, Random rng, int elapsedMs)
    {
        if (state.Paused || state.GameOver || state.WaitingToStart)
        {
            return;
        }

        state.DropAccumulatorMs += elapsedMs;
        while (state.DropAccumulatorMs >= state.DropIntervalMs)
        {
            state.DropAccumulatorMs -= state.DropIntervalMs;
            if (!PieceMovement.TryMove(state, 0, 1))
            {
                PieceLock.Lock(state, rng);
                break;
            }
        }
    }
}
