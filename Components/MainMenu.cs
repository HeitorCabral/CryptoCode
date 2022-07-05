namespace DarkEngine.CodeCompression.Components
{
    public class MainMenu : Control
    {
        readonly MenuStrip MenuStrip = new() { BackColor = Color.FromArgb(200, 200, 200) };

        readonly ToolStripMenuItem File = new() { Text = "File" };

        public readonly ToolStripMenuItem New = new() { Text = "New" };
        public readonly ToolStripMenuItem Open = new() { Text = "Open" };

        readonly Control MainControl = new() { Height = 40, Dock = DockStyle.Top };
        public readonly Button Encrypt = new("Encrypt") { Width = 80, Dock = DockStyle.Left };
        public readonly Button Decrypt = new("Decrypt") { Width = 80, Dock = DockStyle.Right };

        public MainMenu()
        {
            Height = MenuStrip.Height + MainControl.Height;
            InitializeComponent();
        }

        void InitializeComponent()
        {
            MainControl.Controls.Add(Decrypt);
            MainControl.Controls.Add(Encrypt);

            Controls.Add(MainControl);

            MenuStrip.Items.AddRange(new ToolStripItem[] { File });
            File.DropDownItems.AddRange(new ToolStripItem[] { New, Open });

            Controls.Add(MenuStrip);
        }
    }
}
