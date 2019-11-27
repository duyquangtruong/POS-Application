using System.Collections.Generic;

namespace winformapp
{
    public class pMenu
    {
        private int id;
        private string name;
        private List<string> listPrdName = new List<string>();
        private List<int> listPrdPrice = new List<int>();

        public pMenu(int id, string name, List<string> listp,List<int> listpp)
        {
            this.id = id;this.name = name;
            listPrdName = listp;
            listPrdPrice = listpp;
        }

        public int CountProduct()
        {
            return this.listPrdName.Count;
        }
        public string getName()
        {
            return this.name;
        }

        public List<string> getListName()
        {
            return this.listPrdName;
        }
        public List<int> getListPrice()
        {
            return this.listPrdPrice;
        }
    }
}