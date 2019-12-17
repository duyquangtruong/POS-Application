using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        public class DELIVERY
        {
            public static int flag = 0;
            private static List<string> description = new List<string>();
            private static List<DeliveryListView> list = new List<DeliveryListView>();
            public static List<string> Description { get => description; set => description = value; }
            public static List<DeliveryListView> List { get => list; set => list = value; }
        }
        public Delivery()
        {
            InitializeComponent();
            if (DELIVERY.flag == 0) CheckBill();
            Listview_Load();
        }
        public Delivery(Order order, string desc, int newID)
        {
            InitializeComponent();
            DELIVERY.List.Add(new DeliveryListView(newID, order.total.Text.ToString(), order.StartTime.Text));
            DELIVERY.Description.Add(desc);
            Listview_Load();

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
               Option option = new Option(0);
               NavigationService.Navigate(option);
            //NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order(2);
            NavigationService.Navigate(order);
        }

        private void Listview_Load()
        {
            //add listview
            var Ls = DELIVERY.List;
            Listview.Items.Clear();
            foreach (var ls in Ls)
            {
                Listview.Items.Add(ls);
            }
        }
        public class DeliveryListView
        {
            public int ID { get; set; }
            public string Total { get; set; }
            public string Time { get; set; }
            public DeliveryListView(int id, string total, string time) { this.ID = id; this.Total = total; this.Time = time; }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                MessageBox.Show(DELIVERY.Description[i], Title = "CHI TIẾT");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var i = Listview.SelectedIndex;
            if (i != -1)
            {
                CheckISOver(i);
                Listview.Items.Remove(i);
                DELIVERY.List.RemoveAt(i);
                DELIVERY.Description.RemoveAt(i);
                Listview_Load();
            }
        }
        private void CheckBill()
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand("select COUNT(*) from BILL where CusTypeID=2 and IsOver=0", connection))
                {
                    connection.Open();
                    count = (Int32)command.ExecuteScalar();
                }
                if (count != 0)
                {
                    List<int> idTmp = new List<int>();
                    string desc = "Tổng tiền: ";
                    using (SqlCommand command = new SqlCommand("select BillID,TotalAmount,Date from BILL  where CusTypeID=2 and  IsOver=0", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    int id = Convert.ToInt32(reader["BillID"].ToString());
                                    int total = Convert.ToInt32(reader["TotalAmount"].ToString());
                                    String time = reader["Date"].ToString();
                                    DELIVERY.List.Add(new DeliveryListView(id, Convert.ToDecimal(total).ToString("#,##0"), time));
                                    idTmp.Add(id);
                                    desc = desc + total + '\n';
                                    DELIVERY.Description.Add(desc);
                                    desc = "Tổng tiền: ";
                                }
                            }
                        }

                    }
                    for (int i = 0; i < idTmp.Count; i++)
                    {
                        using (SqlCommand command = new SqlCommand("select* from BILLDETAIL where  BillID = " + idTmp[i], connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader != null)
                                {
                                    while (reader.Read())
                                    {
                                        int id = Convert.ToInt32(reader["BillDetailID"].ToString());
                                        string prdName = reader["ProductName"].ToString();
                                        string Prdquantity = reader["BDQuantity"].ToString();
                                        string itemsPrice = reader["BDTotalAmount"].ToString();
                                        DELIVERY.Description[i] += prdName + " (SL:" + Prdquantity + "_Giá:" + itemsPrice + ")" + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            DELIVERY.flag = 1;
        }
        private void CheckISOver(int index)
        {
            if (DELIVERY.List[index].ID != -1)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=AppTraSua;Integrated Security=True"))
                {
                    using (SqlCommand command = new SqlCommand("update BILL set IsOver=1 where BillID=@id", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", DELIVERY.List[index].ID);
                        command.ExecuteScalar();
                    }
                }
            }
        }

    }
}
