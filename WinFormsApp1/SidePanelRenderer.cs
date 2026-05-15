using System.Drawing;

namespace WinFormsApp1;

public static class SidePanelRenderer
{
    public static void Draw(Graphics g, GameState state, int x, int y)
    {
        using var textBrush = new SolidBrush(Color.Gainsboro);
        using var titleFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 12, FontStyle.Bold);
        using var valueFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 11, FontStyle.Regular);

        void Stat(string label, string value, int oy)
        {
            g.DrawString(label, titleFont, textBrush, x, y + oy);
            g.DrawString(value, valueFont, textBrush, x, y + oy + 24);
        }

        Stat("Score", state.Score.ToString(), 0);
        Stat("Lines", state.TotalLines.ToString(), 56);
        Stat("Level", state.Level.ToString(), 112);

        g.DrawString("Next", titleFont, textBrush, x, y + 176);
        MiniPieceRenderer.Draw(g, x, y + 204, state.NextQueue.Peek());
        g.DrawString("Hold", titleFont, textBrush, x, y + 300);
        if (state.HoldType.HasValue)
        {
            MiniPieceRenderer.Draw(g, x, y + 328, state.HoldType.Value);
        }

        g.DrawString("Controls", titleFont, textBrush, x, y + 420);
        using var controlsFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 9, FontStyle.Regular);
        g.DrawString("Left/Right Move", controlsFont, textBrush, x, y + 444);
        g.DrawString("Up/Z Rotate", controlsFont, textBrush, x, y + 462);
        g.DrawString("Down Soft", controlsFont, textBrush, x, y + 480);
        g.DrawString("Space Hard", controlsFont, textBrush, x, y + 498);
        g.DrawString("C Hold", controlsFont, textBrush, x, y + 516);
        g.DrawString("P Pause", controlsFont, textBrush, x, y + 534);
        g.DrawString("R Restart", controlsFont, textBrush, x, y + 552);
    }
}
