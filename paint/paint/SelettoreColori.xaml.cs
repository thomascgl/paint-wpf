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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace paint
{
    /// <summary>
    /// Logica di interazione per SelettoreColori.xaml
    /// </summary>
    public partial class SelettoreColori : Window
    {
        private Color hoveredColor; //la variabile è in inglese perchè non so come dirlo in italiano
        public Color coloreScelto;
        public bool confermato;

        

        public SelettoreColori()
        {
            InitializeComponent();

            coloreScelto = Color.FromRgb(0, 0, 0);
            confermato = false;
            new_color.Fill = new SolidColorBrush(coloreScelto);
        }

        private void Conferma_Button_Click(object sender, RoutedEventArgs e)
        {
            confermato = true;
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            coloreScelto = hoveredColor;
            new_color.Fill = new SolidColorBrush(coloreScelto);
            red_text.Text = hoveredColor.R.ToString();
            green_text.Text = hoveredColor.G.ToString();
            blue_text.Text = hoveredColor.B.ToString();
            hex_text.Text = string.Format("#{0:X2}{1:X2}{2:X2}", hoveredColor.R, hoveredColor.G, hoveredColor.B);
            Brush b = new SolidColorBrush(hoveredColor);
            new_color.Fill = b;
            coloreScelto = hoveredColor;

            var colore = ((SolidColorBrush)new_color.Fill).Color;

            modifica_opacità.Fill = new LinearGradientBrush(
                Color.FromArgb(0, colore.R, colore.G, colore.B), // trasparente
                colore,                                          // colore pieno
                90                                                // verticale
            );
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            //variabile img è qui per comodità
            Image img = ImageColore;
            if (img == null) return;
            BitmapSource src = (BitmapSource)ImageColore.Source;
            if (src == null) return;

            //posizione del mouse relativa al controllo Image
            Point pos = e.GetPosition(img);

            int bmpW = src.PixelWidth;
            int bmpH = src.PixelHeight;
            double imgW = img.ActualWidth;
            double imgH = img.ActualHeight;

            if (bmpW == 0 || bmpH == 0 || imgW == 0 || imgH == 0) return;

            //calcola le coordinate del pixel nella bitmap tenendo conto dello Stretch
            double xInBitmap = 0;
            double yInBitmap = 0;

            //questa operazione funziona solo con la Stretch DIrection messa a Fill, quindi non cambiamola
            double scaleX = bmpW / imgW;
            double scaleY = bmpH / imgH;
            xInBitmap = pos.X * scaleX;
            yInBitmap = pos.Y * scaleY;

            int px = (int)Math.Floor(xInBitmap);
            int py = (int)Math.Floor(yInBitmap);

            if (px < 0 || py < 0 || px >= bmpW || py >= bmpH) return;

            //assicuriamoci di leggere in formato Bgra32 (4 byte)
            BitmapSource readable;
            if (src.Format == PixelFormats.Bgra32)
                readable = src;
            else
                readable = new FormatConvertedBitmap(src, PixelFormats.Bgra32, null, 0);

            CroppedBitmap cb = new CroppedBitmap(readable, new Int32Rect(px, py, 1, 1));
            byte[] pixels = new byte[4]; // B,G,R,A
            cb.CopyPixels(pixels, 4, 0);

            //salviamo il colore nella variabile che andrà alla MainWindow e lo mettiamo nel rettangolo di anteprima
            hoveredColor = Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
            Brush b = new SolidColorBrush(hoveredColor);
            q_colore.Fill = b;
        }

        private void quadrato_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //codice riutilizzato per la selezione dei colori di default(cri sei un grande)
            if (sender is Rectangle rec)
            {
                SolidColorBrush scb = (SolidColorBrush)rec.Fill;
                red_text.Text=scb.Color.R.ToString();
                green_text.Text=scb.Color.G.ToString();
                blue_text.Text=scb.Color.B.ToString();
                hex_text.Text=string.Format("#{0:X2}{1:X2}{2:X2}", scb.Color.R, scb.Color.G, scb.Color.B);
                new_color.Fill=scb;

                coloreScelto = scb.Color;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void red_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //questo serve alla creazione della textBox
            if (red_text == null || hex_text == null) return;

            if (byte.TryParse(red_text.Text, out byte valoreRosso))
            {
                coloreScelto.R = valoreRosso;
                SolidColorBrush scb = new SolidColorBrush(coloreScelto);
                hex_text.Text = string.Format("#{0:X2}{1:X2}{2:X2}", scb.Color.R, scb.Color.G, scb.Color.B);
                new_color.Fill = scb;
            }
        }

        private void green_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //questo serve alla creazione della textBox
            if (green_text == null || hex_text == null) return;

            if (byte.TryParse(green_text.Text, out byte valoreVerde))
            {
                coloreScelto.G = valoreVerde;
                SolidColorBrush scb = new SolidColorBrush(coloreScelto);
                hex_text.Text = string.Format("#{0:X2}{1:X2}{2:X2}", scb.Color.R, scb.Color.G, scb.Color.B);
                new_color.Fill = scb;
            }
        }

        private void blu_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //questo serve alla creazione della textBox
            if (blue_text == null || hex_text == null) return;

            if (byte.TryParse(blue_text.Text, out byte valoreBlu))
            {
                coloreScelto.B = valoreBlu;
                SolidColorBrush scb = new SolidColorBrush(coloreScelto);
                hex_text.Text = string.Format("#{0:X2}{1:X2}{2:X2}", scb.Color.R, scb.Color.G, scb.Color.B);
                new_color.Fill = scb;
            }
        }

        private void hex_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //questo serve alla creazione della textBox
            if (hex_text == null || red_text == null || green_text == null || blue_text == null) return;

            string s = hex_text.Text;
            if(s.Length != 7) return;
            if (s[0] != '#') return;

            //verifica se le altre lettere siano valide
            for(int i=1; i < 7; i++)
            {
                //se non è un numero verifica che sia compreso tra A e F
                if (!int.TryParse(s[i].ToString(), out int varInutile))
                {
                    if (s[i] < 65 && s[i] > 70) return;

                }
            }

            coloreScelto = (Color)ColorConverter.ConvertFromString(hex_text.Text);
            red_text.Text = coloreScelto.R.ToString();
            green_text.Text = coloreScelto.G.ToString();
            blue_text.Text = coloreScelto.B.ToString();
        }
    }
}
