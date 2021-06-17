using Microsoft.AspNetCore.Mvc;
using Shop.Date.Interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllKnives _knifeRep;
        

        public HomeController(IAllKnives knifeRep)
        {
            _knifeRep = knifeRep; 
        }

        public ViewResult Index()
        {
            var homeKnives = new HomeViewModel
            {
                favKnives = _knifeRep.getFavKnives
            };
            return View(homeKnives);
        }

    }
}
