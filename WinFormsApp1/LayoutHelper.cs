namespace WinFormsApp1;

public static class LayoutHelper
{
    public static Size GetClientSize() =>
        new Size(
            GameConfig.FieldWidth * GameConfig.CellSize + GameConfig.SidePanelWidth + GameConfig.MarginSize * 3,
            GameConfig.FieldHeight * GameConfig.CellSize + GameConfig.MarginSize * 2);

    public static Rectangle GetFieldRect(Point origin) =>
        new Rectangle(
            origin.X,
            origin.Y,
            GameConfig.FieldWidth * GameConfig.CellSize,
            GameConfig.FieldHeight * GameConfig.CellSize);
}
