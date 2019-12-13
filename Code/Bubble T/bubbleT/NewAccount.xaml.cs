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
    /// Interaction logic for NewAccount.xaml
    /// </summary>
    public partial class NewAccount : Window
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxUserName.Text == "" || txtboxPassWord.Text == "" || cboxAccountType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
            }
            else
            {
                string UserName = txtboxUserName.Text;
                string PassWord = txtboxPassWord.Text;
                string Type = cboxAccountType.Text.ToString();
                int id = 2;
              

                if (Type == "Quản lý")
                {
                    id = 1;
                }

                Dao cn = new Dao();
                if (cn.UsernameCheck(UserName) == false)
                {
                    MessageBox.Show("Username đã tồn tại!");
                }
                else {
                    using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
                    {
                        string Query = "insert into [USER] (UserName,Password,isActive,GroupID) values (@UNAME,@PASS,@ACTIVE,@ID)";
                        using (SqlCommand command = new SqlCommand(Query, connection))
                        {
                            command.Parameters.AddWithValue("@UNAME", UserName);
                            command.Parameters.AddWithValue("@PASS", PassWord);
                            command.Parameters.AddWithValue("@ACTIVE", 1);
                            command.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            command.ExecuteScalar();
                        }
                        connection.Close();
                    }
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
            }

        }
    }
}
