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
    /// Interaction logic for Option.xaml
    /// </summary>
    public partial class Option : Page
    {
        public Option(int ID)
        {
            InitializeComponent();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }      

        private void btnSelling_Click(object sender, RoutedEventArgs e)
        {
            Selling selling = new Selling();
            NavigationService.Navigate(selling);
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            Delivery delivery = new Delivery();
            NavigationService.Navigate(delivery);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            NavigationService.Navigate(report);
        }

        private void btnMenuSetting_Click(object sender, RoutedEventArgs e)
        {
            MenuSetting menusetting = new MenuSetting();
            NavigationService.Navigate(menusetting);

        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            Accountmanage accountmanage = new Accountmanage();
            NavigationService.Navigate(accountmanage);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
