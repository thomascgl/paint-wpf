using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace paint
{
    public class DraggableToolBar : ToolBar
    {
        private bool isDragging = false;
        private Point clickPosition;

        public DraggableToolBar()
        {
            this.MouseDown += Toolbar_MouseDown;
            this.MouseMove += Toolbar_MouseMove;
            this.MouseUp += Toolbar_MouseUp;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(this);
            this.CaptureMouse();
        }

        private void Toolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var canvas = VisualTreeHelper.GetParent(this) as Canvas;
                if (canvas != null)
                {
                    Point mousePos = e.GetPosition(canvas);
                    Canvas.SetLeft(this, mousePos.X - clickPosition.X);
                    Canvas.SetTop(this, mousePos.Y - clickPosition.Y);
                }
            }
        }

        private void Toolbar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            this.ReleaseMouseCapture();
        }
    }
}