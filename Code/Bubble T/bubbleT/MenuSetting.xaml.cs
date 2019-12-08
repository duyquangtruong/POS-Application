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
            
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void List0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dao cn = new Dao();
            
            if (cn.InsertProduct(t1.Text,t2.Text,t3.Text,c.IsChecked))
            {
                MessageBox.Show("ok!");
            }
            else {
                MessageBox.Show("error!");
            }
        }
    }
}
