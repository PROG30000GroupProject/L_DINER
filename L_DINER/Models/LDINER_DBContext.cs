using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class LDINER_DBContext : DbContext
    {
        public LDINER_DBContext(DbContextOptions<LDINER_DBContext> options) : base(options) { }

        //entity
        public DbSet<Order> Orders { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}
