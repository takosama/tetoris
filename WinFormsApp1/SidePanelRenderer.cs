using System.Drawing;

namespace WinFormsApp1;

public static class SidePanelRenderer
{
    public static void Draw(Graphics g, GameState state, int x, int y)
    {
        using var textBrush = new SolidBrush(Color.Gainsboro);
        using var titleFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 12, FontStyle.Bold);
        using var valueFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 11, FontStyle.Regular);
        g.DrawString("Score", titleFont, textBrush, x, y);
        g.DrawString(state.Score.ToString(), valueFont, textBrush, x, y + 24);
        g.DrawString("Lines", titleFont, textBrush, x, y + 56);
        g.DrawString(state.TotalLines.ToString(), valueFont, textBrush, x, y + 80);
        g.DrawString("Level", titleFont, textBrush, x, y + 112);
        g.DrawString(state.Level.ToString(), valueFont, textBrush, x, y + 136);
        g.DrawString("Next", titleFont, textBrush, x, y + 176);
        MiniPieceRenderer.Draw(g, x, y + 204, NextPreview.Peek(state));
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
