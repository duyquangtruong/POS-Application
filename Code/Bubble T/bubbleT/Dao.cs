using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace bubbleT
{
    class Dao
    {
        public static SqlConnection Con;
        public SqlConnection Connect()
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            string datasource = ".";

            string database = "AppTraSua";
            Con.ConnectionString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            Con.Open();
            return Con;
        }
        public int GetLogin(string a, string b)
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select UserID from [USER] as u where u.UserName = '" + a + "' and u.Password = '" + b + "'", cnn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();
                cnn.Close();
                if (dt.Tables[0].Rows.Count > 0)
                {
                    var array = dt.Tables[0].Rows[0].ItemArray;
                    var index = array[0].ToString();
                    return Int32.Parse(index);
                }
                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show("loiaoi");
                MessageBox.Show(e.ToString());
                return -1;
            }
        }
        public bool InsertProduct(string a, string b, string c, bool? d)
        {
            try
            {
                SqlConnection cnn = Connect();
                int i;
                if (d ?? true)
                {
                    i = 1;
                }
                else {
                    i = 0;
                }
                SqlDataAdapter da = new SqlDataAdapter(string.Format("insert into PRODUCT values({0},'{1}',{2},{3},6,NULL)", a, b, i, c), cnn);
                MessageBox.Show(string.Format("insert into PRODUCT values({0},'{1}',{3},{2},6,NULL)", a, b, c, i));
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("loiaoi");
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public DataTable GetProduct()
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select ProductID,ProductName,isActive,Price from PRODUCT", cnn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();
                return dt.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public DataTable GetID()
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select PersonID from n_Customer", cnn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();
                return dt.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool UsernameCheck(string username)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select UserName from [USER]", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataAdapter.Dispose();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (username == row[0].ToString())
                    {
                        MessageBox.Show("Username đã tồn tại !");
                        connection.Close();
                        return false;
                    }
                }               
                connection.Close();
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public DataTable GetAccount()
        {
            try
            {
                SqlConnection connection = Connect();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from [USER]", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataAdapter.Dispose();
                return dataSet.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public DataTable GetUserGroup()
        {
            try
            {
                SqlConnection connection = Connect();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from [USERGROUP]", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataAdapter.Dispose();
                return dataSet.Tables[0];
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public bool DeleteAccount(int ID)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("delete from [USER] where UserID = '"+ID+"'", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataAdapter.Dispose();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
