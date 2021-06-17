using Microsoft.AspNetCore.Mvc;
using Shop.Date.Interfaces;
using Shop.Date.Models;
using Shop.Date.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllKnives _knifeRep;
        private readonly ShopCart _shopCart;

        public ShopCartController (IAllKnives knifeRep, ShopCart shopCart)
        {
            _knifeRep = knifeRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _knifeRep.allKnives.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
