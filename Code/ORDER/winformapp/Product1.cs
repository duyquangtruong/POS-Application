using System;

namespace UsingListViewSample
{
    public class Product
    {
        private string productName;
        private int quantity;
        private int totalAmout;
        private int defaultPrice;
        public Product(string prdName,int quantity,int totalAmout)
        {
            this.productName = prdName;
            this.quantity = quantity;
            this.totalAmout = totalAmout;
            this.defaultPrice = totalAmout;
        }
        public string getQuantityString()
        {

            return quantity.ToString();
        }
        public string getTotalAmoutString()
        {
            //Console.WriteLine(totalAmout.ToString());
            string myString = totalAmout.ToString();
            return myString;
        }
        public int getTotalAmout()
        {
            return this.totalAmout;
        }
        public string getProductName()
        {
            return productName;
        }
        public int getdefaultPrice()
        {
            return this.defaultPrice;
        }
        
        public void setQuantity(int q)
        {
            this.quantity = q;
        }
        public void setTotalAmout(int q)
        {
            this.totalAmout = q;
        }
        public void setName(string q)
        {
            this.productName = q;
        }
    }
    
}