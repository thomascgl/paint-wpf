using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace paint
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        //grazie tanto a : http://www.kirupa.com/blend_wpf/inkcanvas_pg1.htm
        bool matitaSelected = false;
        DraggableToolBar toolbar = new DraggableToolBar();

        public MainWindow()
        {
            InitializeComponent();
            ellisse_n.Fill = Brushes.Black;
            ellisse_b.Fill = Brushes.White;

            DrawingAttributes inkAttributes = new DrawingAttributes();

            //inkAttributes.IsHighlighter = false;
            inkAttributes.FitToCurve = true;
            inkAttributes.Height = 5;
            inkAttributes.Width = 5;
            inkAttributes.Color = Colors.Red;

            paintSurface.DefaultDrawingAttributes = inkAttributes;
            paintSurface.EraserShape = new RectangleStylusShape(10, 10); //grandezza gomma
        }

        private void bordoMatita_MouseEnter(object sender, MouseEventArgs e)
        {
            bordoMatita.BorderBrush = Brushes.Coral;
            bordoMatita.BorderThickness = new Thickness(2);
        }

        private void bordoMatita_MouseLeave(object sender, MouseEventArgs e)
        {
            bordoMatita.BorderBrush = Brushes.Transparent;
            bordoMatita.BorderThickness = new Thickness(2);
        }

        private void matita_MouseDown(object sender, MouseButtonEventArgs e)
        {
            matitaSelected = true;
            paintSurface.EditingMode = InkCanvasEditingMode.Ink;
            //MessageBox.Show("selezionata");
        }
        private void gomma_border_MouseEnter(object sender, MouseEventArgs e)
        {
            gomma_border.BorderBrush = Brushes.Coral;
            gomma_border.BorderThickness = new Thickness(2);
        }

        private void gomma_border_MouseLeave(object sender, MouseEventArgs e)
        {
            gomma_border.BorderBrush = Brushes.Transparent;
            gomma_border.BorderThickness = new Thickness(2);
        }

        private void gomma_bordo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void bordo_secchiello_MouseEnter(object sender, MouseEventArgs e)
        {
            bordo_secchiello.BorderBrush = Brushes.Coral;
            bordo_secchiello.BorderThickness = new Thickness(2);
        }

        private void bordo_secchiello_MouseLeave(object sender, MouseEventArgs e)
        {
            bordo_secchiello.BorderBrush = Brushes.Transparent;
            bordo_secchiello.BorderThickness = new Thickness(2);
        }

        private void bordo_testo_MouseEnter(object sender, MouseEventArgs e)
        {
            bordo_testo.BorderBrush = Brushes.Coral;
            bordo_testo.BorderThickness = new Thickness(2);
        }

        private void bordo_testo_MouseLeave(object sender, MouseEventArgs e)
        {
            bordo_testo.BorderBrush = Brushes.Transparent;
            bordo_testo.BorderThickness = new Thickness(2);
        }

        private void gomma_MouseDown(object sender, MouseButtonEventArgs e)
        {
            matitaSelected = false;
            paintSurface.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }
    }
}
