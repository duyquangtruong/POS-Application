﻿using System;
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
        public bool InsertProduct(string a, string b,string c,bool? d)
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
                SqlDataAdapter da = new SqlDataAdapter(string.Format("insert into PRODUCT values({0},'{1}',{2},{3},6,NULL)",a,b,i,c), cnn);
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
    }
}