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
            DataTable dt1 = cn.Gettype();
            dt1 = dt1.DefaultView.ToTable();
            dt1.AcceptChanges();
            list1.ItemsSource = dt1.DefaultView;
            list1.SelectedIndex = 1;
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
                t2.Text = ((DataRowView)item.Content)["ProductName"].ToString();
                t3.Text = ((DataRowView)item.Content)["Price"].ToString();
                list1.Text = ((DataRowView)item.Content)["Name"].ToString();               
            }
        }
        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            cn.InsertProduct(list1.SelectedIndex + 1, t2.Text, t3.Text, c.IsChecked);
            HienthiProduct();
        }

        private void List0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            cn.DeleteProduct(t2.Text);
            HienthiProduct();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            cn.UpdateProduct(list1.SelectedIndex + 1, t2.Text, t3.Text, c.IsChecked);
            HienthiProduct();
        }
    }
}
