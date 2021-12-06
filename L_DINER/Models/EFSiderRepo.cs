using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class EFSiderRepo: ISideRepository
    {
        private LDINER_DBContext context;
        public EFSiderRepo(LDINER_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Side> Sides => context.Sides;
    }
}
