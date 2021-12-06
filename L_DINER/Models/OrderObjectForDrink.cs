using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class OrderObjectForDrink
    {
        public int ID { get; set; }

        public Drink Drink { get; set; }

        public int Quantity { get; set; }
    }
}
