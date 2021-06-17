using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Models
{
    public class Knife
    {
        public int id { get; set; }
        public string nameKnife { get; set; }
        public string shortDisc { get; set; }
        public string longDisc { get; set; }
        public string imgKnife { get; set; }
        public string steal { get; set; }
        public ushort priceKnife { get; set; }
        public bool isFavorite { get; set; }
        public bool available { get; set; }

        public int categoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}
