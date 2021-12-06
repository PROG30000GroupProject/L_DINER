using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class Burger
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public ICollection<IngredientLine> Ingredients { get; set; } = new List<IngredientLine>();
        public double Price { get; set; }
    }
}
