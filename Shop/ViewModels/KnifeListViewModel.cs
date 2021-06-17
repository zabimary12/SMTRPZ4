using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class KnifeListViewModel
    {
        public IEnumerable<Knife> GetKnives { get; set; }
        public string currCategory { get; set; }

    }
}
