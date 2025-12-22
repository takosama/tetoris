namespace WinFormsApp1;

public static class NextPreview
{
    public static int Peek(GameState state)
    {
        return state.NextQueue.Count > 0 ? state.NextQueue.Peek() : state.CurrentType;
    }
}
