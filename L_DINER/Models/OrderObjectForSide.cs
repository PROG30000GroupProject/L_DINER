using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class OrderObjectForSide
    {
        public int ID { get; set; }

        public Side Side { get; set; }

        public int Quantity { get; set; }
    }
}
