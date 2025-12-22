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
        var bag = new List<int>();
        for (var i = 0; i < 7; i++)
        {
            bag.Add(i);
        }

        for (var i = bag.Count - 1; i > 0; i--)
        {
            var j = rng.Next(i + 1);
            var temp = bag[i];
            bag[i] = bag[j];
            bag[j] = temp;
        }

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
