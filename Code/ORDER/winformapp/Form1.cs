using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsingListViewSample;

namespace winformapp
{

    public partial class Form1 : Form
    {
        public class ProductOrder
        {
            public static List<Product> list2 = new List<Product>();
            public static int i = 1;
            public static List<pMenu> menu = new List<pMenu>();

        }
        public Form1()
        {
            InitializeComponent();
            LoadMenu();
            if (ProductOrder.menu.Count>0)
            LoadNamePrice(0);
        }

        private void LoadMenu()
        {
            List<string> ls1;
             ls1= new List<string>
            {
                "Cafe Sữa 1", "Cafe Sữa 2",   "Cafe Sữa 3",  "Cafe Sữa 4"
            };
            List<int> lsp1 = new List<int>
            {
                25000, 35000,   45000,  55000
            };
            ProductOrder.menu.Add(new pMenu(1, "Cafe", ls1,lsp1));
            ls1 = new List<string>
            {
                "Trà Sữa 1",  "Trà Sữa 2","Trà Sữa 3", "Trà Sữa 4",  "Trà Sữa 5","Trà Sữa 6"
            };
            lsp1 = new List<int>
            {
                25000, 35000,   45000,  55000,35000,33000
            };
            ProductOrder.menu.Add(new pMenu(2, "Trà sữa", ls1, lsp1));

            ls1 = new List<string>
            {
                "Trà Đào 1", "Trà Đào 2","Trà Đào 3", "Trà Đào 4", "Trà Đào 5",
                "Trà Đào 6","Trà Đào 7", "Trà Đào 8" };
            lsp1 = new List<int>
            {
                35000, 45000, 11000, 55000,35000,33000, 11000  ,  55000
            };
            ProductOrder.menu.Add(new pMenu(3, "Trà Đào", ls1, lsp1));
            //load group menu
            for (int i = 0; i < ProductOrder.menu.Count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        group1.Text = ProductOrder.menu[i].getName();
                        break;
                    case 2:
                        group2.Text = ProductOrder.menu[i].getName();
                        break;
                    case 3:
                        group3.Text = ProductOrder.menu[i].getName();
                        break;
                    case 4:
                        group4.Text = ProductOrder.menu[i].getName();
                        break;
                    case 5:
                        group5.Text = ProductOrder.menu[i].getName();
                        break;
                    case 6:
                        group6.Text = ProductOrder.menu[i].getName();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            var Prd = ProductOrder.list2;
            listView1.Items.Clear();
            foreach (var prd in Prd)
            {
                string[] row = new string[] { prd.getProductName(), prd.getQuantityString(), prd.getTotalAmoutString(), DateTime.Today.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = prd;
                sumTotal();
                listView1.Items.Add(lvi);
            }

        }
        private List<Product> GetProductList()
        {
            var list = new List<Product>();
            list.Add(new Product("cafe", 1, 25000));
            return list;
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (p1.Text != "")
            {
                ProductOrder.i=1;
                string[] tmpList = p1.Text.Split('\n');
                string name = tmpList[0]; string price = tmpList[1];
                ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                Form1_Load(sender, e);
                string tmp = Convert.ToString(ProductOrder.i);
                textBox1.Text = tmp;
            }
            
        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }


        private void ListView1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            Button1_Click_2(sender, e);
            listView1.Select();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ClearGroup();
            group2.BackColor = Color.Sienna;
            LoadNamePrice(1);
        }

        private void ClearGroup()
        {
            group1.BackColor= Color.DeepSkyBlue;
            group2.BackColor= Color.DeepSkyBlue;
            group3.BackColor= Color.DeepSkyBlue;
            group4.BackColor= Color.DeepSkyBlue;
            group5.BackColor= Color.DeepSkyBlue;
            group6.BackColor= Color.DeepSkyBlue;
            p1.Text = ""; p2.Text = ""; p3.Text = ""; p4.Text = ""; p5.Text = "";
            p6.Text = ""; p7.Text = ""; p8.Text = ""; p9.Text = "";
        }
        private void LoadNamePrice(int index)
        {
             if (ProductOrder.menu.Count>index)
            { 
            List<string> lname = ProductOrder.menu[index].getListName();
            List<int> lprice = ProductOrder.menu[index].getListPrice();
            int n = lname.Count;
            for (int i = 0; i < n; i++)
            {
                switch (i+1)
                {
                    case 1:
                        p1.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 2:
                        p2.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 3:
                        p3.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 4:
                        p4.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 5:
                        p5.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 6:
                        p6.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 7:
                        p7.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 8:
                        p8.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    case 9:
                        p9.Text = lname[i] + "\n" + Convert.ToString(lprice[i]);
                        break;
                    default:
                        break;
                }
            }
            }
        }
        private void Button22_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            ClearGroup();
            group1.BackColor = Color.Sienna;
            LoadNamePrice(0);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
                if (p2.Text != "")
                {
                ProductOrder.i = 1;
                string[] tmpList = p2.Text.Split('\n');
                    string name = tmpList[0]; string price = tmpList[1];
                    ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                    Form1_Load(sender, e);
                    string tmp = Convert.ToString(ProductOrder.i);
                    textBox1.Text = tmp;
                }
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

            int val;
            int tmp = 1;
            if (int.TryParse(textBox1.Text, out val))
            {
                tmp = Convert.ToInt32(val);
            }
            if (ProductOrder.list2.Count != 0)
            {
                Product prd = ProductOrder.list2[ProductOrder.list2.Count - 1];
                prd.setQuantity(tmp);
                prd.setTotalAmout(tmp * prd.getdefaultPrice());
            }
            Form1_Load(sender, e);
            sumTotal();
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Button21_Click_1(object sender, EventArgs e)
        {
            if (ProductOrder.list2.Count != 0)
            {
                if (ProductOrder.i - 1 != 0)
            {
                ProductOrder.i = ProductOrder.i - 1;
            }
            string tmp = Convert.ToString(ProductOrder.i);
            textBox1.Text = tmp;
                Product prd = ProductOrder.list2[ProductOrder.list2.Count - 1];
                prd.setQuantity(ProductOrder.i);
                prd.setTotalAmout(ProductOrder.i * prd.getdefaultPrice());
            Form1_Load(sender, e);
            sumTotal();
            }

        }

        private void Button22_Click_1(object sender, EventArgs e)
        {
            if (ProductOrder.list2.Count!=0)
            { 
            ProductOrder.i = ProductOrder.i + 1;
            string tmp = Convert.ToString(ProductOrder.i);
            textBox1.Text = tmp;
            Product prd = ProductOrder.list2[ProductOrder.list2.Count - 1];
           prd.setQuantity(ProductOrder.i);
             prd.setTotalAmout(ProductOrder.i * prd.getdefaultPrice());
            Form1_Load(sender, e);
            sumTotal();
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {

        }
        private void sumTotal()
        {
            int sum = 0;
            for (int i = 0; i < ProductOrder.list2.Count; i++)
            {
                sum += ProductOrder.list2[i].getTotalAmout();
            }
            sumAll.Text = Convert.ToString(sum);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ClearGroup();
            group6.BackColor = Color.Sienna;
            LoadNamePrice(5);
        }

        private void Group3_Click(object sender, EventArgs e)
        {
            ClearGroup();
            group3.BackColor = Color.Sienna;
            LoadNamePrice(2);
        }

        private void Group4_Click(object sender, EventArgs e)
        {
            ClearGroup();
            group4.BackColor = Color.Sienna;
            LoadNamePrice(3);
        }

        private void Group5_Click(object sender, EventArgs e)
        {
            ClearGroup();
            group5.BackColor = Color.Sienna;
            LoadNamePrice(4);
        }

        private void P3_Click(object sender, EventArgs e)
        {
                if (p3.Text != "")
                {
                ProductOrder.i = 1;
                string[] tmpList = p3.Text.Split('\n');
                    string name = tmpList[0]; string price = tmpList[1];
                    ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                    Form1_Load(sender, e);
                    string tmp = Convert.ToString(ProductOrder.i);
                    textBox1.Text = tmp;
                }
        }

        private void P4_Click(object sender, EventArgs e)
        {
                    if (p4.Text != "")
                    {
                ProductOrder.i = 1;
                string[] tmpList = p4.Text.Split('\n');
                        string name = tmpList[0]; string price = tmpList[1];
                        ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                        Form1_Load(sender, e);
                        string tmp = Convert.ToString(ProductOrder.i);
                        textBox1.Text = tmp;
                    }
        }

        private void P5_Click(object sender, EventArgs e)
        {
                        if (p5.Text != "")
            {
                ProductOrder.i = 1;
                string[] tmpList = p5.Text.Split('\n');
                            string name = tmpList[0]; string price = tmpList[1];
                            ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                            Form1_Load(sender, e);
                            string tmp = Convert.ToString(ProductOrder.i);
                            textBox1.Text = tmp;
                        }
        }

        private void P6_Click(object sender, EventArgs e)
        {
                            if (p6.Text != "")
            {
                ProductOrder.i = 1;
                string[] tmpList = p6.Text.Split('\n');
                                string name = tmpList[0]; string price = tmpList[1];
                                ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                                Form1_Load(sender, e);
                                string tmp = Convert.ToString(ProductOrder.i);
                                textBox1.Text = tmp;
                            }
        }

        private void P7_Click(object sender, EventArgs e)
        {
                                if (p7.Text != "")
            {
                ProductOrder.i = 1;
                string[] tmpList = p7.Text.Split('\n');
                                    string name = tmpList[0]; string price = tmpList[1];
                                    ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                                    Form1_Load(sender, e);
                                    string tmp = Convert.ToString(ProductOrder.i);
                                    textBox1.Text = tmp;
                                }
        }

        private void P8_Click(object sender, EventArgs e)
        {
                           if (p8.Text != "")
            {
                ProductOrder.i = 1;
                string[] tmpList = p8.Text.Split('\n');
                                        string name = tmpList[0]; string price = tmpList[1];
                                        ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                                        Form1_Load(sender, e);
                                        string tmp = Convert.ToString(ProductOrder.i);
                                        textBox1.Text = tmp;
                                }
        }

        private void P9_Click(object sender, EventArgs e)
        {
           if (p9.Text != "")
            {
                ProductOrder.i = 1;
                string[] tmpList = p9.Text.Split('\n');
                                        string name = tmpList[0]; string price = tmpList[1];
                                        ProductOrder.list2.Add(new Product(name, 1, Convert.ToInt32(price)));
                                        Form1_Load(sender, e);
                                        string tmp = Convert.ToString(ProductOrder.i);
                                        textBox1.Text = tmp;
                                    }
        }
    }
    }
