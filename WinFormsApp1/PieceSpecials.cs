namespace WinFormsApp1;

public static class PieceSpecials
{
    public static void HardDrop(GameState state, Random rng)
    {
        var distance = 0;
        while (PieceMovement.TryMove(state, 0, 1))
        {
            distance++;
        }

        state.Score += distance * 2;
        PieceLock.Lock(state, rng);
    }

    public static void Hold(GameState state, Random rng)
    {
        if (state.HoldUsed)
        {
            return;
        }

        if (!state.HoldType.HasValue)
        {
            state.HoldType = state.CurrentType;
            Spawner.Spawn(state, rng);
        }
        else
        {
            var temp = state.HoldType.Value;
            state.HoldType = state.CurrentType;
            state.CurrentType = temp;
            state.CurrentRotation = 0;
            state.CurrentX = 3;
            state.CurrentY = -1;
            if (Collision.Hits(state, state.CurrentType, state.CurrentRotation, state.CurrentX, state.CurrentY))
            {
                state.GameOver = true;
            }
        }

        state.HoldUsed = true;
    }
}
