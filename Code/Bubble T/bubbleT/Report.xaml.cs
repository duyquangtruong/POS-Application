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
using System.Data.SqlClient;
using System.Data;

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
        {
            InitializeComponent();
            Dao connection = new Dao();
            DataTable dataTable = connection.GetReport();
            dataTable = dataTable.DefaultView.ToTable();
            dataTable.AcceptChanges();
            lvReport.ItemsSource = dataTable.DefaultView;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Option option = new Option(0);
            NavigationService.Navigate(option);
        }
    }
}
