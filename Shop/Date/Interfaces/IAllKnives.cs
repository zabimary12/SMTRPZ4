using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Interfaces
{
    public interface IAllKnives
    {
        IEnumerable<Knife> allKnives { get; /*set;*/ }
        IEnumerable<Knife> getFavKnives { get; /*set;*/ }
        Knife getObjectKnife(int knifeId);
    }
}
