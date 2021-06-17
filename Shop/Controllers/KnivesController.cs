using Microsoft.AspNetCore.Mvc;
using Shop.Date.Interfaces;
using Shop.Date.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class KnivesController : Controller
    {
        private readonly IAllKnives _allKnives;
        private readonly IKnifesCategory _allknifesCategory;

        public KnivesController(IAllKnives iAllknives, IKnifesCategory iKnifesCategory)
        {
            _allKnives = iAllknives;
            _allknifesCategory = iKnifesCategory;
        }
        [Route("Knive/List")]
        [Route("Knive/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Knife> knive = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                knive = _allKnives.allKnives.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("balisong", category, StringComparison.OrdinalIgnoreCase))
                {
                    knive = _allKnives.allKnives.Where(i => i.Category.nameCategory.Equals("Балисонг")).OrderBy(i => i.id);
                    currCategory = "Балисонг";
                }
                else if (string.Equals("stylet", category, StringComparison.OrdinalIgnoreCase))
                {
                    knive = _allKnives.allKnives.Where(i => i.Category.nameCategory.Equals("Стилет")).OrderBy(i => i.id);
                    currCategory = "Стилет";
                }
                

                
            }
            var kniveObj = new KnifeListViewModel
            {
                GetKnives = knive,
                currCategory = currCategory

            };


            ViewBag.Title = "Страница для юного экстримиста";
            
            return View(kniveObj);
        }
    }
}
