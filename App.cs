using DarkEngine.CodeCompression.Components;

namespace DarkEngine.CodeCompression
{
    public class App : Form
    {
        readonly MainMenu MainMenu = new();
        readonly Viewport Viewport = new();

        Encrypt Encrypt { get; set; } = new("");

        public App()
        {
            Text = "CryptoCode";

            StartPosition = FormStartPosition.CenterScreen;

            Width = (int)(Screen.PrimaryScreen.Bounds.Width * .8f);
            Height = (int)(Screen.PrimaryScreen.Bounds.Height * .8f);

            BackColor = Color.FromArgb(16, 16, 16);

            Load += (s, e) => { Viewport.SplitterOnCenter(this); };

            InitializeComponent();
            InitializeCrypting();
        }

        void InitializeComponent()
        {
            MainMenu.Dock = DockStyle.Top;
            Viewport.Dock = DockStyle.Fill;

            Controls.Add(Viewport);
            Controls.Add(MainMenu);
        }

        void InitializeCrypting()
        {
            MainMenu.New.Click += (s, e) =>
            {
                Viewport.CodeEditor.Clear();
                Viewport.EncryptViewer.Clear();
            };

            MainMenu.Open.Click += (s, e) =>
            {
                OpenFileDialog OpenFileDialog = new()
                {
                    InitialDirectory = "c:\\",
                    Filter = "JavaScript Source File (*.js)|*.js|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader Reader = new(OpenFileDialog.OpenFile());
                    Viewport.CodeEditor.Text = Reader.ReadToEnd();
                }
            };

            MainMenu.Encrypt.Click += (s, e) =>
            {
                Viewport.EncryptViewer.Clear();

                Encrypt = new(Viewport.CodeEditor.Text);
                Encrypt.Initialize();

                Encrypt.EncryptCode();

                Viewport.EncryptViewer.Text = Encrypt.Encrypted;
                Encrypt.CreateFile("./", "index");
            };

            MainMenu.Decrypt.Click += (s, e) =>
            {
                if (!Encrypt.DecryptCode()) return;

                Form View = new()
                {
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Size = new Size(Width / 2, Height),
                    StartPosition = FormStartPosition.CenterScreen
                };

                TextBox DecryptViewer = new()
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    BackColor = Color.FromArgb(24, 24, 24),
                    ForeColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    ScrollBars = ScrollBars.Vertical,
                    ReadOnly = true,
                    Text = Encrypt.Decrypted,
                    Font = new("Arial", 14, FontStyle.Regular, GraphicsUnit.Point)
                };

                View.Controls.Add(DecryptViewer);
                View.ShowDialog();
            };
        }
    }
}