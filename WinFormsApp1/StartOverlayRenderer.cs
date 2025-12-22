using System.Drawing;

namespace WinFormsApp1;

public static class StartOverlayRenderer
{
    public static void DrawStartInfo(Graphics g, Rectangle fieldRect, float centerY)
    {
        using var infoFont = new Font(SystemFonts.MessageBoxFont.FontFamily, 10, FontStyle.Regular);
        var info = "Enter/Space: Start  P: Pause  R: Restart";
        var infoSize = g.MeasureString(info, infoFont);
        g.DrawString(
            info,
            infoFont,
            Brushes.Gainsboro,
            fieldRect.Left + (fieldRect.Width - infoSize.Width) / 2f,
            centerY + 36);
        var keys = new[] { "Left/Right: Move", "Up/Z: Rotate", "Down: Soft Drop", "Space: Hard Drop", "C: Hold" };
        var y = centerY + 60;
        foreach (var line in keys)
        {
            var lineSize = g.MeasureString(line, infoFont);
            g.DrawString(
                line,
                infoFont,
                Brushes.Gainsboro,
                fieldRect.Left + (fieldRect.Width - lineSize.Width) / 2f,
                y);
            y += 18;
        }
    }
}
