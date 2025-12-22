using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly GameState state = new GameState();
    private readonly Random rng = new Random();
    private readonly Stopwatch stopwatch = new Stopwatch();
    private readonly Timer frameTimer = new Timer();

    public Form1()
    {
        InitializeComponent();
        DoubleBuffered = true;
        KeyPreview = true;
        Text = "Tetris";
        ClientSize = LayoutHelper.GetClientSize();
        frameTimer.Interval = 16;
        frameTimer.Tick += OnFrame;
        frameTimer.Start();
        stopwatch.Start();
        KeyDown += OnKeyDown;
        GameReset.Reset(state, rng);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        GameRenderer.Draw(e.Graphics, state);
    }

    private void OnFrame(object? sender, EventArgs e)
    {
        var elapsedMs = (int)stopwatch.ElapsedMilliseconds;
        stopwatch.Restart();
        GameTick.Tick(state, rng, elapsedMs);
        Invalidate();
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        InputHandler.Handle(state, rng, e.KeyCode);
    }
}
