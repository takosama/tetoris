namespace WinFormsApp1;

public static class LineClearer
{
    public static int Clear(GameState state)
    {
        var cleared = 0;
        for (var y = GameConfig.FieldHeight - 1; y >= 0; y--)
        {
            var full = true;
            for (var x = 0; x < GameConfig.FieldWidth; x++)
            {
                if (state.Field[x, y] != 0)
                {
                    continue;
                }

                full = false;
                break;
            }

            if (!full)
            {
                continue;
            }

            cleared++;
            for (var yy = y; yy > 0; yy--)
            {
                for (var x = 0; x < GameConfig.FieldWidth; x++)
                {
                    state.Field[x, yy] = state.Field[x, yy - 1];
                }
            }

            for (var x = 0; x < GameConfig.FieldWidth; x++)
            {
                state.Field[x, 0] = 0;
            }

            y++;
        }

        return cleared;
    }
}
