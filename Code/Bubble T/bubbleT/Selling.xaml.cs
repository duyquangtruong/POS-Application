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
        public class SELLING
        {
            public static int i = 0;
            private static List<Order> list = new List<Order>();
            private static List<string> description = new List<string>();

            public static List<string> Description { get => description; set => description = value; }
            internal static List<Order> List { get => list; set => list = value; }

        }
        public Selling()
        {
            InitializeComponent();
            Listview_Load();
        }
        public Selling(Order order, string desc)
        {
            InitializeComponent();
            SELLING.List.Add(order);
            SELLING.Description.Add(desc);
            Listview_Load();

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Option option = new Option();
            NavigationService.Navigate(option);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            NavigationService.Navigate(order);
        }

        private void Listview_Load()
        {
            //add listview
            var Ls = SELLING.List;
            int i = 0;
            Listview.Items.Clear();
            foreach (var ls in Ls)
            {
                var tmp = new SellingListView(i++, ls.total.Content.ToString(), ls.StartTime.Text);
                Listview.Items.Add(tmp);
            }
        }
        public class SellingListView
        {
            public int ID { get; set; }
            public string Total { get; set; }
            public string Time { get; set; }
            public SellingListView(int id, string total, string time) { this.ID = id; this.Total = total; this.Time = time; }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                MessageBox.Show(SELLING.Description[i],Title="CHI TIẾT");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                Listview.Items.Remove(i);
                SELLING.List.RemoveAt(i);
                SELLING.Description.RemoveAt(i);
                Listview_Load();
            }
        }
    }
}
