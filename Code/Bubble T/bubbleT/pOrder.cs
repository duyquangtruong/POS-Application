using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubbleT
{
    class pOrder
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int itemsPrice { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
        public pOrder(int ID,string prdName, int quantity, int total, DateTime time)
        {
            this.ID = ID;
            this.productName = prdName;
            this.quantity = quantity;
            this.itemsPrice = total;
            this.Price = total;
            this.Time = time;
        }
        public void setID (int id){ this.ID = id; }
    }
}
