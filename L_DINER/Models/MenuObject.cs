using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class MenuObject
    {
        public List<Burger> Burgers { get; set; }
        public List<Side> Sides { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
