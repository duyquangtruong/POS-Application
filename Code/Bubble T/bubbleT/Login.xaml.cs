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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Selling selling = new Selling();
            Option op = new Option();
            Dao cn = new Dao();
            string a = username.Text;
            string b = password.Password;
            if (cn.GetLogin(a, b)){
                this.NavigationService.Navigate(op);
            }
            else
            {
                MessageBox.Show("unvalid username or password");
            }
        }
    }
}
