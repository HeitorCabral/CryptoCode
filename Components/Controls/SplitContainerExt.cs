namespace DarkEngine.CodeCompression.Components
{
    public class SplitContainerExt : SplitContainer
    {
        public SplitContainerExt()
        {
            DoubleBuffered = true;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsSplitterFixed = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsSplitterFixed = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsSplitterFixed)
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (Orientation.Equals(Orientation.Vertical))
                    {
                        if (e.X > 0 && e.X < Width)
                        {
                            SplitterDistance = e.X;
                            Refresh();
                        }
                    }
                    else
                    {
                        if (e.Y > 0 && e.Y < Height)
                        {
                            SplitterDistance = e.Y;
                            Refresh();
                        }
                    }
                }
                else
                {
                    IsSplitterFixed = false;
                }
            }
        }
    }
}
