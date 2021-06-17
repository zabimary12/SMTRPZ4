using Microsoft.EntityFrameworkCore;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date
{
    public class AppDBContent : DbContext
    {
        

        public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {

        }

        public DbSet<Knife> knife { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
