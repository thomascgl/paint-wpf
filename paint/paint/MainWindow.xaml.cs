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
            paintSurface.EditingMode = InkCanvasEditingMode.Ink;

            colore_nero.Tag = "attivo";
        }



        private void matita_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bordoMatita.Tag = "attivo";
            gomma_border.Tag = null;
            bordo_testo.Tag = null;
            bordo_secchiello.Tag = null;
            paintSurface.EditingMode = InkCanvasEditingMode.Ink;
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
            paintSurface.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            colore_bianco.Tag = "attivo";
            colore_nero.Tag = null;
            SolidColorBrush scb = (SolidColorBrush)colore_bianco.Fill;
            paintSurface.DefaultDrawingAttributes.Color = scb.Color;
        }

        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            colore_nero.Tag = "attivo";
            colore_bianco.Tag = null;
            SolidColorBrush scb = (SolidColorBrush)colore_nero.Fill;
            paintSurface.DefaultDrawingAttributes.Color = scb.Color;
        }
        private void UpdateLabelPosition(Slider s, TextBlock t, int pos)
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
            t.Margin = new Thickness(x + 13, pos, 0, 0);
        }

        private void slider_dimensione_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabelPosition(slider_dimensione, testo_valore_grandezza, 19);
            slider_dimensione.Value = paintSurface.DefaultDrawingAttributes.Width;
        }

        private void slider_dimensione_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLabelPosition(slider_dimensione, testo_valore_grandezza, 19);
            paintSurface.DefaultDrawingAttributes.Width = slider_dimensione.Value;
            paintSurface.DefaultDrawingAttributes.Height = slider_dimensione.Value;
        }

        private void slider_opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLabelPosition(slider_opacity, testo_opacita, 87);

        }

        private void slider_opacity_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabelPosition(slider_opacity, testo_opacita, 87);

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
            impostazioni_gomma.Visibility = Visibility.Visible;
        }

        private void impostazioni_gomma_MouseLeave(object sender, MouseEventArgs e)
        {
            impostazioni_gomma.Visibility = Visibility.Hidden;
        }



        private void secchiello_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bordo_secchiello.Tag = "attivo";
            bordoMatita.Tag = null;
            gomma_border.Tag = null;
            bordo_testo.Tag = null;

        }


        private void gomma_Img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bordoMatita.Tag = null;
            gomma_border.Tag = "attivo";
            bordo_secchiello.Tag = null;
            bordo_testo.Tag = null;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bordo_testo.Tag = "attivo";
            bordoMatita.Tag = null;
            gomma_border.Tag = null;
            bordo_secchiello.Tag = null;
        }

        private void ellisse_color_6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_6.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_6.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }
        private void ellisse_color_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_5.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_5.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (colore_nero.Tag == "attivo")
            {
                SolidColorBrush scb = (SolidColorBrush)ellisse_color_4.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {
                SolidColorBrush scb = (SolidColorBrush)ellisse_color_4.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_3.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_3.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_2.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_2.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_1.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_1.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_7.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_7.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_8.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_8.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }

        private void ellisse_color_9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colore_nero.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_9.Fill;
                colore_nero.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
            else if (colore_bianco.Tag == "attivo")
            {

                SolidColorBrush scb = (SolidColorBrush)ellisse_color_9.Fill;
                colore_bianco.Fill = scb;
                paintSurface.DefaultDrawingAttributes.Color = scb.Color;
            }
        }
    }
}
    
