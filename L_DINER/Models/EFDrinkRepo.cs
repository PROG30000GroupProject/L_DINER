using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class EFDrinkRepo:IDrinkRepository
    {
        private LDINER_DBContext context;
        public EFDrinkRepo(LDINER_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Drink> Drinks => context.Drinks;
    }
}
