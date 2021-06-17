using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int knifeID { get; set; }
        public int orderID { get; set; }
        public ushort price { get; set; }
        public string adress { get; set; }
        public virtual Knife knife { get; set; }
        public virtual Order order { get; set; }
    }
}
