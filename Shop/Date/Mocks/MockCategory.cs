using Shop.Date.Interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Mocks
{
    public class MockCategory : IKnifesCategory
    {
        public IEnumerable<Category> allCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ nameCategory = "Балисонги", descCategory="Нож-бабочка" },
                    new Category{ nameCategory = "Стилет", descCategory="Небольшой кинжал с тонким клинком." }
                };
            }
        }
    }
}
