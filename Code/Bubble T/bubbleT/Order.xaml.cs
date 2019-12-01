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

namespace bubbleT
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public class ORDER
        {
            private static List<pOrder> list = new List<pOrder>();
            private static List<pType> type = new List<pType>();
            public static int currentQuantity = 1;
            public static int positionSelected = 0;
            internal static List<pOrder> List { get => list; set => list = value; }
            internal static List<pType> Type { get => type; set => type = value; }
        }
        public Order()
        {
            InitializeComponent();

            LoadMenu();
            if (ORDER.Type.Count > 0) groupClick(g1, 0);
        }

        private void LoadMenu()
        {
            List<string> ls;
            ls = new List<string>{
                "Cafe Sữa 1", "Cafe Sữa 2",   "Cafe Sữa 3",  "Cafe Sữa 4"};
            List<int> lsp = new List<int> { 25000, 35000, 45000, 55000 };
            ORDER.Type.Add(new pType(1, "CAFE", ls, lsp));

            ls = new List<string>
            {
                "Trà Sữa 1",  "Trà Sữa 2","Trà Sữa 3", "Trà Sữa 4",  "Trà Sữa 5","Trà Sữa 6"
            };
            lsp = new List<int>
            {
                25000, 35000,   45000,  55000,35000,33000
            };
            ORDER.Type.Add(new pType(2, "TRÀ SỮA", ls, lsp));
            ls = new List<string>
            {
                "Trà Đào 1", "Trà Đào 2","Trà Đào 3", "Trà Đào 4", "Trà Đào 5",
                "Trà Đào 6","Trà Đào 7", "Trà Đào 8" };
            lsp = new List<int>
            {
                35000, 45000, 11000, 55000,35000,33000, 11000  ,  55000
            };
            ORDER.Type.Add(new pType(3, "TRÀ ĐÀO", ls, lsp));
            for (int i = 0; i < ORDER.Type.Count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        g1.Content = ORDER.Type[i].getName();
                        break;
                    case 2:
                        g2.Content = ORDER.Type[i].getName();
                        break;
                    case 3:
                        g3.Content = ORDER.Type[i].getName();
                        break;
                    case 4:
                        g4.Content = ORDER.Type[i].getName();
                        break;
                    case 5:
                        g5.Content = ORDER.Type[i].getName();
                        break;
                    case 6:
                        g6.Content = ORDER.Type[i].getName();
                        break;
                    default:
                        break;
                }
            }
        }
        private void showProduct(int index)
        {
            if (ORDER.Type.Count > index)
            {
                List<string> lname = ORDER.Type[index].getListName();
                List<int> lprice = ORDER.Type[index].getListPrice();
                int n = lname.Count;
                for (int i = 0; i < n; i++)
                {
                    switch (i + 1)
                    {
                        case 1:
                            p1.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 2:
                            p2.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 3:
                            p3.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 4:
                            p4.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 5:
                            p5.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 6:
                            p6.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 7:
                            p7.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 8:
                            p8.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        case 9:
                            p9.Content = lname[i] + "\n" + Convert.ToString(lprice[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void groupClick(Button g, int index)
        {
            //clean
            g1.Background = Brushes.CornflowerBlue; ;
            g2.Background = Brushes.CornflowerBlue; ;
            g3.Background = Brushes.CornflowerBlue; ;
            g4.Background = Brushes.CornflowerBlue; ;
            g5.Background = Brushes.CornflowerBlue; ;
            g6.Background = Brushes.CornflowerBlue; ;
            p1.Content = ""; p2.Content = ""; p3.Content = ""; p4.Content = ""; p5.Content = "";
            p6.Content = ""; p7.Content = ""; p8.Content = ""; p9.Content = "";

            g.Background = Brushes.DarkOrange;
            showProduct(index);
        }
        private void G1_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g1, 0);
        }
        private void G2_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g2, 1);
        }
        private void G3_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g3, 2);
        }
        private void G4_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g4, 3);
        }
        private void G5_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g5, 4);
        }
        private void G6_Click(object sender, RoutedEventArgs e)
        {
            groupClick(g6, 5);
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
        private void AddItem(Button p)
        {
            if (!p.Content.ToString().Equals(""))
            {
                ORDER.currentQuantity = 1;
                //split name, price
                string[] tmpList = p.Content.ToString().Split('\n');
                string name = tmpList[0]; string price = tmpList[1];
                //ADD to list prd
                ORDER.List.Add(new pOrder(name, 1, Convert.ToInt32(price), DateTime.Now));
                ORDER.positionSelected = ORDER.List.Count - 1;
                quantityP.Text = "1";

                //update listview
                Listview_Load();
                //update totalAmount


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
            AddItem(p1);
        }
        private void P2_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p2);
        }
        private void P3_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p3);
        }
        private void P4_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p4);
        }
        private void P5_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p5);
        }
        private void P6_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p6);
        }
        private void P7_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p7);
        }
        private void P8_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p8);
        }
        private void P9_Click(object sender, RoutedEventArgs e)
        {
            AddItem(p9);
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
        private void TotalAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            Listview.Items.Remove(i);
            ORDER.List.RemoveAt(i);
            ORDER.positionSelected--;
            sum();
            Listview_Load();
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
            Listview_Load();
        }
    }
}
