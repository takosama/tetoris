namespace WinFormsApp1;

public sealed class GameState
{
    public readonly int[,] Field = new int[GameConfig.FieldWidth, GameConfig.FieldHeight];
    public readonly Queue<int> NextQueue = new Queue<int>();
    public int CurrentType;
    public int CurrentRotation;
    public int CurrentX;
    public int CurrentY;
    public int? HoldType;
    public bool HoldUsed;
    public int Score;
    public int TotalLines;
    public int Level;
    public int DropIntervalMs;
    public int DropAccumulatorMs;
    public bool Paused;
    public bool GameOver;
    public bool WaitingToStart;
}
