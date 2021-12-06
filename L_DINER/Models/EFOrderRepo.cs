using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class EFOrderRepo:IOrderRepository
    {
        private LDINER_DBContext context;
        public EFOrderRepo(LDINER_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders;

        public void submitOrder(Order order) {
            context.AttachRange(order.Burgers.Select(b=>b.Burger));
            context.AttachRange(order.Sides.Select(b => b.Side));
            context.AttachRange(order.Drinks.Select(b => b.Drink));
            if (order.ID == 0) {
                context.Add<Order>(order);
            }
            
            context.SaveChanges();
        }
    }
}
