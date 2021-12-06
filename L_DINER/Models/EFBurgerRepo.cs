using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class EFBurgerRepo:IBurgerRepository
    {
        private LDINER_DBContext context;
        public EFBurgerRepo(LDINER_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Burger> Burgers => context.Burgers;
    }
}
