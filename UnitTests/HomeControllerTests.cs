using NUnit.Framework;
using Moq;
using Shop.Date.Interfaces;
using Shop.Date.Models;
using System.Collections.Generic;
using Shop.Date.Mocks;
using Shop.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class HomeControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Index_ValidInvoke_NotNull()
        {
            var _knifesCategory = new Mock<IKnifesCategory>();
            _knifesCategory.Setup(s=>s.allCategories).Returns(new List<Category>
                {
                    new Category{ nameCategory = "Балисонги", descCategory="Нож-бабочка" },
                    new Category{ nameCategory = "Стилет", descCategory="Небольшой кинжал с тонким клинком." }
                });
        var knifeRep = new Mock<IAllKnives>();
            knifeRep.Setup(x => x.allKnives).Returns(new List<Knife>
                {
                new Knife { nameKnife = "GuardWay120", shortDisc = "", longDisc = "gradient", imgKnife = "/img/Gradient.jpg", priceKnife = 220, available = true, isFavorite = true, steal = "440C" }  
                });

            HomeController controller = new HomeController(knifeRep.Object);

            

            Assert.NotNull(controller);

        }
    }
}