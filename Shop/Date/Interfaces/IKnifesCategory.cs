using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Interfaces
{
    public interface IKnifesCategory
    {
        IEnumerable<Category> allCategories { get; }

    }
}
