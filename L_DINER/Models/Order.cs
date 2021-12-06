using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class Order
    {
        public int ID { get; set; }
        public ICollection<OrderObjectForBurger> Burgers { get; set; } = new List<OrderObjectForBurger>();
        public ICollection<OrderObjectForSide> Sides { get; set; } = new List<OrderObjectForSide>();
        public ICollection<OrderObjectForDrink> Drinks { get; set; } = new List<OrderObjectForDrink>();
        public double Price { get; set; }
        public String OrderState { get; set; }
        public int UserID { get; set; }
        public double TotalCost() => Burgers.Sum(b => b.Burger.Price * b.Quantity) + 
            Sides.Sum(b => b.Side.Price * b.Quantity) +
            Drinks.Sum(b => b.Drink.Price * b.Quantity);
    }
}
