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

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for Selling.xaml
    /// </summary>
    public partial class Selling : Page
    {
        public Selling()
        {
            InitializeComponent();           
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Option option = new Option();
            NavigationService.Navigate(option);
        }
    }
}
