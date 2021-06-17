using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Models
{
    public class Category
    {
        public int id { get; set; }
        public string nameCategory { get; set; }
        public string descCategory { get; set; }
        public List<Knife> knivesList { get; set; }
    }
}
