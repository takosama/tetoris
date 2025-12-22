namespace WinFormsApp1;

public static class Collision
{
    public static bool Hits(GameState state, int type, int rotation, int x, int y)
    {
        foreach (var p in TetrominoData.Cells(type, rotation))
        {
            var fx = x + p.X;
            var fy = y + p.Y;
            if (fx < 0 || fx >= GameConfig.FieldWidth || fy >= GameConfig.FieldHeight)
            {
                return true;
            }

            if (fy >= 0 && state.Field[fx, fy] != 0)
            {
                return true;
            }
        }

        return false;
    }
}
