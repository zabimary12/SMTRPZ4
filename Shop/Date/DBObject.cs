using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date
{
    public class DBObject
    {

        public static void Initial(AppDBContent content)
        {
            if (!content.category.Any())
            {
                content.category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.knife.Any())
            {
                content.AddRange(

                    new Knife {nameKnife="GuardWay120", shortDisc="120мм лезвие, не является холодным оружием", longDisc="gradient", imgKnife="/img/Gradient.jpg", priceKnife=220, available=true, isFavorite=true, steal="440C", Category= Categories["Балисонг"] },
                    new Knife {nameKnife="GuardWayBlack", shortDisc="120мм лезвие, отличный подшипник", longDisc="Polnostui CHORNAYA", imgKnife="/img/blackBaterflay.jpg", priceKnife=200, available=true, isFavorite=true, steal="420W", Category = Categories["Балисонг"] },
                    new Knife {nameKnife="ТиЛайт", shortDisc="100мм клинок", longDisc=" стальные лайнера на рукояте", imgKnife="/img/Ti-light.jpg", priceKnife=4200, available=true, isFavorite=true, steal="420_55HRC", Category = Categories["Стилет"] },
                    new Knife { nameKnife = "Flamberg", shortDisc = "105mm лезвие, общая длина 245мм", longDisc = "Выброс клинка- боковой", imgKnife = "/img/Flamberg.jpg", priceKnife = 350, available = true, isFavorite = false, steal = "440C_58HRC", Category = Categories["Стилет"] }
                     
                    );
            }
            content.SaveChanges();
        }
        

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ nameCategory = "Балисонг", descCategory="Нож-бабочка" },
                        new Category{ nameCategory = "Стилет", descCategory="Небольшой кинжал с тонким клинком." }
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.nameCategory, el);
                    }
                }

                return category;
            }
        }
    }
}
