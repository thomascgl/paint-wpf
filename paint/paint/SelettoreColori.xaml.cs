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
            RettangoloPreviewColore.Fill = new SolidColorBrush(coloreScelto);
        }

        private void Conferma_Button_Click(object sender, RoutedEventArgs e)
        {
            confermato = true;
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            coloreScelto = hoveredColor;
            RettangoloPreviewColore.Fill = new SolidColorBrush(coloreScelto);
            //TODO: fare in modo che le tre textBox prendano il valore rgb e lo mostrino
            // inoltre se cambi il valore rgb nelle textBox, viene messo quello come coloreScelto
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
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
        }
    }
}
