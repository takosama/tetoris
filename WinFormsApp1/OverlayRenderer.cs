using System.Drawing;

namespace WinFormsApp1;

public static class OverlayRenderer
{
    public static void Draw(Graphics g, GameState state, Rectangle fieldRect)
    {
        if (!state.Paused && !state.GameOver && !state.WaitingToStart)
        {
            return;
        }

        using var overlay = new SolidBrush(Color.FromArgb(170, 10, 10, 12));
        g.FillRectangle(overlay, fieldRect);
        var message = state.GameOver ? "GAME OVER" : state.WaitingToStart ? "START" : "PAUSED";
        using var font = new Font(SystemFonts.MessageBoxFont.FontFamily, 20, FontStyle.Bold);
        var size = g.MeasureString(message, font);
        var center = new PointF(
            fieldRect.Left + (fieldRect.Width - size.Width) / 2f,
            fieldRect.Top + (fieldRect.Height - size.Height) / 2f);
        g.DrawString(message, font, Brushes.WhiteSmoke, center);

        if (state.WaitingToStart)
        {
            StartOverlayRenderer.DrawStartInfo(g, fieldRect, center.Y);
        }
    }
}
