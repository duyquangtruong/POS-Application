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
            string datasource = "LAPTOP-KIRKOR";

            string database = "AppTraSua";
            Con.ConnectionString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            Con.Open();
            return Con;
        }
        public bool GetLogin(string a, string b)
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [USER] as u where u.UserName = '" + a + "' and u.Password = '" + b + "'", cnn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();
                cnn.Close();
                if (dt.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("loiaoi");
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public bool DeleteProduct(string id)
        {
            try
            {
                SqlConnection cnn = Connect();
                MessageBox.Show(string.Format("delete from PRODUCT where PRODUCT.ProductName = N'{0}'", id));
                SqlCommand cmd = new SqlCommand(string.Format("delete from PRODUCT where PRODUCT.ProductName = N'{0}'", id), cnn);
                cmd.ExecuteNonQuery();
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
        public bool UpdateProduct(int a, string b,string c,bool? d)
        {
            try
            {
                SqlConnection cnn = Connect();
                int i;
                if (d ?? true)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                SqlCommand cmd = new SqlCommand(string.Format("delete from PRODUCT where PRODUCT.ProductName = N'{0}'", b), cnn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd0 = new SqlCommand(string.Format("insert into PRODUCT(ProductName,isActive,Price,ProTypeID,Popular) values(N'{0}',{1},{2},{3},0)", b, i, c, a), cnn);
                cmd0.ExecuteNonQuery();
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
        public void InsertProduct(int a, string b,string c,bool? d)
        {
            try
            {               
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from PRODUCT as p where p.ProductName = N'{0}'", b), cnn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                da.Dispose();                
                if (dt.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Name invalid");
                    cnn.Close();
                }
                else
                {
                    int i;
                    if (d ?? true)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }
                    SqlCommand cmd = new SqlCommand(string.Format("insert into PRODUCT(ProductName,isActive,Price,ProTypeID,Popular) values('{0}',{1},{2},{3},0)", b, i, c, a), cnn);
                    MessageBox.Show(string.Format("insert into PRODUCT(ProductName,isActive,Price,ProTypeID,Popular) values('{0}',{1},{2},{3},0)", b, i, c, a));
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }  
            }
            catch (Exception e)
            {
                MessageBox.Show("loiaoi");
                MessageBox.Show(e.ToString());
            }
        }
        public DataTable GetProduct()
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select pt.Name,p.ProductName,p.Price,p.isActive,p.Popular from PRODUCT as p join PRO_TYPE as pt on p.ProTypeID = pt.ProTypeID", cnn);
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
        public DataTable Gettype()
        {
            try
            {
                SqlConnection cnn = Connect();
                SqlDataAdapter da = new SqlDataAdapter("select Name from PRO_TYPE", cnn);
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
    }
}
