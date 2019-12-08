using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubbleT
{
    class pType
    {
        private int id;
        private string name;
        private List<string> listPrdName = new List<string>();
        private List<int> listPrdPrice = new List<int>();

        public pType(int id, string name, List<string> listpn, List<int> listpp)
        {
            this.id = id; this.name = name;
            listPrdName = listpn;
            listPrdPrice = listpp;
        }

        public int getCount()
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
