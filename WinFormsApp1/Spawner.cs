namespace WinFormsApp1;

public static class Spawner
{
    public static void Spawn(GameState state, Random rng)
    {
        state.CurrentType = BagQueue.Pop(state, rng);
        state.CurrentRotation = 0;
        state.CurrentX = 3;
        state.CurrentY = -1;

        if (Collision.Hits(state, state.CurrentType, state.CurrentRotation, state.CurrentX, state.CurrentY))
        {
            state.GameOver = true;
        }
    }
}
