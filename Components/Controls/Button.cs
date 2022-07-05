namespace DarkEngine.CodeCompression.Components
{
    public class Button : Panel
    {
        public new string Text = "";

        public Bitmap Icon = new(1, 1);
        public new Size Size = new(12, 12);

        public Color C_Normal = Color.FromArgb(45, 45, 45);
        public Color C_Enter = Color.FromArgb(35, 35, 35);
        public Color C_Down = Color.FromArgb(25, 25, 25);
        public Color C_Fore = Color.FromArgb(255, 255, 255);

        public bool Pressed { get; set; } = false;

        public Button(string Text)
        {
            this.Text = Text;

            BackColor = C_Normal;
            ForeColor = C_Fore;

            DoubleBuffered = true;

            MouseEnter += (s, e) => { if (!Pressed) BackColor = C_Enter; };
            MouseLeave += (s, e) => { if (!Pressed) BackColor = C_Normal; };
            MouseDown  += (s, e) => { if (e.Button == MouseButtons.Left && !Pressed) BackColor = C_Down; };
            MouseUp    += (s, e) => { if (e.Button == MouseButtons.Left && !Pressed) BackColor = C_Enter; };
        }

        public Button(Bitmap Icon)
        {
            this.Icon = Icon;

            BackColor = C_Normal;
            ForeColor = C_Fore;

            DoubleBuffered = true;

            MouseEnter += (s, e) => { if (!Pressed) BackColor = C_Enter; };
            MouseLeave += (s, e) => { if (!Pressed) BackColor = C_Normal; };
            MouseDown  += (s, e) => { if (e.Button == MouseButtons.Left && !Pressed) BackColor = C_Down; };
            MouseUp    += (s, e) => { if (e.Button == MouseButtons.Left && !Pressed) BackColor = C_Enter; };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Font Font = new("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
            Rectangle Rect = new(0, 0, Width, Height);

            if (Icon != null)
                e.Graphics.DrawImage(Icon, new Rectangle(new Point(Width / 2 - Size.Width / 2, Height / 2 - Size.Height / 2), Size));

            StringFormat StringFormat = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.DrawString(Text, Font, new SolidBrush(C_Fore), Rect, StringFormat);
        }

        public void ResetStyle()
        {
            BackColor = C_Normal;
            ForeColor = C_Fore;
        }
    }
}
