namespace WinFormsApp1;

public static class BagQueue
{
    public static void Ensure(GameState state, Random rng)
    {
        if (state.NextQueue.Count < 7)
        {
            Fill(state, rng);
        }
    }

    public static void Fill(GameState state, Random rng)
    {
        var bag = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        rng.Shuffle(bag);
        foreach (var type in bag)
        {
            state.NextQueue.Enqueue(type);
        }
    }

    public static int Pop(GameState state, Random rng)
    {
        Ensure(state, rng);
        return state.NextQueue.Dequeue();
    }
}
