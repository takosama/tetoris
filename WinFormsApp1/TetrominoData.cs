using System.Drawing;

namespace WinFormsApp1;

public static class TetrominoData
{
    public static readonly Color[] Colors =
    {
        Color.Cyan, Color.Gold, Color.MediumPurple, Color.LimeGreen, Color.IndianRed, Color.DodgerBlue, Color.Orange,
    };

    private static readonly int[][][] ShapeData =
    {
        new[] { new[] { 0, 1, 1, 1, 2, 1, 3, 1 }, new[] { 2, 0, 2, 1, 2, 2, 2, 3 }, new[] { 0, 2, 1, 2, 2, 2, 3, 2 }, new[] { 1, 0, 1, 1, 1, 2, 1, 3 } },
        new[] { new[] { 1, 0, 2, 0, 1, 1, 2, 1 }, new[] { 1, 0, 2, 0, 1, 1, 2, 1 }, new[] { 1, 0, 2, 0, 1, 1, 2, 1 }, new[] { 1, 0, 2, 0, 1, 1, 2, 1 } },
        new[] { new[] { 1, 0, 0, 1, 1, 1, 2, 1 }, new[] { 1, 0, 1, 1, 2, 1, 1, 2 }, new[] { 0, 1, 1, 1, 2, 1, 1, 2 }, new[] { 1, 0, 0, 1, 1, 1, 1, 2 } },
        new[] { new[] { 1, 0, 2, 0, 0, 1, 1, 1 }, new[] { 1, 0, 1, 1, 2, 1, 2, 2 }, new[] { 1, 1, 2, 1, 0, 2, 1, 2 }, new[] { 0, 0, 0, 1, 1, 1, 1, 2 } },
        new[] { new[] { 0, 0, 1, 0, 1, 1, 2, 1 }, new[] { 2, 0, 1, 1, 2, 1, 1, 2 }, new[] { 0, 1, 1, 1, 1, 2, 2, 2 }, new[] { 1, 0, 0, 1, 1, 1, 0, 2 } },
        new[] { new[] { 0, 0, 0, 1, 1, 1, 2, 1 }, new[] { 1, 0, 2, 0, 1, 1, 1, 2 }, new[] { 0, 1, 1, 1, 2, 1, 2, 2 }, new[] { 1, 0, 1, 1, 0, 2, 1, 2 } },
        new[] { new[] { 2, 0, 0, 1, 1, 1, 2, 1 }, new[] { 1, 0, 1, 1, 1, 2, 2, 2 }, new[] { 0, 1, 1, 1, 2, 1, 0, 2 }, new[] { 0, 0, 1, 0, 1, 1, 1, 2 } },
    };

    public static IEnumerable<Point> Cells(int type, int rotation)
    {
        var data = ShapeData[type][rotation];
        for (var i = 0; i < data.Length; i += 2)
        {
            yield return new Point(data[i], data[i + 1]);
        }
    }
}
