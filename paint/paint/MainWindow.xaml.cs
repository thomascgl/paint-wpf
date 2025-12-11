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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace paint
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool matitaSelected = false;
        public MainWindow()
        {
            InitializeComponent();
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
            MessageBox.Show("selezionata");
        }
    }
}
