using Shop.Date.Interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    knifeID = el.knife.id,
                    orderID = order.id,
                    price=el.knife.priceKnife
                   
                };
                appDBContent.OrderDetail.Add(orderDetail);

            }
            appDBContent.SaveChanges();
        }
    }
}
