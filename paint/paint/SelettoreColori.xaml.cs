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
        public SelettoreColori()
        {
            InitializeComponent();
        }

        private void Conferma_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
