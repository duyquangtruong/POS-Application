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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        int editID;
        public EditAccount(int selectedID)
        {
            InitializeComponent();
            editID = selectedID;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            var password = newPassword.Text.ToString();
            if (password == "" || newAccountType.SelectedItem == null)
            {
                MessageBox.Show("Hãy điền đủ thông tin!");
            }
            int type = 2;

            if (newAccountType.Text.ToString() == "Quản Lý")
            {
                type = 1;
            }

            int active = 0;

            if (cbActive.IsChecked == true)
            {
                active = 1;
            }            

            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
            {
                string Query = "update [USER] set Password = @PASS, isActive = @ACTIVE, GroupID = @GROUPID where UserID = @ID";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PASS", password);
                    command.Parameters.AddWithValue("@ACTIVE", active);
                    command.Parameters.AddWithValue("@GROUPID", type);
                    command.Parameters.AddWithValue("@ID", editID);
                    connection.Open();
                    command.ExecuteScalar();
                }
                connection.Close();
                this.Close();
            }
        }
    }
}
