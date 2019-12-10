using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for MenuSetting.xaml
    /// </summary>
    public partial class MenuSetting : Page
    {
        private string productid; 
        public MenuSetting()
        {
            InitializeComponent();
            HienthiProduct();
        }
        private void HienthiProduct()
        {
            Dao cn = new Dao();
            DataTable dt = cn.GetProduct();
            dt = dt.DefaultView.ToTable();
            dt.AcceptChanges();
            list0.ItemsSource = dt.DefaultView;
            
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                productid = ((DataRowView)item.Content)["ProductID"].ToString();
                t2.Text = ((DataRowView)item.Content)["ProductName"].ToString();
                t3.Text = ((DataRowView)item.Content)["Price"].ToString();               
            }
        }
        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            if(t1.Text == "")
            {
                t1.Text = "not null !!!!!";
            }
            else
            {
                cn.InsertProduct(t1.Text, t2.Text, t3.Text, c.IsChecked);
                HienthiProduct();
            }
        }

        private void List0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            cn.DeleteProduct(productid);
            HienthiProduct();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            cn.UpdateProduct(productid, t2.Text, t3.Text, c.IsChecked);
            HienthiProduct();
        }
    }
}
