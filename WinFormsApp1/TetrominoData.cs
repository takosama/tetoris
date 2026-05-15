using System.Drawing;

namespace WinFormsApp1;

public static class TetrominoData
{
    public static readonly Color[] Colors =
    {
        Color.Cyan, Color.Gold, Color.MediumPurple, Color.LimeGreen, Color.IndianRed, Color.DodgerBlue, Color.Orange,
    };

    private static readonly Point[][][] ShapeData =
    [
        // I
        [[new(0,1), new(1,1), new(2,1), new(3,1)], [new(2,0), new(2,1), new(2,2), new(2,3)], [new(0,2), new(1,2), new(2,2), new(3,2)], [new(1,0), new(1,1), new(1,2), new(1,3)]],
        // O
        [[new(1,0), new(2,0), new(1,1), new(2,1)], [new(1,0), new(2,0), new(1,1), new(2,1)], [new(1,0), new(2,0), new(1,1), new(2,1)], [new(1,0), new(2,0), new(1,1), new(2,1)]],
        // T
        [[new(1,0), new(0,1), new(1,1), new(2,1)], [new(1,0), new(1,1), new(2,1), new(1,2)], [new(0,1), new(1,1), new(2,1), new(1,2)], [new(1,0), new(0,1), new(1,1), new(1,2)]],
        // S
        [[new(1,0), new(2,0), new(0,1), new(1,1)], [new(1,0), new(1,1), new(2,1), new(2,2)], [new(1,1), new(2,1), new(0,2), new(1,2)], [new(0,0), new(0,1), new(1,1), new(1,2)]],
        // Z
        [[new(0,0), new(1,0), new(1,1), new(2,1)], [new(2,0), new(1,1), new(2,1), new(1,2)], [new(0,1), new(1,1), new(1,2), new(2,2)], [new(1,0), new(0,1), new(1,1), new(0,2)]],
        // J
        [[new(0,0), new(0,1), new(1,1), new(2,1)], [new(1,0), new(2,0), new(1,1), new(1,2)], [new(0,1), new(1,1), new(2,1), new(2,2)], [new(1,0), new(1,1), new(0,2), new(1,2)]],
        // L
        [[new(2,0), new(0,1), new(1,1), new(2,1)], [new(1,0), new(1,1), new(1,2), new(2,2)], [new(0,1), new(1,1), new(2,1), new(0,2)], [new(0,0), new(1,0), new(1,1), new(1,2)]],
    ];

    public static Point[] Cells(int type, int rotation) => ShapeData[type][rotation];
}
