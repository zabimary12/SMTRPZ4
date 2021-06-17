using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Date.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartID { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("KnifeID") ?? Guid.NewGuid().ToString();

            session.SetString("KnifeID", shopCartId);

            return new ShopCart(context) { ShopCartID = shopCartId };
        }

        public void AddToCart(Knife knife)
        {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartID = ShopCartID,
                knife = knife,
                price = knife.priceKnife
            });
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartID==ShopCartID).Include(s => s.knife).ToList();
            
        }
    }
    
}
