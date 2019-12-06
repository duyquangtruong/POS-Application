using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public class ORDER
        {
            private static List<pOrder> list = new List<pOrder>();
            private static List<pType> type = new List<pType>();
            //số lượng hiện tại 1 món đang order
            public static int currentQuantity = 1;
            //vị trí món order được lựa chọn
            public static int positionSelected = 0;
            //trang hiện tại của nhóm hàng
            public static int pageG = 0;
            //trang hiện tại của mặt hàng
            public static int pageP = 0;
            //Vị trí nhóm hàng đang chọn
            public static int posG = 0;
            internal static List<pOrder> List { get => list; set => list = value; }
            internal static List<pType> Type { get => type; set => type = value; }
        }
        public Order()
        {
            InitializeComponent();

            LoadMenu();
            if (ORDER.Type.Count > 0) groupClick(g1, 0);
            if (ORDER.Type.Count <= 6)
            {
                gPrev.Visibility = Visibility.Hidden;
                gNext.Visibility = Visibility.Hidden;
            }
            else gPrev.IsEnabled = false;
        }
        private void ShowGroupName()
        {
            int n;
            List<Button> gBtn = new List<Button> { g1, g2, g3, g4, g5, g6 };
            if (ORDER.Type.Count >= (ORDER.pageG + 1) * 6) n = 6;
            else n = ORDER.Type.Count % 6;
            for (int i = 0; i < n; i++)
            {
                gBtn[i].Content = ORDER.Type[i + ORDER.pageG * 6].getName();
            }
        }
        private void LoadMenu()
        {
            List<int> typeIDTmp = new List<int>();
            List<string> typeNameTmp = new List<string>();
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PRO_TYPE", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                int ProTypeID = Convert.ToInt32(reader["ProTypeID"].ToString());
                                String Name = reader["Name"].ToString();
                                typeIDTmp.Add(ProTypeID);
                                typeNameTmp.Add(Name);
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < typeIDTmp.Count; i++)
            {
                List<string> ls = new List<string>();
                List<int> lsp = new List<int>();
                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select* from PRODUCT where ProTypeID=" + typeIDTmp[i], connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    while (reader.Read())
                                    {
                                        bool isActive = Convert.ToBoolean(reader["isActive"].ToString());
                                        if (isActive)
                                        {
                                            int ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                                            String PrdName = reader["ProductName"].ToString();
                                            int Price = Convert.ToInt32(reader["Price"].ToString());
                                            ls.Add(PrdName);
                                            lsp.Add(Price);
                                        }
                                    }
                                    ORDER.Type.Add(new pType(typeIDTmp[i], typeNameTmp[i], ls, lsp));
                                }
                            }
                        }
                    }
                }
            }
            ShowGroupName();
        }
        private void showProduct(int index)
        {
            ClearNameAndPrice();
            if (ORDER.Type.Count > index)
            {
                List<string> lname = ORDER.Type[index].getListName();
                List<int> lprice = ORDER.Type[index].getListPrice();
                int n = lname.Count;
                List<TextBlock> nameP = new List<TextBlock> { nameP1, nameP2, nameP3, nameP4, nameP5, nameP6, nameP7, nameP8, nameP9 };
                List<TextBlock> priceP = new List<TextBlock> { priceP1, priceP2, priceP3, priceP4, priceP5, priceP6, priceP7, priceP8, priceP9 };
                for (int i = 0; i < 9; i++)
                {
                    if (i + ORDER.pageP * 9 < n)
                    {
                        nameP[i].Text = lname[i + ORDER.pageP * 9];
                        priceP[i].Text = Convert.ToString(lprice[i + ORDER.pageP * 9]);
                    }
                }
            }
        }
        private void ClearNameAndPrice()
        {
            nameP1.Text = nameP2.Text = nameP3.Text = nameP4.Text = nameP5.Text = nameP6.Text = nameP7.Text =
              nameP8.Text = nameP9.Text = "";
            priceP1.Text = priceP2.Text = priceP3.Text = priceP4.Text = priceP5.Text = priceP6.Text = priceP7.Text =
            priceP8.Text = priceP9.Text = "";
        }
        private void groupClick(Button g, int index)
        {
            ORDER.posG = index;
            ORDER.pageP = 0;
            pPrev.IsEnabled = false;
            if (index < ORDER.Type.Count)
            {
                if (ORDER.Type[ORDER.posG].getListName().Count > 9)
                {
                    pNext.IsEnabled = true;
                }
                else
                {
                    pNext.IsEnabled = false;
                }
            }
            else pNext.IsEnabled = false;

            //clean
            g1.Background = Brushes.CornflowerBlue;
            g2.Background = Brushes.CornflowerBlue;
            g3.Background = Brushes.CornflowerBlue;
            g4.Background = Brushes.CornflowerBlue;
            g5.Background = Brushes.CornflowerBlue;
            g6.Background = Brushes.CornflowerBlue;
            ClearNameAndPrice();
            g.Background = Brushes.DarkOrange;
            showProduct(index);
        }
        private void GNext_Click(object sender, RoutedEventArgs e)
        {
            if (ORDER.pageG + 1 <= (ORDER.Type.Count / 6))
            {
                gPrev.IsEnabled = true;
                g1.Content = g2.Content = g3.Content = g4.Content = g5.Content = g6.Content = "";
                ORDER.pageG = ORDER.pageG + 1;
                groupClick(g1, 0 + ORDER.pageG * 6);
                ShowGroupName();
                if (ORDER.pageG == (ORDER.Type.Count / 6)) gNext.IsEnabled = false;
            }
        }
        private void GPrev_Click(object sender, RoutedEventArgs e)
        {
            if (ORDER.pageG != 0)
            {
                gNext.IsEnabled = true;
                g1.Content = g2.Content = g3.Content = g4.Content = g5.Content = g6.Content = "";
                ORDER.pageG = ORDER.pageG - 1;
                groupClick(g1, 0 + ORDER.pageG * 6);
                ShowGroupName();
                if (ORDER.pageG == 0) { gPrev.IsEnabled = false; }
            }
        }
        private void G1_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g1, 0 + ORDER.pageG * 6);
        }
        private void G2_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g2, 1 + ORDER.pageG * 6);
        }
        private void G3_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g3, 2 + ORDER.pageG * 6);
        }
        private void G4_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g4, 3 + ORDER.pageG * 6);
        }
        private void G5_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g5, 4 + ORDER.pageG * 6);
        }
        private void G6_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g6, 5 + ORDER.pageG * 6);
        }
        private void Listview_Load()
        {
            //add listview
            var Prd = ORDER.List;
            Listview.Items.Clear();
            foreach (var prd in Prd)
            {
                Listview.Items.Add(prd);
            }
            if (Listview.Items.Count != 0)
                if (ORDER.positionSelected > 0) Listview.ScrollIntoView(Listview.Items[ORDER.positionSelected]);
        }
        private void AddItem(TextBlock nameP, TextBlock priceP)
        {
            if (nameP.Text != "" || priceP.Text != "")
            {
                ORDER.currentQuantity = 1;
                //split name, price
                // string[] tmpList = p.Content.ToString().Split('\n');
                //  string name = tmpList[0]; string price = tmpList[1];

                //ADD to list prd
                ORDER.List.Add(new pOrder(nameP.Text, 1, Convert.ToInt32(priceP.Text), DateTime.Now));
                ORDER.positionSelected = ORDER.List.Count - 1;
                quantityP.Text = "1";

                //update listview
                Listview_Load();
                //update totalAmount

                //select quantity in textbox
                quantityP.Focus();
                quantityP.SelectionStart = 0;
                quantityP.SelectionLength = quantityP.Text.Length;

                sum();
            }
        }
        private void sum()
        {
            int sum = 0;
            for (int i = 0; i < ORDER.List.Count; i++)
            {
                sum += ORDER.List[i].itemsPrice;
            }
            total.Content = Convert.ToString(sum);
        }
        private void P1_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP1, priceP1);
        }
        private void P2_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP2, priceP2);
        }
        private void P3_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP3, priceP3);
        }
        private void P4_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP4, priceP4);
        }
        private void P5_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP5, priceP5);
        }
        private void P6_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP6, priceP6);
        }
        private void P7_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP7, priceP7);
        }
        private void P8_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP8, priceP8);
        }
        private void P9_Click(object sender, RoutedEventArgs e)
        {
            AddItem(nameP9, priceP9);
        }
        private void Tp1_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Tp2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tp3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tp4_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tp5_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            if (ORDER.List.Count != 0)
            {
                if (ORDER.positionSelected != ORDER.List.Count - 1)
                    ORDER.currentQuantity = ORDER.List[ORDER.positionSelected].quantity;
                if (ORDER.currentQuantity - 1 != 0)
                {
                    ORDER.currentQuantity = ORDER.currentQuantity - 1;
                }
                string tmp = Convert.ToString(ORDER.currentQuantity);
                quantityP.Text = tmp;
                var prd = ORDER.List[ORDER.positionSelected];
                prd.quantity = ORDER.currentQuantity;
                prd.itemsPrice = ORDER.currentQuantity * prd.Price;
                Listview_Load();
                sum();
            }
        }
        private void QuantityP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ORDER.List.Count == 0)
            {
                quantityP.Text = "";
            }
            else
            {
                quantityP.Focus();
                quantityP.SelectionStart = quantityP.Text.Length;
                quantityP.SelectionLength = 0;
                int val;
                int tmp = 1;
                if (int.TryParse(quantityP.Text, out val))
                {
                    tmp = Convert.ToInt32(val);
                }
                if (ORDER.List.Count != 0)
                {
                    pOrder prd = ORDER.List[ORDER.positionSelected];
                    prd.quantity = tmp;
                    prd.itemsPrice = tmp * prd.Price;
                }
                ORDER.currentQuantity = tmp;
                Listview_Load();
                sum();
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (ORDER.List.Count != 0)
            {
                if (ORDER.positionSelected != ORDER.List.Count - 1)
                    ORDER.currentQuantity = ORDER.List[ORDER.positionSelected].quantity;
                ORDER.currentQuantity = ORDER.currentQuantity + 1;
                string tmp = Convert.ToString(ORDER.currentQuantity);
                quantityP.Text = tmp;
                var prd = ORDER.List[ORDER.positionSelected];
                prd.quantity = ORDER.currentQuantity;
                prd.itemsPrice = ORDER.currentQuantity * prd.Price;
                Listview_Load();
                sum();
            }
        }
        private void Total_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                ORDER.positionSelected = i;
                int tmp = ORDER.List[i].quantity;
                ORDER.currentQuantity = tmp;
                quantityP.Text = tmp.ToString();

                quantityP.Focus();
                quantityP.SelectionStart = 0;
                quantityP.SelectionLength = quantityP.Text.Length;
            }

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                Listview.Items.Remove(i);
                ORDER.List.RemoveAt(i);
                ORDER.positionSelected--;
                sum();
                Listview_Load();
                if (ORDER.List.Count == 0)
                {
                    quantityP.Text = "";
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            int n = ORDER.List.Count;
            for (int k = 0; k < n; k++)
            {
                ORDER.List.RemoveAt(n - k - 1);
                Listview.Items.Remove(n - k - 1);
            }
            ORDER.positionSelected = 0;
            sum();
            quantityP.Text = "";
            Listview_Load();
        }
        private void PPrev_Click(object sender, RoutedEventArgs e)
        {
            if (ORDER.pageP != 0)
            {
                ORDER.pageP = ORDER.pageP - 1;
                showProduct(ORDER.posG);
                if (ORDER.pageP == 0) pPrev.IsEnabled = false;
                pNext.IsEnabled = true;
            }
        }

        private void PNext_Click(object sender, RoutedEventArgs e)
        {
            int n = ORDER.Type[ORDER.posG].getListName().Count / 9;
            if (ORDER.Type[ORDER.posG].getListName().Count % 9 == 0) n = n - 1;
            if (ORDER.pageP + 1 <= n)
            {
                ORDER.pageP = ORDER.pageP + 1;
                showProduct(ORDER.posG);
                if (ORDER.pageP == n) pNext.IsEnabled = false;
                pPrev.IsEnabled = true;
            }
        }
    }
}