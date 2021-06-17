using Shop.Date.Interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Mocks
{
    public class MockKnive : IAllKnives
    {
        private readonly IKnifesCategory _knifesCategory = new MockCategory();
        public IEnumerable<Knife> allKnives
        {
            get
            {
                return new List<Knife>
                {
                    new Knife {nameKnife="GuardWay120", shortDisc="", longDisc="gradient", imgKnife="/img/Gradient.jpg", priceKnife=220, available=true, isFavorite=true, steal="440C", Category=_knifesCategory.allCategories.First() },
                    new Knife {nameKnife="GuardWayBlack", shortDisc="", longDisc="Polnostui CHORNAYA", imgKnife="/img/blackBaterflay.jpg", priceKnife=200, available=true, isFavorite=true, steal="420W", Category=_knifesCategory.allCategories.First() },
                    new Knife {nameKnife="ТиЛайт", shortDisc="100мм клинок", longDisc=" стальные лайнера на рукояте", imgKnife="/img/Ti-light.jpg", priceKnife=4200, available=true, isFavorite=true, steal="420_55HRC", Category=_knifesCategory.allCategories.Last() },
                    new Knife {nameKnife="Flamberg", shortDisc="105mm лезвие, общая длина 245мм", longDisc="Выброс клинка- боковой", imgKnife="/img/Flamberg.jpg", priceKnife=350, available=true, isFavorite=false, steal="440C_58HRC", Category=_knifesCategory.allCategories.Last() }
                };
            }
            set => throw new NotImplementedException();
        }
        public IEnumerable<Knife> getFavKnives { get; set; }

        public Knife getObjectKnife(int knifeId)
        {
            throw new NotImplementedException();
        }
    }
}
