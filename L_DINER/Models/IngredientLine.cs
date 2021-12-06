using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class IngredientLine
    {
        public int ID { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public int Quantity { get; set; }
    }
}
