using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace paint
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        bool matitaSelected = false;
        Ellipse[] colori;

        public MainWindow()
        {
            InitializeComponent();

            DrawingAttributes inkAttributes = new DrawingAttributes()
            {
                FitToCurve = true,
                Height = 5,
                Width = 5,
            };

            paintSurface.DefaultDrawingAttributes = inkAttributes;

            colori= new Ellipse[] {colore_nero,colore_bianco,ellisse_color_1, ellisse_color_2, ellisse_color_3, ellisse_color_4, ellisse_color_5 };
        }

        private void bordoMatita_MouseEnter(object sender, MouseEventArgs e)
        {
            bordoMatita.BorderBrush = Brushes.DimGray;
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
            bordoMatita.BorderBrush = Brushes.DimGray;
            bordoMatita.BorderThickness = new Thickness(2);

            gomma_border.BorderBrush = Brushes.Transparent;
            bordo_testo.BorderBrush = Brushes.Transparent;
            bordo_secchiello.BorderBrush = Brushes.Transparent;
            paintSurface.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void gomma_border_MouseEnter(object sender, MouseEventArgs e)
        {
            gomma_border.BorderBrush = Brushes.DimGray;
            gomma_border.BorderThickness = new Thickness(2);
        }

        private void gomma_border_MouseLeave(object sender, MouseEventArgs e)
        {
            gomma_border.BorderBrush = Brushes.Transparent;
            gomma_border.BorderThickness = new Thickness(2);
        }

        private void gomma_bordo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bordoMatita.BorderBrush = Brushes.Transparent;
            gomma_border.BorderBrush = Brushes.DimGray;
            gomma_border.BorderThickness = new Thickness(2);
            bordo_testo.BorderBrush = Brushes.Transparent;
            bordo_secchiello.BorderBrush = Brushes.Transparent;
        }

        private void bordo_secchiello_MouseEnter(object sender, MouseEventArgs e)
        {
            bordo_secchiello.BorderBrush = Brushes.DimGray;
            bordo_secchiello.BorderThickness = new Thickness(2);
        }

        private void bordo_secchiello_MouseLeave(object sender, MouseEventArgs e)
        {
            bordo_secchiello.BorderBrush = Brushes.Transparent;
            bordo_secchiello.BorderThickness = new Thickness(2);
        }

        private void bordo_testo_MouseEnter(object sender, MouseEventArgs e)
        {
            bordo_testo.BorderBrush = Brushes.DimGray;
            bordo_testo.BorderThickness = new Thickness(2);
        }

        private void bordo_testo_MouseLeave(object sender, MouseEventArgs e)
        {
            bordo_testo.BorderBrush = Brushes.Transparent;
            bordo_testo.BorderThickness = new Thickness(2);
        }

        private void label_freccia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                From = 0,
                To = 150,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation anim2 = new DoubleAnimation
            {
                From = 150,
                To = 40,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };
            grid_strumenti.Visibility = Visibility.Visible;
            if ((String)label_freccia.Content == ">")
            {
                griglia_oggetti.BeginAnimation(WidthProperty, anim);
                label_freccia.Content = "<";
            }
            else if ((String)label_freccia.Content == "<")
            {
                griglia_oggetti.BeginAnimation(WidthProperty, anim2);
                label_freccia.Content = ">";

            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            matitaSelected = false;
            bordoMatita.BorderBrush = Brushes.Transparent;
            gomma_border.BorderBrush = Brushes.DimGray;
            bordo_testo.BorderBrush = Brushes.Transparent;
            bordo_secchiello.BorderBrush = Brushes.Transparent;
            paintSurface.EditingMode = InkCanvasEditingMode.EraseByPoint;

        }

        private void ellisse_color_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellisse_color_5.Stroke = Brushes.DimGray;
            ellisse_color_5.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != ellisse_color_5)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }
        }

        private void ellisse_color_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellisse_color_4.Stroke = Brushes.DimGray;
            ellisse_color_4.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != ellisse_color_4)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }

        }

        private void ellisse_color_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellisse_color_3.Stroke = Brushes.DimGray;
            ellisse_color_3.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != ellisse_color_3)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }
        }

        private void ellisse_color_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellisse_color_2.Stroke = Brushes.DimGray;
            ellisse_color_2.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != ellisse_color_2)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }
        }

        private void ellisse_color_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellisse_color_1.Stroke = Brushes.DimGray;
            ellisse_color_1.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != ellisse_color_1)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }   

        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            colore_bianco.Stroke = Brushes.DimGray;
            colore_bianco.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != colore_bianco)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }
        }

        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            colore_nero.Stroke = Brushes.DimGray;
            colore_nero.StrokeThickness = 2;
            foreach (Ellipse colore in colori)
            {
                if (colore != colore_nero)
                {
                    colore.Stroke = Brushes.Black;
                    colore.StrokeThickness = 1;

                }
            }
        }
        private void UpdateLabelPosition(Slider s, TextBlock t,int pos)
        {
            if (s == null || t == null)
                return;

            // Aggiorna il testo
            t.Text = ((int)s.Value).ToString();

            // Evita calcoli prima che lo slider sia misurato
            if (s.ActualWidth == 0)
                return;

            // Calcolo posizione del thumb
            double percent = (s.Value - s.Minimum) /
                             (s.Maximum - s.Minimum);

            // Larghezza utile dello slider (tolgo il thumb)
            double usableWidth = s.ActualWidth - 20;

            // Posizione X del thumb
            double x = percent * usableWidth;
            double halfTextWidth = t.ActualWidth / 2;


            // Sposta il TextBlock
            t.Margin = new Thickness(x+13, pos, 0, 0);
        }

        private void slider_dimensione_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabelPosition(slider_dimensione,testo_valore_grandezza,19);
            slider_dimensione.Value= paintSurface.DefaultDrawingAttributes.Width;
        }

        private void slider_dimensione_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLabelPosition(slider_dimensione, testo_valore_grandezza,19);
            paintSurface.DefaultDrawingAttributes.Width = slider_dimensione.Value;
            paintSurface.DefaultDrawingAttributes.Height = slider_dimensione.Value;
        }

        private void slider_opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLabelPosition(slider_opacity, testo_opacita,87);

        }

        private void slider_opacity_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabelPosition(slider_opacity, testo_opacita,87);
            
        }

        private void matita_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            specifiche_matita.Visibility = Visibility.Visible;
        }

        private void specifiche_matita_MouseLeave(object sender, MouseEventArgs e)
        {
            specifiche_matita.Visibility = Visibility.Hidden;
        }

        private void slider_dim_gomma_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLabelPosition(slider_dim_gomma, tblock_dim_gomma, 17);
            paintSurface.EditingMode = InkCanvasEditingMode.None;
            paintSurface.UpdateLayout();

            // 3. Applica la nuova forma
            paintSurface.EraserShape = new EllipseStylusShape(slider_dim_gomma.Value, slider_dim_gomma.Value); ;

            // 4. Riattiva la gomma
            paintSurface.EditingMode = InkCanvasEditingMode.EraseByPoint;


        }

        private void slider_dim_gomma_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabelPosition(slider_dim_gomma, tblock_dim_gomma, 17);
            slider_dim_gomma.Value = paintSurface.EraserShape.Width;


        }

        private void gomma_Img_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            impostazioni_gomma.Visibility= Visibility.Visible;
        }

        private void impostazioni_gomma_MouseLeave(object sender, MouseEventArgs e)
        {
            impostazioni_gomma.Visibility = Visibility.Hidden;  
        }

        private void bordo_testo_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void secchiello_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void bordoMatita_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
