namespace WinFormsApp1;

public static class Scoring
{
    private static readonly int[] LineScores = { 0, 100, 300, 500, 800 };

    public static void Apply(GameState state, int cleared)
    {
        if (cleared == 0)
        {
            return;
        }

        state.TotalLines += cleared;
        state.Level = state.TotalLines / 10;
        state.DropIntervalMs = Math.Max(100, 800 - state.Level * 60);
        state.Score += LineScores[cleared] * (state.Level + 1);
    }
}
