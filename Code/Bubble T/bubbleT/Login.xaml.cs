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
            Dao cn = new Dao();
            string a = username.Text;
            string b = password.Password;
            int ID = cn.GetLogin(a, b);
            if (ID != -1) {
                Option op = new Option(ID);
                this.NavigationService.Navigate(op,ID);
            }
            else
            {
                MessageBox.Show("unvalid username or password");
            }
        }
    }
}
