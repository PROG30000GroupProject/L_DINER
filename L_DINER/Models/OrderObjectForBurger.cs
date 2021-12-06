using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class OrderObjectForBurger
    {
        public int ID { get; set; }

        public Burger Burger { get; set; }

        public int Quantity { get; set; }
    }
}
