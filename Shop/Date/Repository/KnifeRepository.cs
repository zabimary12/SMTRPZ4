using Microsoft.EntityFrameworkCore;
using Shop.Date.Interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Repository
{
    public class KnifeRepository : IAllKnives
    {
        private readonly AppDBContent appDBContent;

        public KnifeRepository (AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Knife> allKnives => appDBContent.knife.Include(c => c.Category);

        public IEnumerable<Knife> getFavKnives => appDBContent.knife.Where(f => f.isFavorite).Include(c => c.Category);

        public Knife getObjectKnife(int knifeId) => appDBContent.knife.FirstOrDefault(p => p.id == knifeId);
        
        
    }
}
