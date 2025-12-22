namespace WinFormsApp1;

public static class GameReset
{
    public static void Reset(GameState state, Random rng)
    {
        Array.Clear(state.Field, 0, state.Field.Length);
        state.NextQueue.Clear();
        state.HoldType = null;
        state.HoldUsed = false;
        state.Score = 0;
        state.TotalLines = 0;
        state.Level = 0;
        state.DropIntervalMs = 800;
        state.DropAccumulatorMs = 0;
        state.Paused = false;
        state.GameOver = false;
        state.WaitingToStart = true;
        BagQueue.Fill(state, rng);
        Spawner.Spawn(state, rng);
    }
}
