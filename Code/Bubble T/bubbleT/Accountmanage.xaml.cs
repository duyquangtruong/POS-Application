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

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for Accountmanage.xaml
    /// </summary>
    public partial class Accountmanage : Page
    {
        int userID;
        public Accountmanage(int loginID)
        {
            InitializeComponent();
            userID = loginID;
            Dao connection = new Dao();
            DataTable dataTable = connection.GetAccount();
            dataTable = dataTable.DefaultView.ToTable();
            dataTable.AcceptChanges();            

            /*foreach (DataRow dr in dataTable.Rows) // search whole table
            {
                if (dr[3].ToString() == "True") // if id==2
                {
                    if (dr[4].ToString() == "2")
                    {
                        lookupData temp = new lookupData();
                        temp.Status = "Enable";
                        temp.Type = "Thu Ngân";
                        lookup.Add(temp);
                    }
                    else
                    {
                        lookupData temp = new lookupData();
                        temp.Status = "Enable";
                        temp.Type = "Quản Lý";
                        lookup.Add(temp);
                    }                    
                }
                else {
                    if (dr[4].ToString() == "2")
                    {
                        lookupData temp = new lookupData();
                        temp.Status = "Disable";
                        temp.Type = "Thu Ngân";
                        lookup.Add(temp);
                    }
                    else
                    {
                        lookupData temp = new lookupData();
                        temp.Status = "Disable";
                        temp.Type = "Quản Lý";
                        lookup.Add(temp);
                    }
                }
            }           */
            lvAccount.ItemsSource = dataTable.DefaultView;    
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var screen = new NewAccount();
            screen.ShowDialog();
            Dao connection = new Dao();
            DataTable dataTable = connection.GetAccount();
            dataTable = dataTable.DefaultView.ToTable();
            dataTable.AcceptChanges();
            lvAccount.ItemsSource = dataTable.DefaultView;
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvAccount.SelectedItem == null)
            {
                return;
            }
            var account = lvAccount.SelectedItem as DataRowView;
            string test = account.Row.ItemArray[0].ToString();
            int index = Int32.Parse(test);
            if (index == userID)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!");
            }
            else
            {                
                if (MessageBox.Show("Xóa người dùng đã chọn ?", "XÓA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Dao connection = new Dao();
                    if (connection.DeleteAccount(index))
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    DataTable dataTable = connection.GetAccount();
                    dataTable = dataTable.DefaultView.ToTable();
                    dataTable.AcceptChanges();
                    lvAccount.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvAccount.SelectedItem == null)
            {
                return;
            }
            var account = lvAccount.SelectedItem as DataRowView;
            string test = account.Row.ItemArray[0].ToString();
            int index = Int32.Parse(test);
            var editScreen = new EditAccount(index);
            editScreen.ShowDialog();

            Dao connection = new Dao();
            DataTable dataTable = connection.GetAccount();
            dataTable = dataTable.DefaultView.ToTable();
            dataTable.AcceptChanges();
            lvAccount.ItemsSource = dataTable.DefaultView;
        }
    }
}
