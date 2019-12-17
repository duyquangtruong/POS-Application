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
        public class Prd
        {
            public string productNameR { get; set; }
            public string CusTypeR { get; set; }
            public int quantityR { get; set; }
            public int priceR { get; set; }
            public int totalR { get; set; }
        }
        public Report()
        {
            InitializeComponent();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            //  Option option = new Option();
            //  NavigationService.Navigate(option);
            NavigationService.GoBack();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            listview.Items.Clear();
            DateTime a = Date1.SelectedDate.Value.Date;
            DateTime b = Date2.SelectedDate.Value.Date;
            if (Date1 != null && Date2 != null && a <= b && a != null && b != null)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
                {
                    String query = "exec getProductByDate '" + a + "','" + b + "'";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    Prd prd = new Prd();
                                    prd.productNameR = reader["ProductName"].ToString();
                                    int cus = Convert.ToInt32(reader["CusTypeID"].ToString());
                                    if (cus == 1) prd.CusTypeR = "Order tại quán"; else prd.CusTypeR = "Delivery";
                                    prd.quantityR = Convert.ToInt32(reader["SL"].ToString());
                                    prd.priceR = Convert.ToInt32(reader["Price"].ToString());
                                    prd.totalR = Convert.ToInt32(reader["TongTien"].ToString());
                                    listview.Items.Add(prd);
                                }
                            }
                        }
                    }
                }
            }
            else { listview.Items.Clear(); }
        }

        private void TT_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
