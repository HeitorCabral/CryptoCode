namespace DarkEngine.CodeCompression.Components
{
    public class Viewport : Control
    {
        readonly StatusMenu StatusStrip = new()
        {
            Height = 28,
            Dock = DockStyle.Bottom
        };

        readonly SplitContainerExt SplitEditor = new()
        {
            Dock = DockStyle.Fill,
            SplitterWidth = 8,
            Panel1MinSize = 0,
            Panel2MinSize = 0
        };

        public readonly TextBox CodeEditor = new() 
        { 
            Dock = DockStyle.Fill,
            Multiline = true,
            BackColor = Color.FromArgb(24, 24, 24),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.None,
            ScrollBars = ScrollBars.Vertical
        };

        public readonly TextBox EncryptViewer = new()
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            BackColor = Color.FromArgb(24, 24, 24),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.None,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true
        };

        public Viewport()
        {
            BackColor = Color.FromArgb(16, 16, 16);
            InitializeComponent();    
        }

        void InitializeComponent()
        {
            SplitEditor.Panel1.Padding = new Padding(10);
            SplitEditor.Panel1.Controls.Add(CodeEditor);

            SplitEditor.Panel2.Padding = new Padding(10);
            SplitEditor.Panel2.Controls.Add(EncryptViewer);

            SplitEditor.Panel1.BackColor = Color.FromArgb(24, 24, 24);
            SplitEditor.Panel2.BackColor = Color.FromArgb(24, 24, 24);

            Controls.Add(SplitEditor);
            Controls.Add(StatusStrip);
        }

        public void SplitterOnCenter(Form Parent) => SplitEditor.SplitterDistance = Parent.Width / 2 - SplitEditor.SplitterWidth;
    }
}
